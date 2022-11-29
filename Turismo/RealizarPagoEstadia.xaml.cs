using CapaNegocio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for RealizarPagoEstadia.xaml
    /// </summary>
    public partial class RealizarPagoEstadia : MetroWindow
    {
        public RealizarPagoEstadia(CrearCheckIn CCI, int nro_reserva, string rut_cliente, string nombres, int pago_estadia, string condicion_departamento, string firma_cliente, string anotaciones)
        {
            InitializeComponent();
            this.CCI = CCI;
            BtnSubirComprobante.Visibility = Visibility.Hidden;
            ImgImagen.Visibility = Visibility.Hidden;
            RtFoto.Visibility = Visibility.Hidden;
            lblEfectivo.Visibility = Visibility.Hidden;
            lblTransferencia.Visibility = Visibility.Hidden;
            BtnConfirmarPago.Visibility = Visibility.Hidden;
            RtEfectivo.Visibility = Visibility.Hidden;
            RtTransferencia.Visibility = Visibility.Hidden;
            tbMonto.Text = pago_estadia.ToString();
            this.nro_reserva = nro_reserva;
            tbNumeroReserva.Text = nro_reserva.ToString();
            tbRutCliente.Text = rut_cliente;
            tbNombreCliente.Text = nombres;
            RtEfectivoSeleccionado.Visibility = Visibility.Hidden;
            RtTransferenciaSeleccionado.Visibility = Visibility.Hidden;
            this.pago_estadia = pago_estadia;
        }

        Business logic = new Business();
        string metodo_pago;
        string id_multa;
        CrearCheckIn CCI;
        int pago_estadia;
        int nro_reserva;
        string comprobante_transferencia;
        string condicion_departamento;
        string firma_cliente;
        string anotaciones;

        private void BtnConfirmarPago_Click(object sender, RoutedEventArgs e)
        {

            if (metodo_pago == "E")
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Confirmar Pago en Efectivo de: $" + tbMonto.Text, "Pago en Efectivo", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    try
                    {
                        logic.newCheckIn(condicion_departamento, pago_estadia, nro_reserva, firma_cliente, anotaciones);

                        //tablas de pago
                        string id_pago = (Convert.ToInt32(logic.getIdPago()) + 1).ToString();
                        logic.newPago(id_pago, pago_estadia);
                        logic.newPagoReservaEstadía(nro_reserva, id_pago, "Efectivo", "");

                        CCI.Close();
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
                            logic.newCheckIn(condicion_departamento, pago_estadia, nro_reserva, firma_cliente, anotaciones);

                            //tablas de pago
                            string id_pago = (Convert.ToInt32(logic.getIdPago()) + 1).ToString();
                            logic.newPago(id_pago, pago_estadia);
                            logic.newPagoReservaEstadía(nro_reserva, id_pago, "Transferencia", comprobante_transferencia);

                            CCI.Close();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se debe subir el comprobante de transferencia");
                    }
                }
                catch (Exception ex)
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
            lblEfectivo.Visibility = Visibility.Hidden;
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
