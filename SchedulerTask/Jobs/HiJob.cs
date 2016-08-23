using System;
using Quartz;

namespace SchedulerTask.Jobs
{
    [DisallowConcurrentExecution]
    public class HiJob : IJob,IQuartzScheduler
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Greetings from Hi!");
        }

        public IJobDetail GetJobDetail()
        {
            return JobBuilder.Create<HiJob>()
                    .WithIdentity("hi_job2", "group1")
                    .Build();
        }

        public ITrigger GetJobTrigger()
        {
            return TriggerBuilder.Create()
                .WithIdentity("hi_trigger2", "group1")
                .StartNow()
                .WithCronSchedule(App.Default.CronScheduleExpriredItem)
                .Build();
        }
    }
}