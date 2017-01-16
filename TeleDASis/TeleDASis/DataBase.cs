using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace TeleDASis
{
    class databaseConnector
    {
        // Singletone
        protected static databaseConnector _instance = null;

        public static databaseConnector instance
        {
            get
            {
                if (_instance == null)
                    _instance = new databaseConnector();
                return _instance;
            }
        }

        // ATTRIBUTES
        protected string connStr;
        protected MySqlConnection connection = null;
        protected string serverName = "127.0.0.1";
        protected string serverUser = "root";
        protected string database = "mydb";
        protected string password = "olakase";

        protected uint serverPort = 3306;

        protected databaseConnector()
        {
            // Create connection to MySql database
            connStr = "server=" + serverName + "; user=" + serverUser + ";database=" + database + ";port=" + serverPort + ";password=" + password + ";";
            connection = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();
                // Perform database operations
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Done.");
        }


 

        public bool addUser(string dni, string nombre, string apellidos, string fechaDeAlta, int telefono, int movil, int telefonoFamiliar)
        {
            try
            {
                string sql = "INSERT INTO usuarios (dni, nombre, apellidos, fechaDeAlta, telefono, movil, telefonoFamiliar) VALUES (@dni, @nombre, @apellidos, @fechaDeAlta, @telefono, @movil, @telefonoFamiliar)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellidos", apellidos);
                cmd.Parameters.AddWithValue("@fechaDeAlta", fechaDeAlta);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@movil", movil);
                cmd.Parameters.AddWithValue("@telefonoFamiliar", telefonoFamiliar);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        //public User checkUser(string username, string password)
        //{
        //    // If user exists returns user from database
        //    // TODO
        //    string sql = "SELECT * from usuarios WHERE dni = @dni";
        //    MySqlCommand cmd = new MySqlCommand(sql, connection);
        //    cmd.Parameters.AddWithValue("@dni", username);
        //    MySqlDataReader rdr = cmd.ExecuteReader();
        //    if (rdr.Read())
        //    {
        //        User dataUser = new User((string)rdr["dni"]);
        //        dataUser.hashPass = (string)rdr["pass"];
        //        rdr.Close();
        //        return dataUser.checkPassword(password) ? dataUser : null;
        //    }
        //    rdr.Close();
        //    return null;
        //}

        public void close()
        {
            connection.Close();
        }

    }

   
}