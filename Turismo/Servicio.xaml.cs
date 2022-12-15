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
using MahApps.Metro.Controls;
using System.Data;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for Servicio.xaml
    /// </summary>
    public partial class Servicio : MetroWindow
    {
        public Servicio(string id_departamento, string nombre_departamento)
        {
            InitializeComponent();
            dgOtrosServicios.Visibility = Visibility.Hidden;
            dgServiciosActuales.ItemsSource = logic.ServiciosActuales(id_departamento).DefaultView;
            dgOtrosServicios.ItemsSource = logic.ServiciosOtros().DefaultView;

            this.id_departamento = id_departamento;
            this.nombre_departamento = nombre_departamento;
            tbidDepartamento.Text = id_departamento;
            tbnombreDepartamento.Text = nombre_departamento;
            rtBtnOtrSer.Visibility = Visibility.Hidden;
            BtnServiciosActuales.IsEnabled = false;

            tbidDepartamento.Text = id_departamento;
            tbnombreDepartamento.Text = nombre_departamento;

            btnCrear.IsEnabled = false;
            btnEditar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
        }


        Business logic = new Business();
        string id_departamento;
        string nombre_departamento;
        string id_servicio;
        string nombre_servicio;
        string descripcion;
        int costo;
        bool tab = true;

        private void refreshDatagridSerAct()
        {
            dgServiciosActuales.ItemsSource = null;
            dgServiciosActuales.ItemsSource = logic.ServiciosActuales(id_departamento).DefaultView;
        }
        private void refreshDatagridOtrSer()
        {
            dgOtrosServicios.ItemsSource = null;
            dgOtrosServicios.ItemsSource = logic.ServiciosOtros().DefaultView;
        }
        private void BtnServiciosActuales_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagridSerAct();
            dgOtrosServicios.Visibility = Visibility.Hidden;
            dgServiciosActuales.Visibility = Visibility.Visible;
            rtBtnOtrSer.Visibility = Visibility.Hidden;
            rtBtnSerAct.Visibility = Visibility.Visible;
            BtnServiciosActuales.IsEnabled = false;
            BtnOtrosServicios.IsEnabled = true;
            btnCrear.IsEnabled = false;
            btnEditar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            tab = true;
        }

        private void BtnOtrosServicios_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagridOtrSer();
            dgServiciosActuales.Visibility = Visibility.Hidden;
            dgOtrosServicios.Visibility = Visibility.Visible;
            rtBtnSerAct.Visibility = Visibility.Hidden;
            rtBtnOtrSer.Visibility = Visibility.Visible;
            BtnOtrosServicios.IsEnabled = false;
            BtnServiciosActuales.IsEnabled = true;
            btnCrear.IsEnabled = true;
            tab = false;
        }

        private void dgServiciosActuales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                id_servicio = dr["ID_SERVICIO"].ToString();
                nombre_servicio = dr["NOMBRE_SERVICIO"].ToString();
                descripcion = dr["DESCRIPCION"].ToString();
                costo = Convert.ToInt32(dr["COSTO"]);
                btnCrear.IsEnabled = false;
                btnEditar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
            }
        }

        private void dgOtrosServicios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                id_servicio = dr["ID_SERVICIO"].ToString();
                nombre_servicio = dr["NOMBRE_SERVICIO"].ToString();
                descripcion = dr["DESCRIPCION"].ToString();
                costo = Convert.ToInt32(dr["COSTO"]);
                btnCrear.IsEnabled = true;
                btnEditar.IsEnabled = true;
                btnEliminar.IsEnabled = true;
            }
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            new CrearServicio(id_departamento, id_servicio).Show();
            //logic.newServicio(nombre_servicio, descripcion, costo);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estás seguro que deseas borrar el servicio seleccionado", "Eliminar Servicio", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)

            logic.deleteServicio(id_servicio);
            refreshDatagridOtrSer();
            refreshDatagridSerAct();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            new EditarServicio(id_departamento, id_servicio, nombre_servicio, descripcion, costo).Show();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagridOtrSer();
            refreshDatagridSerAct();   
        }

        private void btnMoverServicio_Click(object sender, RoutedEventArgs e)
        {
            if (tab == true)
            {
                logic.deleteServAsoc(id_servicio, id_departamento);
                refreshDatagridOtrSer();
                refreshDatagridSerAct();
            }
            else if (tab == false)
            {
                logic.MoveServAsoc(id_servicio, id_departamento);
                refreshDatagridOtrSer();
                refreshDatagridSerAct();
            }
            else
            {
            }
        }
    }
}
