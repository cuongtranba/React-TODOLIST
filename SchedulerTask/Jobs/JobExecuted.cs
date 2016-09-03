using System.Collections.Generic;
using Quartz;

namespace SchedulerTask.Jobs
{
    public class JobExecuted
    {
        private readonly IEnumerable<IQuartzJob> quartzSchedulers;
        private IScheduler scheduler;
        public JobExecuted(IEnumerable<IQuartzJob> quartzSchedulers, IScheduler scheduler)
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
