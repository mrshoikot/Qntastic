using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebSocketSharp;

namespace Qntastic.Helpers
{
    static class Socket
    {
        public static WebSocket client;
        static string host = "ws://localhost:8080";

        public static void init()
        {
            client = new WebSocket(host);

            client.OnOpen += (ss, ee) =>
            {
                Debug.WriteLine("connected");
            };
            client.OnError += (ss, ee) =>
               Debug.WriteLine("     Error: " +ee.Message);
            client.OnMessage += (ss, ee) =>
               Debug.WriteLine("Echo: " +ee.Data);
            client.OnClose += (ss, ee) =>
               Debug.WriteLine(string.Format("Disconnected"));


            client.Connect();
        }

    }
}
