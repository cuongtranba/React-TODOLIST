using System.Collections.Generic;

namespace Empty
{
    public class ServerTimingHeaderValue
    {
        public ICollection<ServerTimingMetric> ServerTimingMetrics { get; }

        public ServerTimingHeaderValue()
        {
            ServerTimingMetrics = new List<ServerTimingMetric>();
        }

        public override string ToString()
        {
            return string.Join(",", ServerTimingMetrics);
        }
    }
}
