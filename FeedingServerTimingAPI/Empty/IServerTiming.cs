using System.Collections.Generic;

namespace Empty
{
    public interface IServerTiming
    {
        ICollection<ServerTimingMetric> Metrics { get; }
    }
    internal class ServerTiming : IServerTiming
    {
        public ICollection<ServerTimingMetric> Metrics { get; }
        public ServerTiming()
        {
            Metrics = new List<ServerTimingMetric>();
        }
    }
}
