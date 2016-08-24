using Quartz;
using ServiceInterfaces;

namespace SchedulerTask.Jobs
{
    public class ExpiredTaskJob:IJob, IQuartzScheduler
    {
        private IToDoItemService itemService;

        public ExpiredTaskJob(IToDoItemService itemService)
        {
            this.itemService = itemService;
        }

        public void Execute(IJobExecutionContext context)
        {
            itemService.DeActiveTaskWhenExpired(App.Default.ExpriredTime);
        }

        public IJobDetail GetJobDetail()
        {
            return JobBuilder.Create<ExpiredTaskJob>()
                    .WithIdentity(App.Default.ExpiredTaskJob, "group1")
                    .Build();
        }

        public ITrigger GetJobTrigger()
        {
            return TriggerBuilder.Create()
                .WithIdentity(App.Default.TriggerExpiredTaskJob, "group1")
                .StartNow()
                .WithCronSchedule(App.Default.CronScheduleExpriredItem)
                .Build();
        }
    }
}
