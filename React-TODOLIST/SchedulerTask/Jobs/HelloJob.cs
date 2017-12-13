using System;
using Quartz;

namespace SchedulerTask.Jobs
{
    [DisallowConcurrentExecution]
    public class HelloJob : BaseJob
    {
        public override void ExecuteJob(IJobExecutionContext context)
        {
            Console.WriteLine("Hello job 1");
        }
        public override IJobDetail GetJobDetail()
        {
            return JobBuilder.Create<HelloJob>()
                    .WithIdentity("Hello_job1", "group1")
                    .Build();
        }

        public override ITrigger GetJobTrigger()
        {
            return TriggerBuilder.Create()
                .WithIdentity("hello_trigger1", "group1")
                .StartNow()
                .WithCronSchedule(App.Default.CronScheduleExpriredItem)
                .Build();
        }
    }
}