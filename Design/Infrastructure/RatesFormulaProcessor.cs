using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace Design.Infrastructure
{
    public class RatesFormulaProcessor
    {
        public static string[] Validate(string formula, FormulaParameter[] attributes)
        {
            List<string> result = new List<string>();
            List<string> variables = new List<string>();

            Regex rx = new Regex(@"[a-zA-Z0-9 +-/*)(]");
            Regex rxSign = new Regex(@"[+-/*]");

            if (!string.IsNullOrEmpty(formula) && !rx.IsMatch(formula))
            {
                result.Add("Формула содержит некорректные символы");
            }
            else
            {
                string tempFormula = string.IsNullOrEmpty(formula) ? string.Empty : formula.Replace(" ", string.Empty);
                if (!string.IsNullOrEmpty(tempFormula))
                {
                    if (rxSign.IsMatch(tempFormula.Substring(0, 1)))
                    {
                        result.Add("Формула начинается знаком");
                    }
                    else
                    {
                        if (rxSign.IsMatch(tempFormula.Substring(tempFormula.Length - 1)))
                        {
                            result.Add("Формула заканчивается значком");
                        }
                        else
                        {
                            result.AddRange(ParseFormula(tempFormula, variables));
                        }
                    }
                }
                else {
                    result.Add("Формула не задана");
                }
            }

            if (attributes == null || attributes.Length == 0)
            {
                foreach (string variable in variables)
                {
                    result.Add("Переменная '" + variable + "' не объявлена в аттрибутах");
                }
            }
            else
            {
                foreach (string v in variables)
                {
                    string s = v.ToLower();
                    if (!attributes.Any(a => a.Code.ToLower() == s))
                    {
                        result.Add("Переменная '" + v + "' не объявлена в аттрибутах");
                    }
                }
            }
            if (variables.Count == 0)
            {
                if (attributes != null)
                {
                    foreach (FormulaParameter a in attributes)
                    {
                        result.Add("Аттрибут '" + a.Name + "' не используется в формуле");
                    }
                }
            }
            else
            {
                if (attributes != null)
                {
                    foreach (FormulaParameter a in attributes)
                    {
                        string s = a.Code.ToLower();
                        if (!variables.Any(v => v.ToLower() == s))
                        {
                            result.Add("Аттрибут '" + a.Name + "' не используется в формуле");
                        }
                    }
                }
            }

            if (attributes != null)
            {
                foreach (FormulaParameter a in attributes)
                {
                    string s = a.Code.ToLower();
                    if (attributes.Count(v => v.Code.ToLower() == s) != 1)
                    {
                        result.Add("Аттрибут '" + a.Name + "' объявлен более одного раза");
                    }
                }
            }

            return result.ToArray();
        }

        private static string[] ParseFormula(string formula, ICollection<string> variables)
        {
            
            KeyValuePair<string, string> innerPair = GetLastWithIn(formula);
            if (innerPair.Key == string.Empty)
            {
                return ParseLineFormula(formula, variables);
            }
            if (innerPair.Value == formula)
            {
                return ParseLineFormula(innerPair.Key, variables);
            }

            Regex rxSign = new Regex(@"[+-/*]");
            List<string> result = new List<string>();
            result.AddRange(ParseLineFormula(innerPair.Key, variables));

            int pos = formula.LastIndexOf(innerPair.Value);
            if (pos < 0)
            {
                result.Add("Ожидается скобка");
                return result.ToArray();
            }
            if (pos == 0 || !formula.Substring(0, pos).Any(c => c != '('))
            {
                if (!rxSign.IsMatch(formula.Substring(pos + innerPair.Value.Length, 1)) &&
                    formula.Substring(pos + innerPair.Value.Length, 1) != ")")
                {
                    result.Add("Знак отсутствует");
                    return result.ToArray();
                }

                string prepareStr;
                if (pos == 0)
                {
                    prepareStr = rxSign.IsMatch(formula.Substring(pos + innerPair.Value.Length, 1))
                                     ? formula.Substring(innerPair.Value.Length + 1)
                                     : formula.Substring(innerPair.Value.Length);
                }
                else
                {
                    prepareStr = formula.Substring(0, pos) + formula.Substring(pos + innerPair.Value.Length + 1);
                }

                result.AddRange(ParseFormula(prepareStr, variables));
                return result.ToArray();
            }
            if (!rxSign.IsMatch(formula.Substring(pos - 1, 1)))
            {
                result.Add("Знак отсутствует");
                return result.ToArray();
            }
            string prepareStr1 = formula.Substring(0, pos - 1) + formula.Substring(pos + innerPair.Value.Length);
            result.AddRange(ParseFormula(prepareStr1, variables));
            return result.ToArray();
        }

        private static KeyValuePair<string, string> GetLastWithIn(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return new KeyValuePair<string, string>();
            }
            if (s.IndexOf("(") < 0)
            {
                return new KeyValuePair<string, string>(s.Replace(")", string.Empty),
                                                        s.Replace(")", string.Empty));
            }
            int posIn = s.LastIndexOf("(");
            string value = s.Substring(posIn);
            string key = s.Substring(posIn + 1);

            int posOut = value.IndexOf(")");
            if (posOut < 0)
            {
                return new KeyValuePair<string, string>(key, value);
            }
            return new KeyValuePair<string, string>(key.Substring(0, posOut - 1),
                                                    value.Substring(0, posOut + 1));
        }

        private static string[] ParseLineFormula(string list, ICollection<string> variables)
        {
            Regex rxSign = new Regex(@"[+-/*]");
            Regex rx = new Regex(@"[a-zA-Z]");
            if (string.IsNullOrEmpty(list))
            {
                return new string[] { };
            }
            if (rxSign.IsMatch(list.Substring(0, 1)) || rxSign.IsMatch(list.Substring(list.Length - 1)))
            {
                return new[] { "Знак отсутствует" };
            }
            string letter = string.Empty;
            Int64 t;
            foreach (char ch in list)
            {
                if (rx.IsMatch(ch.ToString()))
                {
                    letter += ch;
                    continue;
                }

                if (string.IsNullOrEmpty(letter) && Regex.IsMatch(ch.ToString(), @"[0-9]"))
                {
                    continue;
                }

                if (!rxSign.IsMatch(ch.ToString()))
                {
                    return new[] { "Некорректный символ '" + ch.ToString() + "'" };
                }
                if (!Int64.TryParse(letter, out t) && !string.IsNullOrEmpty(letter))
                {
                    variables.Add(letter);
                }
                letter = string.Empty;
            }
            if (!Int64.TryParse(letter, out t) && !string.IsNullOrEmpty(letter))
            {
                variables.Add(letter);
            }
            return new string[] { };
        }


        private static decimal CalcInnerLine(string formula)
        {
            KeyValuePair<string, string> innerPair = GetLastWithIn(formula);
            if (string.IsNullOrEmpty(innerPair.Key))
            {
                return CalcLineFormula(formula);
            }
            decimal result = CalcLineFormula(innerPair.Key);
            if (innerPair.Value == formula)
            {
                return result;
            }
            int pos = formula.LastIndexOf(innerPair.Value);
            if (pos > 0)
            {
                return CalcInnerLine(formula.Substring(0, pos) + result + formula.Substring(innerPair.Value.Length + pos));
            }
            return CalcInnerLine("" + result + formula.Substring(innerPair.Value.Length));
        }

        private static decimal CalcLineFormula(string lineFormula)
        {
            if (string.IsNullOrEmpty(lineFormula))
            {
                return 0;
            }
            List<char> signs = new List<char>();
            List<decimal> decimals = new List<decimal>();
            string letter = string.Empty;
            Regex rx = new Regex(@"[0-9.]");
            decimal d;
            try
            {
                foreach (var ch in lineFormula)
                {
                    if (rx.IsMatch(ch.ToString()))
                    {
                        letter += ch;
                        continue;
                    }
                    if (!string.IsNullOrEmpty(letter))
                    {
                        if (!Decimal.TryParse(letter, out d))
                        {
                            d = 0;
                        }
                        decimals.Add(d);
                        letter = string.Empty;
                    }
                    signs.Add(ch);
                }
                if (!string.IsNullOrEmpty(letter))
                {
                    if (!Decimal.TryParse(letter, out d))
                    {
                        d = 0;
                    }
                    decimals.Add(d);
                }
                decimal[] dec = decimals.ToArray();
                char[] singsAr = signs.ToArray();
                decimal result;
                for (int i = 0; i < singsAr.Length; i++)
                {
                    if (singsAr[i] == '*')
                    {
                        result = dec[i]*dec[i + 1];
                        dec[i] = result;
                        dec[i + 1] = result;
                        singsAr[i] = '=';
                        continue;
                    }
                    if (singsAr[i] != '/') continue;
                    try
                    {
                        result = dec[i]/dec[i + 1];
                    }
                    catch
                    {
                        result = 0;
                    }
                    dec[i] = result;
                    dec[i + 1] = result;
                    singsAr[i] = '=';
                }
                decimals.Clear();
                signs.Clear();
                result = dec[0];
                for (int i = 0; i < singsAr.Length; i++)
                {
                    if (singsAr[i] != '=')
                    {
                        decimals.Add(result);
                        signs.Add(singsAr[i]);
                    }
                    result = dec[i + 1];
                }
                decimals.Add(result);

                dec = decimals.ToArray();
                singsAr = signs.ToArray();
                result = dec[0];
                for (int i = 0; i < singsAr.Length; i++)
                {
                    if (singsAr[i] == '+')
                    {
                        result = result + dec[i + 1];
                        continue;
                    }
                    if (singsAr[i] == '-')
                    {
                        result = result - dec[i + 1];
                    }
                }
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public static string PresentationDemo(string formula, FormulaParameter[] attributes, object[][] values)
        {
            return Presentation(formula, attributes, PresentationMode.DemoMode, values);
        }

        public static string Presentation(string formula, FormulaParameter[] attributes, PresentationMode mode, object[][] values)
        {
            if (string.IsNullOrEmpty(formula))
            {
                return string.Empty;
            }

            string result = string.Empty;
            Regex rxLetter = new Regex(@"[a-zA-Z]");
            string letter = string.Empty;
            foreach (char ch in formula)
            {
                if (rxLetter.IsMatch(ch.ToString()))
                {
                    letter += ch;
                }
                else
                {
                    if (!string.IsNullOrEmpty(letter))
                    {
                        result = result + GetValue(letter, attributes, values);
                        letter = string.Empty;
                    }
                    result += ch;
                }
            }
            if (!string.IsNullOrEmpty(letter))
            {
                result = result + GetValue(letter, attributes, values);
            }
            return result;
        }

        private static decimal GetValue(string letter, IEnumerable<FormulaParameter> attributes, object[][] values)
        {
            FormulaParameter attr = attributes.FirstOrDefault(a => a.Code.ToLower() == letter.ToLower());
            if (attr == null)
            {
                return 0;
            }

            return attr.TypeId > 0 ? CalcPreDefinedValue(attr, values) : (decimal)attr.Value; 
        }

          public static decimal CalcPreDefinedValue(FormulaParameter attr, object[][] values)
        {
            object[] vl = values.FirstOrDefault(v => ((string)v[0]) == attr.Code);
            return vl == null || vl.Length == 0 ? 0 : (decimal)vl[1];
        }

        public static decimal Calculate(string expression, FormulaParameter[] attributes, object[][] values)
        {
            string presentatonForm = Presentation(expression, attributes, PresentationMode.RealMode, values).Replace(" ", string.Empty);
            return CalcInnerLine(presentatonForm);
        }

        public static decimal CalculateDemo(string expression, FormulaParameter[] attributes, object[][] values)
        {
            string presentatonForm = PresentationDemo(expression, attributes, values).Replace(" ", string.Empty);
            return CalcInnerLine(presentatonForm);
        }
    }

    public enum PresentationMode
    {
        DemoMode,
        RealMode

    }
}
