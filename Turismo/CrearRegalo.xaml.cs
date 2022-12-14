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
    /// Interaction logic for CrearRegalo.xaml
    /// </summary>
    public partial class CrearRegalo : MetroWindow
    {
        Business logic = new Business();
        Regalos rega = new Regalos();
        public CrearRegalo()
        {
            InitializeComponent();
        }

        private void btnCrearRegalo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logic.newRegalo(tbContenido.Text, Convert.ToInt32(tbValor.Text));
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}
