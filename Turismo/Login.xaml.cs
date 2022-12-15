using CapaNegocio;
using System.Data;
using System.Windows;
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
            try
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

                    else if (dt.Rows[0][1].ToString() == "Funcionario")
                    {
                        logic.Usuario(dt.Rows[0][0].ToString());
                        logic.TipoUsuario(dt.Rows[0][1].ToString());
                        this.Hide();
                        new CheckIn().ShowDialog();
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
            catch 
            {
            }
            
        }
    }
}
