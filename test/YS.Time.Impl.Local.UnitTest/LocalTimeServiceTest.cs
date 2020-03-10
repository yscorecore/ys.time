using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace YS.Time.Impl.Local
{
    [TestClass]
    public class LocalTimeServiceTest
    {
        [TestMethod]
        public async Task ShouldReturnLocalTimeWhenGetCurrent()
        {
            var timeSerivce = new LocalTimeService();
            var current = await timeSerivce.Current();
            Assert.IsTrue((DateTimeOffset.Now - current).TotalMilliseconds < 10);
        }
    }
}
