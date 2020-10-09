using Microsoft.EntityFrameworkCore;

namespace YS.Time.Impl.SqlServer
{
    [SqlServerDbContext("TimeContext")]
    public class TimeContext : DbContext
    {
        public TimeContext(DbContextOptions<TimeContext> options):base(options) { }
    }
}
