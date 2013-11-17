using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    public class QGasCalculation : CalcFormula
    {

        public string Name
        {
            get { return Properties.Settings.Default.SettingName; }
        }

        public string ShowFormula {
            get {return "a * D^2 * pn * ( MAX(pk/pn)^1.5385 - MAX(pk/pn)^1.7962)^0.5 / (9 * T + 2463.35)^0.5";}
        }
        public string[] InitPredicates()
        {
            var l = new List<string>();
            l.Add(Properties.Settings.Default.pk);
            l.Add(Properties.Settings.Default.pn);
            l.Add(Properties.Settings.Default.D);
            l.Add(Properties.Settings.Default.T);

            return l.ToArray();
        }

        public decimal Calc(object[][] values) { return 0; }

        public bool CanCalc(object[][] values) 
        {
            try
            {
                var o = values.FirstOrDefault(d => (string)d[0] == Properties.Settings.Default.pk);
                if (o == null || (decimal)o[1] < 0)
                {
                    return false;
                }
                o = values.FirstOrDefault(d => (string)d[0] == Properties.Settings.Default.T);
                if (o == null || (decimal)o[1] < 0)
                {
                    return false;
                }
                o = values.FirstOrDefault(d => (string)d[0] == Properties.Settings.Default.pn);
                if (o == null || (decimal)o[1] == 0)
                {
                    return false;
                }

            }
            catch { return false; }
            return true;
        }
    }
}
