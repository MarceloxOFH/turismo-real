using CapaNegocio;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            tbHoraInicio.Text = fecha_inicio.ToString("HH");
            tbMinutoInicio.Text = fecha_inicio.ToString("mm");
            dpFechaTermino.Text = fecha_termino.ToShortDateString();
            tbHoraTermino.Text = fecha_termino.ToString("HH");
            tbMinutoTermino.Text = fecha_termino.ToString("mm");
            tbCosto.Text = costo.ToString();
            tbDesccripcion.Text = descripcion;
        }

        Business logic = new Business();
        string id_mantencion;

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime? dtFechaHoraInicio = dpFechaInicio.SelectedDate;
                DateTime? dtFechaHoraTermino = dpFechaTermino.SelectedDate;

                string stFechaHoraInicio = dtFechaHoraInicio.Value.Date.ToString("dd/MM/yyyy") + " " + tbHoraInicio.Text + ":" + tbMinutoInicio.Text;
                string stFechaHoraTermino = dtFechaHoraTermino.Value.Date.ToString("dd/MM/yyyy") + " " + tbHoraTermino.Text + ":" + tbMinutoTermino.Text;

                DateTime fechaInicio = DateTime.ParseExact(stFechaHoraInicio, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                DateTime fechaTermino = DateTime.ParseExact(stFechaHoraTermino, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                logic.editMantencion(tbIdDepartamento.Text, id_mantencion, fechaInicio, fechaTermino, Convert.ToInt32(tbCosto.Text), tbDesccripcion.Text);

                MessageBox.Show("Se editó la mantención");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}
