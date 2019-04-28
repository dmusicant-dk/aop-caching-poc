using System;
using AopTest.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CachingUnitTests.Service.Tests
{
    [TestClass]
    public class ItemServiceTests
    {
        [TestMethod]
        public void testGetItem()
        {
            ItemService service = new ItemServiceImpl();

            //Defaults to the value "one"
            Assert.AreEqual("one", service.getItem("Item1"));
        }
    }
}
