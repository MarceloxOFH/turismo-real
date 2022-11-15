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
    /// Interaction logic for RealizarCheckOut.xaml
    /// </summary>
    public partial class RealizarCheckOut : Window
    {
        public RealizarCheckOut()
        {
            InitializeComponent();
        }

        string base64Text = null;
        Business logic = new Business();

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void dgMultas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnSubirFirma_Click(object sender, RoutedEventArgs e)
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
