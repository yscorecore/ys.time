using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace YS.Time.Impl.SqlServer
{
    [YS.Knife.Service(typeof(ITimeService), ServiceLifetime.Singleton)]
    public class SqlServerTimeService:RemoteTimeServiceBase
    {
        private readonly TimeContext timeContext;
        public SqlServerTimeService(IOptions<RemoteTimeOptions> remoteOptions, TimeContext timeContext) : base(remoteOptions)
        {
            this.timeContext = timeContext;
        }

        protected override Task<DateTimeOffset> OnGetRemoteTime()
        {
            DateTime time = (DateTime)this.timeContext.Database.ExecuteSqlAsScalar("select getdate()");
            DateTimeOffset timeOffset = DateTime.SpecifyKind(time, DateTimeKind.Utc);
            return Task.FromResult(timeOffset);
        }
    }
}
