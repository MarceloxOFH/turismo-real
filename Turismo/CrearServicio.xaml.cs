using CapaNegocio;
using MahApps.Metro.Controls;
using System;
using System.Windows;


namespace Turismo
{
    /// <summary>
    /// Interaction logic for CrearServicio.xaml
    /// </summary>
    public partial class CrearServicio : MetroWindow
    {
        public CrearServicio(string id_departamento, string id_servicio)
        {
            InitializeComponent();
        }

        Business logic = new Business();
        //string id_departamentp;
        //string id_servicio;
        //string nombre_servicio;

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            logic.newServicio(tbNombreServicio.Text, tbDescripcion.Text, Convert.ToInt32(tbCosto.Text));
        }
    }
}
