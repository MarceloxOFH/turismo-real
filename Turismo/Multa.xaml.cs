using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
    /// Interaction logic for Multa.xaml
    /// </summary>
    public partial class Multa : MetroWindow
    {
        public Multa(CheckOut CO, int nro_reserva, string rut_cliente, string nombres, string apellidos)
        {
            InitializeComponent();
            dgMulta.ItemsSource = logic.MultaData(nro_reserva).DefaultView;
            this.nro_reserva = nro_reserva;
            tbNumeroReserva.Text = nro_reserva.ToString();
            tbRutCliente.Text = rut_cliente;
            tbNombreCliente.Text = nombres + " " + apellidos;
            BtnEditar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            BtnPagarMulta.IsEnabled = false;
            this.CO = CO;
            multas_activas = logic.getMultas(nro_reserva);
            CheckMultasStatus();
        }

        

        Business logic = new Business();
        Multa MUL;
        CheckOut CO;
        int nro_reserva;
        string rut_cliente;
        string nombres;
        string apellidos;
        int multas_activas;
        string id_multa;
        string descripcion;
        int costo;
        string pagada;
        DateTime fecha_creacion;

        public void CheckMultasStatus()
        {
            if (multas_activas > 0)
            {
                LblMulta.Foreground = System.Windows.Media.Brushes.Red;
                LblMulta.Content = "✗ Existen " + multas_activas + " multas activas";
            }
            else if (multas_activas == 0)
            {
                LblMulta.Foreground = System.Windows.Media.Brushes.DarkGreen;
                LblMulta.Content = "✓ No hay multas activas";
            }
            else
            {
                LblMulta.Foreground = System.Windows.Media.Brushes.Black;
                LblMulta.Content = "";
            }
        }

        public void refreshDatagrid()
        {
            dgMulta.ItemsSource = null;
            dgMulta.ItemsSource = logic.MultaData(nro_reserva).DefaultView;
            CO.refreshDatagrid();
            multas_activas = logic.getMultas(nro_reserva);
            CheckMultasStatus();
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
                fecha_creacion = DateTime.Parse(dr["FECHA_CREACION"].ToString());
                BtnEditar.IsEnabled = true;
                BtnEliminar.IsEnabled = true;
                BtnPagarMulta.IsEnabled = true;
            }
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            CrearMulta CM = new CrearMulta(this, nro_reserva);
            CM.Show();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditarMulta EM = new EditarMulta(this, id_multa, descripcion, costo);
            EM.Show();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Eliminar multa seleccionada?", "Eliminar", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                logic.deleteMulta(id_multa);
                refreshDatagrid();
                BtnEditar.IsEnabled = false;
                BtnEliminar.IsEnabled = false;
                BtnPagarMulta.IsEnabled = false;
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagrid();
        }

        private void BtnPagarMulta_Click(object sender, RoutedEventArgs e)
        {
            RealizarPago RP = new RealizarPago(this, id_multa, descripcion, costo, nro_reserva);
            RP.Show();
        }
    }
}
