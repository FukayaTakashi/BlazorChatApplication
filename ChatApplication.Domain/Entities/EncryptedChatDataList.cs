namespace ChatApplication.Domain.Entities
{
    public sealed class EncryptedChatDataList : List<string>
    {
        public EncryptedChatDataList() { }
        public List<string> Between(int startIndex, int lastIndex)
        {
            return this.Skip(startIndex).Take(lastIndex - startIndex).ToList();
        }
    }
}
