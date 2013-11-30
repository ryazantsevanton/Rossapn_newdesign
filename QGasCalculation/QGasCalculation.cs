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

        public decimal Calc(object[][] values) 
        { 
            if (values == null || values.Length != 4) {
                return 0;
            }
            decimal pn = 0;
            decimal pk = 0;
            decimal D = 0;
            decimal T = 0;
            foreach (var v in values)
            {
                switch ((string)v[0]) {
                    case "P шлейфа" : {
                        pk = (decimal)v[1];
                        continue;
                    }
                    case "P буферное" : {
                        pn = (decimal)v[1];
                        continue;
                    }
                    case "T буферное" : {
                        T = (decimal)v[1];
                        continue;
                    }
                    case "D штуцера" : {
                        D = (decimal)v[1];
                        continue;
                    }
                }
            }
            if (T < 0 || pn == 0 || pk < 0)
            {
                return 0;
            }

            try
            {
                var v1 = (double)pk / (double)pn;
                if (pk * 2 >= pn)
                {
                    v1 = 0.5D;
                }
                double r = Math.Pow((Math.Pow(v1, 2D / 1.3) - Math.Pow(v1, 1 + 1D / 1.3)) / (9 * (double)T + 2463.35), 0.5);

                return new Decimal(Math.Round( Math.Pow((double)D, 2) * (double)pn * r, 4));
            }
            catch
            {
                return 0;
            }
        }

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
