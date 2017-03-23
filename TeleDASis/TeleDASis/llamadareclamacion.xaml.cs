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
        List<LlamadaServicio> serviciosList = new List<LlamadaServicio>();
        LlamadaServicio servicio;

        public llamadareclamacion()
        {
            InitializeComponent();

            //Fecha.SelectedDate = DateTime.Today;
            //Hora.SelectedDateFormat = DatePickerFormat.Short;
           
          
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTelefono.Text) || string.IsNullOrEmpty(tbSolucion.Text) || string.IsNullOrEmpty(tbMotivo.Text))
            {
                System.Windows.MessageBox.Show("Debes rellenar todos los campos","Campos vacíos",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                llamada.usuarios_idUsuario = usuario.id;
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
                        if (cbAmbulancia.IsChecked == true)
                        {
                            servicio = new LlamadaServicio(llamada.idLlamadas, 2);
                            databaseConnector.instance.insertarServiciosEnLlamadas(servicio);
                            serviciosList.Add(servicio);
                        }
                        if (cbBomberos.IsChecked == true)
                        {
                            servicio = new LlamadaServicio(llamada.idLlamadas, 3);
                            databaseConnector.instance.insertarServiciosEnLlamadas(servicio);
                            serviciosList.Add(servicio);

                        }
                        if (cbPolicia.IsChecked == true)
                        {
                            servicio = new LlamadaServicio(llamada.idLlamadas, 1);
                            databaseConnector.instance.insertarServiciosEnLlamadas(servicio);
                            serviciosList.Add(servicio);

                        }
                        if (cbAmbulancia.IsChecked == false && cbBomberos.IsChecked == false && cbPolicia.IsChecked == false)
                        {
                            servicio = new LlamadaServicio(llamada.idLlamadas, 4);
                            databaseConnector.instance.insertarServiciosEnLlamadas(servicio);
                            serviciosList.Add(servicio);
                        }
                        break;
                    case "Informativa":
                        llamada.tipoLlamada = 4;
                        break;
                    case "Reclamación/Sugerencia":
                        llamada.tipoLlamada = 5;
                        break;
                    case "Agenda":
                        llamada.tipoLlamada = 6;
                        llamada.fechayHora = DateTime.Parse(dpDate.Text);
                        break;
                    case "Llamada saliente":
                        llamada.tipoLlamada = 1;
                        break;
                }
                //llamada.telefonoUsuario = usuario.telefono;
                llamada.descripcion = tbMotivo.Text;
                llamada.solucion = tbSolucion.Text;
                llamada.telefonoUsuario = usuario.telefono;
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

                if (llamada.tipoLlamada == 6)
                {
                    //hay que mirar el id de llamadas haber como lo ponemos.
                    llamada.idLlamadas = 1;
                    databaseConnector.instance.siEsLlamadaAgendaInsertaFechaEnAgenda(llamada);
                }
            }
        }

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
            usuario.telefono = tbTelefono.Text;
            databaseConnector.instance.showPhoneNumber(dtgConsultas, usuario);

        }
    }
}
