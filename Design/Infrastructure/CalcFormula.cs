using System;
using System.Collections.Generic;
using System.Linq;

namespace Design
{
    public interface CalcFormula
    {
        string Name { get; }

        string ShowFormula { get; }

        string[] InitPredicates();

        bool CanCalc(object[][] values);

        decimal Calc(object[][] values);
    }
}
