namespace File_Cabinet.Entities
{
    public class LocalizedBook : Book
    {
        public string OriginalPublisher { get; set; }
        public string LocalizationCountry { get; set; } 
        public string LocalPublisher { get; set; }  
    }
}
