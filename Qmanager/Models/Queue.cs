using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Qntastic.Helpers;

namespace Qntastic.Models
{
    class Queue : Model
    {
        public int id { get; set; }
        public string token { get; set; }
        public  string name { get; set; }
        public int desk_id { get; set; }
        public bool is_active { get; set; }
        public DateTime created_at { get; set; }
        public int totalEntry { get; set; }
        public Desk desk { get; set; }
        public int Index { get; set; }
        public Entry ActiveEntry { get; set; }

        string generateToken()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path.Substring(0, 10);
        }

        public void save()
        {
            string sql = "INSERT INTO queues (name, token, desk_id, is_active) VALUES ('" + name + "', '" + generateToken() + "'," + desk.id + ",1)";
            Console.WriteLine(sql);
            MySqlDataReader reader = run(sql);
        }

        
        public void Move()
        {
            string sql = "SELECT id FROM entries WHERE is_done=0 AND queue_id=" + id + " LIMIT 1";

            Debug.WriteLine("loading");
            MySqlDataReader reader = run(sql);
            while (reader.Read())
            {
                ActiveEntry = new Entry(reader.GetInt32(0));
            }

            if (Index < totalEntry)
            {
                run("UPDATE entries SET is_done=1 WHERE id=" + ActiveEntry.id);
                Socket.client.Send(token + " " + Index+1);
            }
        }


        public int loadIndex()
        {
            Index = count("FROM entries WHERE queue_id=" + id + " AND is_done=1")+1;
            return Index;
        }


        public List<Entry> Entries()
        {
            string sql = "SELECT id FROM entries WHERE queue_id="+id;

            MySqlDataReader reader = run(sql);
            List<Entry> entries = new List<Entry>();

            while (reader.Read())
            {
                Debug.WriteLine(id);
                entries.Add(new Entry(reader.GetInt32(0)));
            }

            connection.Close();

            return entries;

        }

        
        public int loadTotalEntry()
        {
            totalEntry = count("FROM entries WHERE queue_id=" + id);
            return totalEntry;
        }


        public Queue(int id = 0)
        {
            if (id != 0)
            {
                string sql = "SELECT * from queues WHERE id=" + id.ToString();
                MySqlDataReader reader = run(sql);

                while (reader.Read())
                {
                    this.id = id;
                    this.name = reader.GetString(2);
                    this.token = reader.GetString(1);
                    this.desk = new Desk(reader.GetInt32(3));
                    this.desk_id = desk.id;
                    this.is_active = reader.GetBoolean(4);
                    this.created_at = DateTime.Parse(reader.GetString(5));
                    System.Diagnostics.Debug.WriteLine(desk.id);
                }
            }
            loadTotalEntry();
            loadIndex();
        }
    }
}
