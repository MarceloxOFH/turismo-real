using CapaNegocio;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
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

                string stFechaHoraInicio = dtFechaHoraInicio.Value.Date.ToString("dd/MM/yyyy") + " " + tbHoraInicio.Text + ":" + tbMinutoInicio.Text + ":00";
                string stFechaHoraTermino = dtFechaHoraTermino.Value.Date.ToString("dd/MM/yyyy") + " " + tbHoraTermino.Text + ":" + tbMinutoTermino.Text + ":00";

                DateTime fechaInicio = DateTime.ParseExact(stFechaHoraInicio, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime fechaTermino = DateTime.ParseExact(stFechaHoraTermino, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                logic.newMantencion(tbIdDepartamento.Text, fechaInicio, fechaTermino, Convert.ToInt32(tbCosto.Text), tbDesccripcion.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }


    }
}
