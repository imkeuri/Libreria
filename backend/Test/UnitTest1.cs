using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void TestMethod1()
        {

        }
        public HttpClient httpClient { get; set; }
        public  Mock<IBooksContract> { get; set; }

        public void ConfigureTesting()
        {
            
        }

    }


}
