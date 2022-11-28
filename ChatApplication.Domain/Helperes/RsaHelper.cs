using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;

namespace ChatApplication.Domain.Helperes
{
    public static class RsaHelper
    {
        private static readonly RsaKeyPairGenerator _rsaKeyPairGenerator = new();

        public static (string privateKeyText, string publicKeyText) GenerateKey(int bitLength)
        {
            var keyGenerationParameters = new KeyGenerationParameters(
                    new SecureRandom(),
                    bitLength);
            _rsaKeyPairGenerator.Init(keyGenerationParameters);
            var keyPair = _rsaKeyPairGenerator.GenerateKeyPair();

            string privateKeyText;
            string publicKeyText;
            using (var textWriter = new StringWriter())
            {
                var pemWriter = new PemWriter(textWriter);
                pemWriter.WriteObject(keyPair.Private);
                pemWriter.Writer.Flush();
                privateKeyText = textWriter.ToString();
            }
            using (var textWriter = new StringWriter())
            {
                var pemWriter = new PemWriter(textWriter);
                pemWriter.WriteObject(keyPair.Public);
                pemWriter.Writer.Flush();
                publicKeyText = textWriter.ToString();
            }
            return (privateKeyText, publicKeyText);
        }
        public static byte[] Encrypt(string publicKeyText, byte[] plainData)
        {
            var rsa = new Pkcs1Encoding(new RsaEngine());
            var publicKeyPem = new StringReader(publicKeyText);
            var publicKeyReader = new PemReader(publicKeyPem);
            var publicKeyParam = (AsymmetricKeyParameter)publicKeyReader.ReadObject();
            rsa.Init(true, publicKeyParam);
            return rsa.ProcessBlock(plainData, 0, plainData.Length);
        }

        internal static byte[] Decrypt(string privateKeyText, byte[] encryptedData)
        {
            var rsa = new Pkcs1Encoding(new RsaEngine());
            var privateKeyPem = new StringReader(privateKeyText);
            var privateKeyReader = new PemReader(privateKeyPem);
            var privateKeyParam = (AsymmetricKeyParameter)privateKeyReader.ReadObject();
            rsa.Init(false, privateKeyParam);
            return rsa.ProcessBlock(encryptedData, 0, encryptedData.Length);
        }
    }
}
