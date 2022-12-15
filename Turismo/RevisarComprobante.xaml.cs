using System.Windows;
using CapaNegocio;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for RevisarComprobante.xaml
    /// </summary>
    public partial class RevisarComprobante : MetroWindow
    {
        public RevisarComprobante(int nro_reserva, string id_pago)
        {
            InitializeComponent();

            try
            {
                this.id_pago = id_pago;
                comprobante = logic.GetComprobanteFromPago(id_pago);
                estado = logic.GetEstadoFromPago(id_pago);

                lblEstado.Content = estado;

                logic.fromStringToPhoto(comprobante, ImgImagen);


                BtnValidarPago.IsEnabled = false;

                if (estado == "POR CONFIRMAR")
                {
                    BtnValidarPago.IsEnabled = true;
                }
            }
            catch
            { 
            }
        }

        string comprobante;
        string estado;
        string id_pago;

        Business logic = new Business();

        private void BtnValidarPago_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logic.ValidarPago(id_pago);
            }
            catch
            { 
            }
        }
    }
}
