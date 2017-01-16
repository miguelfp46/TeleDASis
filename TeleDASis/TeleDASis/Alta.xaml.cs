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
    /// Interaction logic for Alta.xaml
    /// </summary>
    public partial class Alta : Window
    {
        String nombre;
        String apellido;
        String apellido2;
        String dni;
        String nTelefono;
        String nTelefonoFamiliar;
        String movil;
        int codigoIdentificacion = 0;
        String targetaSanitaria;
        String fechaDeAlta;
        int vivienda = 0;
        
        
        public Alta()
        {

            InitializeComponent();
            nombre = tbNombre.Text;
            apellido = tbApellido.Text;
            apellido2 = tbApellido2.Text;
            dni = tbDni.Text;
            nTelefono = tbTelefono.Text;
            nTelefonoFamiliar = tbFamiliar.Text;
            movil = tbMovil.Text;
            codigoIdentificacion = int.Parse(tbCodigoIdentificacion.Text);
            targetaSanitaria = tbTargetaSanitaria.Text;
            fechaDeAlta = tbFechaDeAlta.Text;
            vivienda = int.Parse(tbCodigoIdentificacion.Text);
            
            
        }

        private void btAccept_Click(object sender, RoutedEventArgs e)
        {
            databaseConnector.instance.addUser(nombre,apellido,apellido2,dni,nTelefono,
                nTelefonoFamiliar,movil,codigoIdentificacion,targetaSanitaria,fechaDeAlta,vivienda);
        }
    }
}
