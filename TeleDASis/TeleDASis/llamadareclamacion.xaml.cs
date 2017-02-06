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
        public llamadareclamacion()
        {
            InitializeComponent();
            Fecha.SelectedDate = DateTime.Today;
            Hora.SelectedDateFormat = DatePickerFormat.Short;
           
          
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
