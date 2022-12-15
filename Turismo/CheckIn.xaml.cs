using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CapaNegocio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MahApps.Metro.Controls;
using Paragraph = iTextSharp.text.Paragraph;
using System.Globalization;

namespace Turismo
{

    public partial class CheckIn : MetroWindow
    {
        public CheckIn()
        {
            InitializeComponent();


            LblUsuario.Content = Business.user_login;
            LblCargo.Content = Business.usertype_login;

            if (Business.usertype_login == "Funcionario")
            {
                BtnCheckIn.Margin = new Thickness(12, 105, 0, 0);
                BtnCheckOut.Margin = new Thickness(12, 150, 0, 0);
                BtnDepartamentos.Visibility = Visibility.Hidden;
                BtnInventario.Visibility = Visibility.Hidden;
                BtnEmpleados.Visibility = Visibility.Hidden;
                BtnClientes.Visibility = Visibility.Hidden;
                BtnConductores.Visibility = Visibility.Hidden;
                BtnVehiculos.Visibility = Visibility.Hidden;
                BtnEstadisticas.Visibility = Visibility.Hidden;
                BtnPagos.Visibility = Visibility.Hidden;
            }

            dgReserva.ItemsSource = logic.ReservaData().DefaultView;
            dgCheckIn.ItemsSource = logic.CheckInData().DefaultView;
            dgCheckIn.Visibility = Visibility.Hidden;
            rtCheckInRealizado.Visibility = Visibility.Hidden;
            BtnGenerarComprobante.IsEnabled = false;

            DataTable dted = logic.dtestadoNroReservaInData();

            DataTable dter = logic.dtestadoRegaloInData();
            //cbRegalo.ItemsSource = dted.AsDataView();
            //cbRegalo.DisplayMemberPath = "CONTENIDO";
            //cbRegalo.SelectedValuePath = "ID_REGALO";



        }


        Business logic = new Business();
        int nro_reserva;
        int pago_total;
        string rut_cliente;
        string nombres;
        string apellidos;
        string nombre_completo;
        string id_checkin;
        DateTime fecha_ingreso;
        DateTime fecha_termino;
        int pago_estadia;
        DateTime fecha_inicio;

        //string id_checkin;
        //string condicion_departamento;
        //DateTime hora_ingreso;
        //int pago_estadia;
        //int reserva_nro_reserva;
        //string firma_conformidad;
        //string contenido;
        //string regalo_id_regalo;

        public void actualizarDatagridReserva()
        {
            dgReserva.ItemsSource = null;
            dgReserva.ItemsSource = logic.ReservaData().DefaultView;
        }

        public void actualizarDatagridCheck()
        {
            dgCheckIn.ItemsSource = null;
            dgCheckIn.ItemsSource = logic.CheckInData().DefaultView;
        }


        

        private void btnRegalos_Click(object sender, RoutedEventArgs e)
        {
            new Regalos().Show();
        }

        private void actualizar_Click(object sender, RoutedEventArgs e)
        {
            actualizarDatagridReserva();
            actualizarDatagridCheck();
        }

        private void dgReserva_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            { 
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {

                nro_reserva = Convert.ToInt32(dr["NRO_RESERVA"].ToString());
                rut_cliente = dr["CLIENTE_RUT_CLIENTE"].ToString();
                nombres = dr["NOMBRES"].ToString();
                apellidos = dr["APELLIDOS"].ToString();
                pago_total = Convert.ToInt32(dr["VALOR_TOTAL"].ToString());
                nombre_completo = nombres + " " + apellidos;
                tbRutCliente.Text = rut_cliente;
                tbNombreCliente.Text = nombre_completo;
            }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Reservas().Show();
        }

        private void btnReservas_Click(object sender, RoutedEventArgs e)
        {
            BtnGenerarComprobante.IsEnabled = false;
            rtReservasAgendadas.Visibility = Visibility.Visible;
            rtCheckInRealizado.Visibility = Visibility.Hidden;
            nro_reserva = 0;
            rut_cliente = "";
            nombres = "";
            apellidos = "";
            btnReservas.IsEnabled = false;
            btndgCheckIn.IsEnabled = true;
            dgReserva.Visibility = Visibility.Visible;
            dgCheckIn.Visibility = Visibility.Hidden;
            BtnCrear.IsEnabled = true;
            tbNombreCliente.Text = "";
            tbRutCliente.Text = "";
            actualizarDatagridReserva();
        }

        private void btndgCheckIn_Click(object sender, RoutedEventArgs e)
        {
            rtCheckInRealizado.Visibility = Visibility.Visible;
            rtReservasAgendadas.Visibility = Visibility.Hidden;
            nro_reserva = 0;
            rut_cliente = "";
            nombres = "";
            apellidos = "";
            btndgCheckIn.IsEnabled = false;
            btnReservas.IsEnabled = true;
            dgCheckIn.Visibility = Visibility.Visible;
            dgReserva.Visibility = Visibility.Hidden;
            BtnCrear.IsEnabled = false;
            tbNombreCliente.Text = "";
            tbRutCliente.Text = "";
            actualizarDatagridCheck();
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            if (nro_reserva != 0)
            {
                new CrearCheckIn(nro_reserva, (pago_total/10)*6 , nombre_completo, rut_cliente).Show();
            }
            else 
            {
                MessageBox.Show("Se debe escoger alguna Reserva", "Error");
            }
        }

        private void dgCheckIn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            { 
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                
                nro_reserva = Convert.ToInt32(dr["RESERVA_NRO_RESERVA"].ToString());
                rut_cliente = dr["RUT_CLIENTE"].ToString();
                nombres = dr["NOMBRES"].ToString();
                apellidos = dr["APELLIDOS"].ToString();
                id_checkin = dr["ID_CHECKIN"].ToString();
                fecha_ingreso = DateTime.ParseExact(dr["HORA_INGRESO"].ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                fecha_inicio = DateTime.ParseExact(dr["RESERVA_INICIO"].ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                fecha_termino = DateTime.ParseExact(dr["RESERVA_TERMINO"].ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                pago_estadia = Convert.ToInt32(dr["PAGO_ESTADIA"]);
                nombre_completo = nombres + " " + apellidos;
                tbRutCliente.Text = rut_cliente;
                tbNombreCliente.Text = nombre_completo;
                BtnGenerarComprobante.IsEnabled = true;

            }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
        }



        private void ExportToPdf()
        {
            try
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                string nombre_documento = nro_reserva + "-" + DateTime.Now.ToString("ddMMMyyyy-HHmmss") + ".pdf";
                FileStream file = new FileStream(Business.filePath + nombre_documento, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(doc, file);
                doc.Open();
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                doc.Add(new Paragraph("                                                                                                                                  TURISMO REAL", boldFont));
                doc.Add(new Paragraph("             COMPROBANTE DE CHECK IN", boldFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Paragraph("             Fecha Comprobante: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), boldFont));
                doc.Add(new Paragraph("             Ingreso: " + fecha_ingreso.ToString("dd/MM/yyyy HH:mm"), boldFont));
                doc.Add(new Paragraph("             N° Reserva: " + nro_reserva, boldFont));
                doc.Add(new Paragraph("             Rut Cliente: " + rut_cliente, boldFont));
                doc.Add(new Paragraph("             Nombres: " + nombres, boldFont));
                doc.Add(new Paragraph("             Apellidos: " + apellidos, boldFont));
                doc.Add(new Paragraph("             Fecha Inicio: " + fecha_inicio.ToString("dd/MM/yyyy HH:mm"), boldFont));
                doc.Add(new Paragraph("             Fecha Termino: " + fecha_termino.ToString("dd/MM/yyyy HH:mm"), boldFont));
                doc.Add(new Paragraph("             Pago por estadía: " + pago_estadia.ToString(), boldFont));
                doc.Add(new Paragraph("             Estado Check In: Realizado", boldFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Paragraph("             Gracias por su preferencia, disfrute su estadía.", boldFont));

                doc.Close();
                writer.Close();
                System.Diagnostics.Process.Start(Business.filePath + nombre_documento);


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


            private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void BtnDepartamentos_Click(object sender, RoutedEventArgs e)
        {
            new Departamentos().Show();
            this.Close();
        }

        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {
            new Inventario().Show();
            this.Close();
        }

        private void BtnVehiculos_Click(object sender, RoutedEventArgs e)
        {
            new Vehiculo().Show();
            this.Close();
        }

        private void BtnConductores_Click(object sender, RoutedEventArgs e)
        {
            new Conductor().Show();
            this.Close();
        }

        private void BtnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            new CheckOut().Show();
            this.Close();
        }

        private void BtnCheckIn_Click(object sender, RoutedEventArgs e)
        {
            //new CheckIn().Show();
            //this.Close();
        }

        private void BtnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            new Empleados().Show();
            this.Close();
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            new Clientes().Show();
            this.Close();
        }

        private void BtnEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            new Estadisticas().Show();
            this.Close();
        }

        private void BtnPagos_Click(object sender, RoutedEventArgs e)
        {
            new Pago().Show();
            this.Close();
        }

        private void BtnGenerarComprobante_Click(object sender, RoutedEventArgs e)
        {
            ExportToPdf();
        }

        


    }
}
