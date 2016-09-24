using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamChatApp.Security.Encryption;
using System.Text;

namespace StreamChatApp.UtilsTest
{
    [TestClass]
    public class AssymetricEncryptionTest
    {
        [TestMethod]
        public void AssymetricEncryptionWorkflowTest()
        {
            //Arrange
            var keySize = 1024;
            var encryptionProviderClient = new AssymetricEncryptionProvider(keySize);
            var encryptionProviderServer = new AssymetricEncryptionProvider(keySize);
            var str = "lolHere";
            var infoToEncrypt = Encoding.Unicode.GetBytes(str);
            
            //Act
            var serverModulus = encryptionProviderServer.GetModulus();
            var encryptedDate = encryptionProviderClient.Encrypt(infoToEncrypt, serverModulus);
            var decryptedData = encryptionProviderServer.Decrypt(encryptedDate);

            //Assert
            Assert.AreEqual(str, decryptedData);
        }
    }
}
