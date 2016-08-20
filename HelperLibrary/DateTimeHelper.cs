using System;
using System.Collections.Generic;

namespace HelperLibrary
{
    public class DateTimeCompare : IComparer<DateTime>
    {
        public int Compare(DateTime x, DateTime y)
        {
            Int32 unixTimestampX = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            Int32 unixTimestampY = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            if (unixTimestampY == unixTimestampX)
            {
                return 0;
            }
            if (unixTimestampX < unixTimestampY)
            {
                return -1;
            }
            return 1;
        }
    }
}
