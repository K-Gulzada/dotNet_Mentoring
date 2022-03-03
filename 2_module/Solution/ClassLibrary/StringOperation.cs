namespace ClassLibrary
{
    public class StringOperation
    {
        public string ConcatStrings(string username)
        {
            string result = String.Empty;
            DateTime currentDateTime = DateTime.Now;

            if (username != null)
            {
                result = String.Concat(currentDateTime, " Hello, ", username, "!");
            }

            return result;
        }

        public string DisplayInfo(string username) {
            DateTime currentDateTime = DateTime.Now;
            return $"{currentDateTime} Hello, {username}!"; 
        }
    }
}
