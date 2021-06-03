using LoggingTask.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingTask.Implementations
{
    /// <inheritdoc/>
    internal class EuclideanAlgorithm : IAlgorithm
    {
        /// <inheritdoc/>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public int Calculate(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);
            while (first != 0 && second != 0)
            {
                if (first > second)
                {
                    first = first % second;
                }
                else
                {
                    second = second % first;
                }
            }

            if (first == 0)
            {
                return second;
            }

            return first;
        }
    }
}
