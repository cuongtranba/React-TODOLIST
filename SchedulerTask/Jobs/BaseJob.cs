using System;
using Quartz;

namespace SchedulerTask.Jobs
{
    public abstract class BaseJob : IQuartzJob
    {
        protected BaseJob()
        {
            
        }
        public abstract void ExecuteJob(IJobExecutionContext context);

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                Console.WriteLine($"start time:{DateTime.Now} - {GetJobDetail().Key} - {GetJobDetail().Description}");
                ExecuteJob(context);
                Console.WriteLine($"end time:{DateTime.Now} - {GetJobDetail().Key} - {GetJobDetail().Description}");
                Console.WriteLine("------------------------------------------------------------");
            }
            catch (JobExecutionException jobExecutionException)
            {
                Console.WriteLine($"end time:{DateTime.Now} - {GetJobDetail().Key} - {GetJobDetail().Description}");
                Console.WriteLine(
                    $"Job {GetJobDetail().Key} threw a JobExecutionException:{jobExecutionException.Message} ");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"end time:{DateTime.Now} - {GetJobDetail().Key} - {GetJobDetail().Description}");
                Console.WriteLine(
                    $"Job {GetJobDetail().Key} threw a JobExecutionException:{exception.Message} ");
            }
        }

        public abstract IJobDetail GetJobDetail();
        

        public abstract ITrigger GetJobTrigger();
    }
}
