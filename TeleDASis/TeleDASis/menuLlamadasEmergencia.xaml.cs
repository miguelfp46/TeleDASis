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
    /// Interaction logic for LlamadaEmergencia.xaml
    /// </summary>
    public partial class menuLlamadaEmergencia : Window
    {
        public menuLlamadaEmergencia()
        {
            InitializeComponent();
        }

        private void btnemergencia1_Click(object sender, RoutedEventArgs e)
        {
            formularioEmergencia1 emerleve = new formularioEmergencia1();
            emerleve.Show();
        }

        private void btnemergencia2_Click(object sender, RoutedEventArgs e)
        {
            formularioEmergencia1 emergencia = new formularioEmergencia1();
            emergencia.Show();
        }

        private void btnemergencia3_Click(object sender, RoutedEventArgs e)
        {
            formularioEmergencia1 emergrave = new formularioEmergencia1();
            emergrave.Show();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}