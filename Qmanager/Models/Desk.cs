using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Qntastic.Models
{
    class Desk : Model
    {
        public int id { get; set; }
        public string name { get; set; }
        public string personal { get; set; }
        public DateTime created_at { get; set; }

        public void save()
        {
            run("INSERT INTO desks (name, personal) VALUES ('" + this.name + "', '" + this.personal + "')");
        }


        public Desk(int id = 0)
        {
            this.tableName = "desks";
            if(id != 0)
            {
                string sql = "SELECT * from desks WHERE id="+id.ToString();
                MySqlDataReader reader = run(sql);

                while (reader.Read())
                {
                    this.id = id;
                    this.name = reader.GetString(1);
                    this.personal = reader.GetString(2);
                    this.created_at = DateTime.Parse(reader.GetString(3));
                }
            }
            this.connection.Close();
        }

    }

}
