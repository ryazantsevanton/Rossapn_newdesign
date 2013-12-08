using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Design
{
    public interface EventChecker
    {
        string Name { get; }
        string Help { get; }

        object[] IsEventExists(object[] c, DateTime d, SqlConnection con);
    }
}
