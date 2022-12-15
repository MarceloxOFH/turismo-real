using CapaNegocio;
using System.Windows;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for EditarCategoria.xaml
    /// </summary>
    public partial class EditarCategoria : MetroWindow
    {
        public EditarCategoria(string id_categoria, string categoria, string descripcion)
        {
            InitializeComponent();
            tbIdCategoria.Text = id_categoria;
            tbCategoria.Text = categoria;
            tbDescripcion.Text = descripcion;
        }

        Business logic = new Business();

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            logic.editCategoria(tbIdCategoria.Text, tbCategoria.Text, tbDescripcion.Text);
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
