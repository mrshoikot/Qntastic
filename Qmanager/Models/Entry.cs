using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Qntastic.Helpers;

namespace Qntastic.Models
{
    class Entry : Model
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int queue_id { get; set; }
        public bool is_done { get; set; }
        public Queue queue { get; set; }
        public DateTime created_at { get; set; }

        public void save()
        {
            if (queue != null)
            {
                string sql = "INSERT INTO entries (name, phone, queue_id) VALUES ('" + name + "', '" + phone + "'," + queue.id + "); SELECT LAST_INSERT_ID();";
                MySqlDataReader reader = run(sql);
                while (reader.Read())
                {
                    this.id = reader.GetInt32(0);
                }
            }
        }

        public void sms()
        {
            string body = "Dear " + this.name + ",\nCatch up with your queue status at " + State.getInst() + " by following this below URL.\n" + "http://127.0.0.1:8181/?queue="+queue.token+"&user=" + id;
            Socket.client.Send("sms||" + phone + "||" + body);
        }

        public int position()
        {
            int count = 1;
            foreach(Entry e in this.queue.Entries())
            {
                if(e.id == this.id)
                {
                    return count;
                }
                count++;
            }
            return 0;
        }

        public Entry(int id = 0)
        {
            this.tableName = "entries";
            if (id != 0)
            {
                string sql = "SELECT * from entries WHERE id=" + id.ToString();
                Console.WriteLine(sql);
                MySqlDataReader reader = run(sql);

                while (reader.Read())
                {
                    this.id = id;
                    this.name = reader.GetString(1);
                    this.phone = reader.GetString(2);
                    this.is_done = reader.GetBoolean(4);
                    this.queue = new Queue(reader.GetInt32(3));
                    this.queue_id = this.queue.id;
                    this.created_at = DateTime.Parse(reader.GetString(5));
                }
            }
        }
    }
}
