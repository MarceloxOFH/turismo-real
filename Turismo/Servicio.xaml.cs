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
    /// <summary>
    /// Interaction logic for Servicio.xaml
    /// </summary>
    public partial class Servicio : Window
    {
        public Servicio(string id_departamento, string nombre_departamento)
        {
            InitializeComponent();
            dgOtrosServicios.Visibility = Visibility.Hidden;
            dgServiciosActuales.ItemsSource = logic.ServiciosActuales(id_departamento).DefaultView;
            dgOtrosServicios.ItemsSource = logic.ServiciosOtros(id_departamento).DefaultView;

            this.id_departamento = id_departamento;
            this.nombre_departamento = nombre_departamento;
            tbidDepartamento.Text = id_departamento;
            tbnombreDepartamento.Text = nombre_departamento;
            rtBtnOtrSer.Visibility = Visibility.Hidden;
            BtnServiciosActuales.IsEnabled = false;
        }


        Business logic = new Business();
        string id_departamento;
        string nombre_departamento;

        private void refreshDatagridSerAct()
        {
            dgServiciosActuales.ItemsSource = null;
            dgServiciosActuales.ItemsSource = logic.ServiciosActuales(id_departamento).DefaultView;
        }
        private void refreshDatagridOtrSer()
        {
            dgOtrosServicios.ItemsSource = null;
            dgOtrosServicios.ItemsSource = logic.ServiciosOtros(id_departamento).DefaultView;
        }
        private void BtnServiciosActuales_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagridOtrSer();
            refreshDatagridSerAct();
            dgOtrosServicios.Visibility = Visibility.Hidden;
            dgServiciosActuales.Visibility = Visibility.Visible;
            rtBtnOtrSer.Visibility = Visibility.Hidden;
            rtBtnSerAct.Visibility = Visibility.Visible;
            BtnServiciosActuales.IsEnabled = false;
            BtnOtrosServicios.IsEnabled = true;
        }

        private void BtnOtrosServicios_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagridSerAct();
            refreshDatagridOtrSer();
            dgServiciosActuales.Visibility = Visibility.Hidden;
            dgOtrosServicios.Visibility = Visibility.Visible;
            rtBtnSerAct.Visibility = Visibility.Hidden;
            rtBtnOtrSer.Visibility = Visibility.Visible;
            BtnOtrosServicios.IsEnabled = false;
            BtnServiciosActuales.IsEnabled = true;
        }

        private void dgServiciosActuales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgOtrosServicios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
