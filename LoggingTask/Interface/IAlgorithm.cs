using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingTask.Interface
{
    /// <summary>
    /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue].
    /// </summary>
    public interface IAlgorithm
    {
        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue].
        /// </summary>
        /// <param name="first">first value.</param>
        /// <param name="second">second value.</param>
        /// <returns>The GCD value.</returns>
        int Calculate(int first, int second);
    }
}
