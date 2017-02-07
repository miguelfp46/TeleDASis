﻿using System;
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
        protected string serverName = "172.16.10.20";
        protected string serverUser = "root";
        protected string database = "m18";
        protected string password = "admin2";

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
        

        public bool addUser(String nombre,String apellido,String apellido2,String dni,String nTelefono,
                            String nTelefonoFamiliar, String movil,String targetaSanitaria,
                            String fechaDeAlta, int vivienda)
        {
            try
            {
                string sql = "INSERT INTO usuarios (nombre, apellido, apellido2, dni, nTelefono, nTelefonoFamiliar, movil, targetaSanitaria, fechaDeAlta, vivienda) VALUES (@nombre, @apellido, @apellido2, @dni, @nTelefono, @nTelefonoFamiliar, @movil, @targetaSanitaria, @fechaDeAlta, @vivienda)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@apellido2", apellido2);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@nTelefono", nTelefono);
                cmd.Parameters.AddWithValue("@nTelefonoFamiliar", nTelefonoFamiliar);
                cmd.Parameters.AddWithValue("@movil", movil);
                //cmd.Parameters.AddWithValue("@codigoIdentificacion", codigoIdentificacion);
                cmd.Parameters.AddWithValue("@targetaSanitaria", targetaSanitaria);
                cmd.Parameters.AddWithValue("@fechaDeAlta", fechaDeAlta);
                cmd.Parameters.AddWithValue("@vivienda", vivienda);
                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
                

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        
        public Usuario showUser(String dni)
        {
            Usuario usuario = new Usuario();
            try
            {
                
                string sql = "SELECT nombre, apellido, apellido2 FROM usuarios WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@dni", dni);

                MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                {

                    usuario.nombre = Convert.ToString(reader["nombre"]);
                    usuario.primerApellido = Convert.ToString(reader["apellido"]);
                    usuario.segundoApellido = Convert.ToString(reader["apellido2"]);
                }

                reader.Close();
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                usuario.nombre = null;
                return usuario;
            }
        }

        public bool delUser(String nombre, String dni)
        {
            try
            {

                string sql = "DELETE FROM usuarios WHERE dni=@dni and nombre = @nombre";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                Console.WriteLine(cmd.CommandText);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@nombre", nombre);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return true;
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