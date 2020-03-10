using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YS.Time
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void ShouldReturnExpectedValueWhenGetUtcNow()
        {
            var time = DateTimeOffset.Parse("2020-03-10");
            var timeService = Moq.Mock.Of<ITimeService>(p => p.Current() == Task.FromResult(time));
            Assert.AreEqual(time, timeService.UtcNow());
        }
    }
}
