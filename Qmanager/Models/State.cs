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

        public  static MySqlDataReader run(string sql)
        {
            connection.Close();
            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public static List<Desk> AllDesks()
        {
            string sql = "SELECT id FROM desks";

            MySqlDataReader reader = run(sql);
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
            string sql = "SELECT id FROM queues";

            MySqlDataReader reader = run(sql);
            List<Queue> allQueues = new List<Queue>();

            while (reader.Read())
            {
                allQueues.Add(new Queue(reader.GetInt32(0)));
            }

            connection.Close();

            return allQueues;

        }

        public static void setInst(string inst)
        {
            string sql = "UPDATE settings SET value='" + inst + "' WHERE id=1";
            System.Diagnostics.Debug.WriteLine(sql);
            run(sql);
        }

        public static string getInst()
        {
            string sql = "SELECT * FROM settings WHERE id=1";

            MySqlDataReader reader = run(sql);

            while (reader.Read())
            {
                return reader.GetString(2);
            }

            connection.Close();

            return "";
        }


        public static Queue SelectedQueue = new Queue();


    }
}
