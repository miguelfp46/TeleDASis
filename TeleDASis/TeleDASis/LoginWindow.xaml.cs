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

        /// <summary>
        /// El metodo siguiente es sobre
        /// </summary>
        
        private void botonEntrar_Click(object sender, RoutedEventArgs e)
        {
            emp.nombreUsuario = loginName.Text;
            emp.passwd = passwd.Password;

            string rol;
            if (databaseConnector.instance.login(emp,out rol )== true)
            {
                
                MainWindows info = new MainWindows(rol);
                this.Hide();
                info.Show();
                this.Close();
            }
            else
            {
               
                    MessageBox.Show("Contraseña incorrecta", "Introduzca una contraseña valida", MessageBoxButton.OK, MessageBoxImage.Error);
                
                    loginName.Text = "";
                    passwd.Password = "";
                   
                }
            }
        }
    }
