namespace File_Cabinet.Entities
{
    public class Book : Document
    {
        public string ISBN { get; set; }
        public List<string> Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }

        public void ToString()
        {
            Console.WriteLine(DocumentNumber + "    |    " + Title + "    |    " + ISBN + "    |    "
                + NumberOfPages + "    |    " + Publisher + "    |    " + PublishedDate);
        }
    }
}
