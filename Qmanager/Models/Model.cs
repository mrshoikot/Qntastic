using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Qntastic.Models
{
    class Model
    {
        string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=qntastic;SslMode=none";
        public MySqlConnection connection;
        public string tableName;

        public Model()
        {
            connection = new MySqlConnection(this.connString);
        }

        public MySqlDataReader run(string sql)
        {
            connection.Close();
            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public int count(string sqlpart)
        {
            connection.Close();
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) "+sqlpart, connection);
            Debug.WriteLine("SELECT COUNT(*) " + sqlpart);
            return int.Parse(command.ExecuteScalar().ToString());
        }

        public void delete(int id)
        {
            run("DELETE FROM " + this.tableName + " WHERE id=" + id);
        }


        ~Model()
        {
            connection.Close();
        }
    }
}
