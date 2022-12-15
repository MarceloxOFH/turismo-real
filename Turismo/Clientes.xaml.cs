using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using CapaNegocio;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for Clientes.xaml
    /// </summary>
    public partial class Clientes : MetroWindow
    {
        public Clientes()
        {
            InitializeComponent();
            LblUsuario.Content = Business.user_login;
            LblCargo.Content = Business.usertype_login;
            dgClientes.ItemsSource = logic.ClientesData().DefaultView;


        }

        Business logic = new Business();
        string rut_cliente;
        string nombres;
        string apellidos;
        int telefono;
        string email;
        string contrasena;



        public void actualizarDatagrid()
        {
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = logic.ClientesData().DefaultView;
        }

        private void dgEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            { 
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                rut_cliente = dr["RUT_CLIENTE"].ToString();
                nombres = dr["NOMBRES"].ToString();
                apellidos = dr["APELLIDOS"].ToString();
                telefono = Convert.ToInt32(dr["TELEFONO"]);
                email = dr["EMAIL"].ToString();
                //contrasena = dr["CONTRASENA"].ToString();


                tbClienteNombre.Text = nombres;
                tbClienteRut.Text = rut_cliente;


            }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
        }

        private void BtnCrearCliente_Click(object sender, RoutedEventArgs e)
        {
            new CrearCliente().Show();
        }

        private void BtnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estás seguro que deseas borrar el cliente '" + tbClienteNombre.Text + "' ", "Eliminar empleado", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)

                try
                {
                    logic.deleteCliente(rut_cliente);
                    actualizarDatagrid();
                    tbClienteNombre.Text = "";
                    tbClienteRut.Text = "";
                    BtnEliminarCliente.IsEnabled = false;
                    rut_cliente = null;

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un problema para eliminar el cliente seleccionado: " + ex);
                }
        }

        private void BtnEditarCliente_Click(object sender, RoutedEventArgs e)
        {
            new EditarCliente(rut_cliente, nombres, apellidos, telefono, email, contrasena).Show();

        }

        private void btnActualizarEditar_Click(object sender, RoutedEventArgs e)
        {
            actualizarDatagrid();
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void BtnDepartamentos_Click(object sender, RoutedEventArgs e)
        {
            new Departamentos().Show();
            this.Close();
        }

        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {
            new Inventario().Show();
            this.Close();
        }

        private void BtnVehiculos_Click(object sender, RoutedEventArgs e)
        {
            new Vehiculo().Show();
            this.Close();
        }

        private void BtnConductores_Click(object sender, RoutedEventArgs e)
        {
            new Conductor().Show();
            this.Close();
        }

        private void BtnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            new CheckOut().Show();
            this.Close();
        }

        private void BtnCheckIn_Click(object sender, RoutedEventArgs e)
        {
            new CheckIn().Show();
            this.Close();
        }

        private void BtnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            new Empleados().Show();
            this.Close();
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            //new Clientes().Show();
            //this.Close();
        }

        private void BtnEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            new Estadisticas().Show();
            this.Close();
        }

        private void BtnPagos_Click(object sender, RoutedEventArgs e)
        {
            new Pago().Show();
            this.Close();
        }
    }
}
