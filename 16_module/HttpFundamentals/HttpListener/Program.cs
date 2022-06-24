

using System.Net;

namespace Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("HttpListener.IsSupported returned FALSE");
                return;
            }

            string[] prefixes = new string[] { "http://localhost:8888/MyName/" };

            HttpListener listener = new HttpListener();

            foreach (var prefix in prefixes)
            {
                listener.Prefixes.Add(prefix);
            }

            listener.Start();
            Console.WriteLine("Listening...");

            // The GetContext method blocks while waiting for a request.
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;

            HttpListenerResponse response = context.Response;
            // Construct a response.
            string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
            listener.Stop();
        }

        static void Main_2(string[] args)
        {
            StatusCodeListener(new[] { "http://localhost:8888/" });
        }

        static void StatusCodeListener(string[] prefixes)
        {
            if (prefixes is null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            using HttpListener httpListener = new HttpListener();

            foreach (string prefix in prefixes)
            {
                httpListener.Prefixes.Add(prefix);
            }
            httpListener.Start();

            Console.WriteLine("Server is listening its clients");

            while (true)
            {
                HttpListenerContext context = httpListener.GetContext();
                Console.WriteLine("Client connected");

                using (var response = context.Response)
                {
                    string absolutePath = context.Request.Url.AbsolutePath;

                    if (absolutePath == "/MyNameByCookies")
                    {
                        MyNameByCookies(response);
                    }
                }
            }
        }

        static void MyNameByCookies(HttpListenerResponse httpListenerResponse)
        {
            var myNameCookie = new Cookie("MyName", GetMyName());
            httpListenerResponse.Cookies.Add(myNameCookie);
            httpListenerResponse.Close();
        }

        static string GetMyName() => "TestName";

    }
}