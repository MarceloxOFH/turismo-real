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

namespace Turismo
{
    /// <summary>
    /// Interaction logic for Conductor.xaml
    /// </summary>
    public partial class Conductor : Window
    {
        public Conductor()
        {
            InitializeComponent();

            dgConductor.ItemsSource = logic.ConductorData().DefaultView;
            
            BtnEliminar.IsEnabled = false;
            BtnEditar.IsEnabled = false;
        }

        Business logic = new Business();
        string rut_conductor;
        string nombres;
        string apellidos;
        DateTime caducidad_licencia;
        string disponibilidad;
        int sueldo;


        public void refreshDatagrid()
        {
            dgConductor.ItemsSource = null;
            dgConductor.ItemsSource = logic.ConductorData().DefaultView;
        }


        private void dgConductor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                rut_conductor = dr["RUT_CONDUCTOR"].ToString();
                nombres = dr["NOMBRES"].ToString();
                apellidos = dr["APELLIDOS"].ToString();
                caducidad_licencia = DateTime.Parse(dr["CADUCIDAD_LICENCIA"].ToString()); 
                disponibilidad = dr["DISPONIBILIDAD"].ToString();
                sueldo = Convert.ToInt32(dr["SUELDO"]);

                tbRut.Text = rut_conductor;
                tbNombres.Text = nombres;
                tbApellidos.Text = apellidos;
                cbDisponibilidad.Text = disponibilidad;

                BtnEliminar.IsEnabled = true;
                BtnEditar.IsEnabled = true;
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estás seguro que deseas borrar el conductor de RUT: '" + tbRut.Text + "'?", "Eliminar conductor", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)

                try
                {
                    logic.deleteConductor(rut_conductor);
                    refreshDatagrid();
                    tbRut.Text = "";
                    tbNombres.Text = "";
                    tbApellidos.Text = "";
                    cbDisponibilidad.Text = "";
                    BtnEliminar.IsEnabled = false;
                    BtnEditar.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se debe seleccionar un conductor");
                }
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            new CrearConductor().Show();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                new EditarConductor(rut_conductor, nombres, apellidos, caducidad_licencia, disponibilidad, sueldo).Show();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Se debe seleccionar un conductor");
            }
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

        private void Departamentos_Click(object sender, RoutedEventArgs e)
        {
            new Departamentos().Show();
            this.Close();
        }
    }
}
