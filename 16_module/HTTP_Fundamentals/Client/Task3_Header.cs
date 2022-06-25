namespace Client
{
    internal static class Task3_Header
    {

        public static async Task GetHeaderAsync()
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8888/");
            var response = await httpClient.GetAsync("MyNameByHeader");
            var myName = response.Headers.GetValues("X-MyName")?.First();

            Console.WriteLine($"My name is {myName}");

            Console.ReadKey();
        }
     
    }
}
