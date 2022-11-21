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
using MahApps.Metro.Controls;


namespace Turismo
{
    public partial class MantenciónDep : MetroWindow
    {
        public MantenciónDep(string id_departamento, string nombre_departamento)
        {
            InitializeComponent();
            dgMantencionTerminada.Visibility = Visibility.Hidden;
            dgMantencion.ItemsSource = logic.MantencionDepId(id_departamento).DefaultView;
            dgMantencionTerminada.ItemsSource = logic.MantencionTerminadaDepId(id_departamento).DefaultView;
            btnEditar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            this.id_departamento = id_departamento;
            this.nombre_departamento = nombre_departamento;
            tbidDepartamento.Text = id_departamento;
            tbnombreDepartamento.Text = nombre_departamento;
            rtBtnManTer.Visibility = Visibility.Hidden;
            BtnMantencionesAgendadas.IsEnabled = false;
        }

        Business logic = new Business();
        string id_departamento;
        string nombre_departamento;
        string id_mantencion;
        DateTime fecha_inicio;
        DateTime fecha_termino;
        int costo;
        string descripcion;

        private void dgMantencion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                id_mantencion = dr["ID_MANTENCION"].ToString();
                fecha_inicio = DateTime.Parse(dr["FECHA_INICIO"].ToString());
                fecha_termino = DateTime.Parse(dr["FECHA_TERMINO"].ToString());
                costo = Convert.ToInt32(dr["COSTO"]);
                descripcion = dr["DESCRIPCION"].ToString();

                btnEditar.IsEnabled = true;
                btnEliminar.IsEnabled = true;
            }
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            new CrearMantención(id_departamento, nombre_departamento).Show();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            new EditarMantención(id_departamento, nombre_departamento, id_mantencion, fecha_inicio, fecha_termino, costo, descripcion).Show();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estás seguro que deseas borrar esta mantención?", "Caption", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)

                try
                {
                    logic.deleteMantención(id_mantencion);
                    refreshDatagridManTer();
                    refreshDatagridManAge();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un problema para eliminar la mantención seleccionada: " + ex);
                }
        }

        public void refreshDatagridManTer()
        {
            dgMantencionTerminada.ItemsSource = null;
            dgMantencionTerminada.ItemsSource = logic.MantencionTerminadaDepId(id_departamento).DefaultView;
        }

        public void refreshDatagridManAge()
        {
            dgMantencion.ItemsSource = null;
            dgMantencion.ItemsSource = logic.MantencionDepId(id_departamento).DefaultView;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagridManTer();
            refreshDatagridManAge();
        }

        private void btnMantencionesTerminadas_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagridManAge();
            refreshDatagridManTer();
            dgMantencion.Visibility = Visibility.Hidden;
            dgMantencionTerminada.Visibility = Visibility.Visible;
            rtBtnManAge.Visibility = Visibility.Hidden;
            rtBtnManTer.Visibility = Visibility.Visible;
            btnMantencionesTerminadas.IsEnabled = false;
            BtnMantencionesAgendadas.IsEnabled = true;
            
        }

        private void BtnMantencionesAgendadas_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagridManTer();
            refreshDatagridManAge();
            dgMantencionTerminada.Visibility = Visibility.Hidden;
            dgMantencion.Visibility = Visibility.Visible;
            rtBtnManTer.Visibility = Visibility.Hidden;
            rtBtnManAge.Visibility = Visibility.Visible;
            BtnMantencionesAgendadas.IsEnabled = false;
            btnMantencionesTerminadas.IsEnabled = true;
            
        }
    }
}