using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design;

namespace SimpleEventCondition
{
    public class SimpleEventCondition : EventChecker
    {

        public string Name { get { return "Пороговое"; } }
        public string Help
        {
            get
            {
                return "Переключение происходит, когда усредненное значение ряда предыдущих измерений отличается на заданное число процентов от текущего";
            }
        }

        public object[] IsEventExists(object[] c, DateTime d, SqlConnection con)
        {
            decimal argValue = 0;
            if (!Decimal.TryParse(((string)c[2]).Replace(',','.'), out argValue)) {
                return null;
            }

            using (var command = con.CreateCommand())
            {
                command.CommandText = string.Format("select top 5 metrixValue, metrixData from metrix where entityid={0} and predicateid={1}" +
                    "and metrixData <= CONVERT(datetime, '{2}.{3}.{4}',104) order by metrixData desc", 
                    (int)c[3], (int)c[0], d.Day, d.Month, d.Year);

                using (var reader = command.ExecuteReader())
                {
                    if (reader == null || !reader.Read()) { return null; }
                    double realValue = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader.GetDecimal(0));
                    double avdValue = 0;
                    int count = 0;
                    while (reader.Read())
                    {
                        avdValue += (reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader.GetDecimal(0)));
                        count++;
                    }
                    
                    avdValue = count == 0 ? avdValue : avdValue / count;

                    double delta = Math.Abs((realValue - avdValue) / realValue);
                    if (delta > Convert.ToDouble(argValue)/100)
                    {
                        return new object[] {
                            true,
                            avdValue * (100 + Convert.ToDouble(argValue))/100,
                            realValue
                        };
                    }
                }
            }
            return null;
        }
    }
}
