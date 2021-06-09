using LoggingTask.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingTask.Implementations
{
    public class StopWatchAdapter : ITimer
    {
        private readonly Stopwatch _stopwatch;

        public StopWatchAdapter(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        public long ElapsedMilliseconds => _stopwatch.ElapsedMilliseconds;

        public void Start()
        {
            this._stopwatch.Start();
        }

        public void Stop()
        {
            this._stopwatch.Stop();
        }
    }
}
