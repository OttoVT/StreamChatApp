using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamChatApp.Security.Encryption;
using System.Text;
using StreamChatApp.Common.IPDiscovery;

namespace StreamChatApp.UtilsTest
{
    [TestClass]
    public class IPDiscoveryTest
    {
        [TestMethod]
        public void GetHostIPTest()
        {
            //Arrange
            var ipDiscovery = new IPDiscovery();

            //Act
            var result = ipDiscovery.DiscoverHostIP();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
