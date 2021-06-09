using Microsoft.Extensions.Logging;
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

        int Calculate(int first, int second, ILogger logger)
        {
            if(logger == null)
            {
                return this.Calculate(first, second);
            }

            try
            {
                var resultGCD = this.Calculate(first, second);
                logger.LogInformation($"GCD for {first} and {second} is {resultGCD}");
                return resultGCD;
            }
            catch(Exception)
            {
                logger.LogError("GCD not correct.");
                throw;
            }
        }

        (int gcd, long milliseconds) Calculate(int first, int second, ITimer timer)
        {
            if(timer == null)
            {
                throw new ArgumentNullException(nameof(timer));
            }

            timer.Start();
            var resultGCD = this.Calculate(first, second);
            timer.Stop();

            return (resultGCD, timer.ElapsedMilliseconds);
        }

        (int gcd, long milliseconds) Calculate(int first, int second, ITimer timer, ILogger logger)
        {
            if (logger == null)
            {
                return this.Calculate(first, second, timer);
            }

            try
            {
                (int gcd,long milliseconds) = this.Calculate(first, second, timer);
                logger.LogInformation($"Gcd of first and second: {gcd}. Time of first and second: {milliseconds}");
                return (gcd, milliseconds);
            }

            catch (Exception)
            {
                logger.LogError("Gcd and time not correct");
                throw;
            }
        }
    }
}
