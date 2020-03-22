using StackExchange.Redis;
using YS.Knife;

namespace YS.Time.Impl.Redis
{
    [OptionsClass()]
    public class RedisOptions
    {
        public string ConnectionString { get; set; } = "localhost";
        public ConfigurationOptions Configuration { get; set; }
    }
}
