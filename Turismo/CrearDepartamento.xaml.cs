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
using CapaNegocio;

namespace Turismo
{
    public partial class CrearDepartamento : Window
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
            ComboBoxItem reservadocb = (ComboBoxItem)cbReservado.SelectedItem;
            TextBlock reservado = (TextBlock)reservadocb.Content;


            try
            {
                logic.newDepartamento(tbNombre.Text, Convert.ToInt32(tbArriendoDiario.Text), reservado.Text, Convert.ToInt32(tbHabitaciones.Text), Convert.ToInt32(tbBaños.Text), tbDescripcion.Text, Convert.ToInt32(tbValoracion.Text), Convert.ToInt32(tbMetrosCuadrados.Text), idRegion, tbDireccion.Text, idEstado);
            }
            
            catch(Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
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
