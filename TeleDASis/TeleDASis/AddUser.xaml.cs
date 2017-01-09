using System.Windows;

namespace TeleDASis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        

        private void textName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
        
            TestDatabase ddbb = TestDatabase.instance;

            // Check texts
            if (textName.Text.Length == 0 || passwordBox.Password.Length == 0)
            {
                MessageBox.Show("Rellena el nombre y/o contraseña");
            }
            else
            {
                if (!ddbb.addUser(new User(textName.Text, passwordBox.Password)))
                {

                    MessageBox.Show("Error! El usuario " + textName.Text + " ya existe");
                }
                else
                {
                    MessageBox.Show("Usuario " + textName.Text + " dado de alta correctamente");
                    Close();
                }
            }
        }
    
    }
}