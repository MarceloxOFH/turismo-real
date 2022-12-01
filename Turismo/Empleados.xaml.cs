using CapaNegocio;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Turismo
{
    /// <summary>
    /// Interaction logic for Empleados.xaml
    /// </summary>
    public partial class Empleados : MetroWindow
    {
        public Empleados()
        {
            InitializeComponent();
            LblUsuario.Content = Business.user_login;
            LblCargo.Content = Business.usertype_login;
            dgEmpleados.ItemsSource = logic.EmpleadosData().DefaultView;

            DataTable dtca = logic.dtestadoEmpleadoData();
            cbCargo.ItemsSource = dtca.AsDataView();
            cbCargo.DisplayMemberPath = "NOMBRE";
            cbCargo.SelectedValuePath = "ID_CARGO";


        }

        Business logic = new Business();
        string id_empleado;
        string nombres;
        string apellidos;
        DateTime anno_contratacion;
        string cargo;
        int sueldo;
        DateTime horario_trabajo;
        string id_cargo;
        string acceso_username;

        public void actualizarDatagrid()
        {
            dgEmpleados.ItemsSource = null;
            dgEmpleados.ItemsSource = logic.EmpleadosData().DefaultView;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estás seguro que deseas borrar el departamento '" + tbnombreEmpleado.Text + "' ", "Eliminar empleado", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)

                try
                {
                    logic.deleteEmpleado(id_empleado);
                    actualizarDatagrid();
                    tbnombreEmpleado.Text = "";
                    tbApellidoEmpleado.Text = "";
                    BtnEliminar.IsEnabled = false;
                    id_empleado = null;
                    cbCargo.SelectedItem = null;

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un problema para eliminar el departamento seleccionado: " + ex);
                }
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            new CrearEmpleado().Show();
        }



        private void dgEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                DataRowView dr = dg.SelectedItem as DataRowView;
                if (dr != null)
                {
                    id_empleado = dr["ID_EMPLEADO"].ToString();
                    nombres = dr["NOMBRES"].ToString();
                    apellidos = dr["APELLIDOS"].ToString();
                    anno_contratacion = Convert.ToDateTime(dr["AÑO_CONTRATACION"]);
                    cargo = dr["CARGO"].ToString();
                    sueldo = Convert.ToInt32(dr["SUELDO"]);
                    id_cargo = dr["ID_CARGO"].ToString();
                    acceso_username = dr["USERNAME"].ToString();


                    tbnombreEmpleado.Text = nombres;
                    tbApellidoEmpleado.Text = apellidos;
                    BtnEliminar.IsEnabled = true;
                    BtnEditar.IsEnabled = true;

                    cbCargo.SelectedIndex = Convert.ToInt32(id_cargo) - 1;

                }
            }
            catch (Exception ex)
            { 
            }
        }


        private void btnEmpleado_Click(object sender, RoutedEventArgs e)
        {
            new CrearEmpleado().Show();
        }

        private void btnAcceso_Click(object sender, RoutedEventArgs e)
        {
            new CrearAcceso().Show();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            new EditarEmpleado(nombres, apellidos, anno_contratacion, sueldo, horario_trabajo, id_cargo, acceso_username).Show();
        }

        private void BtnCrearCargo_Click(object sender, RoutedEventArgs e)
        {
            new CrearCargo().Show();
        }

        private void actualizar_Click(object sender, RoutedEventArgs e)
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
            //new Empleados().Show();
            //this.Close();
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            new Clientes().Show();
            this.Close();
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
