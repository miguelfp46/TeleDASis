using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TeleDASis
{
    /// <summary>
    /// Interaction logic for ConsultasUsuarios.xaml
    /// </summary>
    public partial class ConsultasUsuarios : Window
    {
        Usuario user = new Usuario();
        System.Windows.Controls.DataGrid dataGridTable;
        public ConsultasUsuarios()
        {
            InitializeComponent();
            loadDataTable();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtGConsultas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = new Usuario();
            user.nombre = txtNombre.Text;
            user.primerApellido = txtApellido1.Text;
            user.segundoApellido = txtApellido2.Text;
            user.tarjetaSanitaria = txtTarjetaSanitaria.Text;
            //user.tlfmovil = Convert.ToInt32(txtMovil.Text);
            //user.telefono = Convert.ToInt32(txtTelefono.Text);
            //user.telefonofamiliar = Convert.ToInt32(txtTelFamiliar.Text);
            user.dni = txtDni.Text;
            user.poblacion = txtPoblacion.Text;
            user.direccion = txtDir.Text;
            user.puerta = txtPur.Text;
           

            databaseConnector.instance.showUserTable(dataGridTable,user);
        }  
        public void loadDataTable()
        {
            dataGridTable = dtGConsultas;
            
            //databaseConnector.instance.showUserTable();
        }
        public void SoloLetras(TextCompositionEventArgs e)
        {
            //se convierte a Ascci del la tecla presionada 
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            //verificamos que se encuentre en ese rango que son entre el a y el z
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
                e.Handled = false;
            else e.Handled = true;
        }
        private void Letras(object sender, TextCompositionEventArgs e)
        {
            SoloLetras(e);
        }
    }
}
