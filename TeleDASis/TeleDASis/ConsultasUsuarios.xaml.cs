using System;
using System.Collections.Generic;
using System.Data;
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

           //dtGConsultas.DataContext = databaseConnector.instance.showUserTable();
        }
        public void loadDataTable()
        {
            dataGridTable = dtGConsultas;
            
            //databaseConnector.instance.showUserTable();
        }
    }
}
