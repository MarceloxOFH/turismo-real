using CapaNegocio;
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
using MahApps.Metro.Controls;

namespace Turismo
{
    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }
        
        Business logic = new Business();

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = logic.Login(tbUsuario.Text, pwContrasena.Password);
            
            if (dt.Rows.Count == 1)
            {
                
                if (dt.Rows[0][1].ToString() == "Administrador")
                {
                    logic.Usuario(dt.Rows[0][0].ToString());
                    logic.TipoUsuario(dt.Rows[0][1].ToString());
                    this.Hide();
                    new Departamentos().ShowDialog();   
                }
                else
                {
                    MessageBox.Show("error de login");
                }
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecta");
            }

            
        }
    }
}
