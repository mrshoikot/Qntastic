using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Qntastic.Models
{
    static class State
    {
        static string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=qntastic;SslMode=none";
        static MySqlConnection connection = new MySqlConnection(connString);

        public static List<Desk> AllDesks()
        {
            connection.Open();
            string sql = "SELECT id FROM desks";

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<Desk> allDesks = new List<Desk>();

            while (reader.Read())
            {
                allDesks.Add(new Desk(reader.GetInt32(0)));
            }

            connection.Close();

            return allDesks;

        }

        public static List<Queue> AllQueues()
        {
            connection.Open();
            string sql = "SELECT id FROM queues";

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<Queue> allQueues = new List<Queue>();

            while (reader.Read())
            {
                allQueues.Add(new Queue(reader.GetInt32(0)));
            }

            connection.Close();

            return allQueues;

        }


        public static Queue SelectedQueue = new Queue();


    }
}
