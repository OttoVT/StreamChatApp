namespace StreamChatApp.Security.Encryption
{
    public interface IEncryptionProvider
    {
        byte[] Decrypt(byte[] info);
        byte[] Encrypt(byte[] info);
        byte[] GetModulus();
    }
}