namespace Client
{
    internal static class Task4_Cookies
    {
        public static async Task GetCookiesAsync()
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8888/");
            var response = await httpClient.GetAsync("MyNameByCookies");
            var myName = (response.Headers.GetValues("Set-Cookie")?.First()).Split('=')[1];

            Console.WriteLine($"My name is {myName}");

            Console.ReadKey();
        }
    }
}
