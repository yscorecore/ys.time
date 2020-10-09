using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace YS.Time
{
    public abstract class RemoteTimeServiceBase : ITimeService
    {
        public RemoteTimeServiceBase(IOptions<RemoteTimeOptions> remoteOptions)
        {
            _ = remoteOptions ?? throw new ArgumentNullException(nameof(remoteOptions));
            this.cacheTime = TimeSpan.FromSeconds(remoteOptions.Value.CacheSeconds);
        }
        private TimeSpan cacheTime;
        private DateTimeOffset lastLocalTime;
        private DateTimeOffset lastRemoteTime;
        public async Task<DateTimeOffset> Current()
        {
            var localNow = DateTimeOffset.Now;
            if (localNow - lastLocalTime > cacheTime)
            {
                lastRemoteTime = await OnGetRemoteTime();
                lastLocalTime = DateTimeOffset.Now;
            }
            return lastRemoteTime + (localNow - lastLocalTime);
        }

        protected abstract Task<DateTimeOffset> OnGetRemoteTime();

    }
}
