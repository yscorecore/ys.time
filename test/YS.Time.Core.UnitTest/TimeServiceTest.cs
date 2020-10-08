using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YS.Knife.Hosting;

namespace YS.Time
{
    public abstract class TimeServiceTest : KnifeHost
    {
        [TestMethod]
        public async Task ShouldReturnExpectedTimeWhenGetCurrent()
        {
            var timeService = this.GetService<ITimeService>();
            var current = await timeService.Current();
            Console.WriteLine(current);
            var timespan = DateTimeOffset.Now - current;
            Assert.IsTrue(timespan.TotalMilliseconds < 5000);
            var current2 = await timeService.Current();
            Console.WriteLine(current2 - current);
            Assert.IsTrue((current2 - current).TotalMilliseconds < 2000);
        }
    }
}
