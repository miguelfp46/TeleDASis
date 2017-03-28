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
    /// Interaction logic for MainWindows.xaml
    /// </summary>
    public partial class MainWindows : Window
    {
        public MainWindows()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Este metodo te envian al menu de llamadas
        /// </summary>
        /// <param name="info">Valor que le asignamos la ventana de llamadas</param>
        
        private void btLlamadas_Click(object sender, RoutedEventArgs e)
        {
            llamadareclamacion info = new llamadareclamacion();

            info.Show();
        }

        /// <summary>
        /// Este metodo te envian al menu de Agenda
        /// </summary>
        /// <param name="info">Valor que le asignamos la ventana de Agenda</param>

        private void btn_Agenda_Click(object sender, RoutedEventArgs e)
        {
            formLlamadaAgenda info = new formLlamadaAgenda();

            info.Show();
        }

        /// <summary>
        /// Este metodo te envian al menu de modificar de Usuarios
        /// </summary>
        /// <param name="modificar">Valor que le asignamos la ventana de modificar</param>

        private void botonModificaciones_Click(object sender, RoutedEventArgs e)
        {
            ModificacionesUsuarios modificar = new ModificacionesUsuarios();
            modificar.Show();

        }

        /// <summary>
        /// Este metodo te envian al menu de modificar de Empleados
        /// </summary>
        /// <param name="modificar">Valor que le asignamos la ventana de modificar</param>

        private void botonModificaciones_Emp(object sender, RoutedEventArgs e)
        {
            Modificación_Empleados modificar = new Modificación_Empleados();
            modificar.Show();

        }

        /// <summary>
        /// Este metodo te envian al menu de alta de Usuarios
        /// </summary>
        /// <param name="info">Valor que le asignamos la ventana de alta</param>

        private void botonAlta_Click(object sender, RoutedEventArgs e)
        {
            Alta info = new Alta();

            info.Show();

        }

        /// <summary>
        /// Este metodo te envian al menu de alta de Empleados
        /// </summary>
        /// <param name="info">Valor que le asignamos la ventana de alta</param>
        /// 
        private void botonAlta_Emp(object sender, RoutedEventArgs e)
        {
            Window3 info = new Window3();

            info.Show();

        }

        /// <summary>
        /// Este metodo te envian al menu de Baja de Usuarios
        /// </summary>
        /// <param name="info">Valor que le asignamos la ventana de baja</param>

        private void botonBaja_Click(object sender, RoutedEventArgs e)
        {
            Baja info = new Baja();

            info.Show();
        }

        /// <summary>
        /// Este metodo te envian al menu de Baja de Empleados
        /// </summary>
        /// <param name="info">Valor que le asignamos la ventana de baja</param>

        private void botonBaja_Emp(object sender, RoutedEventArgs e)
        {
            Eliminar_Empleados info = new Eliminar_Empleados();

            info.Show();
        }

        /// <summary>
        /// Este metodo te envian al menu de Consuktas de Usuarios
        /// </summary>
        /// <param name="consultas">Valor que le asignamos la ventana de consultas</param>

        private void botonConsultas_Click(object sender, RoutedEventArgs e)
        {
            ConsultasUsuarios consultas = new ConsultasUsuarios();

            consultas.Show();
        }

        /// <summary>
        /// Este metodo te envian al menu de Consuktas de Empleados
        /// </summary>
        /// <param name="consultas">Valor que le asignamos la ventana de consultas</param>

        private void botonConsultas_Emp(object sender, RoutedEventArgs e)
        {
            Consultas_Empleado consultas = new Consultas_Empleado();

            consultas.Show();
        }
    }
}
