using CapaNegocio;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using MahApps.Metro.Controls;

namespace Turismo
{
    public partial class InventarioDep : MetroWindow
    {
        public InventarioDep(string id_departamento, string nombre_departamento)
        {
            InitializeComponent();
            dgInvDepartamento.ItemsSource = logic.getInventarioDep(id_departamento).DefaultView;
            rtBtnInvGen.Visibility = Visibility.Hidden;
            this.id_departamento = id_departamento;
            tbIdDepartamento.Text = id_departamento;
            tbNombreDepartamento.Text = nombre_departamento;
            BtnAgregarArticulo.Visibility = Visibility.Hidden;
            BtnAgregarArticulo.IsEnabled = false;
            BtnEditarArticulo.IsEnabled = false;


        }

        Business logic = new Business();
        string id_departamento;
        string id_articulo;
        string nombre_articulo;
        int valor;
        int cantidad;
        int cantidad_temp;
        int valor_inventario;


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
                valor = Convert.ToInt32(dr["VALOR"]);
                cantidad = Convert.ToInt32(dr["CANTIDAD"]);
                cantidad_temp = cantidad - cantidad * 2;

                tbCantidad.Text = cantidad.ToString();
                tbValor.Text = valor.ToString();

                tbArticuloSeleccionado.Text = nombre_articulo;
                tbIdArticulo.Text = id_articulo;

                BtnEditarArticulo.IsEnabled = true;
            }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
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
            BtnAgregarArticulo.Visibility = Visibility.Hidden;
            BtnEditarArticulo.Visibility = Visibility.Visible;
            tbArticuloSeleccionado.Text = "";
            tbIdArticulo.Text = "";
            id_articulo = "";
            nombre_articulo = "";
            lbldescripcion.Content = "Modificar inventario de departamento";
            BtnAgregarArticulo.IsEnabled = false;
            BtnEditarArticulo.IsEnabled = false;
            tbValor.Text = "";
            tbCantidad.Text = "";
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
            BtnEditarArticulo.Visibility = Visibility.Hidden;
            BtnAgregarArticulo.Visibility = Visibility.Visible;
            tbArticuloSeleccionado.Text = "";
            tbIdArticulo.Text = "";
            id_articulo = "";
            nombre_articulo = "";
            lbldescripcion.Content = "Agregar articulo a departamento";
            BtnAgregarArticulo.IsEnabled = false;
            BtnEditarArticulo.IsEnabled = false;
            tbCantidad.Text = "1";
            tbValor.Text = "";
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
            try
            { 
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                id_articulo = dr["ID_ARTICULO"].ToString();
                nombre_articulo = dr["NOMBRE_ARTICULO"].ToString();

                tbArticuloSeleccionado.Text = nombre_articulo;
                tbIdArticulo.Text = id_articulo;

                BtnAgregarArticulo.IsEnabled = true;
            }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
        }

        private void BtnAgregarArticulo_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            if (Convert.ToInt32(tbCantidad.Text) > 0)
            {
                try
                {
                    logic.addDepaInventario(Convert.ToInt32(tbValor.Text), Convert.ToInt32(tbCantidad.Text), tbIdArticulo.Text, id_departamento);
                    valor_inventario = logic.GetIventarioValor(id_departamento);
                    logic.UpdateInventarioValor(id_departamento, valor_inventario);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se deben llenar todos los campos", "Error");
                }
            }
            else 
            {
                MessageBox.Show("La cantidad debe ser un número positivo", "Error");
            }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
        }

        private void BtnEditarArticulo_Click(object sender, RoutedEventArgs e)
        {
             try
             {
                if (Convert.ToInt32(tbCantidad.Text) < 0)
                {
                    MessageBox.Show("La cantidad no puede ser un número negativo", "Error");
                }

                if (Convert.ToInt32(tbCantidad.Text) > 0)
                {
                    logic.editDepaInventario(Convert.ToInt32(tbValor.Text), Convert.ToInt32(tbCantidad.Text), tbIdArticulo.Text, id_departamento);
                    valor_inventario = logic.GetIventarioValor(id_departamento);
                    logic.UpdateInventarioValor(id_departamento, valor_inventario);
                    refreshDgInvDepartamento();
                }

                else if (Convert.ToInt32(tbCantidad.Text) == 0)
                {
                    logic.deleteDepaInventario(id_articulo, id_departamento);
                    valor_inventario = logic.GetIventarioValor(id_departamento);
                    logic.UpdateInventarioValor(id_departamento, valor_inventario);
                    tbValor.Text = "";
                    tbCantidad.Text = "";
                    refreshDgInvDepartamento();
                }   
            }
             catch //(Exception ex)
             {
                MessageBox.Show("Se deben llenar todos los campos","Error");
             }
        }

        private void BtnAgregarMas_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (tbCantidad.Text != "" && id_articulo != "")
                {
                    tbCantidad.Text = (Convert.ToInt32(tbCantidad.Text) + 1).ToString();
                }
            }
            catch 
            { 
            
            }
        }

        private void BtnAgregarMenos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbCantidad.Text != "" && id_articulo != "" && tbCantidad.Text != "0")
                {
                    tbCantidad.Text = (Convert.ToInt32(tbCantidad.Text) - 1).ToString();
                }
            }
            catch
            {

            }
        }
    }
}
