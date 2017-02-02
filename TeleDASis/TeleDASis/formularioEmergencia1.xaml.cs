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
        public formularioEmergencia1()
        {
            InitializeComponent();
            Fecha.SelectedDate = DateTime.Today;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

            if (CMB.Text == "Ambulancia")
            {
                //perfil = 1;
            }else if (CMB.Text == "Policia")
            {

            }
            else
            {

            }
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {

        }

       // private void CMB_DropDownClosed(object sender, EventArgs e)
      //  {
      //      if (handle) Handler();
      //      handle = true;
      //  }

      //  private void combocomboBox_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
      //  {
       //     ComboBox cmb = sender as ComboBox;
      //      handle = !cmb.IsDropDownOpen;
       //     handle();
      //  }

      //  private void Handle()
      //  {
       //     switch(CMB.SelectedItem.ToString().Split(new string[] {":" }, StringSplitOptions.None))
        //}
    }
}
