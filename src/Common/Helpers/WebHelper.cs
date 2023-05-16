using System.Net;
using System.Net.Sockets;

namespace Common.Helpers
{
    public class WebHelper
    {
        private static WebHelper instance;
        private static readonly object lockObject = new object();
        public int HttpPort { get; set; }

        private int _httpsPort;
        public int HttpsPort
        {
            get => _httpsPort;
            set
            {
                if (_httpsPort == default)
                    _httpsPort = value;
            }
        }

        public string ApiBase { get; set; }
        public string ApiHttpsAddress { get; set; }
        public string ApiHttpAddress { get; set; }
        private WebHelper()
        {
            HttpPort = RandomPort();
            HttpsPort = RandomPort();
            ApiBase = "https://localhost";
            ApiHttpsAddress = $"{ApiBase}:{HttpsPort}";
            ApiHttpAddress = $"{ApiBase}:{HttpPort}";
        }

        public static WebHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new WebHelper();
                            System.Console.WriteLine("new instance");
                        }
                    }
                }
                return instance;
            }
        }

        // public int GetEmptyPort()
        // {
        //     using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        //     {
        //         socket.Bind(new IPEndPoint(IPAddress.Loopback, 0));

        //         var endPoint = (IPEndPoint)socket.LocalEndPoint;
        //         return endPoint.Port;
        //     }
        // }
        public int RandomPort()
        {
            Random random = new Random();
            int port = random.Next(1024, 65535); // 1024-65535 arasında bir sayı

            // IPEndPoint oluşturma
            return new IPEndPoint(IPAddress.Any, port).Port;
        }
    }
}