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
        protected string serverName = "10.0.0.7";
        protected string serverUser = "admin";
        protected string database = "test";
        protected string password = "admintest";

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


        public IList<User> getUsers()
        {
            // TODO
            return null;
        }

        public bool addUser(string dni, string nombre, string apellidos, string fechaDeAlta , int telefono, int movil, int telefonoFamiliar)
        {
            try
            {
                string sql = "INSERT INTO usuarios (dni, nombre, apellidos, fechaDeAlta, telefono, movil, telefonoFamiliar) VALUES (@dni, @nombre, @apellido, @fechaDeAlta, @telefono, @movil, @telefonoFamiliar)";
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

        public User checkUser(string username, string password)
        {
            // If user exists returns user from database
            // TODO
            string sql = "SELECT * from usuarios WHERE dni = @dni";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@dni", username);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                User dataUser = new User((string)rdr["dni"]);
                dataUser.hashPass = (string)rdr["pass"];
                rdr.Close();
                return dataUser.checkPassword(password) ? dataUser : null;
            }
            rdr.Close();
            return null;
        }

        public void close()
        {
            connection.Close();
        }

        // INTERNAL METHODS
        protected User getUser(string username)
        {
            // If user exists returns user from database
            // TODO
            return null;
        }
    }

    public class User
    {
        String _name;
        String _pass = null;    // MD5 password

        // CONSTRUCTOR
        public User(string name, string pass)
        {
            _name = name;
            this.pass = pass;
        }

        public User(string name)
        {
            _name = name;
        }

        // GETTERS & SETTERS
        public string dni
        {
            get { return _name; }
        }
        public string pass
        {
            get { return _pass; }
            set { _pass = doHash(value); }
        }
        public string hashPass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        // PUBLIC METHODS
        public bool save()
        {
            return databaseConnector.instance.addUser(this);
        }

        public bool checkPassword(string plainPass)
        {
            return doHash(plainPass) == _pass;
        }

        // PRIVATE METHODS
        protected string doHash(String str)
        {
            MD5 hasher = MD5.Create();
            // Do Hash
            byte[] hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(str));
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}