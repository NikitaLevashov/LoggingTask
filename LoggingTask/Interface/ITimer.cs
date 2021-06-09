using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingTask.Interface
{
    public interface ITimer
    {
        /// <summary>
        /// Get elapsed time.
        /// </summary>
       long ElapsedMilliseconds { get; }

       /// <summary>
       /// Start timer.
       /// </summary>
       void Start();

       /// <summary>
       /// Stop timer.
       /// </summary>
       void Stop();
       
    }
}
