﻿using System;
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
    /// Interaction logic for MainWindows.xaml
    /// </summary>
    public partial class MainWindows : Window
    {
        public MainWindows()
        {
            InitializeComponent();
        }
        
        private void btLlamadas_Click(object sender, RoutedEventArgs e)
        {
            llamadareclamacion info = new llamadareclamacion();

            info.Show();
        }
        
       

        private void botonModificaciones_Click(object sender, RoutedEventArgs e)
        {
            ModificacionesUsuarios modificar = new ModificacionesUsuarios();
            modificar.Show();

        }

        private void botonModificaciones_Emp(object sender, RoutedEventArgs e)
        {
            Modificación_Empleados modificar = new Modificación_Empleados();
            modificar.Show();

        }

        private void botonAlta_Click(object sender, RoutedEventArgs e)
        {
            Alta info = new Alta();

            info.Show();

        }

        private void botonAlta_Emp(object sender, RoutedEventArgs e)
        {
            Window3 info = new Window3();

            info.Show();

        }

        private void botonBaja_Click(object sender, RoutedEventArgs e)
        {
            Baja info = new Baja();

            info.Show();
        }

        private void botonBaja_Emp(object sender, RoutedEventArgs e)
        {
            Eliminar_Empleados info = new Eliminar_Empleados();

            info.Show();
        }

        private void botonConsultas_Click(object sender, RoutedEventArgs e)
        {
            ConsultasUsuarios consultas = new ConsultasUsuarios();

            consultas.Show();
        }

        private void botonConsultas_Emp(object sender, RoutedEventArgs e)
        {
            Consultas_Empleado consultas = new Consultas_Empleado();

            consultas.Show();
        }

        private void btn_Rllamadas_Click(object sender, RoutedEventArgs e)
        {
            FormularioRLlamadas info = new FormularioRLlamadas();

            info.Show();
        }
    }
}
