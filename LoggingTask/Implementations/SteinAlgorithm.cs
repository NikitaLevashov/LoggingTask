using LoggingTask.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingTask.Implementations
{
    internal class SteinAlgorithm : IAlgorithm
    {
        /// <inheritdoc/>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public int Calculate(int first, int second)
        {
            if (first == int.MinValue || second == int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(first));
            }

            first = Math.Abs(first);
            second = Math.Abs(second);

            if (first == 0)
            {
                return second;
            }

            if (second == 0 || first == second)
            {
                return first;
            }

            if (first == 1 || second == 1)
            {
                return 1;
            }

            if ((first & 1) == 0)
            {
                if ((second & 1) == 0)
                {
                    return this.Calculate(first >> 1, second >> 1) << 1;
                }
                else
                {
                    return this.Calculate(first >> 1, second);
                }
            }
            else
            {
                if ((second & 1) == 0)
                {
                    return this.Calculate(first, second >> 1);
                }
                else
                {
                    return this.Calculate(second, first > second ? (first - second) : (second - first));
                }
            }
        }
    }
}
