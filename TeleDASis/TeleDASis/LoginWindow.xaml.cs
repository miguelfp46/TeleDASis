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

        public MainWindow()
        {
            InitializeComponent();

            // Load data base
            ddbb = databaseConnector.instance;
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            User user = ddbb.checkUser(loginName.Text, passwd.Password);
            if (user == null)
            {
                // NOT IN DATABASE or PASSWORD INCORRECT
                MessageBox.Show("Error! El usuario o la contraseña es incorrecto!!!!");
            }
            else
            {
                MessageBox.Show("Bienvenido " + user.dni);
                Application.Current.Shutdown();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ddbb.close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            new AddUser().Show();

        }
    }
}