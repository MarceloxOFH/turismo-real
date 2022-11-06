using CapaNegocio;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for EditarCategoria.xaml
    /// </summary>
    public partial class EditarCategoria : Window
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
