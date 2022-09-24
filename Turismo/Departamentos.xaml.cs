﻿using System;
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
using System.Data.OracleClient;
using System.Data;
//using CapaDatos;
using CapaNegocio;
using System.Drawing;
using Tienda;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class Departamentos : Window
    {
        public Departamentos()
        {
            InitializeComponent();
            
            dgDepartamento.ItemsSource = logic.DepartamentoData().DefaultView;
            //dgDepartamento.Items.Add(logic.DepartamentoData().DefaultView);
            BtnEliminar.IsEnabled = false;
            BtnEditar.IsEnabled = false;

            //COMBOBOX ESTADO DEPARTAMENTO
            DataTable dted = logic.dtestadoDepartamentoData();
            cbEstado.ItemsSource = dted.AsDataView();
            cbEstado.DisplayMemberPath = "NOMBRE";
            cbEstado.SelectedValuePath = "ID_ESTADO";
            
            //cbEstado.selec

            //COMBOBOX REGION
            DataTable dtr = logic.dtregionData();
            cbRegion.ItemsSource = dtr.AsDataView();
            cbRegion.DisplayMemberPath = "NOMBRE";
            cbRegion.SelectedValuePath = "ID_REGION";
            
        }

        Business logic = new Business();
        string id_departamento;
        string nombre_departamento;
        int arriendo_diario;
        string reservado;
        int habitaciones;
        int banos;
        int valoracion;
        int metros_cuadrados;
        int valor_inventario;
        DateTime último_inventario;
        string id_ubicacion;
        string id_region;
        string direccion;
        string descripcion;
        string region;
        string estado;
        string id_estado;

        public void refreshDatagrid() 
        {
            dgDepartamento.ItemsSource = null;
            dgDepartamento.ItemsSource = logic.DepartamentoData().DefaultView;
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estás seguro que deseas borrar el departamento '" + tbnombreDepartamento.Text + "' ", "Eliminar departamento", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)

            try
            { 
                logic.deleteDepartamento(id_departamento);
                refreshDatagrid();
                tbidDepartamento.Text = "";
                tbnombreDepartamento.Text = "";
                BtnEliminar.IsEnabled = false;
                id_departamento = null;
                cbEstado.SelectedItem = null;
                cbRegion.SelectedItem = null;
            }
            
            catch(Exception ex)
            {
                MessageBox.Show("Hubo un problema para eliminar el departamento seleccionado: " + ex);
            }
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            new CrearDepartamento().Show();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            new EditarDepartamento(id_departamento, nombre_departamento, arriendo_diario, habitaciones, banos, valoracion, metros_cuadrados, direccion, descripcion, region, id_region, estado, id_estado, id_ubicacion, reservado).Show();
        }

        private void dgDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                id_departamento = dr["ID_DEPARTAMENTO"].ToString();
                nombre_departamento = dr["NOMBRE"].ToString();
                arriendo_diario = Convert.ToInt32(dr["ARRIENDO_DIARIO"]);
                reservado = dr["RESERVADO"].ToString();
                habitaciones = Convert.ToInt32(dr["HABITACIONES"]);
                banos = Convert.ToInt32(dr["BANOS"]);
                valoracion = Convert.ToInt32(dr["VALORACION"]);
                metros_cuadrados = Convert.ToInt32(dr["METROS_CUADRADOS"]);
                descripcion = dr["DESCRIPCION"].ToString();
                id_ubicacion = dr["ID_UBICACION"].ToString();
                region = dr["REGION"].ToString();
                id_region = dr["ID_REGION"].ToString();
                direccion = dr["DIRECCION"].ToString();
                estado = dr["ESTADO"].ToString();
                id_estado = dr["ID_ESTADO"].ToString();


                tbidDepartamento.Text = id_departamento;
                tbnombreDepartamento.Text = nombre_departamento;
                BtnEliminar.IsEnabled = true;
                BtnEditar.IsEnabled = true;

                cbEstado.SelectedIndex = Convert.ToInt32(id_estado) - 1;
                cbRegion.SelectedIndex = Convert.ToInt32(id_region) - 1;
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagrid();
        }

        private void BtnVerInventario_Click(object sender, RoutedEventArgs e)
        {
            new InventarioDep().Show();
        }

        private void BtnVerMantencion_Click(object sender, RoutedEventArgs e)
        {
            new MantenciónDep(id_departamento).Show();
        }

    }
}
