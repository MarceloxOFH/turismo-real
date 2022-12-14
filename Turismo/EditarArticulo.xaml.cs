using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for EditarArticulo.xaml
    /// </summary>
    public partial class EditarArticulo : MetroWindow
    {
        public EditarArticulo(string id_articulo, string nombre_articulo, string descripcion, string id_categoria)
        {
            InitializeComponent();
            this.id_articulo = id_articulo;
            this.nombre_articulo = nombre_articulo;
            this.descripcion = descripcion;
            this.id_categoria = id_categoria;
            tbId.Text = id_articulo;
            tbNombre.Text = nombre_articulo;
            tbDescripcion.Text = descripcion;
            //cbCategoria

            //COMBOBOX CATEGORIA
            DataTable dtr = logic.CategoriaData();
            cbCategoria.ItemsSource = dtr.AsDataView();
            cbCategoria.DisplayMemberPath = "CATEGORIA";
            cbCategoria.SelectedValuePath = "ID_CATEGORIA";
            cbCategoria.SelectedIndex = Convert.ToInt32(id_categoria) - 1;
            this.id_categoria = (Convert.ToInt32(cbCategoria.SelectedIndex) + 1).ToString();
        }

        Business logic = new Business();
        string id_articulo;
        string nombre_articulo;
        string descripcion;
        string id_categoria;

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            logic.editArticulo(tbId.Text, tbNombre.Text, tbDescripcion.Text, id_categoria);
        }

        private void cbCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.id_categoria = (Convert.ToInt32(cbCategoria.SelectedIndex) + 1).ToString();
        }
    }
}
