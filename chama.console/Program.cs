using chama.domain.Entities;
using chama.domain.Interfaces;
using chama.domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;

namespace chama.console
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<ICourseService, CourseService>()
                .AddTransient<IStudentService, StudentService>()
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            logger.LogDebug("All done!");

            while (true)
            {
                //do a request in sql


                //do the actual work here
                var courseService = serviceProvider.GetService<ICourseService>();
                courseService.SignUp(1, 1);


                Thread.Sleep(30000);
            }
        }
    }
}
