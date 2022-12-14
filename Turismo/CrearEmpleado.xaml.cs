using CapaNegocio;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for CrearEmpleado.xaml
    /// </summary>
    public partial class CrearEmpleado : MetroWindow
    {
        Business logic = new Business();
        string idCargo;
        Empleados emp = new Empleados();

        public CrearEmpleado()
        {
            InitializeComponent();

            DataTable dted = logic.dtCargoEmpleadoData();
            cbCargo.ItemsSource = dted.AsDataView();
            cbCargo.DisplayMemberPath = "NOMBRE";
            cbCargo.SelectedValuePath = "ID_CARGO";

        }

        private void cbCargo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idCargo = cbCargo.SelectedValue.ToString();
            //MessageBox.Show(idEstado);
        }


        private void BtnCrearEmpleado_Click(object sender, RoutedEventArgs e)
        {


            //MessageBox.Show("id cargo" + idCargo);
            try
            {
                logic.newEmpleado(tbNombre.Text, tbApellido.Text, Convert.ToDateTime(dtpAnnoContrato.Text), Convert.ToInt32(tbSueldo.Text), idCargo, tbAccesoUsername.Text);
            }

            catch //(Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }


    }
}
