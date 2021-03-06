﻿using System;
using System.Windows;
using TeleDASis;

namespace TeleDASis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class LoginWindow : Window
    {
        // Load data base
        databaseConnector ddbb = null;
        Empleados emp = new Empleados();

        public LoginWindow()
        {
            InitializeComponent();

            // Load data base
            ddbb = databaseConnector.instance;
        }

        private void loginName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// En metodo siguiente recibira el usuario y la contraseña del Empleado,
        /// si es correcto lo dejara pasar en cambio si no lo es le saltara un mensaje de error.
        /// </summary>
        
        private void botonEntrar_Click(object sender, RoutedEventArgs e)
        {
            emp.nombreUsuario = loginName.Text;
            emp.passwd = databaseConnector.instance.sha256(passwd.Password);

            string rol;
            if (databaseConnector.instance.login(emp,out rol)== true)
            {
                
                MainWindows info = new MainWindows(rol);
                this.Hide();
                info.Show();
                this.Close();

            }
            else
            {
               
                    MessageBox.Show("Contraseña incorrecta", "Introduzca una contraseña valida", MessageBoxButton.OK, MessageBoxImage.Error);
                
                    loginName.Text = string.Empty;
                    passwd.Password = string.Empty;
                    

            }
            }

        private void passwd_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                botonEntrar_Click(sender, e);
            }
        }
    }
    }
