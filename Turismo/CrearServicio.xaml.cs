using CapaNegocio;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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
