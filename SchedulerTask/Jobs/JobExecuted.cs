using System.Collections.Generic;
using Quartz;

namespace SchedulerTask.Jobs
{
    public class JobExecuted
    {
        private readonly IEnumerable<IQuartzScheduler> quartzSchedulers;
        private IScheduler scheduler;
        public JobExecuted(IEnumerable<IQuartzScheduler> quartzSchedulers, IScheduler scheduler)
        {
            this.quartzSchedulers = quartzSchedulers;
            this.scheduler = scheduler;
        }

        public void RunJobs()
        {
            scheduler.Start();
            foreach (var quartzScheduler in quartzSchedulers)
            {
                scheduler.ScheduleJob(quartzScheduler.GetJobDetail(),quartzScheduler.GetJobTrigger());
            }
        }

    }
}
