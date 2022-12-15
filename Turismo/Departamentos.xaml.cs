using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using CapaNegocio;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class Departamentos : MetroWindow
    {
        public Departamentos()
        {
            InitializeComponent();
            LblUsuario.Content = Business.user_login;
            LblCargo.Content = Business.usertype_login;
            dgDepartamento.ItemsSource = logic.DepartamentoData().DefaultView;
            //dgDepartamento.Items.Add(logic.DepartamentoData().DefaultView);
            BtnEliminar.IsEnabled = false;
            BtnEditar.IsEnabled = false;
            BtnVerInventario.IsEnabled = false;
            BtnVerMantencion.IsEnabled = false;
            BtnVerFotos.IsEnabled = false;
            BtnServicios.IsEnabled = false;

            //COMBOBOX ESTADO DEPARTAMENTO
            DataTable dted = logic.dtestadoDepartamentoData();
            cbEstado.ItemsSource = dted.AsDataView();
            cbEstado.DisplayMemberPath = "NOMBRE";
            cbEstado.SelectedValuePath = "ID_ESTADO";
            
            //cbEstado.selec

            //COMBOBOX REGION
            DataTable dtr = logic.dtregionData();
            cbRegion.ItemsSource = dtr.AsDataView();
            cbRegion.DisplayMemberPath = "NOMBRE";
            cbRegion.SelectedValuePath = "ID_REGION";
            
        }

        Business logic = new Business();
        string id_departamento;
        string nombre_departamento;
        int numero;
        int arriendo_diario;
        string reservado;
        int habitaciones;
        int banos;
        int valoracion;
        int metros_cuadrados;
        int valor_inventario;
        DateTime último_inventario;
        string id_ubicacion;
        string id_region;
        string direccion;
        string descripcion;
        string region;
        string estado;
        string id_estado;

        public void refreshDatagrid() 
        {
            dgDepartamento.ItemsSource = null;
            dgDepartamento.ItemsSource = logic.DepartamentoData().DefaultView;
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estás seguro que deseas borrar el departamento '" + tbnombreDepartamento.Text + "' ", "Eliminar", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)

            try
            { 
                logic.deleteDepartamento(id_departamento);
                logic.deleteUbicacion(id_ubicacion);
                refreshDatagrid();
                tbidDepartamento.Text = "";
                tbnombreDepartamento.Text = "";
                BtnEliminar.IsEnabled = false;
                id_departamento = null;
                cbEstado.SelectedItem = null;
                cbRegion.SelectedItem = null;
            }
            
            catch(Exception ex)
            {
                MessageBox.Show("Hubo un problema para eliminar el departamento seleccionado: " + ex);
            }
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            new CrearDepartamento().Show();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditarDepartamento ED = new EditarDepartamento(this, id_departamento, nombre_departamento, numero, arriendo_diario, habitaciones, banos, metros_cuadrados, direccion, descripcion, region, id_region, estado, id_estado, id_ubicacion);
            ED.Show();
        }

        private void dgDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                DataRowView dr = dg.SelectedItem as DataRowView;
                if (dr != null)
                {
                    id_departamento = dr["ID_DEPARTAMENTO"].ToString();
                    nombre_departamento = dr["NOMBRE"].ToString();
                    numero = Convert.ToInt32(dr["NUMERO"]);
                    arriendo_diario = Convert.ToInt32(dr["ARRIENDO_DIARIO"]);
                    habitaciones = Convert.ToInt32(dr["HABITACIONES"]);
                    banos = Convert.ToInt32(dr["BANOS"]);
                    metros_cuadrados = Convert.ToInt32(dr["METROS_CUADRADOS"]);
                    descripcion = dr["DESCRIPCION"].ToString();
                    id_ubicacion = dr["ID_UBICACION"].ToString();
                    region = dr["REGION"].ToString();
                    id_region = dr["ID_REGION"].ToString();
                    direccion = dr["DIRECCION"].ToString();
                    estado = dr["ESTADO"].ToString();
                    id_estado = dr["ID_ESTADO"].ToString();


                    tbidDepartamento.Text = id_departamento;
                    tbnombreDepartamento.Text = nombre_departamento;
                    BtnEliminar.IsEnabled = true;
                    BtnEditar.IsEnabled = true;
                    BtnVerInventario.IsEnabled = true;
                    BtnVerMantencion.IsEnabled = true;
                    BtnVerFotos.IsEnabled = true;
                    BtnServicios.IsEnabled = true;

                    cbEstado.SelectedIndex = Convert.ToInt32(id_estado) - 1;
                    cbRegion.SelectedIndex = Convert.ToInt32(id_region) - 1;
                }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Hubo un problema para leer los datos");
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagrid();
        }

        private void BtnVerInventario_Click(object sender, RoutedEventArgs e)
        {
            new InventarioDep(id_departamento, nombre_departamento).Show();
        }

        private void BtnVerMantencion_Click(object sender, RoutedEventArgs e)
        {
            new MantenciónDep(id_departamento, nombre_departamento).Show();
        }


        private void BtnVehiculos_Click(object sender, RoutedEventArgs e)
        {
            new Vehiculo().Show();
            this.Close();
        }

        private void BtnVerFotos_Click(object sender, RoutedEventArgs e)
        {
            new Foto(id_departamento, nombre_departamento).Show();
        }

        private void BtnServicios_Click(object sender, RoutedEventArgs e)
        {
            new Servicio(id_departamento, nombre_departamento).Show();
        }


        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {
            new Inventario().Show();
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

        private void BtnDepartamentos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            new Empleados().Show();
            this.Close();
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            new Clientes().Show();
            this.Close();
        }

        private void BtnCheckIn_Click(object sender, RoutedEventArgs e)
        {
            new CheckIn().Show();
            this.Close();
        }

        private void BtnEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            new Estadisticas().Show();
            this.Close();
        }


        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void BtnPagos_Click(object sender, RoutedEventArgs e)
        {
            new Pago().Show();
            this.Close();
        }
    }
}
