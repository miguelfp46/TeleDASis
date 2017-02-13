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
        

        public bool addUser(string nombre, string tarjetaSanitaria, string movil, string telefono, string dni, string tlfPersonaContacto,
            string fechaAlta, string primerApellido, string segundoApellido, int vivienda_idVivienda)
        {
            try
            {
                string sql = "INSERT INTO USUARIOS (nombre, tarjetaSanitaria, movil, telefono, dni, tlfPersonaContacto, fechaAlta, primerApellido, segundoApellido, vivienda_idVivienda) VALUES (@nombre, @tarjetaSanitaria, @movil, @telefono, @dni, @tlfPersonaContacto, @fechaAlta, @primerApellido, @segundoApellido, @vivienda_idVivienda)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@tarjetaSanitaria", tarjetaSanitaria);
                cmd.Parameters.AddWithValue("@movil", movil);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@tlfPersonaContacto", tlfPersonaContacto);
                cmd.Parameters.AddWithValue("@fechaAlta", fechaAlta);
                cmd.Parameters.AddWithValue("@primerApellido", primerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", segundoApellido);
                cmd.Parameters.AddWithValue("@vivienda_idVivienda", vivienda_idVivienda);
                //cmd.Parameters.AddWithValue("@codigoIdentificacion", codigoIdentificacion);
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

        //Mostrar usuario por dni <--- Este metodo lo llama la baja de usuarios.
        public Usuario showUser(String dni)
        {
            Usuario usuario = new Usuario();
            try
            {
                
                string sql = "SELECT nombre, primerApellido, segundoApellido FROM USUARIOS WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@dni", dni);

                MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                {

                    usuario.nombre = Convert.ToString(reader["nombre"]);
                    usuario.primerApellido = Convert.ToString(reader["primerApellido"]);
                    usuario.segundoApellido = Convert.ToString(reader["segundoApellido"]);
                }

                reader.Close();
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                usuario.nombre = null;
                return null;
            }
        }

        public bool delUser(String dni)
        {
            try
            {

                string sql = "DELETE FROM USUARIOS WHERE dni=@dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                Console.WriteLine(cmd.CommandText);
                cmd.Parameters.AddWithValue("@dni", dni);
                

                if (cmd.ExecuteNonQuery()>=1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
          
        }
        //metrodo para mostrar todos los datos de un usuario
        public Usuario showUserAll(String dni)
        {
            Usuario usuario = new Usuario();
            try
            {

                string sql = "SELECT nombre, primerApellido, segundoApellido, tarjetaSanitaria, movil, telefono, tlfPersonaContacto, vivienda_idVivienda FROM USUARIOS WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@dni", dni);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    usuario.nombre = Convert.ToString(reader["nombre"]);
                    usuario.primerApellido = Convert.ToString(reader["primerApellido"]);
                    usuario.segundoApellido = Convert.ToString(reader["segundoApellido"]);
                    usuario.tarjetasanitaria = Convert.ToString(reader["tarjetaSanitaria"]);
                    usuario.tlfmovil = Convert.ToInt32(reader["movil"]);
                    usuario.telefono = Convert.ToInt32(reader["telefono"]);
                    usuario.telefonofamiliar = Convert.ToInt32(reader["tlfPersonaContacto"]);
                    usuario.vivienda = Convert.ToString(reader["vivienda_idVivienda"]);
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

        //MODIFICA EL USUARIO CON TODOS LOS DATOS, SE TIENE QUE TERMINAR
        public bool updateUser(Usuario user)
        {
            try
            {
                string sql = "UPDATE USUARIOS SET nombre = @nombre, tarjetaSanitaria = @tarjetaSanitaria, movil = @movil, telefono = @telefono, tlfPersonaContacto = @tlfPersonaContacto, primerApellido = @primerApellido, segundoApellido = @segundoApellido, vivienda_idVivienda = @vivienda_idVivienda WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nombre", user.nombre);
                cmd.Parameters.AddWithValue("@tarjetaSanitaria", user.tarjetasanitaria);
                cmd.Parameters.AddWithValue("@movil", user.tlfmovil);
                cmd.Parameters.AddWithValue("@telefono", user.telefono);
                cmd.Parameters.AddWithValue("@tlfPersonaContacto", user.telefonofamiliar);
                cmd.Parameters.AddWithValue("@primerApellido", user.primerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", user.segundoApellido);
                cmd.Parameters.AddWithValue("@vivienda_idVivienda", user.vivienda);
                cmd.Parameters.AddWithValue("@dni", user.dni);
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