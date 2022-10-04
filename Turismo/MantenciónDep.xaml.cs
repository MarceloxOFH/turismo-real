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


namespace Turismo
{
    public partial class MantenciónDep : Window
    {
        public MantenciónDep(string id_departamento, string nombre_departamento)
        {
            InitializeComponent();
            dgMantencion.ItemsSource = logic.MantencionDepId(id_departamento).DefaultView;
            this.id_departamento = id_departamento;
            this.nombre_departamento = nombre_departamento;
            tbidDepartamento.Text = id_departamento;
            tbnombreDepartamento.Text = nombre_departamento;
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
                    refreshDatagrid();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un problema para eliminar la mantención seleccionada: " + ex);
                }
        }

        public void refreshDatagrid()
        {
            dgMantencion.ItemsSource = null;
            dgMantencion.ItemsSource = logic.MantencionDepId(id_departamento).DefaultView;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagrid();
        }
    }
}