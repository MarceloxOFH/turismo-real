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
    /// <summary>
    /// Interaction logic for Inventario.xaml
    /// </summary>
    public partial class Inventario : Window
    {
        public Inventario()
        {
            InitializeComponent();
            dgInventario.ItemsSource = logic.InventarioData().DefaultView;
            dgInvDepartamento.ItemsSource = logic.DepartamentoData().DefaultView;
        }

        Business logic = new Business();
        string id_articulo;
        string nombre_articulo;
        string descripcion;
        string id_departamento;
        string nombre_departamento;
        string reservado;

        public void refreshDatagrid()
        {
            dgInventario.ItemsSource = null;
            dgInvDepartamento.ItemsSource = null;
            dgInventario.ItemsSource = logic.InventarioData().DefaultView;
            dgInvDepartamento.ItemsSource = logic.DepartamentoData().DefaultView;
        }

        private void dgInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                id_articulo = dr["ID_ARTICULO"].ToString();
                nombre_articulo = dr["NOMBRE_ARTICULO"].ToString();
                descripcion = dr["DESCRIPCION"].ToString();

                tbNombreArticulo.Text = nombre_articulo;
                tbIdArticulo.Text = id_articulo;
            }
        }

        private void dgInvDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                id_departamento = dr["ID_DEPARTAMENTO"].ToString();
                nombre_departamento = dr["NOMBRE"].ToString();
                reservado = dr["RESERVADO"].ToString();

                tbNombreDepartamento.Text = nombre_departamento;
                tbIdDepartamento.Text = id_departamento;
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            new InventarioDep(id_departamento, nombre_departamento).Show();
        }

        private void BtnIngresarInventario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDepartamentos_Click(object sender, RoutedEventArgs e)
        {
            new Departamentos().Show();
            this.Close();
        }
    }
}
