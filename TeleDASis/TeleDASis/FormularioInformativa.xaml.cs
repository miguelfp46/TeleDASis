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
    /// Interaction logic for FormularioInformativa.xaml
    /// </summary>
    public partial class FormularioInformativa : Window
    {
        public FormularioInformativa()
        {
            InitializeComponent();
            Fecha.SelectedDate = DateTime.Today;
        }

        

       

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
