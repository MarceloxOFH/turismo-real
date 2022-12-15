using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using CapaNegocio;
using MahApps.Metro.Controls;

namespace Turismo
{
    public partial class CrearDepartamento : MetroWindow
    {

        Business logic = new Business();
        string idEstado;
        string idRegion;
        Departamentos dep = new Departamentos();
        public CrearDepartamento()
        {
            InitializeComponent();

            //COMBOBOX ESTADO DEPARTAMENTO
            DataTable dted = logic.dtestadoDepartamentoData();
            cbEstado.ItemsSource = dted.AsDataView();
            cbEstado.DisplayMemberPath = "NOMBRE";
            cbEstado.SelectedValuePath = "ID_ESTADO";

            
            //COMBOBOX REGION
            DataTable dtr = logic.dtregionData();
            cbRegion.ItemsSource = dtr.AsDataView();
            cbRegion.DisplayMemberPath = "NOMBRE";
            cbRegion.SelectedValuePath = "ID_REGION";
            
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logic.newDepartamento(tbNombre.Text, Convert.ToInt32(tbNumero.Text),Convert.ToInt32(tbArriendoDiario.Text), Convert.ToInt32(tbHabitaciones.Text), Convert.ToInt32(tbBaños.Text), tbDescripcion.Text, Convert.ToInt32(tbMetrosCuadrados.Text), idRegion, tbDireccion.Text, idEstado);
            }
            
            catch //(Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos","Error");
            }
        }

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idEstado = cbEstado.SelectedValue.ToString();
            //MessageBox.Show(idEstado);
        }

        private void cbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idRegion = cbRegion.SelectedValue.ToString();
        }

      
    }
}
