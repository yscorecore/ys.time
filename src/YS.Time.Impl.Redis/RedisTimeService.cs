using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using YS.Knife;

namespace YS.Time.Impl.Redis
{
    [ServiceClass]
    public class RedisTimeService : RemoteTimeServiceBase
    {
        public RedisTimeService(IOptions<RemoteTimeOptions> remoteOptions, IOptions<RedisOptions> redisOptions, ILogger<RedisTimeService> logger) : base(remoteOptions)
        {
            _ = redisOptions ?? throw new ArgumentNullException(nameof(redisOptions));
            this.redisOptions = redisOptions.Value;
            this.logger = logger;
        }
        private readonly ILogger logger;
        private readonly RedisOptions redisOptions;
        protected override async Task<DateTimeOffset> OnGetRemoteTime()
        {
            using (var connection = this.CreateConnection())
            {
                var database = connection.GetDatabase();
                var result = await database.ExecuteAsync("TIME");
                var timeparts = (long[])result;
                var redisTime = DateTimeOffset.FromUnixTimeSeconds(timeparts[0]).AddMilliseconds(timeparts[1] / 1000.0);
                logger.LogInformation("Get time {time} from redis server.", redisTime);
                return redisTime;
            }

        }

        private ConnectionMultiplexer CreateConnection()
        {
            return redisOptions.Configuration != null ?
                    ConnectionMultiplexer.Connect(redisOptions.Configuration) :
                    ConnectionMultiplexer.Connect(redisOptions.ConnectionString);
        }
    }
}
