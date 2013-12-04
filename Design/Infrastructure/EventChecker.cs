using System;
using System.Collections.Generic;
using System.Linq;

namespace Design
{
    public interface EventChecker
    {
        string Name { get; }
        string Help { get; }

        List<object[]> findEvents(List<object[]> metrix, string[] arguments);

    }
}
