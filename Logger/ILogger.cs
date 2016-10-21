using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public interface ILogger
    {
          void WiteLog(string source, string log, string message, object[] extraParam = null);
    }
}
