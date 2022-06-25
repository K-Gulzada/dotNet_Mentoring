using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal static class Task1_URL
    {
        public static void GetMyName()
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8888/");

            var response = httpClient.GetAsync("/MyName").Result;

            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
    }
}
