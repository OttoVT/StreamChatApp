using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Security.Encryption
{
    public class EncryptionProvider
    {
        private int keySize;
        private RSAParameters rsaParameters;
        //private RSACryptoServiceProvider rsaProvider;

        /// <summary>
        /// Encryption Provider for assymetric encryption
        /// </summary>
        /// <param name="keySize">Key size in bits</param>
        public EncryptionProvider(int keySize)
        {
            if (keySize < 64)
                throw new ArgumentException("Key should not be less than 64 bit, so f*ck you");
            this.keySize = keySize;
            var rsaProvider = new RSACryptoServiceProvider(keySize);
            rsaParameters = rsaProvider.ExportParameters(true);
            rsaProvider.Dispose();
        }

        /// <summary>
        /// Get Public key
        /// </summary>
        public byte[] GetModulus()
        {
            return rsaParameters.Modulus;
        }

        public byte[] Encrypt(byte[] info, byte[] modulus = null)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keySize))
            {
                if (modulus == null || modulus.Count() != 0)
                {
                    rsa.ImportParameters(rsaParameters);
                }
                else
                {
                    var parameters = new RSAParameters()
                    {
                        Exponent = new byte[] { 1, 0, 1 },
                        Modulus = modulus,
                    };
                    rsa.ImportParameters(parameters);
                }
                
                var encryptedBytes = rsa.Encrypt(info, false);
                return encryptedBytes;
            }
        }

        public byte[] Decrypt(byte[] info)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keySize))
            {
                rsa.ImportParameters(rsaParameters);
                var decryptedBytes = rsa.Decrypt(info, false);
                return decryptedBytes;
            }
        }
    }
}
