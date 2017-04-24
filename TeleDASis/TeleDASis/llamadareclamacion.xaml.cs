using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TeleDASis
{
    /// <summary>
    /// Interaction logic for llamadareclamacion.xaml
    /// </summary>
    public partial class llamadareclamacion : Window
    {
        Llamadas llamada = new Llamadas();
        Usuario usuario = new Usuario();
        Agenda agenda = new Agenda();
        List<LlamadaServicio> serviciosList = new List<LlamadaServicio>();
        LlamadaServicio servicio;

        public llamadareclamacion()
        {
            InitializeComponent();

            //Fecha.SelectedDate = DateTime.Today;
            //Hora.SelectedDateFormat = DatePickerFormat.Short;   
        }

        /// <summary>
        /// Este metodo es donde guardaremos los datos
        /// </summary>
        /// <param name="idLlamada">Guardara la id de la llamada</param>
        /// <param name="telefono">Guardara el numero de telefono</param>
        /// <param name="nombre">Guardara el nombre</param>
        /// <param name="primerApellido">Guardara el primer apellido</param>
        /// <param name="segundoApellido">Guardara el segundo apellido</param>
        /// <param name="DNI">Guardara el DNI</param>
        /// <param name="motivo">Guardara el motivo, si es que lo hay</param>
        /// <param name="solucion">Guardara la solucion</param>
        public llamadareclamacion(int idLlamada, string telefono , string nombre, string primerApellido, string segundoApellido, string DNI, string motivo, string solucion)
        {
            InitializeComponent();
            this.llamada.idLlamadas = idLlamada;
            this.llamada.telefonoUsuario = telefono;
            this.usuario.dni = DNI;
            this.usuario.nombre = nombre;
            this.usuario.primerApellido = primerApellido;
            this.usuario.segundoApellido = segundoApellido;
            this.llamada.descripcion = motivo;
            this.llamada.solucion = solucion;
            tbTelefono.Text = llamada.telefonoUsuario;
            tbNombre.Text = usuario.nombre;
            tbDNI.Text = usuario.dni;
            
            tbPrimerApellido.Text = usuario.primerApellido;
            tbSegundoApellido.Text = usuario.segundoApellido;
            cbTipoLlamada.Text = "Llamada saliente";
            tbMotivo.Text = llamada.descripcion;
            tbSolucion.Text = llamada.solucion;
            usuario.telefono = llamada.telefonoUsuario;
            usuario = databaseConnector.instance.searchUserByPhone(usuario);
            usuario.telefono = llamada.telefonoUsuario;
 

        }

        /// <summary>
        /// Cierra la ventana
        /// </summary>
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Este metodo enviara a la base de datos que se han introducido
        /// </summary>
       
        private void btEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTelefono.Text) || string.IsNullOrEmpty(tbSolucion.Text) || string.IsNullOrEmpty(tbMotivo.Text))
            {
                System.Windows.MessageBox.Show("Debes rellenar todos los campos", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                
                llamada.usuarios_idUsuario = usuario.id;
                llamada.descripcion = tbMotivo.Text;
                llamada.solucion = tbSolucion.Text;
                llamada.telefonoUsuario = usuario.telefono;
                switch (cbTipoLlamada.Text)
                {
                    case "Emergencia nivel 1":
                        llamada.tipoLlamada = 1;
                        break;
                    case "Emergencia nivel 2":
                        llamada.tipoLlamada = 2;
                        break;
                    case "Emergencia nivel 3":
                        llamada.tipoLlamada = 3;
                        break;
                    case "Informativa":
                        llamada.tipoLlamada = 4;
                        break;
                    case "Reclamación/Sugerencia":
                        llamada.tipoLlamada = 5;
                        break;
                    case "Agenda":
                        llamada.tipoLlamada = 6;
                        
                        string horas = dpDate.Text + " " + hora.Text;
                        llamada.fechayHora = DateTime.Parse(horas);
                        break;
                    case "Llamada saliente":
                        llamada.tipoLlamada = 7;
                        break;
                }
                
                if (llamada.tipoLlamada == 7) {
                    
                    MessageBoxResult resultado = System.Windows.MessageBox.Show("¿Desear llamar a " + usuario.nombre + " " + usuario.primerApellido + "?", "Llamar a usuario",MessageBoxButton.YesNo,MessageBoxImage.Information);
                    if(resultado == MessageBoxResult.Yes)
                    {
                        databaseConnector.instance.insertCall(llamada);
                        
                        agenda.idLlamada = llamada.idLlamadas;
                        databaseConnector.instance.siEsLlamadaSalienteEliminaDeAgenda(agenda);
                        MessageBoxResult resultado2 = System.Windows.MessageBox.Show("Llamando...", "Llamar a usuario", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        
                        if(resultado2 == MessageBoxResult.OK)
                        {
                            this.Close();
                            formLlamadaAgenda agenda = new formLlamadaAgenda();
                            agenda.Show();
                        }
                    }          
                }
                else {
                    MessageBoxResult resultado = System.Windows.MessageBox.Show("Registrar llamada: " +
                        ":\nUsuario: " + usuario.nombre + " " + usuario.primerApellido + " " + usuario.segundoApellido + "\n"
                        + "Teléfono: " + usuario.telefono + "\n"
                        + "Tipo de llamada: " + cbTipoLlamada.Text + "\n"
                        + "Motivo de llamada: " + llamada.descripcion + "\n"
                        + "Solución: " + llamada.solucion, "Comprobar datos", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultado == MessageBoxResult.Yes)
                    {
                        databaseConnector.instance.insertCall(llamada);

                    }
                    llamada.idLlamadas = databaseConnector.instance.recuperaridLlamada(llamada);
                    //System.Windows.MessageBox.Show(Convert.ToString(llamada.idLlamadas));
                    if (cbAmbulancia.IsChecked == true)
                    {
                        databaseConnector.instance.insertarServiciosEnLlamadas(llamada, 2);
                    }
                    if (cbBomberos.IsChecked == true)
                    {
                        databaseConnector.instance.insertarServiciosEnLlamadas(llamada, 3);
                    }
                    if (cbPolicia.IsChecked == true)
                    {
                        databaseConnector.instance.insertarServiciosEnLlamadas(llamada, 1);
                    }
                    if (cbAmbulancia.IsChecked == false && cbBomberos.IsChecked == false && cbPolicia.IsChecked == false)
                    {
                        databaseConnector.instance.insertarServiciosEnLlamadas(llamada, 4);
                    }
                    if (llamada.tipoLlamada == 6)
                    {
                        //hay que mirar el id de llamadas haber como lo ponemos.
                        databaseConnector.instance.siEsLlamadaAgendaInsertaFechaEnAgenda(llamada);
                    }
                    this.Close();
                }
            } }


        /// <summary>
        /// Este metodo restringe que tipo de caracteres puedes escribir, en este caso solo puedes escribir numeros
        /// </summary>
        /// <param name="ascci">Valor que le asignamos para obtener un int</param>
        public void SoloNumeros(TextCompositionEventArgs e)
        {
            
            //se convierte a Ascci del la tecla presionada 
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            //verificamos que se encuentre en ese rango que son entre el 0 y el 9 
            if (ascci >= 48 && ascci <= 57)
                e.Handled = false;
            else e.Handled = true;
            //3q5zw46xerc7tvyuomi,p.`-
        }

        private void tbMovil_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloNumeros(e);
        }

        /// <summary>
        /// El Siguiente metodo muestra las opciones que habra en el combobox de la pagina.
        /// </summary>
        private void Handle()
        {
            switch (cbTipoLlamada.SelectedItem.ToString().Split(new string[] { ":" }, StringSplitOptions.None).Last())
            {
                case "Policia":
                    llamada.servicio = 1;
                    break;
                case "Ambulancia":
                    llamada.servicio = 2;
                    break;
                case "Bomberos":
                    llamada.servicio = 3;
                    break;
                default:
                    llamada.servicio = 4;
                    break;


            }
        }


        private void CMB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() => tcTipoLLamada.SelectedIndex = cbTipoLlamada.SelectedIndex));
            tcTipoLLamada.Visibility = Visibility.Visible;
        }

        private void tcTipoLLamada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// Busca al empleado y te lo muesta si en DNI es correcto
        /// </summary>
        /// <param name="nombre">Valor que le asignamos para obtener el nombre del usuario</param>
        /// <param name="primerApellido">Valor que le asignamos para obtener el primer apellido del usuario</param>
        /// <param name="segundoApellido">Valor que le asignamos para obtener el segundo apellido del usuario</param>
        /// <param name="telefonofamiliar">Valor que le asignamos para obtener el telefono familiar del usuario</param>
        /// <param name="tlfmovil">Valor que le asignamos para obtener el movil del usuario</param>
        /// <param name="telefono">Valor que le asignamos para obtener el telefono del usuario</param>
        /// <param name="dni">Valor que le asignamos para obtener el dni del usuario</param>
        /// 
        private void btBuscar_Click(object sender, RoutedEventArgs e)
        {
            //buscamos a un usuario por telefono y lo cargamos.
            usuario.telefono = tbTelefono.Text;
            usuario.tlfmovil = tbTelefono.Text;
            usuario.telefonofamiliar = tbTelefono.Text;
            usuario = databaseConnector.instance.searchUserByPhone(usuario);
            tbNombre.Text = usuario.nombre;
            tbPrimerApellido.Text = usuario.primerApellido;
            tbSegundoApellido.Text = usuario.segundoApellido;
            tbDNI.Text = usuario.dni;
            
            databaseConnector.instance.showPhoneNumber(dtgConsultas, usuario);

        }
    }
}
