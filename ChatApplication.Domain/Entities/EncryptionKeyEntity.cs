using System.Security.Cryptography;
using System.Text;

namespace ChatApplication.Domain.Entities
{
    public sealed class EncryptionKeyEntity : IDisposable
    {
        private static readonly int _keySize = 256;
        private readonly Aes _aes;

        public EncryptionKeyEntity(byte[] plainKey)
        {
            _aes = Aes.Create();
            _aes.KeySize = _keySize;
            _aes.Key = plainKey;
            _aes.IV = plainKey.Take(_aes.BlockSize / 8).ToArray();
            _aes.Mode = CipherMode.CBC;
            _aes.Padding = PaddingMode.PKCS7;
        }

        public byte[] PlainKey => _aes.Key;

        public string Decrypt(string encryptedText)
        {
            var encryptTextBinary = Convert.FromBase64String(encryptedText);
            var encodedPlainText = _aes.CreateDecryptor().TransformFinalBlock(
                encryptTextBinary, 0, encryptTextBinary.Length);
            var plainText = Encoding.UTF8.GetString(encodedPlainText);
            return plainText;
        }

        public string Encrypt(string plainText)
        {
            var encodedPlainText = Encoding.UTF8.GetBytes(plainText);
            var encryptTextBinary = _aes.CreateEncryptor().TransformFinalBlock(
                encodedPlainText, 0, encodedPlainText.Length);
            var encryptedText = Convert.ToBase64String(encryptTextBinary);
            return encryptedText;
        }

        public void Dispose()
        {
            _aes.Dispose();
        }

        public static EncryptionKeyEntity GenerateKey()
        {
            using var aes = Aes.Create();
            aes.KeySize = _keySize;
            aes.GenerateKey();
            var plainKey = aes.Key;
            return new EncryptionKeyEntity(plainKey);
        }
    }
}
