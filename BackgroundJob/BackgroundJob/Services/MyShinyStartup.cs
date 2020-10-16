

using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Shiny.Jobs;
using System;

namespace BackgroundJob.Services
{
    public class MyShinyStartup : ShinyStartup
    {
        public static JobInfo RepeatedJob;
        public override void ConfigureServices(IServiceCollection services)
        {
            TimeSpan span = new TimeSpan(0, 0, 15, 0, 0);
            var job = new JobInfo(typeof(RepeatedTask))
            {
                BatteryNotLow = true,
                DeviceCharging = false,
                Repeat = true,
                PeriodicTime = span,
                RequiredInternetAccess = InternetAccess.Any
            };
            RepeatedJob = job;
            services.RegisterJob(job);
        }
    }
}
