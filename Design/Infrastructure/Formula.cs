using System;
using System.Collections.Generic;
using System.Linq;

namespace Design.Infrastructure
{
    public class Formula
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public List<FormulaParameter> Parameters {get; set;}
        public string Expression { get; set;}

        public Formula() {
            Parameters = new List<FormulaParameter>();
        }
    }

    public class FormulaParameter {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public decimal Value { get; set;}
    }

    public class TestValue
    {
        public string ParamName { get; set; }
        public decimal ParamValue { get; set; }
    }
}
