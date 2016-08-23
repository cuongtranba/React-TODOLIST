using System.Collections.Generic;
using Quartz;

namespace SchedulerTask.Jobs
{
    public class JobExecuted
    {
        private readonly List<IQuartzScheduler> quartzSchedulers;
        private IScheduler scheduler;
        public JobExecuted(List<IQuartzScheduler> quartzSchedulers, IScheduler scheduler)
        {
            this.quartzSchedulers = quartzSchedulers;
            this.scheduler = scheduler;
        }

        public void RunJobs()
        {
            foreach (var quartzScheduler in quartzSchedulers)
            {
                scheduler.ScheduleJob(quartzScheduler.GetJobDetail(),quartzScheduler.GetJobTrigger());
            }
        }

    }
}
