using CapaNegocio;
using System;
using System.Windows;
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
            catch //(Exception ex) 
            { 
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
