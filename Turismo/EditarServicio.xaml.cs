using System;
using System.Windows;
using CapaNegocio;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for EditarServicio.xaml
    /// </summary>
    public partial class EditarServicio : MetroWindow
    {
        public EditarServicio(string id_departamento, string id_servicio, string nombre_servicio, string descripcion, int costo)
        {
            InitializeComponent();
            this.id_servicio = id_servicio;
            tbNombreServicio.Text = nombre_servicio;
            tbCosto.Text = costo.ToString();
            tbDescripcion.Text = descripcion; 
        }

        Business logic = new Business();
        string id_departamentp;
        string id_servicio;

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("id_servicio: " + id_servicio);
            logic.editServicio(id_servicio, tbNombreServicio.Text, tbDescripcion.Text, Convert.ToInt32(tbCosto.Text));
        }
    }
}
