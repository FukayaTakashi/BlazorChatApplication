namespace ChatApplication.Domain.Entities
{
    public sealed class EncryptedEncryptionKeyEntity
    {
        public EncryptedEncryptionKeyEntity(byte[] encryptedKey)
        {
            EncryptedKey = encryptedKey;
        }

        public byte[] EncryptedKey { get; set; }

        public EncryptionKeyEntity DecryptKey(KeyEncryptionKeyEntity keyEncryptionKeyEntity)
        {
            var plainKey = keyEncryptionKeyEntity.DecryptKey(EncryptedKey);
            return new EncryptionKeyEntity(plainKey);
        }
    }
}
