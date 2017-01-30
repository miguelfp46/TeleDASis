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
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CMB.Text == "Ambulancia")
            {
                //perfil = 1;
            }else if (CMB.Text == "Policia")
            {

            }
            else
            {

            }
        }
    }
}
