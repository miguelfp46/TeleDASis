using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TeleDASis
{
    /// <summary>
    /// Interaction logic for Consultas_Empleado.xaml
    /// </summary>
    public partial class Consultas_Empleado : Window
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="user">Valor que utilizaremos comom enlace al campo de empleados de la base de datos</param>
        Empleados user = new Empleados();

        System.Windows.Controls.DataGrid dataGridTable;

        public Consultas_Empleado()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Este metodo cierra la ventana
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtGConsultas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// Busca al empleado y te lo muesta si en DNI es correcto
        /// </summary>
        /// <param name="nombre">Valor que le asignamos para obtener el nombre del empleado</param>
        /// <param name="primerApellido">Valor que le asignamos para obtener el primer apellido del empleado</param>
        /// <param name="segundoApellido">Valor que le asignamos para obtener el segundo apellido del empleado</param>
        /// <param name="tlfmovil">Valor que le asignamos para obtener el movil del empleado</param>
        /// <param name="telefono">Valor que le asignamos para obtener el telefono del empleado</param>
        /// <param name="dni">Valor que le asignamos para obtener el dni del empleado</param>
        /// <param name="password">Valor que le asignamos para obtener el password del empleado</param>
        /// <param name="nombreUsuario">Valor que le asignamos para obtener el nombre de usuario del empleado</param>

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            user.nombre = txtNombre.Text;
            user.primerApellido = txtApellido1.Text;
            user.segundoApellido = txtApellido2.Text;         
            user.tlfmovil = Convert.ToInt32(txtMovil.Text);
            user.telefono = Convert.ToInt32(txtTelefono.Text);     
            user.dni = txtDni.Text;
            user.password = txtPasswd.Password;
            user.nombreUsuario = txtUser.Text;
            
            databaseConnector.instance.showEmpTable(dataGridTable, user);

        }

        /// <summary>
        /// Este metodo restringe que tipo de caracteres puedes escribir, en este caso solo puedes escribir letas
        /// </summary>
        /// <param name="ascci">Valor que le asignamos para obtener un int</param>
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
