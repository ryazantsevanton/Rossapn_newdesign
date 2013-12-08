using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    public class ChangeEventChecker : EventChecker
    {

        public string Name
        {
            get
            {
                return "Скачок параметра";
            }
        }

        public string Help
        {
            get
            {
                return "В качестве аргумента укажите значение значение доверительного интервала в процентах";
            }
        }

        public object[] IsEventExists(object[] c, DateTime d, SqlConnection con)
        {
            return null;
        }

    }
}
