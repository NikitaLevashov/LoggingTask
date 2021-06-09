using System;
using System.Diagnostics;
using LoggingTask.Implementations;
using LoggingTask.Interface;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace LoggingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начало метода main");

            Stopwatch watch = new Stopwatch();

            IAlgorithm algorithm = new EuclideanAlgorithm();
            var timer = new StopWatchAdapter(watch);

            ILoggerFactory loggerFactory = LoggerFactory.Create(
            builder =>
            {
                builder
                     .AddConsole()
                     .AddDebug()
                     .AddEventLog()
                     .AddNLog()
                     .SetMinimumLevel(LogLevel.Trace);
            });

            ILogger<Program> logger = loggerFactory.CreateLogger<Program>();

            algorithm.Calculate(100000, 245000, null, logger);

            //Algorithm algorithm1 = new Algorithm(new EuclideanAlgorithm(),loggerFactory);
            //Algorithm algorithm2 = new Algorithm(new SteinAlgorithm(), loggerFactory2);
            //Algorithm algorithm3 = new Algorithm(new SteinAlgorithm(), loggerFactory3);



            //algorithm1.GcdLogging(0,0);
            //algorithm2.GcdLogging(int.MinValue, 12);
            //algorithm2.GcdLogging(14, 12);

            Console.ReadKey();

        
        }
    }
}
