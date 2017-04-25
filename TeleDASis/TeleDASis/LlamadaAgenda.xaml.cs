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
    /// Interaction logic for formLlamadaAgenda.xaml
    /// </summary>
    public partial class formLlamadaAgenda : Window
    {
        Agenda ag = new Agenda();
        Llamadas llamada = new Llamadas();
        Usuario usuario = new Usuario();
        System.Windows.Controls.DataGrid dataGridTable;
        public formLlamadaAgenda()
        {
            InitializeComponent();
            dataGridTable = dtGAgenda;
            databaseConnector.instance.showAgendaTable(dtGAgenda,ag);            
        }

        // <summary>
        ///Cierra la ventana
        /// </summary>      
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Este metodo restringe que tipo de caracteres puedes escribir, en este caso solo puedes escribir numeros
        /// </summary>
        /// <param name="ascci">Valor que le asignamos para obtener un int</param>
        public void SoloNumeros(TextCompositionEventArgs e)
        {
            //se convierte a Ascci del la tecla presionada 
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            //verificamos que se encuentre en ese rango que son entre el 0 y el 9 
            if (ascci >= 48 && ascci <= 57)
                e.Handled = false;
            else e.Handled = true;
        }

        private void tbMovil_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloNumeros(e);
        }
        
        /// <summary>
        /// Este metodo te muestra en el datagrid las llamadas de agendas que se han introducido en la base de datos.
        /// </summary>
        
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dtGAgenda.SelectedItem;
            if (String.IsNullOrEmpty((dtGAgenda.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text))
            {
                MessageBox.Show("¡¡No hay llamadas!!","Registro de llamadas vacío.",MessageBoxButton.OK,MessageBoxImage.Information);
            } else
            {
                llamada.idLlamadas = int.Parse((dtGAgenda.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                usuario.dni = (dtGAgenda.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                usuario.nombre = (dtGAgenda.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                usuario.primerApellido = (dtGAgenda.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                usuario.segundoApellido = (dtGAgenda.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                llamada.telefonoUsuario = (dtGAgenda.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                llamada.descripcion = (dtGAgenda.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                llamada.solucion = (dtGAgenda.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
                llamadareclamacion llamadareclamacion = new llamadareclamacion(llamada.idLlamadas, llamada.telefonoUsuario, usuario.nombre, usuario.primerApellido
                    , usuario.segundoApellido, usuario.dni, llamada.descripcion, llamada.solucion);
                llamadareclamacion.Show();
                this.Close();
            }
   

        

        }
    }
}
