using CapaNegocio;
using System;
using System.Windows;
using MahApps.Metro.Controls;

namespace Turismo
{
    public partial class CrearMantención : MetroWindow
    {
        public CrearMantención(string id_departamento, string nombre_departamento)
        {
            InitializeComponent();
            tbIdDepartamento.Text = id_departamento;
            tbNombre.Text = nombre_departamento;
        }

        Business logic = new Business();

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime? dtFechaHoraInicio = dpFechaInicio.SelectedDate;
                DateTime? dtFechaHoraTermino = dpFechaTermino.SelectedDate;

                string stFechaHoraInicio = dtFechaHoraInicio.Value.Date.ToString("dd/MM/yyyy") + " " + tbHoraInicio.Text + ":" + tbMinutoInicio.Text;
                string stFechaHoraTermino = dtFechaHoraTermino.Value.Date.ToString("dd/MM/yyyy") + " " + tbHoraTermino.Text + ":" + tbMinutoTermino.Text;

                DateTime fechaInicio = DateTime.ParseExact(stFechaHoraInicio, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                DateTime fechaTermino = DateTime.ParseExact(stFechaHoraTermino, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                logic.newMantencion(tbIdDepartamento.Text, fechaInicio, fechaTermino, Convert.ToInt32(tbCosto.Text), tbDesccripcion.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}
