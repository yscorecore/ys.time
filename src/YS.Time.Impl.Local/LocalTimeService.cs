using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using YS.Knife;

namespace YS.Time.Impl.Local
{
    [Service(Lifetime = ServiceLifetime.Singleton)]
    public class LocalTimeService : ITimeService
    {
        public Task<DateTimeOffset> Current() => Task.FromResult(DateTimeOffset.Now);
    }
}
