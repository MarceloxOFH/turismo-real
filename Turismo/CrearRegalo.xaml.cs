using CapaNegocio;
using System;
using System.Windows;
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

            catch //(Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}
