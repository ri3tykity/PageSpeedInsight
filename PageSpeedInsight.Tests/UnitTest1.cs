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
        PageSpeedCore ps = new PageSpeedCore();
        string inputUrl1 = "http://www.carchat24.com";
        //string inputUrl2 = "https://www.googleapis.com/pagespeedonline/v2/runPagespeed?url=https://developers.google.com/speed/pagespeed/insights/&strategy=mobile&key=yourAPIKey";
        //string inputUrl3 = "afafafaf";
        //string inputUrl4 = "";
        [TestMethod]
        public void FetURL_NotValid()
        {
            //var response = ps.FetchURL("");
            var res = ps.FetchURL("URL is not valid.");
            Assert.AreEqual("URL is not valid.", res);
        }

        [TestMethod]
        public void FetURL()
        {
            var response = ps.FetchURL(inputUrl1);
            Assert.AreEqual("Lots of string", response.ToString());
        }

        [TestMethod]
        public void ValidURL()
        {
            bool isValidURL = ps.IsValidURL(inputUrl1);
            Assert.AreEqual(true, isValidURL);
        }

        [TestMethod]
        public void ValidURL_WithWrongStringInput()
        {
            bool isValidURL = ps.IsValidURL(inputUrl1);
            Assert.AreNotEqual(false, isValidURL);
        }

        [TestMethod]
        public void Test_ExtractDomainName()
        {
            string rawURL = "http://www.carchat24.com/about";
            string expectedURL = "http://www.carchat24.com";
            string result = ps.ExtractDomainFromURL(rawURL);
            Assert.AreEqual(expectedURL, result);
        }
        [TestMethod]
        public void Test_ExtractDomainName_WithPathAndQuery()
        {
            string rawURL = "http://www.carchat24.com";
            string expectedURL = "http://www.carchat24.com";
            string result = ps.ExtractDomainFromURL(rawURL);
            Assert.AreEqual(expectedURL, result);
        }

    }
}
