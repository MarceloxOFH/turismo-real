using CapaNegocio;
using System;
using System.Windows;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for CrearMulta.xaml
    /// </summary>
    public partial class CrearMulta : MetroWindow
    {
        public CrearMulta(Multa MUL, int nro_reserva)
        {
            InitializeComponent();
            this.nro_reserva = nro_reserva;
            this.MUL = MUL;
        }

        Business logic = new Business();
        int nro_reserva;
        Multa MUL;


        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logic.newCheckOutAndMulta(nro_reserva, tbDescripcion.Text, Convert.ToInt32(tbCosto.Text));
                MUL.refreshDatagrid();
            }
            catch //(Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
