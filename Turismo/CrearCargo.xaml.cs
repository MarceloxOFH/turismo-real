using CapaNegocio;
using MahApps.Metro.Controls;
using System;
using System.Windows;

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

            catch //(Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}