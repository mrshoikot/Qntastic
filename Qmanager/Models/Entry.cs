using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

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
            string sql = "INSERT INTO entries (name, phone, queue_id) VALUES ('" + name + "', '" + phone + "'," + queue.id + ")";
            MySqlDataReader reader = run(sql);
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
                    this.is_done = reader.GetBoolean(3);
                    this.queue = new Queue(reader.GetInt32(4));
                    this.queue_id = this.queue.id;
                    this.created_at = DateTime.Parse(reader.GetString(5));
                }
            }
        }
    }
}
