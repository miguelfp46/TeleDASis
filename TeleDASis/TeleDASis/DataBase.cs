using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Data;
using System.Windows.Controls;
using System.Windows;

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

		public bool addUser(Usuario user)
		{
			try
			{
				string sql = "INSERT INTO usuarios (nombre, tarjetaSanitaria, movil, telefono, dni, tlfPersonaContacto, primerApellido, segundoApellido, direccion, puerta, poblacion) VALUES (@nombre, @tarjetaSanitaria, @movil, @telefono, @dni, @tlfPersonaContacto, @primerApellido, @segundoApellido, @direccion, @puerta, @poblacion)";
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@nombre", user.nombre);
				cmd.Parameters.AddWithValue("@tarjetaSanitaria", user.tarjetaSanitaria);
				cmd.Parameters.AddWithValue("@movil", user.tlfmovil);
				cmd.Parameters.AddWithValue("@telefono", user.telefono);
				cmd.Parameters.AddWithValue("@dni", user.dni);
				cmd.Parameters.AddWithValue("@tlfPersonaContacto", user.telefonofamiliar);
				cmd.Parameters.AddWithValue("@primerApellido", user.primerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", user.segundoApellido);
                cmd.Parameters.AddWithValue("@poblacion", user.poblacion);
                cmd.Parameters.AddWithValue("@direccion", user.direccion);
                cmd.Parameters.AddWithValue("@puerta", user.puerta);
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

        //Mostrar usuario por dni y recuperar todo el usuario para luego insertalo en historico <--- Este metodo lo llama la baja de usuarios.
        public Usuario showUser(String dni)
        {
            Usuario usuario = new Usuario();
            try
            {
                
                string sql = "SELECT * FROM usuarios WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@dni", dni);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    usuario.nombre = Convert.ToString(reader["nombre"]);
                    usuario.tarjetaSanitaria = Convert.ToString(reader["tarjetaSanitaria"]);
                    usuario.tlfmovil = Convert.ToInt32(reader["movil"]);
                    usuario.telefono = Convert.ToInt32(reader["telefono"]);
                    usuario.dni = Convert.ToString(reader["dni"]);
                    usuario.telefonofamiliar = Convert.ToInt32(reader["tlfPersonaContacto"]);
                    usuario.fechaAlta = Convert.ToString(reader["fechaAlta"]);
                    usuario.primerApellido = Convert.ToString(reader["primerApellido"]);
                    usuario.segundoApellido = Convert.ToString(reader["segundoApellido"]);
                    usuario.direccion = Convert.ToString(reader["direccion"]);
                    usuario.puerta = Convert.ToString(reader["puerta"]);
                    usuario.poblacion = Convert.ToString(reader["poblacion"]);
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

        public bool delUser(String dni)
        {
            try
            {
                string sql = "DELETE FROM usuarios WHERE dni=@dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                Console.WriteLine(cmd.CommandText);
                cmd.Parameters.AddWithValue("@dni", dni);
                
                if(cmd.ExecuteNonQuery() >= 1)
					return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return false;
        }

        public bool showUserTable(DataGrid dtGConsultas, Usuario user)
        {
            try
            {
                string sql = "SELECT * FROM usuarios WHERE nombre LIKE  @nombre AND primerApellido LIKE @primerApellido AND segundoApellido LIKE @segundoApellido AND tarjetasanitaria LIKE @tarjetasanitaria AND poblacion LIKE @poblacion AND direccion LIKE @direccion AND puerta LIKE @puerta";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nombre", "%" + user.nombre + "%");
                cmd.Parameters.AddWithValue("@primerApellido", "%" + user.primerApellido + "%");
                cmd.Parameters.AddWithValue("@segundoApellido", "%" + user.segundoApellido + "%");
                cmd.Parameters.AddWithValue("@tarjetaSanitaria", "%" + user.tarjetaSanitaria + "%");
                //cmd.Parameters.AddWithValue("@movil", "%" + user.tlfmovil + "%");
                //cmd.Parameters.AddWithValue("@telefono", "%" + user.telefono + "%");
                cmd.Parameters.AddWithValue("@dni", "%" + user.dni + "%");
                //cmd.Parameters.AddWithValue("@tlfPersonaContacto", "%" + user.telefonofamiliar + "%");
                cmd.Parameters.AddWithValue("@poblacion", "%" + user.poblacion + "%");
                cmd.Parameters.AddWithValue("@direccion", "%" + user.direccion + "%");
                cmd.Parameters.AddWithValue("@puerta", "%" + user.puerta + "%");

                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dtGConsultas.DataContext = dt;
                return true;
            }catch(Exception ex)
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
                string sql = "SELECT nombre, primerApellido, segundoApellido, tarjetaSanitaria, movil, telefono, tlfPersonaContacto ,poblacion,direccion,puerta FROM usuarios WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@dni", dni);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario.nombre = Convert.ToString(reader["nombre"]);
                    usuario.primerApellido = Convert.ToString(reader["primerApellido"]);
                    usuario.segundoApellido = Convert.ToString(reader["segundoApellido"]);
                    usuario.tarjetaSanitaria = Convert.ToString(reader["tarjetaSanitaria"]);
                    usuario.tlfmovil = Convert.ToInt32(reader["movil"]);
                    usuario.telefono = Convert.ToInt32(reader["telefono"]);
                    usuario.telefonofamiliar = Convert.ToInt32(reader["tlfPersonaContacto"]);
                    usuario.poblacion = Convert.ToString(reader["poblacion"]);
                    usuario.direccion = Convert.ToString(reader["direccion"]);
                    usuario.puerta = Convert.ToString(reader["puerta"]);
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
                string sql = "UPDATE usuarios SET nombre = @nombre, tarjetaSanitaria = @tarjetaSanitaria, movil = @movil, telefono = @telefono, tlfPersonaContacto = @tlfPersonaContacto, primerApellido = @primerApellido, segundoApellido = @segundoApellido ,poblacion = @poblacion , direccion = @direccion, puerta = @puerta  WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nombre", user.nombre);
                cmd.Parameters.AddWithValue("@tarjetaSanitaria", user.tarjetaSanitaria);
                cmd.Parameters.AddWithValue("@movil", user.tlfmovil);
                cmd.Parameters.AddWithValue("@telefono", user.telefono);
                cmd.Parameters.AddWithValue("@tlfPersonaContacto", user.telefonofamiliar);
                cmd.Parameters.AddWithValue("@primerApellido", user.primerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", user.segundoApellido);
                cmd.Parameters.AddWithValue("@poblacion", user.poblacion);
                cmd.Parameters.AddWithValue("@direccion", user.direccion);
                cmd.Parameters.AddWithValue("@puerta", user.puerta);
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

        public void close()
        {
            connection.Close();
        }

        public Usuario showUser2(int Tel)
        {
            Usuario usuario = new Usuario();
            try
            {

                string sql = "SELECT nombre, primerApellido, segundoApellido FROM USUARIOS WHERE tel = @telefono";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@telefono", Tel);

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
                return usuario;
            }
        }
        //inserta un usuario en historicobaja antes de que se elimine.
        public bool addDeletedUserToHistory(Usuario user)
        {
            try
            {
                string sql = "INSERT INTO historicoBaja (nombre, tarjetaSanitaria, movil, telefono, dni, tlfPersonaContacto, fechaAlta, primerApellido, segundoApellido, direccion, puerta, poblacion, motivoBaja) VALUES (@nombre, @tarjetaSanitaria, @movil, @telefono, @dni, @tlfPersonaContacto, @fechaAlta, @primerApellido, @segundoApellido, @direccion, @puerta, @poblacion, @motivoBaja)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nombre", user.nombre);
                cmd.Parameters.AddWithValue("@tarjetaSanitaria", user.tarjetaSanitaria);
                cmd.Parameters.AddWithValue("@movil", user.tlfmovil);
                cmd.Parameters.AddWithValue("@telefono", user.telefono);
                cmd.Parameters.AddWithValue("@dni", user.dni);
                cmd.Parameters.AddWithValue("@tlfPersonaContacto", user.telefonofamiliar);
                cmd.Parameters.AddWithValue("@fechaAlta", user.fechaAlta);
                cmd.Parameters.AddWithValue("@primerApellido", user.primerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", user.segundoApellido);
                cmd.Parameters.AddWithValue("@direccion", user.direccion);
                cmd.Parameters.AddWithValue("@puerta", user.puerta);
                cmd.Parameters.AddWithValue("@poblacion", user.poblacion);
                cmd.Parameters.AddWithValue("@motivoBaja", user.motivodeBaja);
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


        //TODO si existe el dni que salte un mensaje
        public bool ifExistDontCreateNewUser(string dni)
        {
            
                string sql = "SELECT COUNT(*) FROM usuarios WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@dni", dni);

            int cont = Convert.ToInt32(cmd.ExecuteScalar());

                if (int.Parse(cont.ToString()) == 0)
                {
                    return false;
                }
                else
                {
                   
                    return true;
                }

            }
            
        }
    }
