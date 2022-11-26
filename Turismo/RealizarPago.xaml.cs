using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CapaNegocio;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for RealizarPago.xaml
    /// </summary>
    public partial class RealizarPago : MetroWindow
    {
        public RealizarPago(Multa MUL, string id_multa, string descripcion, int costo)
        {
            InitializeComponent();
            this.MUL = MUL;
            BtnSubirComprobante.Visibility = Visibility.Hidden;
            ImgImagen.Visibility = Visibility.Hidden;
            RtFoto.Visibility = Visibility.Hidden;
            lblEfectivo.Visibility = Visibility.Hidden;
            lblTransferencia.Visibility = Visibility.Hidden;
            BtnConfirmarPago.Visibility = Visibility.Hidden;
            RtEfectivo.Visibility = Visibility.Hidden;
            RtTransferencia.Visibility = Visibility.Hidden;
            tbMonto.Text = costo.ToString();
            this.id_multa = id_multa;
            tbMonto.Text = costo.ToString();
            tbIdMulta.Text = id_multa;
            tbDescripcion.Text = descripcion;
            RtEfectivoSeleccionado.Visibility = Visibility.Hidden;
            RtTransferenciaSeleccionado.Visibility = Visibility.Hidden;
        }

        Business logic = new Business();
        string metodo_pago;
        string id_multa;
        Multa MUL;

        private void BtnConfirmarPago_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (metodo_pago == "E")
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Confirmar Pago en Efectivo de: $" + tbMonto.Text, "Pago en Efectivo", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        logic.PagarMulta(id_multa);

                        MUL.refreshDatagrid();
                        this.Close();
                    }
                }
                else if (metodo_pago == "T")
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Confirmar Pago con Transferencia de: $" + tbMonto.Text, "Pago con Transferencia", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        MUL.refreshDatagrid();
                        this.Close();
                    }
                }
                else
                {

                }
            }
            catch
            {

            }
        }

        private void BtnEfectivo_Click(object sender, RoutedEventArgs e)
        {
            RtTransferencia.Visibility = Visibility.Hidden;
            RtEfectivo.Visibility = Visibility.Visible;
            lblTransferencia.Visibility = Visibility.Hidden;
            lblEfectivo.Visibility = Visibility.Visible;
            ImgImagen.Visibility = Visibility.Hidden;
            RtFoto.Visibility = Visibility.Hidden;
            BtnEfectivo.IsEnabled = false;
            BtnTransferencia.IsEnabled = true;
            BtnSubirComprobante.Visibility = Visibility.Hidden;
            BtnConfirmarPago.Visibility = Visibility.Visible;
            metodo_pago = "E";
            RtEfectivoSeleccionado.Visibility = Visibility.Visible;
            RtTransferenciaSeleccionado.Visibility = Visibility.Hidden;
        }

        private void BtnTransferencia_Click(object sender, RoutedEventArgs e)
        {
            RtEfectivo.Visibility = Visibility.Hidden;
            RtTransferencia.Visibility = Visibility.Visible;
            lblEfectivo.Visibility= Visibility.Hidden;
            lblEfectivo.Visibility = Visibility.Hidden;
            lblTransferencia.Visibility = Visibility.Visible;
            BtnTransferencia.IsEnabled = false;
            BtnEfectivo.IsEnabled = true;
            BtnSubirComprobante.Visibility = Visibility.Visible;
            ImgImagen.Visibility = Visibility.Visible;
            RtFoto.Visibility = Visibility.Visible;
            BtnConfirmarPago.Visibility = Visibility.Visible;
            metodo_pago = "T";
            RtEfectivoSeleccionado.Visibility = Visibility.Hidden;
            RtTransferenciaSeleccionado.Visibility = Visibility.Visible;
        }

        private void BtnSubirComprobante_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
