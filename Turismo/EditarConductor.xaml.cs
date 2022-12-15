using CapaNegocio;
using System;
using System.Windows;
using MahApps.Metro.Controls;


namespace Turismo
{
    /// <summary>
    /// Interaction logic for EditarConductor.xaml
    /// </summary>
    public partial class EditarConductor : MetroWindow
    {
        public EditarConductor(string rut_conductor, string nombres, string apellidos, DateTime caducidad_licencia, string disponibilidad, int sueldo)
        {
            InitializeComponent();
            tbRut.Text = rut_conductor;
            cbDisponibilidad.Text = disponibilidad;
            tbNombres.Text = nombres;
            tbApellidos.Text = apellidos;
            dpCaducidadLicencia.Text = caducidad_licencia.ToShortDateString();
            tbSueldo.Text = sueldo.ToString();
            this.caducidad_licencia = caducidad_licencia;
            
        }

        Business logic = new Business();
        DateTime caducidad_licencia;

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime? dtCaducidadLicencia = dpCaducidadLicencia.SelectedDate;

                string stCaducidadLicencia = dtCaducidadLicencia.Value.Date.ToString("dd/MM/yyyy") + " 00:00";

                caducidad_licencia = DateTime.ParseExact(stCaducidadLicencia, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                logic.editConductor(tbRut.Text, tbNombres.Text, tbApellidos.Text, caducidad_licencia, cbDisponibilidad.Text, Convert.ToInt32(tbSueldo.Text));
            }

            catch //(Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}
