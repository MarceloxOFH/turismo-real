using CapaNegocio;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for EditarVehiculo.xaml
    /// </summary>
    public partial class EditarVehiculo : MetroWindow
    {
        public EditarVehiculo(string patente, string disponibilidad, string modelo, string id_estado, int capacidad, string descripcion)
        {
            InitializeComponent();

            tbPatente.Text = patente;
            temp_patente = patente;
            tbCapacidad.Text = capacidad.ToString();
            tbDescripcion.Text = descripcion;
            cbDisponibilidad.Text = disponibilidad;
            tbModelo.Text = modelo;


            DataTable dted = logic.dtestadoVehiculoData();
            cbEstado.ItemsSource = dted.AsDataView();
            cbEstado.DisplayMemberPath = "NOMBRE";
            cbEstado.SelectedValuePath = "ID_ESTADO";
            cbEstado.SelectedIndex = Convert.ToInt32(id_estado) - 1;

            this.id_estado = (Convert.ToInt32(cbEstado.SelectedIndex) + 1).ToString();
        }

        Business logic = new Business();
        string patente;
        string temp_patente;
        string disponibilidad;
        string id_estado;
        int capacidad;
        string descripcion;

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            logic.editVehiculo(tbPatente.Text, temp_patente, cbDisponibilidad.Text, tbModelo.Text, id_estado, Convert.ToInt32(tbCapacidad.Text), tbDescripcion.Text);
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            id_estado = (Convert.ToInt32(cbEstado.SelectedIndex) + 1).ToString();
        }

        private void cbDisponibilidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
