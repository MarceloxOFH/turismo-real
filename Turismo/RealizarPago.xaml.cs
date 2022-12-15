using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using CapaNegocio;
using MahApps.Metro.Controls;
using Microsoft.Win32;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for RealizarPago.xaml
    /// </summary>
    public partial class RealizarPago : MetroWindow
    {
        public RealizarPago(Multa MUL, string id_multa, string descripcion, int costo, int nro_reserva)
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
            this.costo = costo;
            this.nro_reserva = nro_reserva;
        }

        Business logic = new Business();
        string metodo_pago;
        string id_multa;
        Multa MUL;
        int costo;
        int nro_reserva;
        string comprobante_transferencia;

        private void BtnConfirmarPago_Click(object sender, RoutedEventArgs e)
        {
           
                if (metodo_pago == "E")
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Confirmar Pago en Efectivo de: $" + tbMonto.Text, "Pago en Efectivo", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                    try
                    {
                        logic.PagarMulta(id_multa);

                        //tablas de pago
                        string id_pago = (Convert.ToInt32(logic.getIdPago()) + 1).ToString();
                        logic.newPago(id_pago, costo);
                        logic.newPagoReservaMulta(nro_reserva, id_pago, "Efectivo", "");

                        MUL.refreshDatagrid();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("BtnConfirmarPago_Click: " + ex);
                    }
                    }
                }
                else if (metodo_pago == "T")
                {
                try
                {
                    if (ImgImagen.Source != null)
                    {
                        MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Confirmar Pago con Transferencia de: $" + tbMonto.Text, "Pago con Transferencia", System.Windows.MessageBoxButton.YesNo);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            logic.PagarMulta(id_multa);

                            //tablas de pago
                            string id_pago = (Convert.ToInt32(logic.getIdPago()) + 1).ToString();
                            logic.newPago(id_pago, costo);
                            logic.newPagoReservaMulta(nro_reserva, id_pago, "Transferencia", comprobante_transferencia);

                            MUL.refreshDatagrid();
                            this.Close();
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Se debe subir el comprobante de transferencia");
                    }
                }
                catch //(Exception ex)
                { 
                
                }
                }
                else
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
            comprobante_transferencia = "";
            ImgImagen.Source = null;
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
            try
            {

                    OpenFileDialog fd = new OpenFileDialog();
                    if (fd.ShowDialog() == true)
                    {
                        ImgImagen.Source = new BitmapImage(new Uri(fd.FileName));
                        Stream stream = File.OpenRead(fd.FileName);
                        stream = File.OpenRead(fd.FileName);
                        byte[] binaryImage = new byte[stream.Length];
                        stream.Read(binaryImage, 0, (int)stream.Length);
                        comprobante_transferencia = logic.ConvertImageToBase64String(binaryImage);
                    }
                

            }
            catch
            {

            }
        }
    }
}
