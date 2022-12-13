using CapaNegocio;
using System;
using System.Collections.Generic;
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
using System.Data;

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
            dgReserva.ItemsSource = logic.ReservasActivasData().DefaultView;
            dgReservaFinalizada.ItemsSource = logic.ReservasFinalizadasData().DefaultView;
            dgReservaFinalizada.Visibility = Visibility.Hidden;
            rtFinalizadas.Visibility = Visibility.Hidden;
            rtActivas.Visibility = Visibility.Visible;
        }

        Business logic = new Business();
        int nro_reserva;
        int monto_total;

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
        }


        private void BtnGenerarInforme_Click(object sender, RoutedEventArgs e)
        {

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
            catch (Exception ex)
            {
                //MessageBox.Show("error selectionchanged");
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
    }
}
