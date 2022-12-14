using CapaNegocio;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for Regalos.xaml
    /// </summary>
    public partial class Regalos : MetroWindow
    {
        public Regalos()
        {
            InitializeComponent();

            dgRegalos.ItemsSource = logic.RegalosData().DefaultView;

        }


        Business logic = new Business();
        string id_regalo;
        string contenido;
        int valor;


        public void actualizarDatagrid()
        {
            dgRegalos.ItemsSource = null;
            dgRegalos.ItemsSource = logic.RegalosData().DefaultView;
        }


        private void dgRegalos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                DataRowView dr = dg.SelectedItem as DataRowView;
                if (dr != null)
                {
                    id_regalo = dr["ID_REGALO"].ToString();
                    contenido = dr["CONTENIDO"].ToString();
                    valor = Convert.ToInt32(dr["VALOR"]);


                }
            }
            catch
            { 
            }

        }

        private void btnCrearRegalo_Click(object sender, RoutedEventArgs e)
        {
            new CrearRegalo().Show();
        }

        private void btnActualizarRegalo_Click(object sender, RoutedEventArgs e)
        {
            actualizarDatagrid();
        }

        private void btnEliminarRegalo_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estás seguro que deseas borrar el regalo?' ", "Eliminar Regalo", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)

                try
                {
                    logic.deleteRegalo(id_regalo);
                    actualizarDatagrid();
                    btnEliminarRegalo.IsEnabled = false;


                }

                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un problema para eliminar el cliente seleccionado: " + ex);
                }
        }

    }
}
