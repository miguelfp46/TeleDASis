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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeleDASis
{
    /// <summary>
    /// Interaction logic for HistoricoBaja.xaml
    /// </summary>
    public partial class HistoricoBaja : Window
    {
        Usuario user = new Usuario();
        System.Windows.Controls.DataGrid dataGridTable;
        public HistoricoBaja()
        {
           
            InitializeComponent();
            dataGridTable = dtGTabla;
            databaseConnector.instance.showBajas(dataGridTable, user);
        }

        private void dtGTabla_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
