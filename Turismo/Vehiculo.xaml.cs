using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
    /// Interaction logic for Vehiculo.xaml
    /// </summary>
    public partial class Vehiculo : MetroWindow
    {
        public Vehiculo()
        {
            InitializeComponent();
            LblUsuario.Content = Business.user_login;
            LblCargo.Content = Business.usertype_login;
            dgVehiculo.ItemsSource = logic.VehiculoData().DefaultView;
            //dgDepartamento.Items.Add(logic.DepartamentoData().DefaultView);
            BtnEliminar.IsEnabled = false;
            BtnEditar.IsEnabled = false;

            //COMBOBOX ESTADO DEPARTAMENTO
            DataTable dted = logic.dtestadoVehiculoData();
            cbEstado.ItemsSource = dted.AsDataView();
            cbEstado.DisplayMemberPath = "NOMBRE";
            cbEstado.SelectedValuePath = "ID_ESTADO";
        }

        Business logic = new Business();
        string patente;
        string disponibilidad;
        string estado;
        string id_estado;
        int capacidad;
        string descripcion;
        string modelo;

        private void dgVehiculo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                patente = dr["PATENTE"].ToString();
                disponibilidad = dr["DISPONIBILIDAD"].ToString();
                estado = dr["ESTADO"].ToString();
                id_estado = dr["ID_ESTADO"].ToString();
                capacidad = Convert.ToInt32(dr["CAPACIDAD"]);
                descripcion = dr["DESCRIPCION"].ToString();
                modelo = dr["MODELO"].ToString();
                tbPatente.Text = patente;
                cbDisponibilidad.Text = disponibilidad;
                tbCapacidad.Text = capacidad.ToString();

                cbEstado.SelectedIndex = Convert.ToInt32(id_estado) - 1;

                BtnEliminar.IsEnabled = true;
                BtnEditar.IsEnabled = true;

                this.id_estado = (Convert.ToInt32(cbEstado.SelectedIndex) + 1).ToString();
            }
        }

        public void refreshDatagrid()
        {
            dgVehiculo.ItemsSource = null;
            dgVehiculo.ItemsSource = logic.VehiculoData().DefaultView;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estás seguro que deseas borrar el vehículo de patente '" + tbPatente.Text + "'?", "Eliminar vehículo", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)

                try
                {
                    logic.deleteVehiculo(patente);
                    refreshDatagrid();

                    tbPatente.Text = "";
                    cbDisponibilidad.Text = "";
                    tbCapacidad.Text = "";
                    cbEstado.SelectedItem = null;

                    BtnEliminar.IsEnabled = false;
                    patente = null;
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un problema para eliminar el vehículo seleccionado: " + ex);
                }
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            new CrearVehiculo().Show();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            new EditarVehiculo(patente, disponibilidad, modelo, id_estado, capacidad, descripcion).Show();
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagrid();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {

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
            //new Vehiculo().Show();
            //this.Close();
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

        }

        private void BtnEmpleados_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEstadisticas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnInformes_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
