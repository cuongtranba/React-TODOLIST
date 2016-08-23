using System;
using Quartz;

namespace SchedulerTask.Jobs
{
    [DisallowConcurrentExecution]
    public class HelloJob : IJob, IQuartzScheduler
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Greetings from HelloJob!");
        }

        public IJobDetail GetJobDetail()
        {
            return JobBuilder.Create<HelloJob>()
                    .WithIdentity("Hello_job1", "group1")
                    .Build();
        }

        public ITrigger GetJobTrigger()
        {
            return TriggerBuilder.Create()
                .WithIdentity("hello_trigger1", "group1")
                .StartNow()
                .WithCronSchedule(App.Default.CronScheduleExpriredItem)
                .Build();
        }
    }
}