namespace File_Cabinet.Entities
{
    public class Patent : Document
    {
        public DateTime ExpirationDate { get; set; }
        public List<string> Authors { get; set; }
    }
}
