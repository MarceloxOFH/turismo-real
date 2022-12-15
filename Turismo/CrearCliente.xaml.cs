using CapaNegocio;
using System;
using System.Windows;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for CrearCliente.xaml
    /// </summary>
    public partial class CrearCliente : MetroWindow
    {
        public CrearCliente()
        {
            InitializeComponent();

        }

        Business logic = new Business();

        Clientes cli = new Clientes();

        private void btnCrearCliente_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                logic.newClientes(tbRut.Text, tbNombresClientes.Text, tbApellidosClientes.Text, Convert.ToInt32(tbTelefono.Text), tbCorreo.Text, tbContraseña.Text);
            }

            catch //(Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }


        }
    }
}
