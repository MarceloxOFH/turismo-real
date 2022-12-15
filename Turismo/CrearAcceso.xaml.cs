using CapaNegocio;
using MahApps.Metro.Controls;
using System;
using System.Windows;
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

            catch //(Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}
