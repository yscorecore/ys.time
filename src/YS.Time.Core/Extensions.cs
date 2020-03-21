using System;

namespace YS.Time
{
    public static class Extensions
    {
        public static DateTimeOffset UtcNow(this ITimeService timeService)
        {
            _ = timeService ?? throw new ArgumentNullException(nameof(timeService));
            return timeService.Current().Result;
        }
    }
}
