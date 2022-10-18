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
            BtnEditar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
        }

        Business logic = new Business();
        string id_articulo;
        string nombre_articulo;
        string descripcion;
        string id_departamento;
        string nombre_departamento;
        string reservado;
        string id_categoria;
        string categoria;

        public void refreshDgDepartamento()
        {
            dgInvDepartamento.ItemsSource = null;
            dgInvDepartamento.ItemsSource = logic.DepartamentoData().DefaultView;
        }

        public void refreshDgInventario()
        {
            dgInventario.ItemsSource = null;
            dgInventario.ItemsSource = logic.InventarioData().DefaultView;
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
                id_categoria = dr["CAT_INV_ID_CAT"].ToString(); 
                categoria = dr["CATEGORIA"].ToString();

                tbNombreArticulo.Text = nombre_articulo;
                tbIdArticulo.Text = id_articulo;

                BtnEditar.IsEnabled = true;
                BtnEliminar.IsEnabled = true;
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
            logic.deleteArticulo(id_articulo);
            tbNombreArticulo.Text = "";
            tbIdArticulo.Text = "";
            BtnEditar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            refreshDgInventario();
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            new CrearArticulo().Show();
        }


        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            refreshDgInventario();
            nombre_articulo = "";
            id_articulo = "";
            tbNombreArticulo.Text = nombre_articulo;
            tbIdArticulo.Text = id_articulo;
        }

        private void BtnIngresarInventario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDepartamentos_Click(object sender, RoutedEventArgs e)
        {
            new Departamentos().Show();
            this.Close();
        }

        private void BtnInvDepartamento_Click(object sender, RoutedEventArgs e)
        {
            new InventarioDep(id_departamento, nombre_departamento).Show();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            new EditarArticulo(id_articulo, nombre_articulo, descripcion, id_categoria).Show();
            refreshDgInventario();
        }

        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {
            new Inventario().Show();
            this.Close();
        }

        private void BtnConductores_Click(object sender, RoutedEventArgs e)
        {
            new Conductor().Show();
            this.Close();
        }

        private void BtnVehiculos_Click(object sender, RoutedEventArgs e)
        {
            new Vehiculo().Show();
            this.Close();
        }

    }
}
