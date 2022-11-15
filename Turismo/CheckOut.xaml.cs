using CapaNegocio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
    public partial class CheckOut : Window
    {
        public CheckOut()
        {
            InitializeComponent();
            dgReserva.ItemsSource = logic.ReservaCOData().DefaultView;
            LblMulta.Content = "";
            LblMulta2.Content = "";
            LblFirma.Content = "";
            BtnGestionarMultas.IsEnabled = false;
            BtnSubirFirma.IsEnabled = false;

            //dgMulta.ItemsSource = logic.MultaData().DefaultView;
            //this.rut_cliente = rut_cliente;
            //this.nombre_cliente = nombre_cliente;
        }

        string firma_cliente = null;
        Business logic = new Business();
        string id_multa;
        string descripcion;
        int costo;
        string pagada;
        int nro_reserva;
        string rut_cliente;
        string nombres;
        string apellidos;
        int multas_activas;
        Multa MUL;

        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnVehiculos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnConductores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCheckIn_Click(object sender, RoutedEventArgs e)
        {

        }

        
        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagrid();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }


        private void BtnSubirFirma_Click(object sender, RoutedEventArgs e)
        {
            if (multas_activas == 0)
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
            else
            {
                MessageBox.Show("Se deben regularizar las multas antes de firmar");
            }
        }

        private void BtnCheckOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgMulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                id_multa = dr["ID_MULTA"].ToString();
                descripcion = dr["DESCRIPCION"].ToString();
                costo = Convert.ToInt32(dr["COSTO"]);
                pagada = dr["PAGADA"].ToString();
            }
        }

        private void dgReserva_Click(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                nro_reserva = Convert.ToInt32(dr["NRO_RESERVA"].ToString());
                rut_cliente = dr["CLIENTE_RUT_CLIENTE"].ToString();
                nombres = dr["NOMBRES"].ToString();
                apellidos = dr["APELLIDOS"].ToString();
                tbRutCliente.Text = rut_cliente;
                tbNombreCliente.Text = nombres + " " + apellidos;
                multas_activas = logic.getMultas(nro_reserva);
                firma_cliente = null;
                ImgImagen.Source = null;
                BtnGestionarMultas.IsEnabled = true;
                BtnSubirFirma.IsEnabled = true;

                LblFirma.Foreground = System.Windows.Media.Brushes.Red;
                LblFirma.Content = "✗ Firma sin subir";

                multas_activas = logic.getMultas(nro_reserva);
                CheckMultasStatus();
            }
        }

        public void CheckMultasStatus()
        {
            if (multas_activas > 0)
            {
                LblMulta.Foreground = System.Windows.Media.Brushes.Red;
                LblMulta.Content = "✗ Existen " + multas_activas + " multas activas";
                LblMulta2.Foreground = System.Windows.Media.Brushes.Red;
                LblMulta2.Content = "✗ Existen " + multas_activas + " multas activas";

            }
            else if (multas_activas == 0)
            {
                LblMulta.Foreground = System.Windows.Media.Brushes.DarkGreen;
                LblMulta.Content = "✓ No hay multas activas";
                LblMulta2.Foreground = System.Windows.Media.Brushes.DarkGreen;
                LblMulta2.Content = "✓ No hay multas activas";
            }
            else
            {
                LblMulta.Foreground = System.Windows.Media.Brushes.Black;
                LblMulta.Content = "";
                LblMulta2.Foreground = System.Windows.Media.Brushes.Black;
                LblMulta2.Content = "";
            }
        }

        private void BtnRealizarCheckOut_Click(object sender, RoutedEventArgs e)
        {
            if (nro_reserva > 0 && firma_cliente != null && multas_activas == 0)
            {
                logic.newCheckOut(nro_reserva, firma_cliente);
                refreshDatagrid();
                BtnGestionarMultas.IsEnabled = false;
                LblMulta.Content = "";
                LblMulta2.Content = "";
                LblFirma.Content = "";
                firma_cliente = null;
                ImgImagen.Source = null;
                tbRutCliente.Text = "";
                tbNombreCliente.Text = "";
                rut_cliente = "";
                nombres = "";
                apellidos = "";
                nro_reserva = -1;
                multas_activas = -1;
                
            }
            else
            {
                MessageBox.Show("Check Out incompleto, verificar firma y multas");
            }
        }

        private void BtnGestionarMultas_Click(object sender, RoutedEventArgs e)
        {
            //new Multa(nro_reserva, rut_cliente, nombres, apellidos).Show();

            Multa MUL = new Multa(this, nro_reserva, rut_cliente, nombres, apellidos);
            MUL.Show();
        }

        public void refreshDatagrid()
        {
            dgReserva.ItemsSource = null;
            dgReserva.ItemsSource = logic.ReservaCOData().DefaultView;
            multas_activas = logic.getMultas(nro_reserva);
            CheckMultasStatus();
        }
    }
}
