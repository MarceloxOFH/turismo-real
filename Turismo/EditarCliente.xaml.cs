using CapaNegocio;
using System.Windows;
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
            //try
            //{
            //    logic.editCliente(tbEditarRut.Text, tbEditarNombresClientes.Text, tbEditarApellidosClientes.Text, Convert.ToInt32(tbEditarTelefono.Text), tbEditarCorreo.Text, tbEditarContraseña.Text);
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show("Se deben llenar todos los campos");
            //}

        }
    }
}
