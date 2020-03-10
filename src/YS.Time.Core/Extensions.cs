using System;

namespace YS.Time
{
    public static class Extensions
    {
        public static DateTimeOffset UtcNow(this ITimeService timeService)
        {
            return timeService.Current().Result;
        }
    }
}
