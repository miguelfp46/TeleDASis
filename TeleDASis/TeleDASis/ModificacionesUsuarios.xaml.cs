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
    /// Interaction logic for ModificacionesUsuarios.xaml
    /// </summary>
    public partial class ModificacionesUsuarios : Window
    {
        public ModificacionesUsuarios()
        {
            InitializeComponent();
            Fecha.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Guardar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
