using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;


namespace CapaConexion2
{
    public partial class Connection
    {
        public Connection()
        {
            //InitializeComponent();
            Connect();
        }

        public OracleConnection Connect()
        {
            OracleConnection conexion = new OracleConnection(ConfigurationManager.ConnectionStrings["TiendaCon"].ConnectionString);
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

        
    }
}