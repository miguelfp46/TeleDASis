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
    class TestDatabase
    {
        // Singletone
        protected static TestDatabase _instance = null;

        public static TestDatabase instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TestDatabase();
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

        protected TestDatabase()
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

        public bool addUser(User newUser)
        {
            try
            {
                string sql = "iNSERT INTO user (name, pass) VALUES (@nombre, @pass)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nombre", newUser.name);
                cmd.Parameters.AddWithValue("@pass", newUser.pass);
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
            string sql = "SELECT * from user WHERE name = @name";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@name", username);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                User dataUser = new User((string)rdr["name"]);
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
        public string name
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
            return TestDatabase.instance.addUser(this);
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