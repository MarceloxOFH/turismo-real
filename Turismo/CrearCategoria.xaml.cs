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
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for CrearCategoria.xaml
    /// </summary>
    public partial class CrearCategoria : MetroWindow
    {
        public CrearCategoria()
        {
            InitializeComponent();
        }

        Business logic = new Business();
        string categoria;
        string descripcion;

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                logic.newCategoria(tbCategoria.Text, tbDescripcion.Text);
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
