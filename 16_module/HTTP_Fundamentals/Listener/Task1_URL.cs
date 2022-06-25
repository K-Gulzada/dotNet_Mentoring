using System.Net;

namespace Listener
{
    internal static class Task1_URL
    {
        public static void NameParserListener(string[] prefixes)
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
                HttpListenerResponse response = context.Response;

                Console.WriteLine("Client connected");

                if (context.Request.Url.AbsolutePath == "/MyName")
                {
                    string responseString = GetName();

                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Close();
                }
            }
        }

        static string GetName() => "Gulzada";
    }
}
