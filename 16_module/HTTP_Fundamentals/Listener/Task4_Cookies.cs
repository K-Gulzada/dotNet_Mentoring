using System.Net;

namespace Listener
{
    internal static class Task4_Cookies
    {
        public static void GetNameByCookies(string[] prefixes)
        {
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

                    if (absolutePath == "/MyNameByCookies")
                    {
                        GetMyNameByCookies(response);
                    }
                }
            }
        }
        static void GetMyNameByCookies(HttpListenerResponse httpListenerResponse)
        {
            var myNameCookie = new Cookie("MyName", GetMyName());
            httpListenerResponse.Cookies.Add(myNameCookie);
            httpListenerResponse.Close();
        }

        static string GetMyName() => "Gulzada";
    }
}
