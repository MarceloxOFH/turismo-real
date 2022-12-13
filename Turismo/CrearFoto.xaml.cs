using CapaNegocio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Turismo
{
    /// <summary>
    /// Interaction logic for CrearFoto.xaml
    /// </summary>
    public partial class CrearFoto : MetroWindow
    {
        public CrearFoto(Foto foto, string id_departamento, string nombre_departamento, string id_foto)
        {
            InitializeComponent();
            tbIdDepartamento.Text = id_departamento;
            tbNombreDepartamento.Text = nombre_departamento;
            this.id_foto = id_foto;
            this.id_departamento = id_departamento;
            this.foto = foto;
            //tbUrlImage.Text = "dep-" + id_departamento + "-" + logic.currentSeqIdFoto() + 1;
        }

        Bitmap image;
        string base64Text = null;
        Business logic = new Business();
        string id_foto;
        string id_departamento;
        Foto foto;


        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (base64Text != null)
                {
                    logic.newFoto(tbDescripcion.Text, "dep-" + id_departamento + "-" + (tbDescripcion.Text).Replace(' ', '-') + ".jpg", base64Text, tbIdDepartamento.Text);
                    File.WriteAllBytes(@"C:\Users\Marcelo\Desktop\" + "dep-" + id_departamento + "-" + (tbDescripcion.Text).Replace(' ', '-') + ".jpg", Convert.FromBase64String(base64Text));
                    foto.refreshDatagrid();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se debe ingresar toda la información");
            }
        }

        private void BtnSubirFoto_Click(object sender, RoutedEventArgs e)
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
