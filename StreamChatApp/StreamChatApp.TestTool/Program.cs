using StreamChatApp.Security.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.TestTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var keySize = 1024;
            var encryptionProviderClient = new EncryptionProvider(keySize);
            var encryptionProviderServer = new EncryptionProvider(keySize);
            var infoToEncrypt = Encoding.Unicode.GetBytes("lolHere");
            var serverModulus = encryptionProviderServer.GetModulus();
            var encryptedDate = encryptionProviderClient.Encrypt(infoToEncrypt, serverModulus);

            var decryptedData = encryptionProviderServer.Decrypt(encryptedDate);
            Console.ReadKey();
        }
    }
}