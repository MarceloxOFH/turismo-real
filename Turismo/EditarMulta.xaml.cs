using CapaNegocio;
using System;
using System.Windows;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for EditarMulta.xaml
    /// </summary>
    public partial class EditarMulta : MetroWindow
    {
        public EditarMulta(Multa MUL, string id_multa, string descripcion, int costo)
        {
            InitializeComponent();
            tbIdMulta.Text = id_multa;
            tbDescripcion.Text = descripcion;
            tbCosto.Text = costo.ToString();
            this.id_multa = id_multa;
            this.descripcion = descripcion;
            this.costo = costo;
            this.MUL = MUL;
        }

        Business logic = new Business();
        Multa MUL;
        string id_multa;
        string descripcion;
        int costo;

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logic.editMulta(id_multa, tbDescripcion.Text, Convert.ToInt32(tbCosto.Text));
                MUL.refreshDatagrid();
            }
            catch 
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
