using System.Windows;
using System.Windows.Controls;

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
            databaseConnector.instance.showUserTable(dataGridTable);
        }  
        public void loadDataTable()
        {
            dataGridTable = dtGConsultas;
            
            //databaseConnector.instance.showUserTable();
        }
    }
}
