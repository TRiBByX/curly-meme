using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Win10WebService;
using Win10_project;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToHotelDB()
        {   
            bool i = HotelDBFacade.PostGuest(125, "ANders", "ljsdf");
            Assert.IsTrue(i);
        }

        [TestMethod]
        public void AddToGuestView()
        {
            bool answer = 
        }
    }
}
