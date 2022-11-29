using CapaNegocio;
using System;
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

            catch (Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }


        }
    }
}
