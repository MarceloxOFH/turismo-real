using CapaNegocio;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for CrearArticulo.xaml
    /// </summary>
    public partial class CrearArticulo : MetroWindow
    {
        public CrearArticulo()
        {
            InitializeComponent();
            //COMBOBOX CATEGORIA
            DataTable dtr = logic.CategoriaData();
            cbCategoria.ItemsSource = dtr.AsDataView();
            cbCategoria.DisplayMemberPath = "CATEGORIA";
            cbCategoria.SelectedValuePath = "ID_CATEGORIA";
        }

        Business logic = new Business();
        string id_categoria;

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
            logic.addArticulo(tbNombre.Text, tbDescripcion.Text, id_categoria);
            }
            
            catch //(Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
}

        private void cbCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            id_categoria = cbCategoria.SelectedValue.ToString();
        }
    }
}
