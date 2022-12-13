using CapaNegocio;
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
using Image = System.Windows.Controls.Image;
using MahApps.Metro.Controls;
using Path = System.IO.Path;

namespace Turismo
{
    /// <summary>
    /// Interaction logic for Foto.xaml
    /// </summary>
    public partial class Foto : MetroWindow
    {
        public Foto(string id_departamento, string nombre_departamento)
        {
            InitializeComponent();
            dgFoto.ItemsSource = logic.FotoDataByIdDepartamento(id_departamento).DefaultView;
            dgFoto.SelectedIndex = 0;
            tbidDepartamento.Text = id_departamento;
            tbnombreDepartamento.Text = nombre_departamento;
            this.id_departamento = id_departamento;
        }

        Business logic = new Business();
        int index_actual = 0;
        string id_foto;
        string url_imagen;
        string descripcion;
        string imagen;
        string id_departamento;


        public void refreshDatagrid()
        {
            dgFoto.ItemsSource = null;
            dgFoto.ItemsSource = logic.FotoDataByIdDepartamento(id_departamento).DefaultView;
        }

        private void dgFoto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                id_foto = dr["ID_FOTO"].ToString();
                url_imagen = dr["URL_IMAGEN"].ToString();
                descripcion = dr["DESCRIPCION"].ToString();
                imagen = dr["IMAGEN"].ToString();

                logic.fromStringToPhoto(imagen, ImgImagen);
                index_actual = dgFoto.SelectedIndex;
                //MessageBox.Show("indexx: " + index_actual);
                

                lblDescripción.Content = descripcion;
                lblIdFoto.Content = id_foto;

                //tbidDepartamento.Text = id_departamento;
                //tbnombreDepartamento.Text = nombre_departamento;
                //BtnEliminar.IsEnabled = true;
                //BtnEditar.IsEnabled = true;
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estás seguro que deseas borrar esta foto?", "Eliminar foto", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)

                try
                {
                    logic.deleteFoto(id_foto);
                    logic.deleteFotoPrincipal(id_departamento);
                    refreshDatagrid();

                    //borrar foto carpeta local
                    try
                    {
                        // recvisa que la direccion de la foto existe  
                        if (File.Exists(Path.Combine(@"C:\Users\Marcelo\Desktop\", "dep-" + id_departamento + "-" + (descripcion).Replace(' ', '-') + ".jpg")))
                        {
                            // si es que existe, se elimina    
                            File.Delete(Path.Combine(@"C:\Users\Marcelo\Desktop\", "dep-" + id_departamento + "-" + (descripcion).Replace(' ', '-') + ".jpg"));
                        }
                    }
                    catch
                    {
                    }

                    dgFoto.SelectedIndex = 0;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un problema para eliminar la foto: " + ex);
                }

            
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            CrearFoto CF = new CrearFoto(this, tbidDepartamento.Text, tbnombreDepartamento.Text, id_foto);
            CF.Show();

            //new CrearFoto(tbidDepartamento.Text, tbnombreDepartamento.Text, id_foto).Show();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditarFoto EF = new EditarFoto(this, descripcion, url_imagen, ImgImagen, imagen, tbidDepartamento.Text, tbnombreDepartamento.Text, id_foto);
            EF.Show();

            //new EditarFoto(descripcion, url_imagen, ImgImagen, imagen, tbidDepartamento.Text, tbnombreDepartamento.Text, id_foto).Show();
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            refreshDatagrid();
        }

        private void BtnAnterior_Click(object sender, RoutedEventArgs e)
        {

            if (dgFoto.SelectedIndex > 0)
            {
                dgFoto.SelectedIndex = index_actual - 1;
            }

        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgFoto.SelectedIndex = index_actual + 1;
            }
            catch 
            { 
                
            }
            
        }

        private void BtnFotoPrincipal_Click(object sender, RoutedEventArgs e)
        {
            logic.newFotoPrincipal(url_imagen, id_departamento);
        }
    }
}
