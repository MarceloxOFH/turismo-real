using CapaNegocio;
using System;
using System.Windows;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for CrearConductor.xaml
    /// </summary>
    public partial class CrearConductor : MetroWindow
    {
        public CrearConductor()
        {
            InitializeComponent();
        }

        Business logic = new Business();

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime? dtCaducidadLicencia = dpCaducidadLicencia.SelectedDate;

                string stCaducidadLicencia = dtCaducidadLicencia.Value.Date.ToString("dd/MM/yyyy") + " 00:00:00";

                DateTime caducidad_licencia = DateTime.ParseExact(stCaducidadLicencia, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                logic.newConductor(tbRut.Text, tbNombres.Text, tbApellidos.Text, caducidad_licencia, cbDisponibilidad.Text, Convert.ToInt32(tbSueldo.Text));
            }

            catch //(Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}
