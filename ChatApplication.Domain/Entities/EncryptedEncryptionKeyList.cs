namespace ChatApplication.Domain.Entities
{
    public class EncryptedEncryptionKeyList : Dictionary<string, byte[]>
    {
        public EncryptionKeyEntity GetEncryptionKeyEntity(
            KeyEncryptionKeyEntity keyEncryptionKeyEntity)
        {
            var fingerprint = keyEncryptionKeyEntity.Fingerprint;
            if (ContainsKey(fingerprint))
            {
                var encryptedEncryptionKeyEntity = new EncryptedEncryptionKeyEntity(
                    this[fingerprint]);
                return encryptedEncryptionKeyEntity.DecryptKey(keyEncryptionKeyEntity);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public static EncryptedEncryptionKeyList GetEncryptedEncryptionKeyList(
            EncryptionKeyEntity encryptionKeyEntity,
            List<KeyEncryptionKeyEntity> keyEncryptionKeyEntities)
        {
            var plainKey = encryptionKeyEntity.PlainKey;
            var encryptedEncryptionKeyList = new EncryptedEncryptionKeyList();
            foreach (var keyEncryptionKeyEntity in keyEncryptionKeyEntities)
            {
                var encryptedKey = keyEncryptionKeyEntity.EncryptKey(plainKey);
                var encryptionKey = new EncryptedEncryptionKeyEntity(encryptedKey);
                encryptedEncryptionKeyList.Add(
                    keyEncryptionKeyEntity.Fingerprint,
                    encryptionKey.EncryptedKey);
            }
            return encryptedEncryptionKeyList;
        }
    }
}
