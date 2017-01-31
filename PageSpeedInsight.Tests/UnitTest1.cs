using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSA;
using System.Net.Http;
using System.Threading.Tasks;

namespace PageSpeedInsight.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FetURL()
        {
            PageSpeedCore ps = new PageSpeedCore();
            var response = ps.FetchURL("http://www.google.com");
            Assert.AreNotEqual(response, null);
        }
    }
}
