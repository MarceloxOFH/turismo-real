using CapaNegocio;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for Inventario.xaml
    /// </summary>
    public partial class Inventario : MetroWindow
    {
        public Inventario()
        {
            InitializeComponent();
            LblUsuario.Content = Business.user_login;
            LblCargo.Content = Business.usertype_login;
            dgInventario.ItemsSource = logic.InventarioData().DefaultView;
            dgInvDepartamento.ItemsSource = logic.DepartamentoData().DefaultView;
            BtnEditar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            BtnInvDepartamento.IsEnabled = false;
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
        string region;

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

        public void limpiarCampos()
        {
            nombre_articulo = "";
            id_articulo = "";
            tbNombreArticulo.Text = nombre_articulo;
            tbIdArticulo.Text = id_articulo;
        }

        private void dgInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                DataRowView dr = dg.SelectedItem as DataRowView;
                if (dr != null)
                {
                    id_articulo = dr["ID_ARTICULO"].ToString();
                    nombre_articulo = dr["NOMBRE_ARTICULO"].ToString();
                    descripcion = dr["DESCRIPCION"].ToString();
                    id_categoria = dr["CATEGORIA_ID_CATEGORIA"].ToString();
                    categoria = dr["CATEGORIA"].ToString();

                    tbNombreArticulo.Text = nombre_articulo;
                    tbIdArticulo.Text = id_articulo;

                    BtnEditar.IsEnabled = true;
                    BtnEliminar.IsEnabled = true;
                }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
        }

        private void dgInvDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            { 
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                id_departamento = dr["ID_DEPARTAMENTO"].ToString();
                nombre_departamento = dr["NOMBRE"].ToString();
                region = dr["REGION"].ToString();

                tbNombreDepartamento.Text = nombre_departamento;
                tbIdDepartamento.Text = id_departamento;
                BtnInvDepartamento.IsEnabled = true;
            }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
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

        private void BtnGestionarCategorias_Click(object sender, RoutedEventArgs e)
        {
            new Categoria().Show();
        }

        private void BtnDepartamentos_Click_1(object sender, RoutedEventArgs e)
        {
            new Departamentos().Show();
        }


        private void BtnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            new CheckOut().Show();
            this.Close();
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void BtnEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            new Estadisticas().Show();
            this.Close();
        }

        private void BtnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            new Empleados().Show();
            this.Close();
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            new Clientes().Show();
            this.Close();
        }

        private void BtnCheckIn_Click(object sender, RoutedEventArgs e)
        {
            new CheckIn().Show();
            this.Close();
        }

        private void BtnPagos_Click(object sender, RoutedEventArgs e)
        {
            new Pago().Show();
            this.Close();
        }
    }
}
