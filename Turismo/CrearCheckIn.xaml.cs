using CapaNegocio;
using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for CrearCheckIn.xaml
    /// </summary>
    public partial class CrearCheckIn : MetroWindow
    {

        string firma_cliente;
        Business logic = new Business();
        int nro_reserva;
        string contenido;
        string regalo_id_regalo;
        CheckIn che = new CheckIn();
        int pago_estadia;
        string condicion_departamento;
        string nombre_completo;
        string rut_cliente;
        bool firma_subida = false;
        string regalo;
        string id_regalo;
        bool combobox_regalo = false;

        public CrearCheckIn(int nro_reserva, int pago_estadia, string nombre_completo, string rut_cliente)
        {
            InitializeComponent();
            this.nro_reserva = nro_reserva;
            this.pago_estadia = pago_estadia;
            this.nombre_completo = nombre_completo;
            this.rut_cliente = rut_cliente;
            lblMontoPago.Content = pago_estadia;

            tbNumeroReserva.Text = nro_reserva.ToString();
            tbRutCliente.Text = rut_cliente;
            tbNombreCliente.Text = nombre_completo;
            //REGALO COMBOBOX
            DataTable dtreg = logic.dtestadoRegaloInData();
            cbRegalo.ItemsSource = dtreg.AsDataView();
            cbRegalo.DisplayMemberPath = "CONTENIDO";
            cbRegalo.SelectedValuePath = "ID_REGALO";

        }




        private void btnSubirFirma_Click(object sender, RoutedEventArgs e)
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
                firma_cliente = logic.ConvertImageToBase64String(binaryImage);
                firma_subida = true;
                LblFirma.Content = "✓ Firma subida";
                LblFirma.Foreground = System.Windows.Media.Brushes.DarkGreen;
            }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
        }

        private void btnRealizarPagoEstadia_Click(object sender, RoutedEventArgs e)
        {
            if (firma_subida == true && combobox_regalo == true)
            {
                try
                {
                    RealizarPagoEstadia RPE = new RealizarPagoEstadia(this, nro_reserva, tbRutCliente.Text, tbNombreCliente.Text, pago_estadia, tbCondicionDepto.Text, firma_cliente, tbAnotaciones.Text, id_regalo);
                    RPE.Show();
                    this.Close();
                    //logic.newCheckIn(tbCondicionDepto.Text, Convert.ToDateTime(dpHoraIngreso.Text), Convert.ToInt32(tbPagoEstadia.Text), Convert.ToInt32(cbNroReserva.Text), firma_cliente, regalo_id_regalo, cbCheckActivo.Text, tbAnotaciones.Text);
                }

                catch //(Exception ex)
                {
                    //MessageBox.Show("Se debe subir la firma");
                }
            }
            else
            {
                MessageBox.Show("Verificar Firma y Regalo", "Error");
            }
        }

        private void cbRegalo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id_regalo = cbRegalo.SelectedValue.ToString();
                combobox_regalo = true;
            
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
}
    }
}