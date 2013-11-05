using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using Design.Infrastructure;

namespace Design
{
    public class DataHelper
    {
        public static string GetConnectionString(string pFilePath)
        {
            string strConnectionString;
            string strExcelExt = Path.GetExtension(pFilePath);

            if (strExcelExt == ".xls")
                strConnectionString =
                    @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties= ""Excel 8.0;HDR=NO;IMEX=1;""";
            //Ahad L. Amdani added support for .xslm for workbooks using macros
            else if (strExcelExt == ".xlsx" || strExcelExt == ".xlsm")
                strConnectionString =
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=NO;IMEX=1;""";
            else
                throw new ArgumentOutOfRangeException("Excel file extenstion is not known.");

            return string.Format(strConnectionString, pFilePath);
        }

        internal static int GetParameter(string value, SqlConnection con)
        {
            using (SqlCommand command = con.CreateCommand())
            {
                int maxNumber = 0;
                command.CommandText = "select max(predicateid) from Predicates";
                object o = command.ExecuteScalar();
                if (o != null && !(o is DBNull))
                {
                    maxNumber = (int)o;
                }
                command.CommandText = "select predicateid from Predicates where predicatevalue = '" + value + "'";
                o = command.ExecuteScalar();
                if (o == null || o is DBNull)
                {
                    maxNumber++;
                    command.CommandText = String.Format("insert into Predicates(predicateid, predicatevalue) values ({0}, '{1}')", maxNumber, value);
                    command.ExecuteNonQuery();
                    return maxNumber;
                }
                else {
                    return (int)o;
                }

            }
        }

        internal static int GetObject(string value, SqlConnection con)
        {
            using (SqlCommand command = con.CreateCommand())
            {
                int maxNumber = 0;
                command.CommandText = "select max(entityid) from Entities";
                object o = command.ExecuteScalar();
                if (o != null && !(o is DBNull))
                {
                    maxNumber = (int)o;
                }
                command.CommandText = "select entityid from Entities where entityvalue = '" + value + "'";
                o = command.ExecuteScalar();
                if (o == null || o is DBNull)
                {
                    maxNumber++;
                    command.CommandText = String.Format("insert into Entities(entityid, entityvalue) values ({0}, '{1}')", maxNumber, value);
                    command.ExecuteNonQuery();
                    return maxNumber;
                }
                else
                {
                    return (int)o;
                }
            }
        }

        public static void ClearData()
        {
            try
            {
                using (var oleCon = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    oleCon.Open();
                    using (SqlCommand command = oleCon.CreateCommand())
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("BEGIN TRANSACTION;").
                            AppendLine("delete Entities;").
                            AppendLine("delete Predicates;").
                            AppendLine("delete metrix;").
                            AppendLine("COMMIT TRANSACTION;");
                        command.CommandText = sb.ToString();
                        command.ExecuteNonQuery();
                    }
                    oleCon.Close();
                }
            }
            catch
            {
            }
        }

        public static void UpdateObject(string newkey, string key, SqlConnection con, bool type) {
            using (var command = con.CreateCommand())
            {
                command.CommandText = type
                    ? "update Predicates set predicatevalue = '" + newkey + "' where predicatevalue = '" + key + "'"
                    : "update Entities set entityvalue = '" + newkey + "' where entityvalue = '" + key + "'";
                command.ExecuteNonQuery();
            }        
        }

        public static void DeleteObject(string key, SqlConnection con, bool type) {
            using (var command = con.CreateCommand())
            {
                command.CommandText = type
                    ? "select min(predicateid) from Predicates where predicatevalue = '" + key + "'"
                    : "select min(entityid) from Entities where entityvalue = '" + key + "'";
                var o = command.ExecuteScalar();

                command.CommandText = type
                    ? "delete metrix where predicateid = " + o
                    : "delete metrix where entityid = " + o;
                command.ExecuteNonQuery();

                command.CommandText = type
                    ? "delete Predicates where predicateid = " + o
                    : "delete Entities where entityid = " + o;
                command.ExecuteNonQuery();
            }
        }

        public static SqlConnection OpenOrCreateDb()
        {
            var connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            connection.Open();

            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "select COUNT(*) from [sys].all_objects where type_desc='USER_TABLE'" +
                                      " and name in ('Entities', 'Predicates', 'metrix', 'aproximatemetrix', 'EntityGroups')";
                var id = command.ExecuteScalar();
                if (!(id is DBNull) && ((int)id) == 5)
                {
                    return connection;
                }
                var comText = new List<string>()
                                  {
                                      "drop TABLE Entities",
                                      "drop TABLE Predicates",
                                      "drop TABLE metrix",
                                      "drop Table aproximatemetrix",
                                      "IF OBJECT_ID('EntityGroups', 'U') IS NOT NULL drop Table EntityGroups",
                                      "CREATE TABLE Entities (entityid INT NOT NULL, entityvalue NVARCHAR(200) NOT NULL, PRIMARY KEY(entityid));",
                                      "CREATE TABLE Predicates (predicateid INT NOT NULL, predicatevalue NVARCHAR(200) NOT NULL, PRIMARY KEY(predicateid));",
                                      "CREATE TABLE metrix (metrixid int IDENTITY(1,1) NOT NULL, predicateid INT NOT NULL, entityid INT NOT NULL, metrixData datetime, metrixValue decimal(18,4) NULL, metrixObject nvarchar(200) null);",
                                      "CREATE TABLE aproximatemetrix (aproximatemetrixid int IDENTITY(1,1) NOT NULL, predicateid INT NOT NULL, entityid INT NOT NULL, metrixData datetime, zetValue NVARCHAR(200) NULL, lRegressionValue NVARCHAR(200) NULL);",
                                      "CREATE TABLE EntityGroups (entityid int FOREIGN KEY REFERENCES Entities(entityid), groupName NVARCHAR(200), subgroupName NVARCHAR(200));",
                                  };
                foreach (var text in comText)
                {
                    try
                    {
                        command.CommandText = text;
                        command.ExecuteNonQuery();
                    }
                    catch(Exception e) 
                    {
                        string s = e.Message;
                    }
                }
            }
            return connection;
        }


        internal static void LoadTriplets(List<Triplet> triplets, SqlConnection con)
        {
            if (triplets == null) { return; }
            using (SqlCommand command = con.CreateCommand())
            {
                foreach (var t in triplets)
                {
                    command.CommandText = string.Format("select max(metrixid) from metrix where entityId = {0} and predicateId={1} and metrixobject = '{2}'",
                                           t.EntityId, t.PredicateId, t.MetrixObject);
                    var o = command.ExecuteScalar();
                    if (o == null || o is DBNull)
                    {
                        if (t.MetrixDate == null) 
                        {
                            command.CommandText = "insert into metrix(entityId, predicateId, metrixobject,  metrixValue) values ("
                             + t.EntityId + "," + t.PredicateId + "," + t.MetrixObject + ", " + t.MetrixValue.ToString() + ")";
                        }
                        else { //yyyy-mm-dd hh:mi:ss
                            command.CommandText = "insert into metrix(entityId, predicateId, metrixobject,  metrixValue, metrixDate) values (" 
                             + t.EntityId + "," + t.PredicateId + "," + t.MetrixObject + ", " + t.MetrixValue.ToString() + 
                             string.Format(", convert(datetime, {0}-{1}-{2} {3}:{4}:{5}, 120))", t.MetrixDate.Value.Year, t.MetrixDate.Value.Month,
                             t.MetrixDate.Value.Day, t.MetrixDate.Value.Hour, t.MetrixDate.Value.Minute, t.MetrixDate.Value.Second);
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        internal static object[][] GetObjectStatistic()
        {
            List<object[]> data = new List<object[]>();
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "select e.entityvalue, COUNT(*) counter from metrix m inner join " +
                                          " Entities e on e.entityid = m.entityid group by e.entityvalue";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                data.Add(new object[] { reader.GetString(0), reader.GetInt32(1), EditAction.None, reader.GetString(0) });
                            }
                        }
                    }
                }
            }
            return data.ToArray();
        }
        
        internal static object[][] GetObjects()
        {
            List<object[]> data = new List<object[]>();
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "select entityid, entityvalue FROM Entities";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                data.Add(new object[] { reader.GetInt32(0), reader.GetString(1), false });
                            }
                        }
                    }
                }
            }
            return data.ToArray();
        }

        internal static object[][] GetObjectsWithGroups()
        {
            List<object[]> data = new List<object[]>();
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "select Entities.entityid, Entities.entityvalue, EntityGroups.groupName, EntityGroups.subgroupName FROM Entities LEFT JOIN EntityGroups ON EntityGroups.entityId = Entities.entityId";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                string group = reader.IsDBNull(2) ? "Месторождение не задано" : reader.GetString(2);
                                string subgroup = reader.IsDBNull(3) ? "Куст не задан" : reader.GetString(3);
                                data.Add(new object[] { reader.GetInt32(0), reader.GetString(1), false, group, subgroup });
                            }
                        }
                    }
                }
            }
            return data.ToArray();
        }

        internal static object[][] GetParameters()
        {
            List<object[]> data = new List<object[]>();
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "select predicateid, predicatevalue FROM Predicates";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                data.Add(new object[] { reader.GetInt32(0), reader.GetString(1), false });
                            }
                        }
                    }
                }
            }
            return data.ToArray();
        }

        internal static SortedDictionary<String, object[]> GetMetrix(int entity, int predicate)
        {
            SortedDictionary<String, object[]> data = new SortedDictionary<String, object[]>();
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = String.Format("select metrixid, metrixObject, metrixValue FROM metrix WHERE entityid={0} AND predicateid={1}", entity, predicate);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                String metrixObject = reader.GetString(1);
                                data.Add(metrixObject, new object[] { reader.GetInt32(0), metrixObject, reader.GetDecimal(2), EditAction.None });
                            }
                        }
                    }
                }
            }
            return data;
        }

        internal static object[][] GetParamStatistic()
        {
            List<object[]> data = new List<object[]>();
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "select e.predicatevalue, COUNT(*) counter from metrix m inner join " +
                                          " Predicates e on e.predicateid = m.predicateid group by e.predicatevalue";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                data.Add(new object[] { reader.GetString(0), reader.GetInt32(1), EditAction.None, reader.GetString(0) });
                            }
                        }
                    }
                }
            }
            return data.ToArray();
        }

        internal static void SaveMetrixBundle(List<object[]> metrix)
        {
            String sql = "";

            foreach (object[] mtx in metrix) {
                if ((EditAction)mtx[3] == EditAction.Modified)
                    sql += String.Format("UPDATE metrix SET metrixValue = {0} WHERE metrixid = {1};", mtx[2].ToString().Replace(',','.'), mtx[0]) + System.Environment.NewLine;
                if ((EditAction)mtx[3] == EditAction.Delete)
                    sql += String.Format("DELETE metrix WHERE metrixid = {0};", mtx[0]) + System.Environment.NewLine;
            }

            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public class Triplet
    {
        public DateTime? MetrixDate { get; private set;  }
        public string MetrixObject { get; private set; }
        public int PredicateId { get; private set; }
        public int EntityId { get; private set; }
        public decimal MetrixValue { get; private set; }

        public Triplet(int entityId, int predicateId, string metrixObject,  decimal value)
        {
            this.PredicateId = predicateId;
            this.EntityId = entityId;
            this.MetrixObject = metrixObject;
            MetrixDate = GetMetrix(metrixObject);
            this.MetrixValue = value;
        }

        private DateTime? GetMetrix(string date)
        {
            // input date must be dd/mm/yyyy or  dd/mm/yyyy hh:mm
            //'yyyy-mm-dd hh:mi:ss'
            //         var dataMetrix = string.Format("convert(datetime,'{0}-{1}-{2} {3}:{4}:{5}', 120)",
            //           metrix.MetrixDate.Value.Year, metrix.MetrixDate.Value.Month,
            //         metrix.MetrixDate.Value.Day, metrix.MetrixDate.Value.Hour,
            //       metrix.MetrixDate.Value.Minute, metrix.MetrixDate.Value.Second);
            int year = 0;
            int month;
            int day;
            int hours;
            int minutes;

            var delimeter = string.Empty;
            int pos = date.IndexOf("/");
            if (pos > -1)
            {
                delimeter = "/";
            }
            pos = date.IndexOf(".");
            if (pos > -1)
            {
                delimeter =  ".";
            }

            pos = date.IndexOf(delimeter);
            if (pos < 0 || !Int32.TryParse(date.Substring(0, pos), out day))
            {
                return null;
            }
            date = date.Substring(pos + 1);

            pos = date.IndexOf(delimeter);
            if (pos < 0 || !Int32.TryParse(date.Substring(0, pos), out month))
            {
                return null;
            }
            date = date.Substring(pos + 1).Trim();

            pos = date.IndexOf(" ");
            if (pos > 0 && !Int32.TryParse(date.Substring(0, pos), out year))
            {
                return null;
            }
            if (pos <= 0 && !Int32.TryParse(date, out year))
            {
                return null;
            }

            if (pos <= 0)
            {
                pos = -1;
                date = string.Empty;
            }
            else
            {
                date = date.Substring(pos + 1);
                pos = date.IndexOf(":");
            }

            if (pos < 0 || !Int32.TryParse(date.Substring(0, pos), out hours))
            {
                try
                {
                    return new DateTime(year, month, day);
                }
                catch { return null; }
            }

            date = date.Substring(pos + 1);

            if (!Int32.TryParse(date, out minutes))
            {
                return null;
            }

            try
            {
                return new DateTime(year, month, day, hours, minutes, 0);
            }
            catch { return null; }
        }
    }
}
