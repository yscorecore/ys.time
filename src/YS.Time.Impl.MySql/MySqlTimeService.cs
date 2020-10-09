using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
namespace YS.Time.Impl.MySql
{
    [YS.Knife.Service(typeof(ITimeService), ServiceLifetime.Singleton)]
    public class MySqlTimeService : RemoteTimeServiceBase
    {
        private readonly TimeContext timeContext;
        public MySqlTimeService(IOptions<RemoteTimeOptions> remoteOptions, TimeContext timeContext) : base(remoteOptions)
        {
            this.timeContext = timeContext;
        }

        protected override Task<DateTimeOffset> OnGetRemoteTime()
        {
            long timeStamp = (long)this.timeContext.Database.ExecuteSqlAsScalar("select unix_timestamp(now())");
            return Task.FromResult(DateTimeOffset.FromUnixTimeSeconds(timeStamp));
        }
    }
}
