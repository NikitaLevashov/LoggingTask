using LoggingTask.Interface;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Diagnostics;

namespace LoggingTask.Implementations
{
    internal class Algorithm : IAlgorithm
    {
        private readonly ILogger<Algorithm> log;
        private readonly IAlgorithm algorithm;
        private readonly ILoggerFactory loggerFactory;

        //Logger loggerNLog = LogManager.GetCurrentClassLogger();

        private Stopwatch stopWatch = new Stopwatch();

        public long Time
        {
            get
            {
                return this.stopWatch.ElapsedMilliseconds;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Algorithm"/> class.
        /// </summary>
        /// <param name="algorithm">algoritm.</param>
        public Algorithm(IAlgorithm algorithm, ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            this.algorithm = algorithm;
        }

        private Algorithm(ILogger<Algorithm> log, IAlgorithm algorithm, ILoggerFactory loggerFactory) : this(algorithm,loggerFactory)
        {
            this.log = log;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue].
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public int Calculate(int first, int second)
        {
            IsValidMinValueTwoNumbers(first, second);
            return this.algorithm.Calculate(first, second);
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue].
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <param name="milliseconds">Method execution time in milliseconds.</param
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public int GcdWithTime(int first, int second)
        {
            stopWatch.Start();
            int result = this.Calculate(first, second);
            stopWatch.Stop();

            return result;
        }

        public int GcdLogging(int first, int second)
        {
            var logger = loggerFactory.CreateLogger("logger");
            int result = 0;

            logger.LogTrace("Start method GcdLogging");
            try
            {
                var log = new Algorithm(loggerFactory.CreateLogger<Algorithm>(), algorithm, loggerFactory);
                logger.LogTrace("Start method GcdWithTime");
                result = GcdWithTime(first, second);
                logger.LogTrace("Finish method GcdWithTime");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                logger.LogInformation("Unhandled exception");
                logger.LogError(ex, $"\nMessage:{ex.Message}\nStackTrace:{ex.StackTrace}.");
            }
            catch (ArgumentException ex)
            {
                logger.LogInformation("Unhandled exception");
                logger.LogError(ex, $"\nMessage:{ex.Message}\nStackTrace:{ex.StackTrace}.");
            }

            catch (Exception ex)
            {
                logger.LogInformation("Unhandled exception");
                logger.LogError(ex, $"\nMessage:{ex.Message}\nStackTrace:{ex.StackTrace}.");
            }

            finally
            {
                logger.LogInformation("The finally block worked.");
            }
            
            stopWatch.Stop();
            return result;
        }


        private static void IsValidMinValueTwoNumbers(int first, int second)
        {
            if (first == int.MinValue || second == int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(first));
            }

            if (first == 0 && second == 0)
            {
                throw new ArgumentException("Can not be zero", nameof(first));
            }
        }       
    }
}
