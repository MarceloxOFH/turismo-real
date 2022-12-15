using CapaNegocio;
using System;
using System.Windows;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Lógica de interacción para EditarMantención.xaml
    /// </summary>
    public partial class EditarMantención : MetroWindow
    {
        public EditarMantención(string id_departamento, string nombre_departamento, string id_mantencion, DateTime fecha_inicio, DateTime fecha_termino, int costo, string descripcion)
        {
            InitializeComponent();

            this.id_mantencion = id_mantencion;
            tbIdDepartamento.Text = id_departamento;
            tbNombre.Text = nombre_departamento;
            dpFechaInicio.Text = fecha_inicio.ToShortDateString();
            //tbHoraInicio.Text = fecha_inicio.ToString("HH");
            //tbMinutoInicio.Text = fecha_inicio.ToString("mm");
            dpFechaTermino.Text = fecha_termino.ToShortDateString();
            //tbHoraTermino.Text = fecha_termino.ToString("HH");
            //tbMinutoTermino.Text = fecha_termino.ToString("mm");
            tbCosto.Text = costo.ToString();
            tbDesccripcion.Text = descripcion;
        }

        Business logic = new Business();
        string id_mantencion;

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime? dtFechaInicio = dpFechaInicio.SelectedDate;
                string stFechaInicio = dtFechaInicio.Value.Date.ToString("dd/MM/yyyy") + " 00:00:00";
                DateTime fecha_inicio = DateTime.ParseExact(stFechaInicio, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                DateTime? dtFechaTermino = dpFechaTermino.SelectedDate;
                string stFechaTermino = dtFechaTermino.Value.Date.ToString("dd/MM/yyyy") + " 00:00:00";
                DateTime fecha_termino = DateTime.ParseExact(stFechaTermino, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);


                logic.editMantencion(tbIdDepartamento.Text, id_mantencion, fecha_inicio, fecha_termino, Convert.ToInt32(tbCosto.Text), tbDesccripcion.Text);

                MessageBox.Show("Se editó la mantención");
            }

            catch //(Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}
