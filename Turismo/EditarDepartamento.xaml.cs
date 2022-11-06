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
using Tienda;

namespace Turismo
{

    public partial class EditarDepartamento : Window
    {
        Departamentos dep;
        string id_departamento;
        int numero;
        Business logic = new Business();
        string id_estado;
        string id_ubicacion;
        string reservado;
        string region;
        string id_region;
        //Departamentos dep = new Departamentos();

        public EditarDepartamento(Departamentos dep, string id_departamento, string nombre_departamento, int numero, int arriendo_diario, int habitaciones, int baños, int valoracion, int metros_cuadrados, string direccion, string descripcion, string region, string id_region, string estado, string id_estado, string id_ubicacion, string reservado)
        {
            InitializeComponent();
            this.dep = dep;

            //COMBOBOX ESTADO DEPARTAMENTO
            DataTable dted = logic.dtestadoDepartamentoData();
            cbEstado.ItemsSource = dted.AsDataView();
            cbEstado.DisplayMemberPath = "NOMBRE";
            cbEstado.SelectedValuePath = "ID_ESTADO";
            cbEstado.SelectedIndex = Convert.ToInt32(id_estado) - 1;
            //cbEstado.selec

            //COMBOBOX REGION
            DataTable dtr = logic.dtregionData();
            cbRegion.ItemsSource = dtr.AsDataView();
            cbRegion.DisplayMemberPath = "NOMBRE";
            cbRegion.SelectedValuePath = "ID_REGION";
            cbRegion.SelectedIndex = Convert.ToInt32(id_region) - 1;


            this.id_departamento = id_departamento;
            tbNombre.Text = nombre_departamento;
            tbNumero.Text = numero.ToString();
            tbArriendoDiario.Text = arriendo_diario.ToString();
            tbHabitaciones.Text = habitaciones.ToString();
            tbBaños.Text = baños.ToString();
            tbValoracion.Text = valoracion.ToString();
            tbMetrosCuadrados.Text = metros_cuadrados.ToString();
            tbDescripcion.Text = descripcion.ToString();
            tbDireccion.Text = direccion.ToString();
            this.id_ubicacion = id_ubicacion;
            cbReservado.Text = reservado;
            this.id_region = (Convert.ToInt32(cbRegion.SelectedIndex) + 1).ToString();
            this.id_estado = (Convert.ToInt32(cbEstado.SelectedIndex) + 1).ToString();

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logic.editDepartamento(id_departamento, tbNombre.Text, Convert.ToInt32(tbNumero.Text),Convert.ToInt32(tbArriendoDiario.Text), Convert.ToInt32(tbHabitaciones.Text), Convert.ToInt32(tbBaños.Text), tbDescripcion.Text, Convert.ToInt32(tbValoracion.Text), Convert.ToInt32(tbMetrosCuadrados.Text), id_region, this.id_estado, tbDireccion.Text, this.id_ubicacion, cbReservado.Text);
                dep.refreshDatagrid();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.id_estado = (Convert.ToInt32(cbEstado.SelectedIndex) + 1).ToString();
        }

        private void cbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.id_region = (Convert.ToInt32(cbRegion.SelectedIndex) + 1).ToString();
        }
    }
}
