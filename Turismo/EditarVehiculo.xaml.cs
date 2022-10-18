using CapaNegocio;
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
    /// Interaction logic for EditarVehiculo.xaml
    /// </summary>
    public partial class EditarVehiculo : Window
    {
        public EditarVehiculo(string patente, string disponibilidad, string id_estado, int capacidad, string descripcion)
        {
            InitializeComponent();

            DataTable dted = logic.dtestadoVehiculoData();
            cbEstado.ItemsSource = dted.AsDataView();
            cbEstado.DisplayMemberPath = "NOMBRE";
            cbEstado.SelectedValuePath = "ID_ESTADO";

            this.id_estado = (Convert.ToInt32(cbEstado.SelectedIndex) + 1).ToString();
        }

        Business logic = new Business();
        string patente;
        string disponibilidad;
        string id_estado;
        int capacidad;
        string descripcion;

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            logic.editVehiculo(patente, disponibilidad, id_estado, capacidad, descripcion);
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
            disponibilidad = (Convert.ToInt32(cbDisponibilidad.SelectedIndex) + 1).ToString();
        }
    }
}
