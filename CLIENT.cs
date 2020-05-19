using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace KP_School
{
    class CLIENT
    {
        Connect k = new Connect();
        public bool insertClient(String name,String lname,String id,String kana,String tel,String email)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO `clients`(`name_`, `l_name`, `id_`, `ka_na`, `tel_`, `e_mail`) VALUES (@na,@lna,@idd,@kn,@te,@em)";
            command.CommandText = insertQuery;
            command.Connection = k.getConnection();

            //@na,@lna,@idd,@kn,@te,@em
            command.Parameters.Add("@na" ,MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@lna" ,MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@idd" ,MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@kn" ,MySqlDbType.VarChar).Value = kana;
            command.Parameters.Add("@te" ,MySqlDbType.VarChar).Value =tel;
            command.Parameters.Add("@em" ,MySqlDbType.VarChar).Value = email;

            k.openConnection();

            if(command.ExecuteNonQuery()==1)

            {
                k.closeConnection();
                return true; 
            }
            else
            {
                k.closeConnection();
                return false;
            }
            
        }
        public DataTable getClients()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `clients`",k.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;

        }
        public bool editClient(int idd,String name, String lname, String id, String kana, String tel, String email)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE `clients` SET `name_`=@na,`l_name`=@lna,`id_`=@id,`ka_na`=@kn,`tel_`=@te,`e_mail`=@em WHERE `id`=@cid";
            command.CommandText = editQuery;
            command.Connection = k.getConnection();

            //@cid,@na,@lna,@idd,@kn,@te,@em
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = idd;
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@lna", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@kn", MySqlDbType.VarChar).Value = kana;
            command.Parameters.Add("@te", MySqlDbType.VarChar).Value = tel;
            command.Parameters.Add("@em", MySqlDbType.VarChar).Value = email;

            k.openConnection();

            if (command.ExecuteNonQuery() == 1)

            {
                k.closeConnection();
                return true;
            }
            else
            {
                k.closeConnection();
                return false;
            }
        }
        public bool removeClient(String id)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = "DELETE FROM `clients` WHERE `id`=@cid";
            command.CommandText = removeQuery;
            command.Connection = k.getConnection();

            //@na
            command.Parameters.Add("@cid", MySqlDbType.VarChar).Value = id;

            k.openConnection();

            if (command.ExecuteNonQuery() == 1)

            {
                k.closeConnection();
                return true;
            }
            else
            {
                k.closeConnection();
                return false;
            }
        }
    }
}
