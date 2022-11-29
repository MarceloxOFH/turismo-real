using CapaNegocio;
using MahApps.Metro.Controls;
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
    /// Interaction logic for EditarEmpleado.xaml
    /// </summary>
    public partial class EditarEmpleado : MetroWindow
    {

        Business logic = new Business();
        string idCargo;
        Empleados emp = new Empleados();

        string id_empleado;

        public EditarEmpleado(string nombres, string apellidos, DateTime anno_contratacion, int sueldo, DateTime horario_trabajo, string id_cargo, string acceso_usernam)
        {
            InitializeComponent();


            DataTable dted = logic.dtestadoEmpleadoData();
            cbCargo.ItemsSource = dted.AsDataView();
            cbCargo.DisplayMemberPath = "NOMBRE";
            cbCargo.SelectedValuePath = "ID_CARGO";

            tbNombre.Text = nombres;
            tbApellido.Text = apellidos;
            this.idCargo = (Convert.ToInt32(cbCargo.SelectedIndex) + 1).ToString();
            //tbSueldo.Text = sueldo.ToString;
            //tbAccesoUsername = acceso_usernam;
            //dtpAnnoContrato = anno_contratacion;
            //dtpHorario = horario_trabajo;







        }

        private void cbCargo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idCargo = cbCargo.SelectedValue.ToString();
            //MessageBox.Show(idEstado);
        }


        private void BtnEditarEmpleados_Click(object sender, RoutedEventArgs e)
        {

            //try
            //{
            //    logic.editEmpleado(id_empleado, tbNombre.Text, tbApellido.Text, Convert.ToDateTime(dtpAnnoContrato.Text), cbCargo.Text, Convert.ToInt32(tbSueldo.Text), Convert.ToDateTime(dtpHorario.Text), idCargo, tbAccesoUsername.Text);
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show("Se deben llenar todos los campos");
            //}


        }
    }
}