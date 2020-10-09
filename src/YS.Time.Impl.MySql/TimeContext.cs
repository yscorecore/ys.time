using Microsoft.EntityFrameworkCore;

namespace YS.Time.Impl.MySql
{
    [MySqlDbContext("TimeContext")]
    public class TimeContext : DbContext
    {
        public TimeContext(DbContextOptions<TimeContext> options) : base(options) { }
    }


}
