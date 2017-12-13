using System;
using Quartz;

namespace SchedulerTask.Jobs
{
    [DisallowConcurrentExecution]
    public class HiJob : BaseJob
    {
        public override void ExecuteJob(IJobExecutionContext context)
        {
            Console.WriteLine("Greetings from Hi!");

        }
        public override IJobDetail GetJobDetail()
        {
            return JobBuilder.Create<HiJob>()
                    .WithIdentity("hi_job2", "group1")
                    .Build();
        }

        public override ITrigger GetJobTrigger()
        {
            return TriggerBuilder.Create()
                .WithIdentity("hi_trigger2", "group1")
                .StartNow()
                .WithCronSchedule(App.Default.CronScheduleExpriredItem)
                .Build();
        }
    }
}