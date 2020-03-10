using System;
using System.Threading.Tasks;

namespace YS.Time
{
    public interface ITimeService
    {
        Task<DateTimeOffset> Current();
    }
}
