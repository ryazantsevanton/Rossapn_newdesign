using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LuchDataLoadService
{
    public partial class LuchDataLoadService : ServiceBase
    {
        private DBSettings dbSettings;
        private MapSettings mapSettings;
        private bool isInitCorrectly;
        private int timeToSleep;
        public LuchDataLoadService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("DataLoadService: Started.");
            timeToSleep = Properties.Settings.Default.TimeToSleep;
            if (timeToSleep < 10)
            {
                timeToSleep = 10;
            }
            try
            {
                using (var sr = new StreamReader("DataLoadSettings.xml"))
                {
                    var serialiser = new XmlSerializer(typeof(DBSettings));
                    dbSettings = (DBSettings)serialiser.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                eventLog1.WriteEntry("DataLoadService: Error on Setting initialization: " + e.Message + " - " + e.StackTrace, EventLogEntryType.Error);
                this.Stop();
                return;
            }
            if (dbSettings.SourceDBConnections == null || dbSettings.SourceDBConnections.Length == 0)
            {
                eventLog1.WriteEntry("DataLoadService: Error on Setting initialization: Source db is not found", EventLogEntryType.Error);
                this.Stop();
                return;
            }
            if (dbSettings.TargetDBConnectionString == null || string.IsNullOrEmpty(dbSettings.TargetDBConnectionString.Value))
            {
                eventLog1.WriteEntry("DataLoadService: Error on Setting initialization: Target db is not found", EventLogEntryType.Error);
                this.Stop();
                return;
            }

            try
            {
                using (var sr = new StreamReader("MapSettings.xml"))
                {
                    var serialiser = new XmlSerializer(typeof(MapSettings));
                    mapSettings = (MapSettings)serialiser.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                eventLog1.WriteEntry("DataLoadService: Error on Setting initialization: " + e.Message + " - " + e.StackTrace, EventLogEntryType.Error);
                this.Stop();
                return;
            }

            eventLog1.WriteEntry("DataLoadService: Initialization was ended correctly");

            Thread t = new Thread(new ThreadStart(RunAction));
            t.IsBackground = true;
            t.Start();           
        }

        private void RunAction()
        {
            while (true)
            {
                Thread.Sleep(timeToSleep * 1000);
                DateTime effectiveDate = DateTime.MinValue;

                using (SqlConnection targetCon = new SqlConnection(dbSettings.TargetDBConnectionString.Value))
                {
                    try
                    {
                        targetCon.Open();
                    }
                    catch
                    {
                        eventLog1.WriteEntry("DataLoadService:RunAction - target connection is broken. Connection data - " + 
                                              dbSettings.TargetDBConnectionString.Value, EventLogEntryType.Error);
                        this.Stop();
                    }
                    using (var tcommand = targetCon.CreateCommand())
                    {
                        foreach (var s in dbSettings.SourceDBConnections)
                        {
                            eventLog1.WriteEntry("DataLoadService:RunAction - StartWork with connection: " + s.Name);

                            using (SqlConnection sourceCon = new SqlConnection(s.Value))
                            {
                                try
                                {
                                    sourceCon.Open();
                                }
                                catch
                                {
                                    eventLog1.WriteEntry("DataLoadService:RunAction - source connection is broken. Connection data - " +
                                                            s.Value, EventLogEntryType.Error);
                                    continue;
                                }
                                using (var command = sourceCon.CreateCommand())
                                {
                                    foreach (MappingLine line in mapSettings.Lines)
                                    {
                                        tcommand.CommandText = "select predicateid from Predicates where predicatevalue ='" + line.ParameterName + "'";
                                        var o = tcommand.ExecuteScalar();
                                        int paramId = o is DBNull ? -1 : (int)o; 

                                        tcommand.CommandText = "select MIN(e.entityid) from Entities e  inner join " +
                                                    " EntityGroups eg on eg.entityid=e.entityid  where e.entityvalue='" +
                                                     line.ObjectName + "' and eg.groupName='" + line.GroupName 
                                                     + "' and eg.subgroupName='" + line.BranchName + "'";
                                        o = tcommand.ExecuteScalar();
                                        int entityId = o is DBNull ? -1 : (int)o;

                                        command.CommandText = "SELECT TagName FROM Tag where Description ='" + line.Tag + "'";
                                        var tagS = command.ExecuteScalar();
                                        string tagCode = tagS is DBNull ? string.Empty : (string)tagS;

                                        bool checkParam = true;
                                        if (entityId < 0)
                                        {
                                            eventLog1.WriteEntry(string.Format("DataLoadService: RunAction - Object :{0};{1};{2}; not found",
                                                line.GroupName, line.BranchName, line.ObjectName));
                                            checkParam = false;
                                        }
                                        if (paramId < 0)
                                        {
                                            eventLog1.WriteEntry(string.Format("DataLoadService: RunAction - Parameter :{0}; not found",
                                                line.ParameterName));
                                            checkParam = false;
                                        }
                                        if (string.IsNullOrEmpty(tagCode))
                                        {
                                            eventLog1.WriteEntry(string.Format("DataLoadService: RunAction - Soource tag :{0}; not found",
                                                line.Tag));
                                            checkParam = false;
                                        }
                                        if (!checkParam)
                                        {
                                            continue;
                                        }
                                        // load data
                                        eventLog1.WriteEntry("DataLoadService: RunAction - start loadData");
                                        int index = 0;
                                        try
                                        {
                                            tcommand.CommandText = "select MAX(metrixdata) from metrix where predicateid=" + paramId + " and entityid=" +
                                                                   entityId + " and metrixvalue is not null";
                                            //  eventLog1.WriteEntry("DataLoadService: RunAction - GetDate: " + tcommand.CommandText);
                                            var d = tcommand.ExecuteScalar();
                                            DateTime startDate = d is DBNull ? new DateTime(1970, 1, 1) : (DateTime)d;

                                            command.CommandText = string.Format("SELECT  DateandTime, Value FROM M01_float " +
                                                        " where Value is not null and TagName ='{0}' and DateandTime > CONVERT(datetime, '{1}-{2}-{3} {4}:{5}:{6}', 120)",
                                                        tagCode, startDate.Year, startDate.Month, startDate.Day, startDate.Hour, startDate.Minute, startDate.Second);

                                            //eventLog1.WriteEntry("DataLoadService: RunAction - GetValues: " + command.CommandText);

                                            using (var r = command.ExecuteReader())
                                            {
                                                while (r != null && r.Read())
                                                {
                                                    DateTime date = r.GetDateTime(0);
                                                    tcommand.CommandText = string.Format("insert into metrix(predicateid, entityid, metrixData, metrixValue) values " +
                                                        "({0}, {1}, convert(datetime, '{2}-{3}-{4} {5}:{6}:{7}', 120), {8})", paramId, entityId, date.Year, date.Month,
                                                        date.Day, date.Hour, date.Minute, date.Second, r.GetDouble(1).ToString().Replace(',', '.'));

                                                    //    eventLog1.WriteEntry("DataLoadService: RunAction - Insert values : " + tcommand.CommandText);
                                                    tcommand.ExecuteNonQuery();

                                                    index++;
                                                }
                                            }
                                            eventLog1.WriteEntry("DataLoadService: RunAction - loadData end. " + index + " metrix were loaded");
                                        }
                                        catch (Exception e)
                                        {
                                            eventLog1.WriteEntry("DataLoadService: RunAction - loadData end with error. " + e.Message + " - " + e.StackTrace);
                                        }
                                    }
                                }
                                sourceCon.Close();
                                eventLog1.WriteEntry("DataLoadService:RunAction - EndWork with connection: " + s.Name);

                            }
                        }
                    }
                    targetCon.Close();
                }
            }
        }
        protected override void OnStop()
        {
            eventLog1.WriteEntry("DataLoadService: Stopped.");
        }
    }
}
