using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebSocketSharp;
using Qntastic.Models;

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
            {
                string command = ee.Data.Split(" ")[0];
                string id = ee.Data.Split(" ")[1];

                if (command == "exit")
                {
                    Entry e = new Entry();
                    e.delete(int.Parse(id));
                }else if (command == "end")
                {
                    Debug.WriteLine(int.Parse(id));
                    Entry e = new Entry(int.Parse(id));
                    e.delete(int.Parse(id));
                    e.save();
                    client.Send("switch " + e.queue.token + " " + e.id.ToString());
                }
                else if (command == "check")
                {
                    string token = ee.Data.Split(" ")[2];
                    id = ee.Data.Split(" ")[1];
                    Queue q = new Queue(0, token);
                    if (q.id == 0)
                    {
                        client.Send("invalid "+token);
                    }
                    else
                    {
                        Entry entry = new Entry(int.Parse(id));
                        if(entry.id == 0)
                        {
                            client.Send("invalid " + token);
                        }else if(entry.queue.token != token)
                        {
                            client.Send("invalid " + token);
                        }else if (entry.is_done)
                        {
                            client.Send("done" + "||" + "Bank Asia, Uttara" + "||" + q.desk.name + "||" + q.desk.personal + "||" + q.token);
                        }
                        else
                        {
                            client.Send("valid"+"||"+"Bank Asia, Uttara" + "||" + q.desk.name + "||" + q.desk.personal + "||" + q.Index + "||" + entry.position() + "||" + q.token);
                        }
                    }
                }

            };
               
            client.OnClose += (ss, ee) =>
               Debug.WriteLine(string.Format("Disconnected"));


            client.Connect();
        }

    }
}
