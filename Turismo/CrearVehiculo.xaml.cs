using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
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
    /// Interaction logic for CrearVehiculo.xaml
    /// </summary>
    public partial class CrearVehiculo : Window
    {
        public CrearVehiculo()
        {
            InitializeComponent();

            //COMBOBOX ESTADO VEHICULO
            DataTable dted = logic.dtestadoVehiculoData();
            cbEstado.ItemsSource = dted.AsDataView();
            cbEstado.DisplayMemberPath = "NOMBRE";
            cbEstado.SelectedValuePath = "ID_ESTADO";
        }

        Business logic = new Business();
        string id_estado;
        string disponibilidad;

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {


            try
            {

                logic.newVehiculo(tbPatente.Text, cbDisponibilidad.Text, id_estado, Convert.ToInt32(tbCapacidad.Text), tbDescripcion.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            id_estado = cbEstado.SelectedValue.ToString();
        }

        private void cbDisponibilidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            disponibilidad = cbDisponibilidad.SelectedValue.ToString();
        }
    }
}
