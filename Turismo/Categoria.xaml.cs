using CapaNegocio;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for Categoria.xaml
    /// </summary>
    public partial class Categoria : MetroWindow
    {
        public Categoria()
        {
            InitializeComponent();

            dgCategoria.ItemsSource = logic.CategoriaData().DefaultView;

            BtnEliminar.IsEnabled = false;
            BtnEditar.IsEnabled = false;
        }

        Business logic = new Business();
        string id_categoria;
        string categoria;
        string descripcion;

        public void refreshDatagrid()
        {
            dgCategoria.ItemsSource = null;
            dgCategoria.ItemsSource = logic.CategoriaData().DefaultView;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estás seguro que deseas borrar la categoría '" + tbCategoria.Text + "'?", "Eliminar categoría", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)

            try
            {
                logic.deleteCategoria(id_categoria);
                refreshDatagrid();
                tbCategoria.Text = "";
                tbIdCategoria.Text = "";
                id_categoria = "";
                BtnEliminar.IsEnabled = false;
                BtnEditar.IsEnabled = false;
            }
            catch //(Exception ex) 
            {
                MessageBox.Show("Se debe seleccionar una categoría");
            }
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            new CrearCategoria().Show();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                new EditarCategoria(id_categoria, categoria, descripcion).Show();
            }
            catch //(Exception ex) 
            {
                MessageBox.Show("Se debe seleccionar una categoría");
            }
}

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagrid();
        }

        private void dgCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                id_categoria = dr["ID_CATEGORIA"].ToString();
                categoria = dr["CATEGORIA"].ToString();
                descripcion = dr["DESCRIPCION"].ToString();

                tbCategoria.Text = categoria;
                tbIdCategoria.Text = id_categoria;

                BtnEliminar.IsEnabled = true;
                BtnEditar.IsEnabled = true;
            }
        }
    }
}
