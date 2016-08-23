using Quartz;
using ServiceInterfaces;

namespace SchedulerTask.Jobs
{
    [DisallowConcurrentExecution]
    class ExpiredtodoitemJob:IJob
    {
        private IToDoItemService _toDoItemService;

        public ExpiredtodoitemJob(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        public void Execute(IJobExecutionContext context)
        {
            _toDoItemService.DeActiveTaskWhenExpired(App.Default.ExpriredTime);
        }
    }
}
