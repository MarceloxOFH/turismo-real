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
using System.Windows.Shapes;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for CrearAcceso.xaml
    /// </summary>
    public partial class CrearAcceso : MetroWindow
    {

        Business logic = new Business();

        public CrearAcceso()
        {
            InitializeComponent();

        }
        private void btnCrearAcceso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logic.newAcceso(tbUsername.Text, tbContraseña.Text, tbEmail.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}
