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
    /// Interaction logic for RegistrodeTodasLasLlamadas.xaml
    /// </summary>
    public partial class RegistrodeTodasLasLlamadas : Window
    {
        System.Windows.Controls.DataGrid dataGridTable;

        public RegistrodeTodasLasLlamadas()
        {
            InitializeComponent();
            dataGridTable = dataGrid;

           // databaseConnector.instance.showLLamadas();
        }

        private void btVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
