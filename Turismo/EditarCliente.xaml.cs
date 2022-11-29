using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
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
    /// Interaction logic for EditarCliente.xaml
    /// </summary>
    public partial class EditarCliente : MetroWindow
    {
        public EditarCliente(string rut_cliente, string nombres, string apellidos, int telefono, string email, string contrasena)
        {
            InitializeComponent();
        }

        Business logic = new Business();

        Clientes cli = new Clientes();

        private void btnEditarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logic.editCliente(tbEditarRut.Text, tbEditarNombresClientes.Text, tbEditarApellidosClientes.Text, Convert.ToInt32(tbEditarTelefono.Text), tbEditarCorreo.Text, tbEditarContraseña.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }

        }
    }
}
