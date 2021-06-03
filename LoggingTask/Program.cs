using System;
using LoggingTask.Implementations;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace LoggingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начало метода main");
            ILoggerFactory loggerFactory = LoggerFactory.Create(
            builder =>
            {
                builder
                     .AddConsole()
                     .AddNLog()
                     .SetMinimumLevel(LogLevel.Trace);
            });

            ILoggerFactory loggerFactory2 = LoggerFactory.Create(
            builder =>
            {
                builder
                    .AddDebug()
                    .SetMinimumLevel(LogLevel.Trace);
            });

            ILoggerFactory loggerFactory3 = LoggerFactory.Create(
            builder =>
            {
               builder
                   .AddEventLog()
                   .SetMinimumLevel(LogLevel.Trace);
            });

            Algorithm algorithm1 = new Algorithm(new EuclideanAlgorithm(),loggerFactory);
            Algorithm algorithm2 = new Algorithm(new SteinAlgorithm(), loggerFactory2);
            Algorithm algorithm3 = new Algorithm(new SteinAlgorithm(), loggerFactory3);



            algorithm1.GcdLogging(0,0);
            algorithm2.GcdLogging(int.MinValue, 12);
            algorithm2.GcdLogging(14, 12);

            Console.ReadKey();

        
        }
    }
}
