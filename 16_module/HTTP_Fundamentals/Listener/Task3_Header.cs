using System.Net;

namespace Listener
{
    internal static class Task3_Header
    {
        public static void GetName(string[] prefixes)
        {
            if (prefixes is null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            using HttpListener httpListener = new HttpListener();

            foreach (string prefix in prefixes)
            {
                httpListener.Prefixes.Add(prefix);
            }

            httpListener.Start();
            Console.WriteLine("Listening...");

            while (true)
            {
                HttpListenerContext context = httpListener.GetContext();
                Console.WriteLine("Client connected task3");

                using (var response = context.Response)
                {
                    string absolutePath = context.Request.Url.AbsolutePath;

                    if (absolutePath == "/MyNameByHeader")
                    {
                        GetMyNameByHeader(response);

                    }
                }
            }
        }
        public static void GetMyNameByHeader(HttpListenerResponse httpListenerResponse)
        {
            httpListenerResponse.AddHeader("X-MyName", GetMyName());
            httpListenerResponse.Close();
        }

        static string GetMyName() => "Gulzada";
    }
}
