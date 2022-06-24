using System.Net;
using System.Net.Http;

namespace Client
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8888/");
                var response = await client.GetAsync("MyNameByCookies");

                var myName = (response.Headers.GetValues("Set-Cookie")?.First()).Split('=')[1];

                Console.WriteLine($"My name is {myName}");

                Console.ReadKey();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }
        }
    }
}