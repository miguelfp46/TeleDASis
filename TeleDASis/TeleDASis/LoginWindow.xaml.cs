using System;
using System.Windows;


namespace TeleDASis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        // Load data base
        databaseConnector ddbb = null;
        Empleados emp = new Empleados();

        public MainWindow()
        {
            InitializeComponent();

            // Load data base
            ddbb = databaseConnector.instance;
        }

        private void loginName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void botonEntrar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = loginName.Text;
            string password = passwd.Password;
            int intentos = 0;

            if (nombre == emp.nombre && password == emp.password)
            {
                MainWindow info = new MainWindow();

                info.Show();
            }
            else
            {
               
                    MessageBox.Show("Contraseña incorrecta", "Introduzca una contraseña valida", MessageBoxButton.OK, MessageBoxImage.Error);
                
                    loginName.Text = "";
                    passwd.Password = "";
                    intentos++;
                }
            }
        }
    }
