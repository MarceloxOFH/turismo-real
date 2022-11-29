using CapaNegocio;
using MahApps.Metro.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for CrearCargo.xaml
    /// </summary>
    public partial class CrearCargo : MetroWindow
    {

        Business logic = new Business();
        Empleados emp = new Empleados();

        public CrearCargo()
        {
            InitializeComponent();
        }

        private void btnCrearCargo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logic.newCargo(tbCargoNombre.Text, tbDescripcion.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}