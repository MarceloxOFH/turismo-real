using System;
using System.Windows;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace CapaConexion
{
    public partial class Connection 
    {
        public Connection()
        {
            InitializeComponent();
            Connect();
        }

        public OracleConnection Connect()
        {
            OracleConnection conexion = new OracleConnection(ConfigurationManager.ConnectionStrings["TURISMOREAL4"].ConnectionString);
            conexion.Open();
            return conexion;
        }

        private String SQLstring;

        public String SQLString
        {
            get { return SQLstring; }
            set { SQLstring = value; }
        }

        private Boolean esSelect;

        public Boolean EsSelect
        {
            get { return esSelect; }
            set { esSelect = value; }
        }

        private System.Data.DataSet dbDataSet;

        public System.Data.DataSet DbDataSet
        {
            get { return dbDataSet; }
            set { dbDataSet = value; }
        }

        public void LoginPageTest(string user, string password)
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT USERNAME, TIPO_USUARIO FROM EMPLOYEE_TEST WHERE USERNAME = :username AND contrasena = :contrasena", Connect());
                command.Parameters.Add("username", txtUsuario.Text);
                command.Parameters.Add("contrasena", passPassword.Password);
                OracleDataAdapter da = new OracleDataAdapter(command);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "ADMINISTRADOR")
                    {
                        MessageBox.Show("conexión funcionando");
                        Connect().Close();
                    }
                    else
                    {
                        MessageBox.Show("error");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrecta");
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            LoginPageTest(this.txtUsuario.Text, this.txtUsuario.Text);
        }
    }
}