using System.Net;

namespace Listener
{
    internal class Task2_HttpStatusMessages
    {
        public static void StatusCodeListener(string[] prefixes)
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
                Console.WriteLine("Client connected");

                using (var response = context.Response)
                {
                    string absolutePath = context.Request.Url.AbsolutePath;

                    if (absolutePath == "Information")
                        response.StatusCode = (int)HttpStatusCode.EarlyHints;
                    else if (absolutePath == "/Success")
                        response.StatusCode = (int)HttpStatusCode.OK;
                    else if (absolutePath == "/Redirection")
                        response.StatusCode = (int)HttpStatusCode.Redirect;
                    else if (absolutePath == "/ClientError")
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                    else if (absolutePath == "/ServerError")
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    else
                        response.StatusCode = (int)HttpStatusCode.BadGateway;

                    response.Close();
                }
            }
        }
    }
}
