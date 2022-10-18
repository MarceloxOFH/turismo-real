using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaConexion;
using CapaDatos;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Windows;
using System.Web.Mvc;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Media;
using Microsoft.Web.Services3.Addressing;
using System.Reflection;

namespace CapaNegocio
{
    public class Business : Controller
    {
        public Business()
        {
            //InitializeComponent();
            configConnection();
        }


        private Connection conec;
        public Connection Conec { get => conec; set => conec = value; }



        public void configConnection()
        {
            this.Conec = new Connection();

        }



        public DataTable InventarioData()
        {
            OracleCommand command = new OracleCommand("SELECT INV.ID_ARTICULO, INV.NOMBRE_ARTICULO, " +
                "INV.DESCRIPCION, CI.ID_CATEGORIA, CI.CATEGORIA, " +
                "INV.CAT_INV_ID_CAT, CI.DESCRIPCION AS DESCRIPCION_CATEGORIA " +
                "FROM INVENTARIO INV " +
                "INNER JOIN CATEGORIA_INVENTARIO CI ON INV.CAT_INV_ID_CAT = CI.ID_CATEGORIA", Conec.Connect());
            OracleDataAdapter da = new OracleDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable ConductorData()
        {
            OracleCommand command = new OracleCommand("SELECT * FROM CONDUCTOR", Conec.Connect());
            OracleDataAdapter da = new OracleDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable getInventarioDep(string id_departamento)
        {
            OracleCommand command = new OracleCommand("SELECT INV.ID_ARTICULO, CI.CATEGORIA, " +
                "INV.NOMBRE_ARTICULO, INV.DESCRIPCION, " +
                "DI.CANTIDAD, DI.VALOR, " +
                "DI.CANTIDAD * DI.VALOR AS TOTAL " +
                "FROM INVENTARIO INV " +
                "INNER JOIN CATEGORIA_INVENTARIO CI ON CI.ID_CATEGORIA = INV.CAT_INV_ID_CAT " +
                "INNER JOIN \"Depa-Inventario\" DI ON DI.INV_DEP_ID_ART = INV.ID_ARTICULO " +
                "WHERE DI.DEP_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());

            command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;
            command.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }


        public DataTable MantencionData()
        {
            OracleCommand command = new OracleCommand("SELECT DEPARTAMENTO_ID_DEPARTAMENTO AS ID_DEPARTAMENTO, " +
                "ID_MANTENCION, FECHA_INICIO, FECHA_TERMINO, COSTO, DESCRIPCION " +
                "FROM MANTENCION_DEPARTAMENTO", Conec.Connect());
            OracleDataAdapter da = new OracleDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable MantencionDepId(string id_departamento)
        {
            OracleCommand command = new OracleCommand("SELECT DEPARTAMENTO_ID_DEPARTAMENTO AS ID_DEPARTAMENTO, " +
                "ID_MANTENCION, FECHA_INICIO, FECHA_TERMINO, COSTO, DESCRIPCION " +
                "FROM MANTENCION_DEPARTAMENTO " +
                "WHERE DEPARTAMENTO_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());

            command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;
            command.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable DepartamentoData()
        {
            OracleCommand command = new OracleCommand("SELECT DEP.ID_DEPARTAMENTO, " +
                "DEP.NOMBRE, REG.NOMBRE AS REGION, UBI.DIRECCION, " +
                "EST.NOMBRE AS ESTADO, DEP.ARRIENDO_DIARIO, DEP.RESERVADO, DEP.HABITACIONES, " +
                "DEP.BANOS, DEP.DESCRIPCION, DEP.VALORACION, DEP.METROS_CUADRADOS, " +
                "DEP.VALOR_INVENTARIO, DEP.ULTIMO_INVENTARIO, REG.ID_REGION, " +
                "DEP.UBICACION_ID_UBICACION AS ID_UBICACION, DEP.ESTADO_DEPARTAMENTO_ID_ESTADO AS ID_ESTADO " +
                "FROM DEPARTAMENTO DEP " +
                "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                "INNER JOIN REGION REG ON REG.ID_REGION = UBI.REGION_ID_REGION " +
                "INNER JOIN ESTADO_DEPARTAMENTO EST ON EST.ID_ESTADO = DEP.ESTADO_DEPARTAMENTO_ID_ESTADO " +
                "WHERE DEP.ID_DEPARTAMENTO != '0' " +
                "ORDER BY TO_NUMBER(DEP.ID_DEPARTAMENTO) ASC", Conec.Connect());
            OracleDataAdapter da = new OracleDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable VehiculoData()
        {
            OracleCommand command = new OracleCommand("SELECT VE.PATENTE, " +
                "VE.DISPONIBILIDAD, EV.ID_ESTADO_VEHI AS ID_ESTADO, " +
                "EV.NOMBRE AS ESTADO, VE.CAPACIDAD, VE.DESCRIPCION " +
                "FROM VEHICULO VE " +
                "INNER JOIN ESTADO_VEHICULO EV ON EV.ID_ESTADO_VEHI = VE.ESTADO_VEHICULO_ID_ESTADO_VEHI " +
                "ORDER BY PATENTE ASC", Conec.Connect());
            OracleDataAdapter da = new OracleDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable dtestadoDepartamentoData()
        {

            OracleCommand command = new OracleCommand("SELECT ID_ESTADO, NOMBRE FROM ESTADO_DEPARTAMENTO", Conec.Connect());
            OracleDataReader dr = command.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(command);
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            da = new OracleDataAdapter(command);
            da.Fill(dt);


            return dt;
        }

        public DataTable dtestadoVehiculoData()
        {

            OracleCommand command = new OracleCommand("SELECT ID_ESTADO_VEHI AS ID_ESTADO, NOMBRE, DESCRIPCION FROM ESTADO_VEHICULO", Conec.Connect());
            OracleDataReader dr = command.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(command);
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            da = new OracleDataAdapter(command);
            da.Fill(dt);


            return dt;
        }

        public DataTable dtregionData()
        {

            OracleCommand command = new OracleCommand("SELECT ID_REGION, NOMBRE FROM REGION", Conec.Connect());
            OracleDataReader dr = command.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(command);
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            da = new OracleDataAdapter(command);
            da.Fill(dt);


            return dt;
        }

        public DataTable dtCategoriaInvData()
        {

            OracleCommand command = new OracleCommand("SELECT ID_CATEGORIA, CATEGORIA FROM CATEGORIA_INVENTARIO", Conec.Connect());
            OracleDataReader dr = command.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(command);
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            da = new OracleDataAdapter(command);
            da.Fill(dt);


            return dt;
        }

        public string getIdUbicacion()
        {

            try
            {
                DataTable _datatable = new DataTable();
                OracleDataAdapter _adapter = new OracleDataAdapter("SELECT MAX(TO_NUMBER(ID_UBICACION)) FROM UBICACION", Conec.Connect());
                _adapter.Fill(_datatable);

                string ubi_id = _datatable.Rows[0][0].ToString();

                return ubi_id;
            }
            catch (Exception ex)
            {
                string ubi_id = "0";
                return ubi_id;
            }
        }

        public void updateDatagrid()
        {

        }

        public void newDepartamento(string nombre, int arriendo_diario, string reservado, int habitaciones, int banos, string descripcion, int valoracion, int metros_cuadrados, string id_region, string direccion, string estado)
        {
            newUbicacion(direccion, id_region);

            string ubi_id = getIdUbicacion();



            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO DEPARTAMENTO " +
                    "(ID_DEPARTAMENTO, NOMBRE, ARRIENDO_DIARIO, RESERVADO, " +
                    "HABITACIONES, BANOS, DESCRIPCION, VALORACION, METROS_CUADRADOS, " +
                    "VALOR_INVENTARIO, UBICACION_ID_UBICACION, " +
                    "ESTADO_DEPARTAMENTO_ID_ESTADO) VALUES (to_char(seq_id_dep.nextval), " +
                    ":nombre, :arriendo_diario, :reservado, :habitaciones, :banos, " +
                    ":descripcion, :valoracion, :metros_cuadrados, :valor_inventario, " +
                    ":ubicacion_id_ubicacion,:estado_departamento_id_estado)", Conec.Connect());

                //select to_char(seq_id_dep.nextval,'FM00') from dual;


                command.Parameters.Add("nombre", OracleDbType.Varchar2, 100).Value = nombre;
                command.Parameters.Add("arriendo_diario", OracleDbType.Int32, 100).Value = arriendo_diario;
                command.Parameters.Add("reservado", OracleDbType.Varchar2, 100).Value = reservado;
                command.Parameters.Add("habitaciones", OracleDbType.Int32, 100).Value = habitaciones;
                command.Parameters.Add("banos", OracleDbType.Int32, 100).Value = banos;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = descripcion;
                command.Parameters.Add("valoracion", OracleDbType.Int32, 100).Value = valoracion;
                command.Parameters.Add("metros_cuadrados", OracleDbType.Int32, 100).Value = metros_cuadrados;
                command.Parameters.Add("valor_inventario", OracleDbType.Int32, 100).Value = 0;
                command.Parameters.Add("ubicacion_id_ubicacion", OracleDbType.Varchar2, 100).Value = ubi_id;
                command.Parameters.Add("estado_departamento_id_estado", OracleDbType.Varchar2, 100).Value = estado;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Departamento agregado");
                //Departamento dep = new Departamento();
                //dep.

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar departamento: " + ex);
            }
        }

        public void newMantencion(string id_departamento, DateTime fecha_inicio, DateTime fecha_termino, int costo, string descripcion)
        {

            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO MANTENCION_DEPARTAMENTO " +
                    "(DEPARTAMENTO_ID_DEPARTAMENTO, ID_MANTENCION, FECHA_INICIO, FECHA_TERMINO, " +
                    "COSTO, DESCRIPCION) VALUES (:id_departamento, to_char(seq_id_man.nextval), " +
                    ":fecha_inicio, :fecha_termino, :costo, :descripcion)", Conec.Connect());

                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;
                command.Parameters.Add("fecha_inicio", OracleDbType.Date, 100).Value = fecha_inicio;
                command.Parameters.Add("fecha_termino", OracleDbType.Date, 100).Value = fecha_termino;
                command.Parameters.Add("costo", OracleDbType.Int32, 100).Value = costo;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = descripcion;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Mantención agregada");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar mantención: " + ex);
            }
        }

        public void newConductor(string rut_conductor, string nombres, string apellidos, DateTime caducidad_licencia, string disponibilidad, int sueldo)
        {

            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO CONDUCTOR " +
                    "(RUT_CONDUCTOR, NOMBRES, APELLIDOS, CADUCIDAD_LICENCIA, " +
                    "DISPONIBILIDAD, SUELDO) VALUES (:rut_conductor, :nombres, " +
                    ":apellidos, :caducidad_licencia, :disponibilidad, :sueldo)", Conec.Connect());

                command.Parameters.Add("rut_conductor", OracleDbType.Varchar2, 100).Value = rut_conductor;
                command.Parameters.Add("nombres", OracleDbType.Varchar2, 100).Value = nombres;
                command.Parameters.Add("apellidos", OracleDbType.Varchar2, 100).Value = apellidos;
                command.Parameters.Add("caducidad_licencia", OracleDbType.Date, 100).Value = caducidad_licencia;
                command.Parameters.Add("disponibilidad", OracleDbType.Varchar2, 100).Value = disponibilidad;
                command.Parameters.Add("sueldo", OracleDbType.Int32, 100).Value = sueldo;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Conductor agregado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Conductor: " + ex);
            }
        }

        public void newVehiculo(string patente, string disponibilidad, string id_estado, int capacidad, string descripcion)
        {

            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO VEHICULO " +
                    "(PATENTE, DISPONIBILIDAD, ESTADO_VEHICULO_ID_ESTADO_VEHI, CAPACIDAD, " +
                    "DESCRIPCION) VALUES (:patente, :disponibilidad, " +
                    ":id_estado, :capacidad, :descripcion)", Conec.Connect());

                command.Parameters.Add("patente", OracleDbType.Varchar2, 100).Value = patente;
                command.Parameters.Add("disponibilidad", OracleDbType.Varchar2, 100).Value = disponibilidad;
                command.Parameters.Add("id_estado", OracleDbType.Varchar2, 100).Value = id_estado;
                command.Parameters.Add("capacidad", OracleDbType.Int32, 100).Value = capacidad;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 500).Value = descripcion;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Vehículo agregado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Vehículo: " + ex);
            }
        }

        public void newUbicacion(string direccion, string id_region)
        {
            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO UBICACION " +
                    "(ID_UBICACION, DIRECCION, REGION_ID_REGION) VALUES (to_char(seq_id_ubi.nextval), " +
                    ":direccion, :region_id_region)", Conec.Connect());

                command.Parameters.Add("direccion", OracleDbType.Varchar2, 100).Value = direccion;
                command.Parameters.Add("region_id_region", OracleDbType.Varchar2, 100).Value = id_region;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar ubicación: " + ex);
            }
        }


        public void editDepartamento(string id_departamento, string nombre, int arriendo_diario, int habitaciones, int banos, string descripcion, int valoracion, int metros_cuadrados, string id_region, string id_estado, string direccion, string id_ubicacion, string reservado)
        {
            //editEstado();


            try
            {
                //MessageBox.Show("id_estado: " + id_estado);
                OracleCommand command = new OracleCommand("UPDATE DEPARTAMENTO " +
                    "SET NOMBRE = :nombre, ARRIENDO_DIARIO = :arriendo_diario, " +
                    "HABITACIONES = :habitaciones, BANOS = :banos, DESCRIPCION = :descripcion, " +
                    "VALORACION = :valoracion, METROS_CUADRADOS = :metros_cuadrados, " +
                    "RESERVADO = :reservado, ESTADO_DEPARTAMENTO_ID_ESTADO = :id_estado " +
                    "WHERE ID_DEPARTAMENTO = :id_departamento", Conec.Connect());


                //MessageBox.Show("reservado: " + reservado);
                //MessageBox.Show("metros_cuadrados: " + metros_cuadrados.ToString());

                command.Parameters.Add("nombre", OracleDbType.Varchar2, 100).Value = nombre;
                command.Parameters.Add("arriendo_diario", OracleDbType.Int32, 100).Value = arriendo_diario; command.Parameters.Add("habitaciones", OracleDbType.Int32, 100).Value = habitaciones;
                command.Parameters.Add("banos", OracleDbType.Int32, 100).Value = banos;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = descripcion;
                command.Parameters.Add("valoracion", OracleDbType.Int32, 100).Value = valoracion;
                command.Parameters.Add("metros_cuadrados", OracleDbType.Int32, 100).Value = metros_cuadrados;
                command.Parameters.Add("reservado", OracleDbType.Varchar2, 100).Value = reservado;
                command.Parameters.Add("id_estado", OracleDbType.Varchar2, 100).Value = id_estado;
                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Departamento editado");

                editUbicacion(direccion, id_ubicacion);
                editRegion(id_ubicacion, id_region);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar departamento: " + ex);
            }
        }

        public void editDepaInventario(int valor, int cantidad, string id_articulo, string id_departamento) 
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE \"Depa-Inventario\" " +
                    "SET VALOR = :valor, CANTIDAD = :cantidad " +
                    "WHERE INV_DEP_ID_ART = :id_articulo AND DEP_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());


                command.Parameters.Add("valor", OracleDbType.Int32, 100).Value = valor;
                command.Parameters.Add("cantidad", OracleDbType.Int32, 100).Value = cantidad;
                command.Parameters.Add("id_articulo", OracleDbType.Varchar2, 100).Value = id_articulo;
                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Valores editados");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar valores: " + ex);
            }
        }

        public void deleteDepaInventario(string id_articulo, string id_departamento)
        {
            try
            {

                OracleCommand command = new OracleCommand("DELETE FROM \"Depa-Inventario\" " +
                    "WHERE INV_DEP_ID_ART = :id_articulo AND DEP_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());

                command.Parameters.Add("id_articulo", OracleDbType.Varchar2, 100).Value = id_articulo;
                command.Parameters.Add("id_articulo", OracleDbType.Varchar2, 100).Value = id_departamento;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Artículo eliminado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar artículo: " + ex);
            }
        }

        public void addDepaInventario(int valor, int cantidad, string id_articulo, string id_departamento)
        {
            try
            {
                OracleCommand command = new OracleCommand("INSERT INTO \"Depa-Inventario\" " +
                    "(VALOR, CANTIDAD, INV_DEP_ID_ART, DEP_ID_DEPARTAMENTO) VALUES (:valor, " +
                    ":cantidad, :id_articulo, :id_departamento)", Conec.Connect());


                command.Parameters.Add("valor", OracleDbType.Int32, 100).Value = valor;
                command.Parameters.Add("cantidad", OracleDbType.Int32, 100).Value = cantidad;
                command.Parameters.Add("id_articulo", OracleDbType.Varchar2, 100).Value = id_articulo;
                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Artículo agregado al departamento");
            }
            catch (Exception ex)
            {
                MessageBox.Show("El artículo ya existe en el departamento: " + ex);
            }
        }

        public void addArticulo(string nombre_articulo, string descripcion, string id_categoria)
        {
            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO INVENTARIO " +
                    "(ID_ARTICULO, NOMBRE_ARTICULO, DESCRIPCION, CAT_INV_ID_CAT) VALUES (to_char(seq_id_art.nextval), " +
                    ":nombre_articulo, :descripcion, :id_categoria)", Conec.Connect());

                command.Parameters.Add("nombre_articulo", OracleDbType.Varchar2, 100).Value = nombre_articulo;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = descripcion;
                command.Parameters.Add("id_categoria", OracleDbType.Varchar2, 100).Value = id_categoria;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Artículo agregado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Artículo: " + ex);
            }
        }

        public void editArticulo(string id_articulo, string nombre_articulo, string descripcion, string id_categoria)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE INVENTARIO " +
                    "SET NOMBRE_ARTICULO = :nombre_articulo, DESCRIPCION = :descripcion, " +
                    "CAT_INV_ID_CAT = :id_categoria " +
                    "WHERE ID_ARTICULO = :id_articulo", Conec.Connect());

                command.Parameters.Add("nombre_articulo", OracleDbType.Varchar2, 100).Value = nombre_articulo;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = descripcion;
                command.Parameters.Add("id_categoria", OracleDbType.Varchar2, 100).Value = id_categoria;
                command.Parameters.Add("id_articulo", OracleDbType.Varchar2, 100).Value = id_articulo;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Artículo editado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar Artículo: " + ex);
            }
        }

        public void editConductor(string rut_conductor, string nombres, string apellidos, DateTime caducidad_licencia, string disponibilidad, int sueldo)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE CONDUCTOR " +
                    "SET NOMBRES = :nombres, " +
                    "APELLIDOS = :apellidos, CADUCIDAD_LICENCIA = :caducidad_licencia, " +
                    "DISPONIBILIDAD = :disponibilidad, SUELDO = :sueldo " +
                    "WHERE RUT_CONDUCTOR = :rut_conductor", Conec.Connect());

                command.Parameters.Add("nombres", OracleDbType.Varchar2, 100).Value = nombres;
                command.Parameters.Add("apellidos", OracleDbType.Varchar2, 100).Value = apellidos;
                command.Parameters.Add("caducidad_licencia", OracleDbType.Date, 100).Value = caducidad_licencia;
                command.Parameters.Add("disponibilidad", OracleDbType.Varchar2, 100).Value = disponibilidad;
                command.Parameters.Add("sueldo", OracleDbType.Int32, 100).Value = sueldo;
                command.Parameters.Add("rut_conductor", OracleDbType.Varchar2, 100).Value = rut_conductor;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Conductor editado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar Conductor: " + ex);
            }
        }

        public void editVehiculo(string patente, string disponibilidad, string id_estado, int capacidad, string descripcion)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE VEHICULO " +
                    "SET PATENTE = :patente, " +
                    "DISPONIBILIDAD = :disponibilidad, ID_ESTADO = :id_estado, " +
                    "CAPACIDAD = :capacidad, DESCRIPCION = :descripcion " +
                    "WHERE PATENTE = :patente", Conec.Connect());

                command.Parameters.Add("patente", OracleDbType.Varchar2, 100).Value = patente;
                command.Parameters.Add("disponibilidad", OracleDbType.Varchar2, 100).Value = disponibilidad;
                command.Parameters.Add("id_estado", OracleDbType.Varchar2, 100).Value = id_estado;
                command.Parameters.Add("capacidad", OracleDbType.Int32, 100).Value = capacidad;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 500).Value = descripcion;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Vehiculo editado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar Vehiculo: " + ex);
            }
        }

        public void deleteArticulo(string id_articulo)
        {
            try
            {

                OracleCommand command = new OracleCommand("DELETE FROM INVENTARIO " +
                    "WHERE ID_ARTICULO = :id_articulo", Conec.Connect());

                command.Parameters.Add("id_articulo", OracleDbType.Varchar2, 100).Value = id_articulo;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Artículo eliminado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar artículo: " + ex);
            }
        }

        public void deleteVehiculo(string patente)
        {
            try
            {

                OracleCommand command = new OracleCommand("DELETE FROM VEHICULO " +
                    "WHERE PATENTE = :patente", Conec.Connect());

                command.Parameters.Add("patente", OracleDbType.Varchar2, 100).Value = patente;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Vehiculo eliminado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar vehiculo: " + ex);
            }
        }

        public void editRegion(string id_ubicacion, string id_region)
        {
            try
            {


                OracleCommand command = new OracleCommand("UPDATE UBICACION " +
                    "SET REGION_ID_REGION = :id_region " +
                    "WHERE ID_UBICACION = :id_ubicacion", Conec.Connect());


                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;
                command.Parameters.Add("id_ubicacion", OracleDbType.Varchar2, 100).Value = id_ubicacion;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar ubicación: " + ex);
            }
        }

        public void editUbicacion(string direccion, string id_ubicacion)
        {
            try
            {

                OracleCommand command = new OracleCommand("UPDATE UBICACION " +
                    "SET DIRECCION = :direccion " +
                    "WHERE ID_UBICACION = :id_ubicacion", Conec.Connect());


                command.Parameters.Add("direccion", OracleDbType.Varchar2, 100).Value = direccion;
                command.Parameters.Add("id_ubicacion", OracleDbType.Varchar2, 100).Value = id_ubicacion;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar ubicación: " + ex);
            }
        }

        public void editMantencion(string id_departamento, string id_mantencion, DateTime fecha_inicio, DateTime fecha_termino, int costo, string descripcion)
        {
            try
            {


                OracleCommand command = new OracleCommand("UPDATE MANTENCION_DEPARTAMENTO " +
                    "SET DEPARTAMENTO_ID_DEPARTAMENTO = :id_departamento, " +
                    "FECHA_INICIO = :fecha_inicio, FECHA_TERMINO = :fecha_termino, " +
                    "COSTO = :costo, DESCRIPCION = :descripcion " +
                    "WHERE ID_MANTENCION = :id_mantencion", Conec.Connect());

                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;
                command.Parameters.Add("fecha_inicio", OracleDbType.Date, 100).Value = fecha_inicio;
                command.Parameters.Add("fecha_termino", OracleDbType.Date, 100).Value = fecha_termino;
                command.Parameters.Add("costo", OracleDbType.Int32, 100).Value = costo;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = descripcion;
                command.Parameters.Add("id_mantencion", OracleDbType.Varchar2, 100).Value = id_mantencion;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar mantención: " + ex);
            }
        }
        public void deleteDepartamento(string id_departamento)
        {
            try
            {

                OracleCommand command = new OracleCommand("DELETE FROM DEPARTAMENTO " +
                    "WHERE ID_DEPARTAMENTO = :id_departamento", Conec.Connect());

                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Departamento eliminado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar departamento: " + ex);
            }
        }

        public void deleteMantención(string id_mantencion)
        {
            try
            {

                OracleCommand command = new OracleCommand("DELETE FROM MANTENCION_DEPARTAMENTO " +
                    "WHERE ID_MANTENCION = :id_mantencion", Conec.Connect());

                command.Parameters.Add("id_mantencion", OracleDbType.Varchar2, 100).Value = id_mantencion;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Mantención eliminada");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar departamento: " + ex);
            }
        }


        public DataTable Login(string username, string contrasena)
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT ACC.USERNAME, CAR.NOMBRE " +
                    "FROM EMPLEADO EMP " +
                    "INNER JOIN CARGO CAR ON CAR.ID_CARGO = EMP.CARGO_ID_CARGO " +
                    "INNER JOIN ACCESO ACC ON ACC.USERNAME = EMP.ACCESO_USERNAME " +
                    "WHERE ACC.USERNAME = :username AND ACC.CONTRASENA = :contrasena", Conec.Connect());
                command.Parameters.Add("username", OracleDbType.Varchar2, 100).Value = username;
                command.Parameters.Add("contrasena", OracleDbType.Varchar2, 100).Value = contrasena;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                MessageBox.Show("Error en el login: " + ex);

                return dt;
            }

        }
    }
}
