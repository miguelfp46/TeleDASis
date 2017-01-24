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
    /// Interaction logic for Alta.xaml
    /// </summary>
    public partial class Alta : Window
    {
        String nombre;
        String apellido;
        String apellido2;
        String dni;
        String nTelefono;
        String nTelefonoFamiliar;
        String movil;
        String targetaSanitaria;
        String fechaDeAlta;
        int vivienda = 0;
        
        
        public Alta()
        {
            InitializeComponent();
            tbFechaDeAlta.SelectedDate = DateTime.Today;   
        }

        private void btAccept_Click(object sender, RoutedEventArgs e)
        {
            nombre = tbNombre.Text;
            apellido = tbApellido.Text;
            apellido2 = tbApellido2.Text;
            dni = tbDni.Text;
            nTelefono = tbTelefono.Text;
            nTelefonoFamiliar = tbFamiliar.Text;
            movil = tbMovil.Text;        
            targetaSanitaria = tbTargetaSanitaria.Text;
            DateTime dt = tbFechaDeAlta.DisplayDate;
            fechaDeAlta = dt.ToString("yyyy/MM/dd");
            vivienda = int.Parse(tbVivienda.Text);
            databaseConnector.instance.addUser(nombre, apellido, apellido2, dni, nTelefono,
                nTelefonoFamiliar, movil, targetaSanitaria, fechaDeAlta, vivienda);
        }
    }
}
