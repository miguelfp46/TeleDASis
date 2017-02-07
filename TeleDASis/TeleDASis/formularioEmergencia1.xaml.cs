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
    /// Interaction logic for formularioEmergencia1.xaml
    /// </summary>
    public partial class formularioEmergencia1 : Window
    {
       private bool handle = true;
       int servicio;

        public formularioEmergencia1()
        {
            InitializeComponent();
            Fecha.SelectedDate = DateTime.Today;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {

        }

       private void CMB_DropDownClosed(object sender, EventArgs e)
      {
           if (handle) Handle();
           handle = true;
      }

      private void combocomboBox_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
     {
          ComboBox cmb = sender as ComboBox;
          handle = !cmb.IsDropDownOpen;
           Handle();
       }

       private void Handle()
       {
            switch(CMB.SelectedItem.ToString().Split(new string[] {":"}, StringSplitOptions.None).Last())
           {
               case "Ambulancia":
                   servicio = 1;
                  break;
               case "Policia":
                   servicio = 2;
                   break;
               case "Bomberos":
                   servicio = 3;
                   break;
               case "Mossos d'escuadra":
                   servicio = 4;
                   break;
               case "Mas de uno":
                   servicio = 5;
                   break;
               default:
                  servicio = 6;
                   break;


           }
       }
    }
}
