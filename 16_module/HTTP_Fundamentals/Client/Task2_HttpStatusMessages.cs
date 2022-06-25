using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Task2_HttpStatusMessages
    {
        public static async Task GetStatusMessages()
        {
            string[] urls = { "Information", "Success", "Redirection", "ClientError", "ServerError" };

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8888/");

            foreach (var url in urls)
            {
                Console.WriteLine($"Requesting {url}");
                var response = await httpClient.GetAsync(url);
                Console.WriteLine($"Response status code: {response.StatusCode}");
            }
        }
    }
}
