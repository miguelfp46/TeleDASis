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
                    usuario.tlfmovil = Convert.ToString(reader["movil"]);
                    usuario.telefono = Convert.ToString(reader["telefono"]);
                    usuario.dni = Convert.ToString(reader["dni"]);
                    usuario.telefonofamiliar = Convert.ToString(reader["tlfPersonaContacto"]);
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

        public Empleados showEmp(String dni)
        {
            Empleados emp = new Empleados();
            try
            {

                string sql = "SELECT * FROM empleados WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@dni", dni);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    emp.nombre = Convert.ToString(reader["nombre"]);
                    emp.tlfmovil = Convert.ToInt32(reader["movil"]);
                    emp.dni = Convert.ToString(reader["dni"]);
                    emp.fechaAlta = Convert.ToString(reader["fechaAlta"]);
                    emp.primerApellido = Convert.ToString(reader["primerApellido"]);
                    emp.segundoApellido = Convert.ToString(reader["segundoApellido"]);
                    emp.nombreUsuario = Convert.ToString(reader["nombreUsuario"]);
                    emp.password = Convert.ToString(reader["password"]);
                  
                }

                reader.Close();
                return emp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                emp.nombre = null;
                return emp;
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

        public bool delEmp(String dni)
        {
            try
            {
                string sql = "DELETE FROM empleados WHERE dni=@dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                Console.WriteLine(cmd.CommandText);
                cmd.Parameters.AddWithValue("@dni", dni);

                if (cmd.ExecuteNonQuery() >= 1)
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
                string sql = "SELECT * FROM usuarios WHERE nombre LIKE  @nombre AND primerApellido LIKE @primerApellido AND segundoApellido LIKE @segundoApellido AND tarjetaSanitaria LIKE @tarjetaSanitaria AND movil LIKE @movil AND telefono LIKE @telefono AND tlfPersonaContacto  LIKE @tlfPersonaContacto  AND poblacion LIKE @poblacion AND direccion LIKE @direccion AND puerta LIKE @puerta";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nombre", "%" + user.nombre + "%");
                cmd.Parameters.AddWithValue("@primerApellido", "%" + user.primerApellido + "%");
                cmd.Parameters.AddWithValue("@segundoApellido", "%" + user.segundoApellido + "%");
                cmd.Parameters.AddWithValue("@tarjetaSanitaria", "%" + user.tarjetaSanitaria + "%");
                cmd.Parameters.AddWithValue("@movil", "%" + user.tlfmovil + "%");
                cmd.Parameters.AddWithValue("@telefono", "%" + user.telefono + "%");
                cmd.Parameters.AddWithValue("@dni", "%" + user.dni + "%");
                cmd.Parameters.AddWithValue("@tlfPersonaContacto", "%" + user.telefonofamiliar + "%");
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

        public bool showEmpTable(DataGrid dtGConsultas, Empleados user)
        {
            try
            {
                string sql = "SELECT * FROM empleados WHERE nombre LIKE  @nombre AND primerApellido LIKE @primerApellido AND segundoApellido LIKE @segundoApellido AND movil LIKE @movil AND telefono LIKE @telefono AND password  LIKE @password  AND user LIKE @nombre Usuario";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nombre", "%" + user.nombre + "%");
                cmd.Parameters.AddWithValue("@primerApellido", "%" + user.primerApellido + "%");
                cmd.Parameters.AddWithValue("@segundoApellido", "%" + user.segundoApellido + "%");
                cmd.Parameters.AddWithValue("@movil", "%" + user.tlfmovil + "%");
                cmd.Parameters.AddWithValue("@telefono", "%" + user.telefono + "%");
                cmd.Parameters.AddWithValue("@dni", "%" + user.dni + "%");
                cmd.Parameters.AddWithValue("@password", "%" + user.password + "%");
                cmd.Parameters.AddWithValue("@user", "%" + user.nombreUsuario + "%");
         

                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dtGConsultas.DataContext = dt;
                return true;
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
                    usuario.tlfmovil = Convert.ToString(reader["movil"]);
                    usuario.telefono = Convert.ToString(reader["telefono"]);
                    usuario.telefonofamiliar = Convert.ToString(reader["tlfPersonaContacto"]);
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

        public Empleados showEmpAll(String dni)
        {
            Empleados usuario = new Empleados();
            try
            {
                string sql = "SELECT nombre, primerApellido, segundoApellido, movil, telefono, password, nombreUsuario FROM empleaods WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@dni", dni);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario.nombre = Convert.ToString(reader["nombre"]);
                    usuario.primerApellido = Convert.ToString(reader["primerApellido"]);
                    usuario.segundoApellido = Convert.ToString(reader["segundoApellido"]);
                    
                    usuario.tlfmovil = Convert.ToInt32(reader["movil"]);
                    usuario.telefono = Convert.ToInt32(reader["telefono"]);
                    usuario.password = Convert.ToString(reader["password"]);
                    usuario.nombreUsuario = Convert.ToString(reader["nombreUsuario"]);
                  
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

        public bool updateEmp(Empleados user)
        {
            try
            {
                string sql = "UPDATE empelados SET nombre = @nombre, movil = @movil, telefono = @telefono, primerApellido = @primerApellido, segundoApellido = @segundoApellido ,password = @passwd , nombreUsuario = @usuario  WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nombre", user.nombre);            
                cmd.Parameters.AddWithValue("@movil", user.tlfmovil);
                cmd.Parameters.AddWithValue("@telefono", user.telefono);
                cmd.Parameters.AddWithValue("@primerApellido", user.primerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", user.segundoApellido);
                cmd.Parameters.AddWithValue("@passwd", user.password);
                cmd.Parameters.AddWithValue("@usuariio", user.nombreUsuario);         
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

        public Usuario searchUserByPhone(Usuario user)
        {
            Usuario usuario = new Usuario();
            try
            {

                string sql = "SELECT nombre, primerApellido, segundoApellido, dni, idUsuario FROM usuarios WHERE telefono = @telefono OR movil = @movil OR tlfPersonaContacto = @tlfPersonaContacto";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@telefono", user.telefono);
                cmd.Parameters.AddWithValue("@movil", user.tlfmovil);
                cmd.Parameters.AddWithValue("@tlfPersonaContacto", user.telefonofamiliar);
              
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    usuario.nombre = Convert.ToString(reader["nombre"]);
                    usuario.primerApellido = Convert.ToString(reader["primerApellido"]);
                    usuario.segundoApellido = Convert.ToString(reader["segundoApellido"]);
                    usuario.dni = Convert.ToString(reader["dni"]);
                    usuario.id = Convert.ToInt32(reader["idUsuario"]);               
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

        //tabla de historicobajas
        public bool showBajas(DataGrid dtGTabla,Usuario user)
        {
            try
            {
                string sql = "SELECT * FROM historicoBaja ";
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
                cmd.Parameters.AddWithValue("@fechaBaja", user.fechaBaja);
                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dtGTabla.DataContext = dt;

                return true;
            }catch(Exception ex)
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

        public bool showAgendaTable(DataGrid dtGAgenda,Agenda ag)
        {
            try
            {
                string sql = "SELECT agenda.idLlamadas, usuarios.dni, usuarios.nombre, usuarios.primerApellido, usuarios.segundoApellido,usuarios.telefono, agenda.fechaAgenda, llamadas.descripcion, llamadas.solucion FROM usuarios,agenda,llamadas WHERE agenda.idLlamadas = llamadas.idLlamadas AND llamadas.usuarios_idUsuario = usuarios.idUsuario AND llamadas.tipoLlamada = 6";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
               
                
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dtGAgenda.DataContext = dt;
                    return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool showLlamadas(DataGrid dataGrid, Llamadas lla)
        {
            try
            {
                string sql = "SELECT usuarios.nombre, usuarios.primerApellido, usuarios.segundoApellido, llamadas.fechaYHora, llamadas.descripcion, llamadas.solucion FROM usuarios, llamadas WHERE usuarios.idUsuario = llamadas.usuarios_idUsuario";
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGrid.DataContext = dt;
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public DataGrid showPhoneNumber(DataGrid dataGrid, Usuario user)
        {
            try
            {
                string sql = "SELECT tlfPersonaContacto AS 'Telefono familiar' FROM usuarios WHERE telefono = @telefono";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@telefono", user.telefono);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGrid.DataContext = dt;
                return dataGrid;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return dataGrid;
            }
        }
        public bool insertCall(Llamadas llamada)
        {
            try
            {
                string sql = "INSERT INTO llamadas (tipoLlamada, usuarios_idUsuario, telefonoUsuario, descripcion, solucion) VALUES (@tipoLlamada, @usuarios_idUsuario, @telefonoUsuario, @descripcion, @solucion)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@tipoLlamada", llamada.tipoLlamada);
                cmd.Parameters.AddWithValue("@usuarios_idUsuario", llamada.usuarios_idUsuario);
                cmd.Parameters.AddWithValue("@telefonoUsuario", llamada.telefonoUsuario);
                cmd.Parameters.AddWithValue("@descripcion", llamada.descripcion);
                cmd.Parameters.AddWithValue("@solucion", llamada.solucion);
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
        public bool siEsLlamadaAgendaInsertaFechaEnAgenda(Llamadas llamada)
        {
            try
            {
                string sql = "INSERT INTO agenda (idLlamadas, idUsuarios, fechaAgenda) VALUES (@idLlamadas, @idUsuarios, @fechaAgenda)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@idLlamadas", llamada.idLlamadas);
                cmd.Parameters.AddWithValue("@idUsuarios", llamada.usuarios_idUsuario);
                cmd.Parameters.AddWithValue("@fechaAgenda", llamada.fechayHora);
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
        //eliminar empleado por acabar
        public bool addEmple(Empleados emple)
        {
            try
            {
                string sql = "INSERT INTO empleados (nombre, movil, dni, primerApellido, segundoApellido, nombreUsuario, password) VALUES (@nombre, @movil, @dni, @primerApellido, @segundoApellido, @nombreUsuario, @passwd)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nombre", emple.nombre);
                cmd.Parameters.AddWithValue("@movil", emple.tlfmovil);
                cmd.Parameters.AddWithValue("@dni", emple.dni);
                cmd.Parameters.AddWithValue("@primerApellido", emple.primerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", emple.segundoApellido);
                cmd.Parameters.AddWithValue("@nombreUsuario", emple.nombreUsuario);
                cmd.Parameters.AddWithValue("@passwd", emple.password);
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

        public bool addDeletedEmpToHistory(Empleados emp)
        {
            try
            {
                string sql = "INSERT INTO historicoBaja (nombre, movil, dni, fechaAlta, primerApellido, segundoApellido, nombreUsuario, passwd) VALUES (@nombre, @movil, @dni, @fechaAlta @primerApellido, @segundoApellido, @nombreUsuario, @passwd)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nombre", emp.nombre);
                cmd.Parameters.AddWithValue("@movil", emp.tlfmovil);
                cmd.Parameters.AddWithValue("@dni", emp.dni);
                cmd.Parameters.AddWithValue("@primerApellido", emp.primerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", emp.segundoApellido);
                cmd.Parameters.AddWithValue("@nombreUsuario", emp.nombreUsuario);
                cmd.Parameters.AddWithValue("@passwd", emp.password);

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
        public bool ifExistDontCreateNewEmpleado(string dni)
        {

            string sql = "SELECT COUNT(*) FROM empleados WHERE dni = @dni";
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

        public bool insertarServiciosEnLlamadas(Llamadas llamada, int servicio)
        {
            try
            {
                string sql = "INSERT INTO llamadaServicios VALUES(@idLlamada,@idServicios)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@idLlamada", llamada.idLlamadas);
                cmd.Parameters.AddWithValue("@idServicios", servicio);
               

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

        public int recuperaridLlamada(Llamadas llamada)
        {
            
            try
            {

                string sql = "SELECT * FROM llamadas WHERE telefonoUsuario = @telefono AND descripcion = @descripcion AND solucion = @solucion AND usuarios_idUsuario = @usuarios_idUsuario";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@telefono", llamada.telefonoUsuario);
                cmd.Parameters.AddWithValue("@descripcion", llamada.descripcion);
                cmd.Parameters.AddWithValue("@solucion", llamada.solucion);
                cmd.Parameters.AddWithValue("@usuarios_idUsuario", llamada.usuarios_idUsuario);


                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    llamada.idLlamadas = Convert.ToInt32(reader["idLlamadas"]);
                }

                reader.Close();
                return llamada.idLlamadas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return llamada.idLlamadas;
            }
        }
        public bool siEsLlamadaSalienteAñadeEnLlamadas(Llamadas llamada)
        {
            try
            {
                string sql = "INSERT INTO llamadas (tipoLlamada, usuarios_idUsuario, telefonoUsuario, descripcion, solucion) VALUES (@tipoLlamada, @usuarios_idUsuario, @telefonoUsuario, @descripcion, @solucion)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@tipoLlamada", llamada.tipoLlamada);
                cmd.Parameters.AddWithValue("@usuarios_idUsuario", llamada.usuarios_idUsuario);
                cmd.Parameters.AddWithValue("@telefonoUsuario", llamada.telefonoUsuario);
                cmd.Parameters.AddWithValue("@descripcion", llamada.descripcion);
                cmd.Parameters.AddWithValue("@solucion", llamada.solucion);

                if (cmd.ExecuteNonQuery() >= 1)
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return false;
        }
        public bool siEsLlamadaSalienteEliminaDeAgenda(Llamadas llamada)
        {
            try
            {
                string sql = "DELETE FROM agenda WHERE idLlamadas = @idLlamadas ";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                Console.WriteLine(cmd.CommandText);
                cmd.Parameters.AddWithValue("@id", llamada.idLlamadas);

                if (cmd.ExecuteNonQuery() >= 1)
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return false;
        }



        //public bool insertarServiciosDeLlamada(List<LlamadaServicio> llamada)
        //{

        //    try
        //    {
        //        string sql = "INSERT INTO llamadaServicios VALUES(@idLlamada,@idServicios)";
        //        MySqlCommand cmd = new MySqlCommand(sql, connection);

        //        foreach (LlamadaServicio servicios in llamada)
        //        {
        //            cmd.Parameters.AddWithValue("@idLlamada", llamada);
        //            cmd.Parameters.AddWithValue("@idServicios", llamada);
        //            cmd.ExecuteNonQuery();
        //        }
        //        Console.WriteLine(cmd.CommandText);
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return false;
        //    }
        //}
    }
}
