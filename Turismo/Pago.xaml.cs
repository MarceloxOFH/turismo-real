using CapaNegocio;
using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using System.Windows.Controls.Primitives;
using System.IO;
using Paragraph = iTextSharp.text.Paragraph;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for Pago.xaml
    /// </summary>
    public partial class Pago : MetroWindow
    {
        public Pago()
        {
            InitializeComponent();
            LblUsuario.Content = Business.user_login;
            LblCargo.Content = Business.usertype_login;

            if (Business.usertype_login == "Funcionario")
            {
                BtnCheckIn.Margin = new Thickness(12, 105, 0, 0);
                BtnCheckOut.Margin = new Thickness(12, 150, 0, 0);
                BtnPagos.Margin = new Thickness(12, 195, 0, 0);
                BtnDepartamentos.Visibility = Visibility.Hidden;
                BtnInventario.Visibility = Visibility.Hidden;
                BtnEmpleados.Visibility = Visibility.Hidden;
                BtnClientes.Visibility = Visibility.Hidden;
                BtnConductores.Visibility = Visibility.Hidden;
                BtnVehiculos.Visibility = Visibility.Hidden;
                BtnEstadisticas.Visibility = Visibility.Hidden;
                //BtnPagos.Visibility = Visibility.Hidden;
            }


            dgReserva.ItemsSource = logic.ReservasActivasData().DefaultView;
            dgReservaFinalizada.ItemsSource = logic.ReservasFinalizadasData().DefaultView;
            dgReservaFinalizada.Visibility = Visibility.Hidden;
            rtFinalizadas.Visibility = Visibility.Hidden;
            rtActivas.Visibility = Visibility.Visible;
            BtnGenerarInforme.IsEnabled = false;
            BtnRevisarComprobantePago.IsEnabled = false;
        }

        Business logic = new Business();
        int nro_reserva;
        int monto_total;
        string rut_cliente;
        string nombres;
        string apellidos;
        string id_pago;
        string estado;
        string medio_pago;

        private void BtnSubirFirma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPagosPendientes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnActivas_Click(object sender, RoutedEventArgs e)
        {
            BtnActivas.IsEnabled = false;
            BtnFinalizadas.IsEnabled = true;
            rtFinalizadas.Visibility = Visibility.Hidden;
            rtActivas.Visibility = Visibility.Visible;
            dgReserva.Visibility = Visibility.Visible;
            dgReservaFinalizada.Visibility = Visibility.Hidden;
            refreshDatagridReservas();
            dgPagos.ItemsSource = null;
            BtnGenerarInforme.IsEnabled = false;
        }

        private void BtnFinalizadas_Click(object sender, RoutedEventArgs e)
        {
            BtnFinalizadas.IsEnabled = false;
            BtnActivas.IsEnabled = true;
            rtActivas.Visibility = Visibility.Hidden;
            rtFinalizadas.Visibility = Visibility.Visible;
            dgReservaFinalizada.Visibility = Visibility.Visible;
            dgReserva.Visibility = Visibility.Hidden;
            refreshDatagridReservas();
            dgPagos.ItemsSource = null;
            BtnGenerarInforme.IsEnabled = false;
        }


        

        private void dgReserva_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                DataRowView dr = dg.SelectedItem as DataRowView;
                if (dr != null)
                {
                    nro_reserva = Convert.ToInt32(dr["NRO_RESERVA"]);
                    rut_cliente = dr["CLIENTE_RUT_CLIENTE"].ToString(); ;
                    nombres = dr["NOMBRES"].ToString();
                    apellidos = dr["APELLIDOS"].ToString();
                    BtnGenerarInforme.IsEnabled = true;
                    //MessageBox.Show(nro_reserva.ToString());
                    refreshDatagrid();
                    //dgPagos.ItemsSource = logic.PagosData(nro_reserva).DefaultView;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
        }

        private void dgPagos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                DataRowView dr = dg.SelectedItem as DataRowView;
                if (dr != null)
                {
                    nro_reserva = Convert.ToInt32(dr["RESERVA_NRO_RESERVA"]);
                    id_pago = dr["PAGO_ID_PAGO"].ToString(); ;
                    estado = dr["ESTADO"].ToString();
                    medio_pago = dr["MEDIO_PAGO"].ToString();
                    BtnRevisarComprobantePago.IsEnabled = true;
                    //refreshDatagrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error selectionchanged" + ex.Message);
            }
        }

        private void dgReservaFinalizada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                DataRowView dr = dg.SelectedItem as DataRowView;
                if (dr != null)
                {
                    nro_reserva = Convert.ToInt32(dr["NRO_RESERVA"]);
                    rut_cliente = dr["RUT_CLIENTE"].ToString(); ;
                    nombres = dr["NOMBRES"].ToString();
                    apellidos = dr["APELLIDOS"].ToString();
                    BtnGenerarInforme.IsEnabled = true;
                    //MessageBox.Show(nro_reserva.ToString());
                    refreshDatagrid();
                    //dgPagos.ItemsSource = logic.PagosData(nro_reserva).DefaultView;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
        }

        public void refreshDatagrid()
        {
            try
            {
                dgPagos.ItemsSource = null;
                dgPagos.ItemsSource = logic.PagosData(nro_reserva).DefaultView;
                monto_total = logic.PagoMontoTotal(nro_reserva);
                lblMontoTotal.Content = monto_total.ToString();
            }

            catch (Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
        }

        public void refreshDatagridReservas()
        {
            try
            {
                dgReserva.ItemsSource = null;
                dgReserva.ItemsSource = logic.ReservasActivasData().DefaultView;
                dgReservaFinalizada.ItemsSource = null;
                dgReservaFinalizada.ItemsSource = logic.ReservasFinalizadasData().DefaultView;
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
            }
        }


       

        private void BtnGenerarInforme_Click(object sender, RoutedEventArgs e)
        {
            ExportToPdf(dgPagos);
        }

        private void ExportToPdf(DataGrid grid)
        {
            try
            {
                PdfPTable table = new PdfPTable(grid.Columns.Count);
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                string nombre_documento = nro_reserva + "-" + DateTime.Now.ToString("ddMMMyyyy-HHmmss") + ".pdf";
                //MessageBox.Show("nombre_documento: " + nombre_documento);
                FileStream file = new FileStream(Business.filePath + nombre_documento, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(doc, file);
                //PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream("Test.pdf", System.IO.FileMode.Create));
                doc.Open();
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                doc.Add(new Paragraph("                                                                                                                                  TURISMO REAL", boldFont));
                doc.Add(new Paragraph("             COMPROBANTE DE PAGOS", boldFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Paragraph("             Fecha Comprobante: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), boldFont));
                doc.Add(new Paragraph("             N° Reserva: " + nro_reserva, boldFont));
                doc.Add(new Paragraph("             Rut Cliente: " + rut_cliente, boldFont));
                doc.Add(new Paragraph("             Nombres: " + nombres, boldFont));
                doc.Add(new Paragraph("             Apellidos: " + apellidos, boldFont));
                doc.Add(new Paragraph("             Pago Total: $ " + lblMontoTotal.Content, boldFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Paragraph("             Lista de Pagos:", boldFont));
                doc.Add(Chunk.NEWLINE);

                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(grid.Columns[j].Header.ToString(), boldFont));
                }
                table.HeaderRows = 1;
                IEnumerable itemsSource = grid.ItemsSource as IEnumerable;
                if (itemsSource != null)
                {
                    foreach (var item in itemsSource)
                    {
                        DataGridRow row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                        if (row != null)
                        {
                            DataGridCellsPresenter presenter = Business.FindVisualChild<DataGridCellsPresenter>(row);
                            for (int i = 0; i < grid.Columns.Count; ++i)
                            {
                                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                                TextBlock txt = cell.Content as TextBlock;
                                if (txt != null)
                                {
                                    table.AddCell(new Phrase(txt.Text, boldFont));
                                }
                            }
                        }
                    }
                    doc.Add(table);

                    doc.Close();
                    writer.Close();
                    System.Diagnostics.Process.Start(Business.filePath + nombre_documento);

                }
            }
            
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message);
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

        private void BtnCheckIn_Click(object sender, RoutedEventArgs e)
        {
            new CheckIn().Show();
            this.Close();
        }

        private void BtnEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            new Estadisticas().Show();
            this.Close();
        }

        private void BtnPagos_Click(object sender, RoutedEventArgs e)
        {
            //new Pago().Show();
            //this.Close();
        }

        private void BtnRevisarComprobantePago_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (medio_pago == "Transferencia")
                {
                    new RevisarComprobante(nro_reserva, id_pago).Show();
                }
                else
                {
                    MessageBox.Show("Función habilitada solo para pagos con Transferencia","Revisar Transferencia de Pago");
                }
            }
            catch
            { 
            }
        }

        
        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagrid();
        }
    }
}
