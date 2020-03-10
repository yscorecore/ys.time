using System;
using System.Threading.Tasks;

namespace YS.Time.Impl.Local
{
    public class LocalTimeService : ITimeService
    {
        public Task<DateTimeOffset> Current() => Task.FromResult(DateTimeOffset.Now);
    }
}
