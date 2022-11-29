using CapaNegocio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Turismo
{
    /// <summary>
    /// Interaction logic for CrearCheckIn.xaml
    /// </summary>
    public partial class CrearCheckIn : Window
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


        public CrearCheckIn(int nro_reserva, int pago_estadia, string nombre_completo, string rut_cliente)
        {
            InitializeComponent();
            this.nro_reserva = nro_reserva;
            this.pago_estadia = pago_estadia;
            this.nombre_completo = nombre_completo;
            this.rut_cliente = rut_cliente;

            tbNumeroReserva.Text = nro_reserva.ToString();
            tbRutCliente.Text = rut_cliente;
            tbNombreCliente.Text = nombre_completo;
            //REGALO COMBOBOX
            DataTable dter = logic.dtestadoRegaloInData();
            //cbRegalo.ItemsSource = dted.AsDataView();
            cbRegalo.DisplayMemberPath = "CONTENIDO";
            cbRegalo.SelectedValuePath = "ID_REGALO";


        }


        private void cbRegalo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            regalo_id_regalo = cbRegalo.SelectedValue.ToString();
            //MessageBox.Show(idEstado);
        }




        private void btnSubirFirma_Click(object sender, RoutedEventArgs e)
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
                LblFirma.Content = "✓ Firma subida";
                LblFirma.Foreground = System.Windows.Media.Brushes.DarkGreen;
            }
        }

        private void btnRealizarPagoEstadia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RealizarPagoEstadia RPE = new RealizarPagoEstadia(this, nro_reserva, tbRutCliente.Text, tbNombreCliente.Text, pago_estadia, tbCondicionDepto.Text, firma_cliente, tbAnotaciones.Text);
                RPE.Show();
                this.Close();
                //logic.newCheckIn(tbCondicionDepto.Text, Convert.ToDateTime(dpHoraIngreso.Text), Convert.ToInt32(tbPagoEstadia.Text), Convert.ToInt32(cbNroReserva.Text), firma_cliente, regalo_id_regalo, cbCheckActivo.Text, tbAnotaciones.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
        }
    }
}