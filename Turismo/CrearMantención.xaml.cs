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
                DateTime? dtFechaInicio = dpFechaInicio.SelectedDate;
                string stFechaInicio = dtFechaInicio.Value.Date.ToString("dd/MM/yyyy") + " 00:00:00";
                DateTime fecha_inicio = DateTime.ParseExact(stFechaInicio, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                DateTime? dtFechaTermino = dpFechaTermino.SelectedDate;
                string stFechaTermino = dtFechaTermino.Value.Date.ToString("dd/MM/yyyy") + " 00:00:00";
                DateTime fecha_termino = DateTime.ParseExact(stFechaTermino, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                logic.newMantencion(tbIdDepartamento.Text, fecha_inicio, fecha_termino, Convert.ToInt32(tbCosto.Text), tbDesccripcion.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}
