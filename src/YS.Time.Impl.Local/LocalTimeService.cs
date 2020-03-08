using System;

namespace YS.Time.Impl.Local
{
    public class LocalTimeService : ITimeService
    {
        public DateTimeOffset Now() => DateTimeOffset.Now;
    }
}
