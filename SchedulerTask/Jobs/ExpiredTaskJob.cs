using Quartz;
using ServiceInterfaces;

namespace SchedulerTask.Jobs
{
    [DisallowConcurrentExecution]
    public class ExpiredTaskJob:BaseJob
    {
        private IToDoItemService itemService;

        public ExpiredTaskJob(IToDoItemService itemService)
        {
            this.itemService = itemService;
        }

        public override void ExecuteJob(IJobExecutionContext context)
        {
            itemService.DeActiveTaskWhenExpired(App.Default.ExpriredTime);
        }

        public override IJobDetail GetJobDetail()
        {
            return JobBuilder.Create<ExpiredTaskJob>()
                    .WithIdentity(App.Default.ExpiredTaskJob, "group1")
                    .Build();
        }

        public override ITrigger GetJobTrigger()
        {
            return TriggerBuilder.Create()
                .WithIdentity(App.Default.TriggerExpiredTaskJob, "group1")
                .StartNow()
                .WithCronSchedule(App.Default.CronScheduleExpriredItem)
                .Build();
        }
    }
}
