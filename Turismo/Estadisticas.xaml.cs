using System;
using System.Collections.Generic;
using System.Data;
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
using CapaNegocio;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for Estadisticas.xaml
    /// </summary>
    public partial class Estadisticas : MetroWindow
    {
        public Estadisticas()
        {
            InitializeComponent();
            LblUsuario.Content = Business.user_login;
            LblCargo.Content = Business.usertype_login;


            DataTable dtr = logic.dtregionData();
            cbRegion.ItemsSource = dtr.AsDataView();
            cbRegion.DisplayMemberPath = "NOMBRE";
            cbRegion.SelectedValuePath = "ID_REGION";
        }

        Business logic = new Business();
        string id_region;
        string region;

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
            //new Estadisticas().Show();
            //this.Close();
        }

        private void BtnPagos_Click(object sender, RoutedEventArgs e)
        {
            new Pago().Show();
            this.Close();
        }
 

        private void cbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id_region = cbRegion.SelectedValue.ToString();
                //MessageBox.Show("id_region: " + id_region);
                lblDepCant.Content = logic.EstDepCantidad(id_region);
                lblDepBuenEstado.Content = logic.EstDepBuenEstado(id_region);
                lblUtilizadosActualmente.Content = logic.EstResReservasActualesCantidad(id_region);
                lblPromedioPrecioDiario.Content = logic.EstDepPrecioPromedio(id_region);
                lblArriendoPrecioBajo.Content = logic.EstDepPrecioMasBajo(id_region);
                lblArriendoPrecioAlto.Content = logic.EstDepPrecioMasAlto(id_region);
                lblInventarioValorPromedio.Content = logic.EstDepValorInventarioPromedio(id_region);
                lblInventarioValorTotal.Content = logic.EstDepValorInventarioTotal(id_region);
                lblReservasTotales.Content = logic.EstResReservasCantidad(id_region);
                lblReservasAgendadas.Content = logic.EstResReservasAgendadasCantidad(id_region);
                lblEstadiasActuales.Content = logic.EstResReservasActualesCantidad(id_region);
                lblReservasFinalizadas.Content = logic.EstResReservasFinalizadasCantidad(id_region);
                lblIngresosReservaWeb.Content = logic.EstResIngresosReserva(id_region);
                lblIngresosCheckIn.Content = logic.EstResIngresosCheckIn(id_region);
                lblCostosMultas.Content = logic.EstResCostosMultas(id_region);
                lblCostoReservaTotal.Content = logic.EstResCostoReservaTotal(id_region);

                //total
                lblDepCant_Copy.Content = logic.TEstDepCantidad(id_region);
                lblDepBuenEstado_Copy.Content = logic.TEstDepBuenEstado(id_region);
                lblUtilizadosActualmente_Copy.Content = logic.TEstResReservasActualesCantidad(id_region);
                lblPromedioPrecioDiario_Copy.Content = logic.TEstDepPrecioPromedio(id_region);
                lblArriendoPrecioBajo_Copy.Content = logic.TEstDepPrecioMasBajo(id_region);
                lblArriendoPrecioAlto_Copy.Content = logic.TEstDepPrecioMasAlto(id_region);
                lblInventarioValorPromedio_Copy.Content = logic.TEstDepValorInventarioPromedio(id_region);
                lblInventarioValorTotal_Copy.Content = logic.TEstDepValorInventarioTotal(id_region);
                lblReservasTotales_Copy.Content = logic.TEstResReservasCantidad(id_region);
                lblReservasAgendadas_Copy.Content = logic.TEstResReservasAgendadasCantidad(id_region);
                lblEstadiasActuales_Copy.Content = logic.TEstResReservasActualesCantidad(id_region);
                lblReservasFinalizadas_Copy.Content = logic.TEstResReservasFinalizadasCantidad(id_region);
                lblIngresosReservaWeb_Copy.Content = logic.TEstResIngresosReserva(id_region);
                lblIngresosCheckIn_Copy.Content = logic.TEstResIngresosCheckIn(id_region);
                lblCostosMultas_Copy.Content = logic.TEstResCostosMultas(id_region);
                lblCostoReservaTotal_Copy.Content = logic.TEstResCostoReservaTotal(id_region);

            }
            catch (Exception ex)
            {
                //MessageBox.Show("error");
            }

            //porcentajes
            try
                {
                    lblPorcCantidad.Content = ((Convert.ToInt32(logic.EstDepCantidad(id_region)) * 100 / Convert.ToInt32(logic.TEstDepCantidad(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcCantidad.Content = "0%";
                }


                try
                {
                    lblPorcBuenEstado.Content = ((Convert.ToInt32(logic.EstDepBuenEstado(id_region)) * 100 / Convert.ToInt32(logic.TEstDepBuenEstado(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcBuenEstado.Content = "0%";
                }


                try
                {
                    lblPorcUtilizados.Content = ((Convert.ToInt32(logic.EstResReservasActualesCantidad(id_region)) * 100 / Convert.ToInt32(logic.TEstResReservasActualesCantidad(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcUtilizados.Content = "0%";
                }


                try
                {
                    lblPorcPrecioDiarioPromedio.Content = ((Convert.ToInt32(logic.EstDepPrecioPromedio(id_region)) * 100 / Convert.ToInt32(logic.TEstDepPrecioPromedio(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcPrecioDiarioPromedio.Content = "0%";
                }


                try
                {
                    lblPorcPrecioDiarioMayor.Content = ((Convert.ToInt32(logic.EstDepPrecioMasAlto(id_region)) * 100 / Convert.ToInt32(logic.TEstDepPrecioMasAlto(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcPrecioDiarioMayor.Content = "0%";
                }


                try
                {
                    lblPorcPrecioDiarioMenor.Content = ((Convert.ToInt32(logic.EstDepPrecioMasBajo(id_region)) * 100 / Convert.ToInt32(logic.TEstDepPrecioMasBajo(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcPrecioDiarioMenor.Content = "0%";
                }


                try
                {
                    lblPorcValorInventarioPromedio.Content = ((Convert.ToInt32(logic.EstDepValorInventarioPromedio(id_region)) * 100 / Convert.ToInt32(logic.TEstDepValorInventarioPromedio(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcValorInventarioPromedio.Content = "0%";
                }


                try
                {
                    lblPorcValorInventarioTotal.Content = ((Convert.ToInt32(logic.EstDepValorInventarioTotal(id_region)) * 100 / Convert.ToInt32(logic.TEstDepValorInventarioTotal(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcValorInventarioTotal.Content = "0%";
                }


                try
                {
                    lblPorcReservasTotales.Content = ((Convert.ToInt32(logic.EstResReservasCantidad(id_region)) * 100 / Convert.ToInt32(logic.TEstResReservasCantidad(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcReservasTotales.Content = "0%";
                }


                try
                {
                    lblPorcReservasAgendadas.Content = ((Convert.ToInt32(logic.EstResReservasAgendadasCantidad(id_region)) * 100 / Convert.ToInt32(logic.TEstResReservasAgendadasCantidad(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcReservasAgendadas.Content = "0%";
                }


                try
                {
                    lblPorcEstadiasActuales.Content = ((Convert.ToInt32(logic.EstResReservasActualesCantidad(id_region)) * 100 / Convert.ToInt32(logic.TEstResReservasActualesCantidad(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcEstadiasActuales.Content = "0%";
                }


                try
                {
                    lblPorcReservasFinalizadas.Content = ((Convert.ToInt32(logic.EstResReservasFinalizadasCantidad(id_region)) * 100 / Convert.ToInt32(logic.TEstResReservasFinalizadasCantidad(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcReservasFinalizadas.Content = "0%";
                }


                try
                {
                    lblPorcIngresosReservaWeb.Content = ((Convert.ToInt32(logic.EstResIngresosReserva(id_region)) * 100 / Convert.ToInt32(logic.TEstResIngresosReserva(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcIngresosReservaWeb.Content = "0%";
                }


                try
                {
                    lblPorcIngresosCheckIn.Content = ((Convert.ToInt32(logic.EstResIngresosCheckIn(id_region)) * 100 / Convert.ToInt32(logic.TEstResIngresosCheckIn(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcIngresosCheckIn.Content = "0%";
                }


                try
                {
                    lblPorcCostoMultas.Content = ((Convert.ToInt32(logic.EstResCostosMultas(id_region)) * 100 / Convert.ToInt32(logic.TEstResCostosMultas(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcCostoMultas.Content = "0%";
                }


                try
                {
                    lblPorcCostoReservaTotal.Content = ((Convert.ToInt32(logic.EstResCostoReservaTotal(id_region)) * 100 / Convert.ToInt32(logic.TEstResCostoReservaTotal(id_region)) * 100) * 10000) / 1000000 + "%";
                }
                catch
                {
                    lblPorcCostoReservaTotal.Content = "0%";
                }
           


        }

    }
}
