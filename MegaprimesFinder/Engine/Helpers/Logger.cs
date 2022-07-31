using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaprimesFinder.Engine.Helpers
{
    internal class Logger
    {
        public static Stopwatch stopWatch;
        private readonly ILog _log;
        private readonly ILog _errorLog;
        public Logger(ILog Log, ILog ErrorLog)
        {
            _log = Log;
            _errorLog = ErrorLog;
        }
        public void MegaprimesEngineStartLogger(int max)
        {
            stopWatch = Stopwatch.StartNew();
            _log.Info($"Stopwatch started for {max} input");
        }

        public void MegaprimesEngineStopLogger()
        {
            stopWatch.Stop();
            _log.Info($"Total engine elapse time {stopWatch.ElapsedMilliseconds} milliseconds");
        }
    }
}
