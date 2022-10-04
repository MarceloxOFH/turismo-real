using CapaNegocio;
using System;
using System.Collections.Generic;
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
    public partial class InventarioDep : Window
    {
        public InventarioDep(string id_departamento, string nombre_departamento)
        {
            InitializeComponent();
            dgInvDepartamento.ItemsSource = logic.getInventarioDep(id_departamento).DefaultView;
            rtBtnInvGen.Visibility = Visibility.Hidden;
            this.id_departamento = id_departamento;
            tbIdDepartamento.Text = id_departamento;
            tbNombreDepartamento.Text = nombre_departamento;
        }

        Business logic = new Business();
        string id_departamento;

        private void dgInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnInventarioDepartamento_Click(object sender, RoutedEventArgs e)
        {
            BtnInventarioDepartamento.IsEnabled = false;
            BtnInventarioGeneral.IsEnabled = true;
            rtBtnInvDep.Visibility = Visibility.Visible;
            rtBtnInvGen.Visibility = Visibility.Hidden;
            lblTipoInventario.Content = "Inventario Departamento";
            refreshDgInvDepartamento();
            dgInvDepartamento.Visibility = Visibility.Visible;
            dgInvGeneral.Visibility = Visibility.Hidden;
        }

        private void BtnInventarioGeneral_Click(object sender, RoutedEventArgs e)
        {
            BtnInventarioGeneral.IsEnabled = false;
            BtnInventarioDepartamento.IsEnabled = true;
            rtBtnInvGen.Visibility = Visibility.Visible;
            rtBtnInvDep.Visibility = Visibility.Hidden;
            lblTipoInventario.Content = "Inventario General";
            refreshDgInvGeneral();
            dgInvGeneral.Visibility = Visibility.Visible;
            dgInvDepartamento.Visibility = Visibility.Hidden;
        }

        public void refreshDgInvDepartamento()
        {
            dgInvDepartamento.ItemsSource = null;
            dgInvDepartamento.ItemsSource = logic.getInventarioDep(id_departamento).DefaultView;
        }

        public void refreshDgInvGeneral()
        {
            dgInvGeneral.ItemsSource = null;
            dgInvGeneral.ItemsSource = logic.InventarioData().DefaultView;
        }

        private void dgInvGeneral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
