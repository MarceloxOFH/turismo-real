using CapaNegocio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for EditarFoto.xaml
    /// </summary>
    public partial class EditarFoto : Window
    {
        public EditarFoto(Foto foto, string descripcion, string url_imagen, Image imgImage, string imagen, string id_departamento, string nombre_departamento, string id_foto)
        {
            InitializeComponent();
            this.foto = foto;
            //logic.fromStringToPhoto( ,img);
            tbDescripcion.Text = descripcion;
            //tbUrlImage.Text = url_imagen;
            tbIdDepartamento.Text = id_departamento;
            tbNombreDepartamento.Text = nombre_departamento;
            //this.imagen = imagen;
            this.id_foto = id_foto;
            this.base64Text = imagen;
            //ImgImagen.Source = imagen;
            if (imagen != null)
            {
                byte[] binaryData = Convert.FromBase64String(imagen);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                Image img = new Image();
                ImgImagen.Source = bi;
            }
        }

        Business logic = new Business();
        string base64Text;
        //string imagen;
        string id_foto;
        Foto foto;

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                logic.editFoto(tbDescripcion.Text, "dep-" + tbIdDepartamento.Text + "-" + (tbDescripcion.Text).Replace(' ', '-') + ".jpg", base64Text, id_foto);
                foto.refreshDatagrid();
            }
            catch 
            { 
            }
        }


        private void BtnCambiarFoto_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                ImgImagen.Source = new BitmapImage(new Uri(fd.FileName));
                Stream stream = File.OpenRead(fd.FileName);
                stream = File.OpenRead(fd.FileName);
                byte[] binaryImage = new byte[stream.Length];
                stream.Read(binaryImage, 0, (int)stream.Length);
                base64Text = logic.ConvertImageToBase64String(binaryImage);
            }
        }
    }
}
