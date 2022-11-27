using ChatApplication.Domain.Helperes;
using System.Security.Cryptography;
using System.Text;

namespace ChatApplication.Domain.Entities
{
    public sealed class KeyEncryptionKeyEntity
    {
        private static readonly int _rsaKeySize = 512;

        public KeyEncryptionKeyEntity(
            string fingerprint,
            string publicKeyText,
            string privateKeyText)
        {
            Fingerprint = fingerprint;
            PublicKeyText = publicKeyText;
            PrivateKeyText = privateKeyText;
        }

        public string Fingerprint { get; set; }
        public string PublicKeyText { get; set; }
        public string PrivateKeyText { get; set; }

        public byte[] EncryptKey(byte[] plainKey)
        {
            return RsaHelper.Encrypt(PublicKeyText, plainKey);
        }

        public byte[] DecryptKey(byte[] encryptedKey)
        {
            return RsaHelper.Decrypt(PrivateKeyText, encryptedKey);
        }

        public static KeyEncryptionKeyEntity GenerateKey()
        {
           (var privateKeyText, var publicKeyText) = RsaHelper.GenerateKey(_rsaKeySize);
            var fingerprint = SHA256.HashData(Encoding.UTF8.GetBytes(publicKeyText));
            return new KeyEncryptionKeyEntity(
                Convert.ToBase64String(fingerprint),
                publicKeyText,
                privateKeyText);

        }
    }
}
