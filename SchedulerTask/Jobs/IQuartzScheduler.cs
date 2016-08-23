using Quartz;

namespace SchedulerTask.Jobs
{
    public interface IQuartzScheduler
    {
        IJobDetail GetJobDetail();
        ITrigger GetJobTrigger();
    }
}
