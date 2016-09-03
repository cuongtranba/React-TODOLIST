using Quartz;

namespace SchedulerTask.Jobs
{
    public interface IQuartzJob:IJob
    {
        IJobDetail GetJobDetail();
        ITrigger GetJobTrigger();
    }
}
