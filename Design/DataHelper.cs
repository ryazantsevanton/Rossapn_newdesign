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

        internal static object[][] GetMetrixByAllConditions(string paramName, int[] selectedObjs, bool isDateType, object start, object end)
        {
            List<object[]> result = new List<object[]>();

            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    if (isDateType)
                    {
                        command.CommandText = "select distinct metrixObject";
                        foreach (var i in selectedObjs)
                        {
                            command.CommandText +=
                            ", (select metrixValue from metrix where metrixObject = m.metrixObject and entityid = " +
                            i + " and predicateid = m.predicateid)";
                        }
                        var first = true;
                        command.CommandText += " FROM metrix m inner join Predicates p on p.predicateid = m.predicateid " +
                                              "where entityid in (";
                        foreach (var i in selectedObjs)
                        {
                            if (!first) { command.CommandText += ","; } else { first = !first; }
                            command.CommandText += i;
                        }
                        var startDate = (DateTime)start;
                        var endDate = (DateTime)end;
                        command.CommandText += String.Format(") and p.predicatevalue='{0}' and  metrixData between convert(datetime, '{1}.{2}.{3}', 104) and convert(datetime, '{4}.{5}.{6}', 104)",
                            paramName, startDate.Day, startDate.Month, startDate.Year, endDate.Day, endDate.Month, endDate.Year);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                var row = new List<object>();
                                while (reader.Read())
                                {
                                    row.Clear();
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        row.Add(i == 0 ? (object)reader.GetString(0) : (object)reader.GetDecimal(i));
                                    }
                                    result.Add(row.ToArray());
                                }
                            }
                        }
                    }
                    else
                    {
                        command.CommandText = "select distinct metrixObject";
                        foreach (var i in selectedObjs)
                        {
                            command.CommandText +=
                            ", (select metrixValue from metrix where metrixObject = m.metrixObject and entityid = " +
                            i + " and predicateid = m.predicateid)";
                        }
                        var first = true;
                        command.CommandText += " FROM metrix m inner join Predicates p on p.predicateid = m.predicateid " +
                                              "where entityid in (";
                        foreach (var i in selectedObjs)
                        {
                            if (!first) { command.CommandText += ","; } else { first = !first; }
                            command.CommandText += i;
                        }
                        command.CommandText += ") and p.predicatevalue='" + paramName + "' and  metrixObject >='" +
                            start + "' and metrixObject <= '" + end + "'";
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                var row = new List<object>();
                                while (reader.Read())
                                {
                                    row.Clear();
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        row.Add(i == 0 ? (object)reader.GetString(0) : (object)reader.GetDecimal(i));
                                    }
                                    result.Add(row.ToArray());
                                }
                            }
                        }
                    }
                }
            }
            return result.ToArray();
        }

        internal static int GetParameter(string value, SqlConnection con, bool inited)
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
                    command.CommandText = String.Format("insert into Predicates(predicateid, predicatevalue, inited) values ({0}, '{1}', {2})", maxNumber, value, inited ? 1 : 0);
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
                            AppendLine("delete EntityGroups;").
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

        public static void UpdateEntityGrouping(int entityid, object subgroup, object group, SqlConnection con)
        {
            using (var command = con.CreateCommand())
            {
                command.CommandText = String.Format("delete EntityGroups where entityid = {0};", entityid) +
                    String.Format("insert into EntityGroups(groupName, subgroupName, entityid) values ({0},{1},{2});", group == null ? "NULL" : "'" + group.ToString() + "'",
                                                                                                                     subgroup == null ? "NULL" : "'" + subgroup.ToString() + "'", 
                                                                                                                     entityid);
                command.ExecuteNonQuery();
            }
        }

        public static void AddObject(string newkey, SqlConnection con, bool type, int inited)
        {
            using (var command = con.CreateCommand())
            {
                command.CommandText = type
                    ? "select max(predicateid) from Predicates"
                    : "select max(entityid) from Entities";
                int o = 0;
                try
                {
                    o = (int)command.ExecuteScalar() + 1;
                }
                catch (Exception e)
                {
                    o = 0;
                }


                command.CommandText = type
                    ? "insert into Predicates (predicateid, predicatevalue, inited) values (" + o + ",'" + newkey + "', " + inited + ")"
                    : "insert into Entities (entityid, entityvalue) values (" + o + ",'" + newkey + "')";
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
                    : "delete EntityGroups where entityid = " + o + "; delete Entities where entityid = " + o;
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
                                      " and name in ('Entities', 'Predicates', 'metrix', 'aproximatemetrix', 'EntityGroups', 'Accounts', 'ActionLog', 'Settings', 'CalcFormula', 'CalcFormulaParams')";
                var id = command.ExecuteScalar();
                if (!(id is DBNull) && ((int)id) == 10)
                {
                    return connection;
                }
                var comText = new List<string>()
                                  {
                                      "IF OBJECT_ID('EntityGroups', 'U') IS NOT NULL drop Table EntityGroups",
                                      "drop TABLE Entities",
                                      "drop TABLE Predicates",
                                      "drop TABLE metrix",
                                      "drop Table aproximatemetrix",
                                      "IF OBJECT_ID('ActionLog', 'U') IS NOT NULL drop Table ActionLog",
                                      "IF OBJECT_ID('Accounts', 'U') IS NOT NULL drop Table Accounts",
                                      "drop Table calcFormula",
                                      "drop Table calcFormulaParams",
                                      "IF OBJECT_ID('Settings', 'U') IS NOT NULL drop Table Settings",
                                      "CREATE TABLE Entities (entityid INT NOT NULL, entityvalue NVARCHAR(200) NOT NULL, PRIMARY KEY(entityid));",
                                      "CREATE TABLE Predicates (predicateid INT NOT NULL, predicatevalue NVARCHAR(200) NOT NULL, PRIMARY KEY(predicateid), inited int);",
                                      "CREATE TABLE metrix (metrixid int IDENTITY(1,1) NOT NULL, predicateid INT NOT NULL, entityid INT NOT NULL, metrixData datetime, metrixValue decimal(18,4) NULL, metrixObject nvarchar(200) null);",
                                      "CREATE TABLE aproximatemetrix (aproximatemetrixid int IDENTITY(1,1) NOT NULL, predicateid INT NOT NULL, entityid INT NOT NULL, metrixData datetime, zetValue NVARCHAR(200) NULL, lRegressionValue NVARCHAR(200) NULL);",
                                      "CREATE TABLE EntityGroups (entityid int FOREIGN KEY REFERENCES Entities(entityid), groupName NVARCHAR(200), subgroupName NVARCHAR(200));",
                                      "CREATE TABLE Accounts (login NVARCHAR(200) not null unique, role INT NOT NULL, passhash NVARCHAR(200) not null, name NVARCHAR(200), data NVARCHAR(200), deleted BIT default 0);",
                                      "INSERT INTO Accounts(login, role, passhash) VALUES ('admin',2,'6216f8a75fd5bb3d5f22b6f9958cdede3fc086c2');",
                                      "CREATE TABLE ActionLog (login NVARCHAR(200) FOREIGN KEY REFERENCES Accounts(login), action INT NOT NULL, arguments NVARCHAR(200), logDateTime datetime);",
                                      "CREATE TABLE Settings (settingName NVARCHAR(200), settingStringValue NVARCHAR(200), settingNumValue numeric(20, 8));",
                                      "CREATE TABLE CalcFormula (formulaId int IDENTITY(1,1) NOT NULL, formulaName NVARCHAR(200), formulaExpression nvarchar(3000));",
                                      "CREATE TABLE calcFormulaParams (paramId int IDENTITY(1,1) NOT NULL, formulaId int not null, typeid int, paramValue numeric(20, 4), name nvarchar(100) not null, code nvarchar(10) not null);",
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
            foreach (var t in triplets)
            {
                SetMetrix(t, con);
            }
        }

        internal static void LoadTriplet(Triplet t, SqlConnection con)
        {
            if (t == null) { return; }
            try {
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = string.Format("select max(metrixid) from metrix where entityId = {0} and predicateId={1} and metrixobject = '{2}'",
                                            t.EntityId, t.PredicateId, t.MetrixObject);
                    var o = command.ExecuteScalar();
                    if (o == null || o is DBNull)
                    {
                        if (t.MetrixDate == null)
                        {
                            command.CommandText = "insert into metrix(entityId, predicateId, metrixobject,  metrixValue) values ("
                                + t.EntityId + "," + t.PredicateId + ",'" + t.MetrixObject + "', " + t.MetrixValue.ToString().Replace(",",".") + ")";
                        }
                        else
                        { //yyyy-mm-dd hh:mi:ss
                            command.CommandText = "insert into metrix(entityId, predicateId, metrixobject,  metrixValue, metrixData) values ("
                                + t.EntityId + "," + t.PredicateId + ",'" + String.Format("{0:yyyy/MM/dd H:mm:ss}", t.MetrixDate) + "', " + t.MetrixValue.ToString().Replace(",", ".") +
                                string.Format(", convert(datetime, '{0}-{1}-{2} {3}:{4}:{5}', 120))", t.MetrixDate.Value.Year, t.MetrixDate.Value.Month,
                                t.MetrixDate.Value.Day, t.MetrixDate.Value.Hour, t.MetrixDate.Value.Minute, t.MetrixDate.Value.Second);
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch{}           
        }

        internal static void SetMetrix(Triplet triplet, SqlConnection con)
        {
            if (triplet == null) { return; }
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = String.Format("select metrixid from metrix where predicateid={0} and entityid = {1}",
                                                    triplet.PredicateId, triplet.EntityId);
                var s = String.IsNullOrEmpty(triplet.MetrixObject) ? string.Empty : triplet.MetrixObject;
                command.CommandText += triplet.MetrixDate == null 
                    ? " and metrixObject ='" + s + "'"
                    : String.Format(" and metrixData=convert(datetime,'{0}-{1}-{2} {3}:{4}:{5}', 120)",  
                        triplet.MetrixDate.Value.Year, triplet.MetrixDate.Value.Month, triplet.MetrixDate.Value.Day, 
                        triplet.MetrixDate.Value.Hour, triplet.MetrixDate.Value.Minute, triplet.MetrixDate.Value.Second);

                var o = command.ExecuteScalar();
                if (o == null)
                {
                    LoadTriplet(triplet, con);
                }
                else
                {
                    command.CommandText = string.Format("update metrix set metrixvalue={0} where metrixid = {1}",
                                          triplet.MetrixValue, (int)o);
                }
            
                command.ExecuteNonQuery();
            }            
        }
        internal static object[][] GetObjectStatistic()
        {
            List<object[]> data = new List<object[]>();
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "select e.entityvalue, COUNT(*) - 1, 0 counter, g.groupName, g.subgroupName, e.entityid from Entities e" +   
                            " left join EntityGroups g on g.entityid = e.entityid" +
                            " left join metrix m on e.entityid = m.entityid group by e.entityvalue, g.groupName, g.subgroupName, e.entityid order by e.entityvalue";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                data.Add(new object[] { reader.GetString(0), reader.GetInt32(1), EditAction.None, reader.GetInt32(2), reader.GetString(0), 
                                                        /* grouping */    reader.IsDBNull(3) ? null : reader.GetString(3), 
                                                                          reader.IsDBNull(4) ? null : reader.GetString(4),
                                                        /* entityid */    reader.GetInt32(5) });
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

        internal static SortedDictionary<String, object[]> GetMetrix(int entity, int predicate, string from, string to)
        {
            SortedDictionary<String, object[]> data = new SortedDictionary<String, object[]>();
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = String.Format("select metrixid, metrixObject, metrixValue FROM metrix WHERE entityid={0} AND predicateid={1} AND metrixObject BETWEEN '{2}' AND '{3}'", entity, predicate, from, to);
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

        internal static List<String> GetAllDistinctMetrixObjects()
        {
            List<String> data = new List<String>();
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT DISTINCT metrixObject FROM metrix ORDER BY metrixObject");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                //String metrixObject = reader.GetString(0);
                                data.Add(reader.GetString(0));
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
                    command.CommandText = "select e.predicatevalue, COUNT(*) - 1, e.inited counter from Predicates e left join " +
                                          "  metrix m on e.predicateid = m.predicateid group by e.predicatevalue, e.inited";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                data.Add(new object[] { reader.GetString(0), reader.GetInt32(1), EditAction.None, reader.GetInt32(2), reader.GetString(0) });
                            }
                        }
                    }
                }
            }
            return data.ToArray();
        }

        internal static int SaveMetrixBundle(List<object[]> metrix)
        {
            String sql = "";
            int changes = 0;

            foreach (object[] mtx in metrix) {
                if ((EditAction)mtx[3] == EditAction.Modified)
                {
                    changes++;
                    sql += String.Format("UPDATE metrix SET metrixValue = {0} WHERE metrixid = {1};", mtx[2].ToString().Replace(',', '.'), mtx[0]) + System.Environment.NewLine;
                }
                if ((EditAction)mtx[3] == EditAction.Delete)
                {
                    changes++;
                    sql += String.Format("DELETE metrix WHERE metrixid = {0};", mtx[0]) + System.Environment.NewLine;
                }
            }

            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }

            return changes;
        }

        internal static Account findAccount(string login)
        {
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT login, role, passhash, name, data FROM Accounts WHERE login = '{0}'", login);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null && reader.Read())
                        {
                            return readAccount(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        internal static Account findAccount(string login, bool deleted)
        {
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT login, role, passhash, name, data FROM Accounts WHERE login = '{0}' AND deleted = {1}", login, deleted ? 1 : 0);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null && reader.Read())
                        {
                            return readAccount(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        internal static List<Account> getAccounts()
        {
            List<Account> accounts = new List<Account>();
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT login, role, passhash, name, data FROM Accounts WHERE deleted = 0");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                                accounts.Add(readAccount(reader));
                        }
                    }
                }
            }
            return accounts;
        }

        internal static List<object[]> getAccountActions(string login)
        {
            List<object[]> log = new List<object[]>();
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT logDateTime, action, arguments FROM ActionLog WHERE login = '{0}' ORDER BY logDateTime DESC", login);
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                                log.Add(new object[] { reader.GetDateTime(0), (Account.Actions)reader.GetInt32(1), reader.IsDBNull(2) ? null : reader.GetString(2) });
                                
                        }
                    }
                }
            }
            return log;
        }

        internal static void logAction(Account.Actions action, string arguments = null)
        {
            using (var con = OpenOrCreateDb())
            {
                logAction(con, action, arguments);
            }
        }

        internal static void logAction(SqlConnection con, Account.Actions action, string arguments = null)
        {
            using (var command = con.CreateCommand())
            {
                command.CommandText = String.Format("INSERT INTO ActionLog (login, action, arguments, logDateTime) VALUES ('{0}','{1}','{2}', GETDATE())", Account.Current.Login, (int)action, arguments);
                command.ExecuteNonQuery();
            }
        }

        private static Account readAccount(SqlDataReader reader)
        {
            return new Account()
            {
                Login = reader.GetString(0),
                Role = (Account.Roles)reader.GetInt32(1),
                PassHash = reader.GetString(2),
                Name = reader.IsDBNull(3) ? null : reader.GetString(3),
                Data = reader.IsDBNull(4) ? null : reader.GetString(4)
            };
        }


        internal static Account AddAccount(string login, string p, Account.Roles role)
        {
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = String.Format("INSERT INTO Accounts(login, role, passhash) VALUES ('{0}',{1},'{2}');", login, (int)role, p);
                    command.ExecuteNonQuery();
                    return new Account()
                    {
                        Login = login,
                        Role = role,
                        PassHash = p,
                        Name = null,
                        Data = null
                    };
                }
            }
        }

        internal static void UpdateAccount(Account account)
        {
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = String.Format("UPDATE Accounts set role = {1}, passhash = '{2}', deleted = {3} WHERE login = '{0}';", account.Login, (int)account.Role, account.PassHash, account.Deleted ? 1 : 0);
                    command.ExecuteNonQuery();
                }
            }
        }

        internal static object[] GetMetrixByTimeConditions(string paramName, int[] selectedObjs, bool isDateType)
        {
            List<object> result = new List<object>();

            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    if (isDateType)
                    {
                        bool first = true;
                        command.CommandText = "select distinct metrixData from metrix m inner join " +
                                              "Predicates p on p.predicateid = m.predicateid " +
                                              "where entityid in (";
                        foreach (var i in selectedObjs)
                        {
                            if (!first) { command.CommandText += ","; } else { first = !first; }
                            command.CommandText += i;
                        }
                        command.CommandText += ") ";
                        if (!String.IsNullOrEmpty(paramName))
                        {
                            command.CommandText += String.Format(" and p.predicatevalue='{0}'", paramName);
                        }
                        command.CommandText += " and metrixData is not null group by metrixData order by metrixData";

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    if (!reader.IsDBNull(0)) {
                                        result.Add(reader.GetDateTime(0));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        bool first = true;
                        command.CommandText = "select distinct metrixObject from metrix m inner join " +
                                              "Predicates p on p.predicateid = m.predicateid " +
                                              "where entityid in (";
                        foreach (var i in selectedObjs)
                        {
                            if (!first) { command.CommandText += ","; } else { first = !first; }
                            command.CommandText += i;
                        }
                        command.CommandText += ") ";
                        if (!String.IsNullOrEmpty(paramName))
                        {
                            command.CommandText += String.Format(" and p.predicatevalue='{0}'", paramName);
                        }
                        command.CommandText += " and rtrim(ltrim(isnull(metrixObject,''))) <> '' group by metrixObject order by metrixObject";
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    result.Add(reader.GetString(0));
                                }
                            }
                        }
                    }
                }
            }
            return result.ToArray();
        }


        internal static void SaveSettings(decimal scale, decimal dost, decimal critValue, decimal intSchedule)
        {
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "select count(*) from Settings where settingName = 'ScaleData'";
                    var o = command.ExecuteScalar();
                    if (o is DBNull || ((int)o) == 0)
                    {
                        command.CommandText = "insert into Settings(settingName, settingNumValue) values ('ScaleData', " + scale + ")";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.CommandText = "update Settings set settingNumValue = " + scale
                                               + " where settingName = 'ScaleData'";
                        command.ExecuteNonQuery();
                    }

                    command.CommandText = "select count(*) from Settings where settingName = 'RowDost'";
                    o = command.ExecuteScalar();
                    if (o is DBNull || ((int)o) == 0)
                    {
                        command.CommandText = "insert into Settings(settingName, settingNumValue) values ('RowDost', " + dost + ")";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.CommandText = "update Settings set settingNumValue = " + dost
                                               + " where settingName = 'RowDost'";
                        command.ExecuteNonQuery();
                    }


                    command.CommandText = "select count(*) from Settings where settingName = 'CriticalValue'";
                    o = command.ExecuteScalar();
                    if (o is DBNull || ((int)o) == 0)
                    {
                        command.CommandText = "insert into Settings(settingName, settingNumValue) values ('CriticalValue', " + critValue + ")";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.CommandText = "update Settings set settingNumValue = " + critValue
                                               + " where settingName = 'CriticalValue'";
                        command.ExecuteNonQuery();
                    }

                    command.CommandText = "select count(*) from Settings where settingName = 'RangeSchedule'";
                    o = command.ExecuteScalar();
                    if (o is DBNull || ((int)o) == 0)
                    {
                        command.CommandText = "insert into Settings(settingName, settingNumValue) values ('RangeSchedule', " + intSchedule + ")";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.CommandText = "update Settings set settingNumValue = " + intSchedule
                                               + " where settingName = 'RangeSchedule'";
                        command.ExecuteNonQuery();
                    }

                }
            }
        }

        internal static decimal GetSettingValue(string p)
        {
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "select settingNumValue from Settings where settingName = '" + p + "'";
                    using (var reader = command.ExecuteReader())
                        try
                        {
                            reader.Read();
                            return reader.GetDecimal(0);
                        }
                        catch
                        {
                            return 0;
                        }
                }
            }
        }

        internal static List<Formula> GetFormulas()
        {
            List<Formula> f = new List<Formula>();
            using (var con = OpenOrCreateDb())
            {
                try
                {
                    using (var command = con.CreateCommand())
                    {
                        command.CommandText = "select formulaId, formulaName, formulaExpression from CalcFormula";
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader == null)
                            {
                                return f;
                            }
                            while (reader.Read())
                            {
                                f.Add(new Formula()
                                {
                                    Id = reader.IsDBNull(0) ? 0 : reader.GetSqlInt32(0).Value,
                                    Name = reader.IsDBNull(1) ? "Unknown" : reader.GetSqlString(1).Value,
                                    Expression = reader.IsDBNull(2) ? string.Empty : reader.GetSqlString(2).Value,
                                });
                            }
                        }
                    }

                    foreach (Formula g in f)
                    {
                        g.Parameters.AddRange(GetFormulaParameters(g.Id, con));
                    }

                }
                catch
                {
                }
                finally
                {
                    con.Close();
                }

                return f;
            }
        }

        internal static void RemoveFormula(Formula formula)
        {
            if (formula == null) { return; }
            using (var con = OpenOrCreateDb())
            {
                try
                {
                    using (var command = con.CreateCommand())
                    {
                        command.CommandText = "delete calcFormulaParams where formulaId = " + formula.Id;
                        command.ExecuteNonQuery();
                        command.CommandText = "delete CalcFormula where formulaId = " + formula.Id;
                        command.ExecuteNonQuery();
                    }
                }
                catch { }
                finally { con.Close(); }
            }
        }

        internal static int SaveFormula(Formula formula)
        {
            int result = 0;
            if (formula == null) { return result; }
            using (var con = OpenOrCreateDb())
            {
                try
                {
                    using (var command = con.CreateCommand())
                    {
                        command.CommandText = formula.Id == 0
                            ? string.Format("insert into calcFormula (formulaName, formulaExpression) values('{0}', '{1}')",
                                            formula.Name, formula.Expression)
                            : string.Format("update calcFormula set formulaName='{0}', formulaExpression='{1}' where formulaid={2}",
                                            formula.Name, formula.Expression, formula.Id);
                        command.ExecuteNonQuery();
                        if (formula.Id == 0)
                        {
                            command.CommandText = "select max(formulaid) from calcFormula";
                            result = (int)command.ExecuteScalar();
                        }
                        else
                        {
                            result = formula.Id;
                        }
                    }
                }
                catch { }
                finally { con.Close(); }
            }
            return result;
        }

        internal static void RemoveFormulaParameter(int paramId)
        {
            using (var con = OpenOrCreateDb())
            {
                try
                {
                    using (var command = con.CreateCommand())
                    {
                        command.CommandText = "delete calcFormulaParams where paramId = " + paramId;
                        command.ExecuteNonQuery();
                    }
                }
                catch { }
                finally { con.Close(); }
            }
        }

        internal static void SaveFormulaParameter(FormulaParameter p, int fid)
        {
            using (var con = OpenOrCreateDb())
            {
                try
                {
                    //"CREATE TABLE calcFormulaParams (paramId int IDENTITY(1,1) NOT NULL, formulaId int not null, 
                    //typeid int, paramValue numeric(20, 4), name nvarchar(100) not null, code nvarchar(10) not null);",
                    using (var command = con.CreateCommand())
                    {
                        int t = 0;
                        if (!String.IsNullOrEmpty(p.TypeName))
                        {
                            command.CommandText = "select min(predicateid) FROM Predicates where  predicatevalue = '" +
                                                    p.TypeName + "'";
                            var i = command.ExecuteScalar();
                            t = i == null || i is DBNull ? 0 : (int)i;
                        }
                        command.CommandText = p.Id == 0
                            ? string.Format("insert into calcFormulaParams(formulaId, typeid, paramValue, name, code) " +
                            " values ({0},{1},{2}, '{3}', '{4}')", fid, t, p.Value, p.Name, p.Code)
                            : string.Format("update calcFormulaParams set typeid={0}, paramValue={1}, name='{2}', code='{3}' "
                            + " where  paramId={4} and formulaId={5}", t, p.Value, p.Name, p.Code, p.Id, fid);
                        command.ExecuteNonQuery();
                    }
                }
                catch { }
                finally { con.Close(); }
            }
        }

        internal static IList<FormulaParameter> GetFormulaParameters(int p, SqlConnection con)
        {
            List<FormulaParameter> g = new List<FormulaParameter>();
            using (var command = con.CreateCommand())
            {
                command.CommandText = "SELECT paramId, typeid, Name, p.predicatevalue, code, paramValue " +
                " FROM calcFormulaParams fp left join Predicates p on p.predicateid = fp.typeid " +
                " where formulaid=" + p;
                using (var reader = command.ExecuteReader())
                {
                    if (reader == null)
                    {
                        return g;
                    }
                    while (reader.Read())
                    {
                        g.Add(new FormulaParameter()
                        {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetSqlInt32(0).Value,
                            TypeId = reader.IsDBNull(1) ? 0 : reader.GetSqlInt32(1).Value,
                            TypeName = reader.IsDBNull(3) ? string.Empty : reader.GetSqlString(3).Value,
                            Name = reader.IsDBNull(2) ? string.Empty : reader.GetSqlString(2).Value,
                            Code = reader.IsDBNull(4) ? string.Empty : reader.GetSqlString(4).Value,
                            Value = reader.IsDBNull(5) ? 0 : reader.GetSqlDecimal(5).Value,
                        });
                    }
                }
            }
            return g;
        }

        public static List<CalcFormula> CustomFormulas { get; set; }

        internal static object GetMetrix(int entityId, string parametr, object metrix, bool typeMetrix, SqlConnection con)
        {
            using(var command = con.CreateCommand()) {
                if (!typeMetrix) {
                    command.CommandText =
                     String.Format("SELECT metrixValue FROM metrix m inner join Predicates p on m.predicateid = p.predicateid" +
                        " where p.predicatevalue = '{0}' and m.entityid = {1} and metrixObject = '{2}'",
                        parametr, entityId, metrix);
                }
                else {
                    var d = (DateTime)metrix;
                    command.CommandText =
                     String.Format("SELECT metrixValue FROM metrix m inner join Predicates p on m.predicateid = p.predicateid" +
                        " where p.predicatevalue = '{0}' and m.entityid = {1} and metrixData =  CONVERT(datetime, '{2}-{3}-{4} {5}:{6}:{7}', 120)",
                        parametr, entityId, d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
                }
                try
                {
                    var o = command.ExecuteScalar();
                    return o == null ? 0 : (decimal)o;
                }
                catch { return 0; }
            }
        }

        internal static string[] GetEntityGroups()
        {
            List<string> groups = new List<string>();
            using (var con = OpenOrCreateDb())
            {
                using(var command = con.CreateCommand()) {
                    command.CommandText = "SELECT distinct groupName + ', ' + subgroupName  FROM EntityGroups" +
                                          " order by groupName + ', ' + subgroupName";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader == null) { return groups.ToArray(); }
                        while (reader.Read()) {
                            if (!reader.IsDBNull(0))
                            {
                                groups.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            return groups.ToArray();
        }

        internal static object[][] GetEntityByGroup(string p)
        {
            List<object[]> entites = new List<object[]>();
            using (var con = OpenOrCreateDb())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "select entityid, entityvalue from Entities where entityid in " +
                                           "(SELECT entityid FROM EntityGroups where groupName + ', ' + " +
                                           " subgroupName = '" + p + "')";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader == null) { entites.ToArray(); }
                        while (reader.Read())
                        {
                            entites.Add(new object[] {reader.IsDBNull(0) ? 0 : reader.GetInt32(0), 
                                                      reader.IsDBNull(1) ? "" : reader.GetString(1)});
                        }
                    }
                }
            }
            return entites.ToArray();
        }
    }

    public class Triplet
    {
        public DateTime? MetrixDate { get; set;  }
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

            if (String.IsNullOrEmpty(date)) { return null; }
            int year = 0;
            int month;
            int day;
            int hours;
            int minutes;
            int seconds;

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

            if (Int32.TryParse(date, out minutes))
                try
                {
                    return new DateTime(year, month, day, hours, minutes, 0);
                }
                catch { return null; }

            try
            {
                if (date.IndexOf(":") != -1 && Int32.TryParse(date.Substring(0,2), out minutes) && Int32.TryParse(date.Substring(2,2), out seconds))
                
                        return new DateTime(year, month, day, hours, minutes, seconds);
                    }
            catch { return null; }

            return null;
        }
    }
}
