using System;
using CapaConexion;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows;
using System.Web.Mvc;
using System.IO;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;


namespace CapaNegocio
{
    public class Business : Controller
    {
        public Business()
        {
            configConnection();
        }


        private Connection conec;
        public Connection Conec { get => conec; set => conec = value; }



        public void configConnection()
        {
            try
            {
                this.Conec = new Connection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión en configConnection(): " + ex);
            }

        }



        public DataTable InventarioData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT INV.ID_ARTICULO, INV.NOMBRE_ARTICULO, " +
                    "INV.DESCRIPCION, CI.ID_CATEGORIA, CI.CATEGORIA, " +
                    "INV.CATEGORIA_ID_CATEGORIA, CI.DESCRIPCION AS DESCRIPCION_CATEGORIA " +
                    "FROM INVENTARIO INV " +
                    "INNER JOIN CATEGORIA CI ON INV.CATEGORIA_ID_CATEGORIA = CI.ID_CATEGORIA", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error en InventarioData(): " + ex);
                DataTable dt = new DataTable();
                return dt;
            }
        }


        public DataTable ReservaCOData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT RES.NRO_RESERVA, " +
                    "RES.CLIENTE_RUT_CLIENTE, CLI.NOMBRES, CLI.APELLIDOS, " +
                    "RES.FECHA_RESERVA, RD.RESERVA_INICIO, RD.RESERVA_TERMINO " +
                    "FROM RESERVA RES " +
                    "LEFT JOIN CHECK_OUT CO ON(CO.RESERVA_NRO_RESERVA = RES.NRO_RESERVA) " +
                    "RIGHT JOIN CHECK_IN CI ON(CI.RESERVA_NRO_RESERVA = RES.NRO_RESERVA) " +
                    "INNER JOIN CLIENTE CLI ON(CLI.RUT_CLIENTE = RES.CLIENTE_RUT_CLIENTE) " +
                    "INNER JOIN RESERVA_DEPTO RD ON(RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA) " +
                    "WHERE CO.ACTIVO != 'N' " +
                    "OR " +
                    "NOT EXISTS " +
                    "(SELECT NULL " +
                    "FROM CHECK_OUT " +
                    "WHERE CO.RESERVA_NRO_RESERVA = RES.NRO_RESERVA) " +
                    "OR " +
                    "NOT EXISTS " +
                    "(SELECT NULL " +
                    "FROM CHECK_IN " +
                    "WHERE CI.RESERVA_NRO_RESERVA = RES.NRO_RESERVA)", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error en ReservaCOData(): " + ex);
                DataTable dt = new DataTable();
                return dt;
            }
        }

        public DataTable ReservasActivasData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT RES.NRO_RESERVA, " +
                    "RES.CLIENTE_RUT_CLIENTE, CLI.NOMBRES, CLI.APELLIDOS, " +
                    "RES.FECHA_RESERVA, RD.RESERVA_INICIO, RD.RESERVA_TERMINO " +
                    "FROM RESERVA RES " +
                    "LEFT JOIN CHECK_OUT CO ON (CO.RESERVA_NRO_RESERVA = RES.NRO_RESERVA) " +
                    "INNER JOIN CLIENTE CLI ON (CLI.RUT_CLIENTE = RES.CLIENTE_RUT_CLIENTE) " +
                    "INNER JOIN RESERVA_DEPTO RD ON (RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA) " +
                    "WHERE CO.ACTIVO != 'N' OR " +
                    "NOT EXISTS " +
                    "(SELECT NULL " +
                    "FROM CHECK_OUT " +
                    "WHERE CO.RESERVA_NRO_RESERVA = RES.NRO_RESERVA)", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("error en ReservaCOData(): " + ex);
                DataTable dt = new DataTable();
                return dt;
            }
        }

        public DataTable ReservasFinalizadasData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT RES.NRO_RESERVA, " +
                    "CLI.RUT_CLIENTE, CLI.NOMBRES, " +
                    "CLI.APELLIDOS, RES.FECHA_RESERVA, " +
                    "RD.RESERVA_INICIO, RD.RESERVA_TERMINO, " +
                    "CO.ACTIVO " +
                    "FROM RESERVA RES " +
                    "INNER JOIN CHECK_OUT CO ON CO.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN CLIENTE CLI ON CLI.RUT_CLIENTE = RES.CLIENTE_RUT_CLIENTE " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "WHERE CO.ACTIVO = 'N'", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("error en Reserva: " + ex);
                DataTable dt = new DataTable();
                return dt;
            }
        }

        public DataTable ReservaCODataFinalizada()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT RES.NRO_RESERVA, " +
                    "RES.CLIENTE_RUT_CLIENTE, CLI.NOMBRES, CLI.APELLIDOS, " +
                    "RES.FECHA_RESERVA, RD.RESERVA_INICIO, RD.RESERVA_TERMINO " +
                    "FROM RESERVA RES " +
                    "LEFT JOIN CHECK_OUT CO ON (CO.RESERVA_NRO_RESERVA = RES.NRO_RESERVA) " +
                    "INNER JOIN CLIENTE CLI ON (CLI.RUT_CLIENTE = RES.CLIENTE_RUT_CLIENTE) " +
                    "INNER JOIN RESERVA_DEPTO RD ON (RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA) " +
                    "WHERE CO.ACTIVO = 'N' OR " +
                    "NOT EXISTS " +
                    "(SELECT NULL " +
                    "FROM CHECK_OUT " +
                    "WHERE CO.RESERVA_NRO_RESERVA = RES.NRO_RESERVA)", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("error en ReservaCOData(): " + ex);
                DataTable dt = new DataTable();
                return dt;
            }
        }

     

        public DataTable PagosData(int nro_reserva)
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT * " +
                    "FROM PAGO PAG " +
                    "INNER JOIN PAGO_RESERVA PR ON PR.PAGO_ID_PAGO = PAG.ID_PAGO " +
                    "WHERE PR.RESERVA_NRO_RESERVA = :nro_reserva " +
                    "ORDER BY PAG.FECHA_PAGO ASC", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.Parameters.Add("nro_reserva", OracleDbType.Int32, 100).Value = nro_reserva;
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }

            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }


        public DataTable FotoDataByIdDepartamento(string id_departamento)
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT * FROM FOTO WHERE DEPARTAMENTO_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }

            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

        public DataTable ConductorData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT * FROM CONDUCTOR", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();

                return dt;
            }
        }

        public DataTable getInventarioDep(string id_departamento)
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT INV.ID_ARTICULO, CI.CATEGORIA, " +
                    "INV.NOMBRE_ARTICULO, INV.DESCRIPCION, " +
                    "DI.CANTIDAD, DI.VALOR, " +
                    "DI.CANTIDAD * DI.VALOR AS TOTAL " +
                    "FROM INVENTARIO INV " +
                    "INNER JOIN CATEGORIA CI ON CI.ID_CATEGORIA = INV.CATEGORIA_ID_CATEGORIA " +
                    "INNER JOIN DEPA_INVENTARIO DI ON DI.INV_ID_ART = INV.ID_ARTICULO " +
                    "WHERE DI.DEP_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());

                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);


                return dt;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("error para acceder al inventario del departamento: " + ex.Message);
                DataTable dt = new DataTable();
                return dt;
            }
        }


        public DataTable MantencionData()
        {
            try
            {

                OracleCommand command = new OracleCommand("SELECT DEPARTAMENTO_ID_DEPARTAMENTO AS ID_DEPARTAMENTO, " +
                    "ID_MANTENCION, FECHA_INICIO, FECHA_TERMINO, COSTO, DESCRIPCION " +
                    "FROM MANTENCION_DEPARTAMENTO", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();

                return dt;
            }
        }

        public DataTable MantencionDepId(string id_departamento)
        {
            try
            {

                OracleCommand command = new OracleCommand("SELECT DEPARTAMENTO_ID_DEPARTAMENTO AS ID_DEPARTAMENTO, " +
                    "ID_MANTENCION, FECHA_INICIO, FECHA_TERMINO, COSTO, DESCRIPCION " +
                    "FROM MANTENCION_DEPARTAMENTO " +
                    "WHERE DEPARTAMENTO_ID_DEPARTAMENTO = :id_departamento AND " +
                    "FECHA_TERMINO > to_char(CURRENT_DATE)", Conec.Connect());

                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

        public DataTable ServiciosActuales(string id_departamento)
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT DSA.DEPARTAMENTO_ID_DEPARTAMENTO AS ID_DEPARTAMENTO, " +
                "DSA.SERVICIO_ASOCIADO_ID_SERVICIO AS ID_SERVICIO, SA.NOMBRE_SERVICIO, SA.DESCRIPCION, SA.COSTO " +
                "FROM DEPA_ASOC DSA " +
                "INNER JOIN SERVICIO_ASOCIADO SA ON SA.ID_SERVICIO = DSA.SERVICIO_ASOCIADO_ID_SERVICIO " +
                "WHERE DSA.DEPARTAMENTO_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());

                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex) 
            {
                DataTable dt = new DataTable();

                return dt;
            }

        }

        public DataTable ServiciosOtros()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT ID_SERVICIO, NOMBRE_SERVICIO, DESCRIPCION, COSTO FROM SERVICIO_ASOCIADO", Conec.Connect());

                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();

                return dt;
            }
        }

        public DataTable MantencionTerminadaDepId(string id_departamento)
        {
            try
            {

                OracleCommand command = new OracleCommand("SELECT DEPARTAMENTO_ID_DEPARTAMENTO AS ID_DEPARTAMENTO, " +
                    "ID_MANTENCION, FECHA_INICIO, FECHA_TERMINO, COSTO, DESCRIPCION " +
                    "FROM MANTENCION_DEPARTAMENTO " +
                    "WHERE DEPARTAMENTO_ID_DEPARTAMENTO = :id_departamento AND " +
                    "FECHA_TERMINO < to_char(CURRENT_DATE)", Conec.Connect());

                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

        public DataTable DepartamentoData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT DEP.ID_DEPARTAMENTO, " +
                    "DEP.NOMBRE, DEP.NUMERO, REG.NOMBRE AS REGION, UBI.DIRECCION, " +
                    "EST.NOMBRE AS ESTADO, DEP.ARRIENDO_DIARIO, DEP.HABITACIONES, " +
                    "DEP.BANOS, DEP.DESCRIPCION, DEP.METROS_CUADRADOS, " +
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
            catch (Exception ex)
            {
                MessageBox.Show("error en DepartamentoData(): " + ex);
                DataTable dt = new DataTable();
                return dt;
            }
        }

        public DataTable VehiculoData()
        {
            try
            {

                OracleCommand command = new OracleCommand("SELECT VE.PATENTE, " +
                    "VE.DISPONIBILIDAD, VE.MODELO, " +
                    "EV.ID_ESTADO_VEHI AS ID_ESTADO, " +
                    "EV.NOMBRE AS ESTADO, VE.CAPACIDAD, VE.DESCRIPCION " +
                    "FROM VEHICULO VE " +
                    "INNER JOIN ESTADO_VEHICULO EV ON EV.ID_ESTADO_VEHI = VE.ESTADO_VEHICULO_ID_ESTADO_VEHI " +
                    "ORDER BY PATENTE ASC", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();

                return dt;
            }
        }

        public DataTable CategoriaData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT * FROM CATEGORIA " +
                    "ORDER BY ID_CATEGORIA ASC", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }



        public DataTable MultaData(int nro_reserva)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT ID_MULTA, " +
                    "DESCRIPCION, COSTO, " +
                    "CHECK_OUT_ID_CHECKOUT, " +
                    "PAGADA, FECHA_CREACION " +
                    "FROM MULTA MUL " +
                    "INNER JOIN CHECK_OUT CO ON(CO.ID_CHECKOUT = MUL.CHECK_OUT_ID_CHECKOUT) " +
                    "WHERE CO.RESERVA_NRO_RESERVA = :nro_reserva AND PAGADA = 'N'", Conec.Connect());

                command.Parameters.Add("nro_reserva", OracleDbType.Int32, 100).Value = nro_reserva;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

        public DataTable dtestadoDepartamentoData()
        {
            try
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
            catch (Exception ex)
            {
                DataTable dt = new DataTable();

                return dt;
            }
        }

        public DataTable dtestadoVehiculoData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT ID_ESTADO_VEHI AS ID_ESTADO, NOMBRE, DESCRIPCION FROM ESTADO_VEHICULO ORDER BY ID_ESTADO ASC", Conec.Connect());
                OracleDataReader dr = command.ExecuteReader();
                OracleDataAdapter da = new OracleDataAdapter(command);
                //DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                da = new OracleDataAdapter(command);
                da.Fill(dt);


                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();

                return dt;
            }
        }

        public DataTable dtregionData()
        {
            try
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
            catch (Exception ex)
            {
                DataTable dt = new DataTable();

                return dt;
            }
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

        public string GetIdCheckOut()
        {
            try
            {
                DataTable _datatable = new DataTable();
                OracleDataAdapter _adapter = new OracleDataAdapter("SELECT MAX(TO_NUMBER(ID_CHECKOUT)) FROM CHECK_OUT", Conec.Connect());
                _adapter.Fill(_datatable);

                string id_checkout = _datatable.Rows[0][0].ToString();

                return id_checkout;
            }
            catch (Exception ex)
            {
                string id_checkout = "0";
                return id_checkout;
            }
        }

        public int PagoMontoTotal(int nro_reserva)
        {

            try
            {
                DataTable _datatable = new DataTable();

                OracleCommand command = new OracleCommand("SELECT SUM(MONTO) FROM PAGO PAG INNER JOIN PAGO_RESERVA PR ON PR.PAGO_ID_PAGO = PAG.ID_PAGO " +
                "WHERE PR.RESERVA_NRO_RESERVA = :nro_reserva", Conec.Connect());

                command.Parameters.Add("nro_reserva", OracleDbType.Int32, 100).Value = nro_reserva;

                OracleDataAdapter _adapter = new OracleDataAdapter(command);
                _adapter.Fill(_datatable);

                int reserva_nro = Convert.ToInt32(_datatable.Rows[0][0].ToString());

                return reserva_nro;
            }
            catch (Exception ex)
            {
                int reserva_nro = 0;
                return reserva_nro;
            }
        }

        public int getMultas(int nro_reserva)
        {

            try
            {
                DataTable _datatable = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(MUL.ID_MULTA) " +
                    "FROM MULTA MUL " +
                    "INNER JOIN CHECK_OUT CO ON (CO.ID_CHECKOUT = MUL.CHECK_OUT_ID_CHECKOUT) " +
                    "WHERE MUL.PAGADA = 'N' AND CO.RESERVA_NRO_RESERVA = :nro_reserva", Conec.Connect());

                command.Parameters.Add("nro_reserva", OracleDbType.Int32, 100).Value = nro_reserva;

                OracleDataAdapter _adapter = new OracleDataAdapter(command);
                _adapter.Fill(_datatable);

                int multas = Convert.ToInt32(_datatable.Rows[0][0].ToString());

                return multas;
            }
            catch (Exception ex)
            {
                int multas = -1;
                return multas;
            }
        }

        public string findIdCheckout(int nro_reserva)
        {
            try
            {
                DataTable _datatable = new DataTable();

                OracleCommand command = new OracleCommand("SELECT ID_CHECKOUT " +
                    "FROM CHECK_OUT " +
                    "WHERE RESERVA_NRO_RESERVA = :nro_reserva", Conec.Connect());

                command.Parameters.Add("nro_reserva", OracleDbType.Int32, 100).Value = nro_reserva;

                OracleDataAdapter _adapter = new OracleDataAdapter(command);
                _adapter.Fill(_datatable);

                string id_checkout = _datatable.Rows[0][0].ToString();

                return id_checkout;
            }
            catch (Exception ex)
            {
                string id_checkout = "";
                //MessageBox.Show("error al encontrar id checkout");
                return id_checkout;
            }
        }


        public void newDepartamento(string nombre, int numero, int arriendo_diario, int habitaciones, int banos, string descripcion, int metros_cuadrados, string id_region, string direccion, string estado)
        {

            try
            {
                newUbicacion(direccion, id_region);

                string ubi_id = getIdUbicacion();

                OracleCommand command = new OracleCommand("INSERT INTO DEPARTAMENTO " +
                    "(ID_DEPARTAMENTO, NOMBRE, NUMERO,ARRIENDO_DIARIO, " +
                    "HABITACIONES, BANOS, DESCRIPCION, METROS_CUADRADOS, " +
                    "VALOR_INVENTARIO, UBICACION_ID_UBICACION, " +
                    "ESTADO_DEPARTAMENTO_ID_ESTADO) " +
                    "VALUES (to_char(seq_id_dep.nextval), " +
                    ":nombre, :numero, :arriendo_diario, :habitaciones, :banos, " +
                    ":descripcion, :metros_cuadrados, :valor_inventario, " +
                    ":ubicacion_id_ubicacion,:estado_departamento_id_estado)", Conec.Connect());

                //select to_char(seq_id_dep.nextval,'FM00') from dual;


                command.Parameters.Add("nombre", OracleDbType.Varchar2, 100).Value = nombre;
                command.Parameters.Add("numero", OracleDbType.Int32, 100).Value = numero;
                command.Parameters.Add("arriendo_diario", OracleDbType.Int32, 100).Value = arriendo_diario;                command.Parameters.Add("habitaciones", OracleDbType.Int32, 100).Value = habitaciones;
                command.Parameters.Add("banos", OracleDbType.Int32, 100).Value = banos;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 500).Value = descripcion;
                command.Parameters.Add("metros_cuadrados", OracleDbType.Int32, 100).Value = metros_cuadrados;
                command.Parameters.Add("valor_inventario", OracleDbType.Int32, 100).Value = 0;
                command.Parameters.Add("ubicacion_id_ubicacion", OracleDbType.Varchar2, 100).Value = ubi_id;
                command.Parameters.Add("estado_departamento_id_estado", OracleDbType.Varchar2, 100).Value = estado;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Departamento agregado exitosamente","Agregar");
                //Departamento dep = new Departamento();
                //dep.

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar departamento: " + ex);
            }
        }




        public void UpdateInventarioValor(string id_departamento, int valor_inventario)
        {

            try
            {
                OracleCommand command = new OracleCommand("UPDATE DEPARTAMENTO " +
                    "SET VALOR_INVENTARIO = :valor_inventario " +
                    "WHERE ID_DEPARTAMENTO = :id_departamento", Conec.Connect());

                command.Parameters.Add("valor_inventario", OracleDbType.Int32, 100).Value = valor_inventario;
                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar valor del inventario del departamento: " + ex);
            }
        }


        public int GetIventarioValor(string id_departamento)
        {
            try
            {

                OracleCommand command = new OracleCommand("SELECT SUM(VALOR * CANTIDAD) AS VALOR_TOTAL " +
                "FROM DEPA_INVENTARIO " +
                "WHERE DEP_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());

                command.Parameters.Add("id_departamento", OracleDbType.Int32, 100).Value = id_departamento;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int valor_inventario = Convert.ToInt32(dt.Rows[0][0].ToString());

                return valor_inventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error get inventario: " + ex);
                int valor_inventario = 0;
                return valor_inventario;
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
                command.Parameters.Add("fecha_inicio", OracleDbType.Varchar2, 100).Value = fecha_inicio.ToString("dd/MM/yyyy HH:mm");
                command.Parameters.Add("fecha_termino", OracleDbType.Varchar2, 100).Value = fecha_termino.ToString("dd/MM/yyyy HH:mm");
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
                command.Parameters.Add("caducidad_licencia", OracleDbType.Varchar2, 100).Value = caducidad_licencia.ToString("dd/MM/yyyy HH:mm");
                command.Parameters.Add("disponibilidad", OracleDbType.Varchar2, 100).Value = disponibilidad;
                command.Parameters.Add("sueldo", OracleDbType.Int32, 100).Value = sueldo;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Conductor agregado exitosamente","Agregar");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Conductor: " + ex);
            }
        }

        public void newFoto(string descripcion, string url_imagen, string base64Text, string id_departamento)
        {
            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO FOTO " +
                    "(ID_FOTO, URL_IMAGEN, DESCRIPCION, DEPARTAMENTO_ID_DEPARTAMENTO, " +
                    "IMAGEN) VALUES (to_char(seq_id_fot.nextval), :url_imagen, " +
                    ":descripcion, :id_departamento, :imagen)", Conec.Connect());

                command.Parameters.Add("url_imagen", OracleDbType.Varchar2, 100).Value = url_imagen;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 500).Value = descripcion;
                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;
                command.Parameters.Add("imagen", OracleDbType.Varchar2, 16000000).Value = base64Text;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Foto agregada exitosamente","Agregar");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Foto: " + ex);
            }
        }

        public void newFotoPrincipal(string url_imagen, string id_departamento)
        {
            try
            {
                OracleCommand command = new OracleCommand("INSERT INTO FOTO_MUESTRA " +
                    "(DEPARTAMENTO_ID_DEPARTAMENTO, URL_IMAGEN) VALUES (:id_departamento, :url_imagen)", Conec.Connect());

                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;
                command.Parameters.Add("url_imagen", OracleDbType.Varchar2, 100).Value = url_imagen;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Foto asignada como Principal", "Foto");

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al asignar Foto Principal: " + ex);
                editFotoPrincipal(url_imagen, id_departamento);
            }
        }

        public void editFotoPrincipal(string url_imagen, string id_departamento)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE FOTO_MUESTRA " +
                    "SET URL_IMAGEN = :url_imagen " +
                    "WHERE DEPARTAMENTO_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());

                command.Parameters.Add("url_imagen", OracleDbType.Varchar2, 100).Value = url_imagen;
                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Foto asignada como Principal", "Foto");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al editar Foto Principal: " + ex);
            }
        }

        public void newCategoria(string categoria, string descripcion)
        {

            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO CATEGORIA " +
                    "(ID_CATEGORIA, CATEGORIA, DESCRIPCION) " +
                    "VALUES (to_char(seq_id_cat.nextval), :categoria, :descripcion)", Conec.Connect());

                command.Parameters.Add("categoria", OracleDbType.Varchar2, 100).Value = categoria;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 500).Value = descripcion;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Categoría agregada exitosamente","Agregar");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Categoría: " + ex);
            }
        }

        public void newServicio(string nombre_servicio, string descripcion, int costo)
        {

            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO SERVICIO_ASOCIADO " +
                    "(ID_SERVICIO, NOMBRE_SERVICIO, DESCRIPCION, COSTO, ESTADO) " +
                    "VALUES (to_char(SEQ_ID_SER.nextval), :nombre_servicio, :descripcion, :costo, :estado)", Conec.Connect());

                command.Parameters.Add("nombre_servicio", OracleDbType.Varchar2, 100).Value = nombre_servicio;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 500).Value = descripcion;
                command.Parameters.Add("costo", OracleDbType.Int32, 100).Value = costo;
                command.Parameters.Add("estado", OracleDbType.Varchar2, 100).Value = "Activo";

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Servicio agregado exitosamente", "Agregar");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Servicio: " + ex);
            }
        }

        public void editServicio(string id_servicio, string nombre_servicio, string descripcion, int costo)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE SERVICIO_ASOCIADO " +
                    "SET NOMBRE_SERVICIO = :nombre_servicio, " +
                    "DESCRIPCION = :descripcion, COSTO = :costo " +
                    "WHERE ID_SERVICIO = :id_servicio", Conec.Connect());

                command.Parameters.Add("nombre_servicio", OracleDbType.Varchar2, 100).Value = nombre_servicio;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = descripcion;
                command.Parameters.Add("costo", OracleDbType.Int32, 100).Value = costo;
                command.Parameters.Add("id_servicio", OracleDbType.Varchar2, 100).Value = id_servicio;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Servicio editado exitosamente", "Editar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar Servicio: " + ex);
            }
        }

        public void deleteServicio(string id_servicio)
        {
            try
            {
                OracleCommand command = new OracleCommand("DELETE FROM SERVICIO_ASOCIADO " +
                    "WHERE ID_SERVICIO = :id_servicio", Conec.Connect());

                command.Parameters.Add("id_servicio", OracleDbType.Varchar2, 100).Value = id_servicio;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Servicio eliminado exitosamente", "Eliminar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar Servicio: " + ex);
            }
        }

        public void deleteServAsoc(string id_servicio, string id_departamento)
        {
            try
            {
                OracleCommand command = new OracleCommand("DELETE FROM DEPA_ASOC " +
                    "WHERE SERVICIO_ASOCIADO_ID_SERVICIO = :id_servicio AND DEPARTAMENTO_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());

                command.Parameters.Add("id_servicio", OracleDbType.Varchar2, 100).Value = id_servicio;
                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Servicio quitado exitosamente", "Quitar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar Servicio: " + ex);
            }
        }

        public void MoveServAsoc(string id_servicio, string id_departamento)
        {

            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO DEPA_ASOC " +
                    "(SERVICIO_ASOCIADO_ID_SERVICIO, DEPARTAMENTO_ID_DEPARTAMENTO) " +
                    "VALUES (:id_servicio, :id_departamento)", Conec.Connect());

                command.Parameters.Add("id_servicio", OracleDbType.Varchar2, 100).Value = id_servicio;
                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Servicio movido exitosamente", "Mover");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mover Servicio: " + ex);
            }
        }

        public void newVehiculo(string patente, string disponibilidad, string modelo, string id_estado, int capacidad, string descripcion)
        {

            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO VEHICULO " +
                    "(PATENTE, DISPONIBILIDAD, MODELO, ESTADO_VEHICULO_ID_ESTADO_VEHI, CAPACIDAD, " +
                    "DESCRIPCION) VALUES (:patente, :disponibilidad, :modelo, " +
                    ":id_estado, :capacidad, :descripcion)", Conec.Connect());

                command.Parameters.Add("patente", OracleDbType.Varchar2, 100).Value = patente;
                command.Parameters.Add("disponibilidad", OracleDbType.Varchar2, 100).Value = disponibilidad;
                command.Parameters.Add("modelo", OracleDbType.Varchar2, 100).Value = modelo;
                command.Parameters.Add("id_estado", OracleDbType.Varchar2, 100).Value = id_estado;
                command.Parameters.Add("capacidad", OracleDbType.Int32, 100).Value = capacidad;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 500).Value = descripcion;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Vehículo agregado exitosamente","Agregar");

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
    
        public void editDepartamento(string id_departamento, string nombre, int numero,int arriendo_diario, int habitaciones, int banos, string descripcion, int metros_cuadrados, string id_region, string id_estado, string direccion, string id_ubicacion)
        {
            //editEstado();


            try
            {
                //MessageBox.Show("id_estado: " + id_estado);
                OracleCommand command = new OracleCommand("UPDATE DEPARTAMENTO " +
                    "SET NOMBRE = :nombre, NUMERO = :numero, ARRIENDO_DIARIO = :arriendo_diario, " +
                    "HABITACIONES = :habitaciones, BANOS = :banos, DESCRIPCION = :descripcion, " +
                    "METROS_CUADRADOS = :metros_cuadrados, " +
                    "ESTADO_DEPARTAMENTO_ID_ESTADO = :id_estado " +
                    "WHERE ID_DEPARTAMENTO = :id_departamento", Conec.Connect());


                //MessageBox.Show("reservado: " + reservado);
                //MessageBox.Show("metros_cuadrados: " + metros_cuadrados.ToString());

                command.Parameters.Add("nombre", OracleDbType.Varchar2, 100).Value = nombre;
                command.Parameters.Add("numero", OracleDbType.Int32, 100).Value = numero;
                command.Parameters.Add("arriendo_diario", OracleDbType.Int32, 100).Value = arriendo_diario;
                command.Parameters.Add("habitaciones", OracleDbType.Int32, 100).Value = habitaciones;
                command.Parameters.Add("banos", OracleDbType.Int32, 100).Value = banos;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = descripcion;
                command.Parameters.Add("metros_cuadrados", OracleDbType.Int32, 100).Value = metros_cuadrados;
                command.Parameters.Add("id_estado", OracleDbType.Varchar2, 100).Value = id_estado;
                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Departamento editado exitosamente","Editar");

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
                OracleCommand command = new OracleCommand("UPDATE DEPA_INVENTARIO " +
                    "SET VALOR = :valor, CANTIDAD = :cantidad " +
                    "WHERE INV_ID_ART = :id_articulo AND DEP_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());


                command.Parameters.Add("valor", OracleDbType.Int32, 100).Value = valor;
                command.Parameters.Add("cantidad", OracleDbType.Int32, 100).Value = cantidad;
                command.Parameters.Add("id_articulo", OracleDbType.Varchar2, 100).Value = id_articulo;
                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Valores editados exitosamente","Editar");
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

                OracleCommand command = new OracleCommand("DELETE FROM DEPA_INVENTARIO " +
                    "WHERE INV_ID_ART = :id_articulo AND DEP_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());

                command.Parameters.Add("id_articulo", OracleDbType.Varchar2, 100).Value = id_articulo;
                command.Parameters.Add("id_articulo", OracleDbType.Varchar2, 100).Value = id_departamento;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Artículo eliminado exitosamente","Eliminar");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar artículo: " + ex);
            }
        }

        public void newCheckOut(int nro_reserva, string firma_cliente)
        {
            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO CHECK_OUT " +
                    "(ID_CHECKOUT, RESERVA_NRO_RESERVA, ACTIVO, HORA_SALIDA, FIRMA_CLIENTE) " +
                    "VALUES (to_char(SEQ_ID_CHECK_OUT.nextval), " +
                    ":nro_reserva, :activo, :hora_salida, :firma_cliente)", Conec.Connect());

                command.Parameters.Add("nro_reserva", OracleDbType.Int32, 100).Value = nro_reserva;
                command.Parameters.Add("activo", OracleDbType.Varchar2, 100).Value = "N";
                command.Parameters.Add("hora_salida", OracleDbType.Varchar2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                command.Parameters.Add("firma_cliente", OracleDbType.Varchar2, 12000000).Value = firma_cliente;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                //MessageBox.Show("El Check Out se realizó exitosamente", "Check Out finalizado");

            }
            catch (Exception ex)
            {
                editPendingCheckOut(nro_reserva, firma_cliente);
                //MessageBox.Show("Error al realizar Check Out: " + ex);
            }
        }

        public void CheckInNoActivo(int nro_reserva)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE CHECK_IN " +
                    "SET ACTIVO = :activo " +
                    "WHERE RESERVA_NRO_RESERVA = :nro_reserva", Conec.Connect());

                command.Parameters.Add("activo", OracleDbType.Varchar2, 100).Value = "N";
                command.Parameters.Add("nro_reserva", OracleDbType.Int32, 100).Value = nro_reserva;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al finalizar Check in: " + ex);
            }
        }


        public void newMulta(string id_checkout, string descripcion, int costo)
        {
            try
            {
                OracleCommand command = new OracleCommand("INSERT INTO MULTA " +
                    "(ID_MULTA, DESCRIPCION, COSTO, FECHA_CREACION, CHECK_OUT_ID_CHECKOUT, PAGADA) " +
                    "VALUES (to_char(SEQ_ID_MUL.nextval), " +
                    ":descripcion, :costo, :fecha_creacion, :id_checkout, :pagada)", Conec.Connect());

                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 200).Value = descripcion;
                command.Parameters.Add("costo", OracleDbType.Varchar2, 100).Value = costo;
                command.Parameters.Add("fecha_creacion", OracleDbType.Varchar2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm"); 
                command.Parameters.Add("id_checkout", OracleDbType.Varchar2).Value = id_checkout;
                command.Parameters.Add("pagada", OracleDbType.Varchar2, 100).Value = "N";
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Multa creada exitosamente", "Crear");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear multa: " + ex);
            }
        }

        public void newCheckOutAndMulta(int nro_reserva, string descripcion, int costo)
        {
            try
            {
                //si el cliente no tenia multas ni un checkout ingresado
                OracleCommand command = new OracleCommand("INSERT INTO CHECK_OUT " +
                    "(ID_CHECKOUT, RESERVA_NRO_RESERVA, ACTIVO) " +
                    "VALUES (to_char(SEQ_ID_CHECK_OUT.nextval), " +
                    ":nro_reserva, :activo)", Conec.Connect());

                command.Parameters.Add("nro_reserva", OracleDbType.Int32, 100).Value = nro_reserva;
                command.Parameters.Add("activo", OracleDbType.Varchar2, 100).Value = "Y";
                //command.Parameters.Add("hora_salida", OracleDbType.Date).Value = null;
                //command.Parameters.Add("firma_cliente", OracleDbType.Varchar2, 12000000).Value = null;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                newMulta(GetIdCheckOut(), descripcion, costo);

            }
            catch (Exception ex)
            {
                //si el cliente tiene un checkout previamente ingresado
                //debido a multa
                newMulta(findIdCheckout(nro_reserva), descripcion, costo);

            }

        }


        public string getIdPago()
        {

            try
            {
                DataTable _datatable = new DataTable();
                OracleDataAdapter _adapter = new OracleDataAdapter("SELECT MAX(TO_NUMBER(ID_PAGO)) FROM PAGO", Conec.Connect());
                _adapter.Fill(_datatable);

                string id_pago = _datatable.Rows[0][0].ToString();

                return id_pago;
            }
            catch (Exception ex)
            {
                string id_pago = "0";
                //MessageBox.Show("error getIdPago()" + ex);
                return id_pago;
            }
        }

        public void newPago(string id_pago, int monto)
        {
            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO PAGO " +
                    "(ID_PAGO, FECHA_PAGO, ESTADO, MONTO) " +
                    "VALUES (:id_pago, " +
                    ":fecha_pago, :estado, :monto)", Conec.Connect());

                command.Parameters.Add("id_pago", OracleDbType.Int32, 100).Value = id_pago;
                command.Parameters.Add("fecha_pago", OracleDbType.Varchar2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                command.Parameters.Add("estado", OracleDbType.Varchar2, 100).Value = "PAGADO";
                command.Parameters.Add("monto", OracleDbType.Int32, 100).Value = monto;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                //MessageBox.Show("newPago(..) realizado");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en newPago(..)" + ex);
            }
        }

        public void newPagoReservaEstadía(int nro_reserva, string id_pago, string medio_pago, string comprobante_transferencia)
        {
            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO PAGO_RESERVA " +
                    "(RESERVA_NRO_RESERVA, PAGO_ID_PAGO, DESCRIPCION, MEDIO_PAGO, COMPROBANTE_TRANSFERENCIA) " +
                    "VALUES (:nro_reserva, :id_pago, :descripcion, :medio_pago, :comprobante_transferencia)", Conec.Connect());

                command.Parameters.Add("nro_reserva", OracleDbType.Int32, 100).Value = nro_reserva;
                command.Parameters.Add("id_pago", OracleDbType.Varchar2, 100).Value = id_pago;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = "Estadía";
                command.Parameters.Add("medio_pago", OracleDbType.Varchar2, 100).Value = medio_pago;
                command.Parameters.Add("comprobante_transferencia", OracleDbType.Varchar2, 12000000).Value = comprobante_transferencia;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                //MessageBox.Show("newPagoReservaMulta(..) realizado");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en newPagoReservaMulta(..)" + ex);
            }
        }


        public void newPagoReservaMulta(int nro_reserva, string id_pago, string medio_pago, string comprobante_transferencia)
        {
            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO PAGO_RESERVA " +
                    "(RESERVA_NRO_RESERVA, PAGO_ID_PAGO, DESCRIPCION, MEDIO_PAGO, COMPROBANTE_TRANSFERENCIA) " +
                    "VALUES (:nro_reserva, :id_pago, :descripcion, :medio_pago, :comprobante_transferencia)", Conec.Connect());

                command.Parameters.Add("nro_reserva", OracleDbType.Int32, 100).Value = nro_reserva;
                command.Parameters.Add("id_pago", OracleDbType.Varchar2, 100).Value = id_pago;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = "Multa";
                command.Parameters.Add("medio_pago", OracleDbType.Varchar2, 100).Value = medio_pago;
                command.Parameters.Add("comprobante_transferencia", OracleDbType.Varchar2, 12000000).Value = comprobante_transferencia;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                //MessageBox.Show("newPagoReservaMulta(..) realizado");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en newPagoReservaMulta(..)" + ex);
            }
        }



        public void editPendingCheckOut(int nro_reserva, string firma_cliente)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE CHECK_OUT " +
                    "SET ACTIVO = :activo, FIRMA_CLIENTE = :firma_cliente, " +
                    "HORA_SALIDA = :hora_salida " +
                    "WHERE RESERVA_NRO_RESERVA = :nro_reserva", Conec.Connect());

                command.Parameters.Add("activo", OracleDbType.Varchar2, 100).Value = "N";
                command.Parameters.Add("firma_cliente", OracleDbType.Varchar2, 12000000).Value = firma_cliente;
                command.Parameters.Add("hora_salida", OracleDbType.Varchar2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                command.Parameters.Add("nro_reserva", OracleDbType.Int32, 100).Value = nro_reserva;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                //MessageBox.Show("El Check Out se realizó exitosamente", "Check Out finalizado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar Check Out: " + ex);
            }
        }

        public void addDepaInventario(int valor, int cantidad, string id_articulo, string id_departamento)
        {
            try
            {
                OracleCommand command = new OracleCommand("INSERT INTO DEPA_INVENTARIO " +
                    "(VALOR, CANTIDAD, INV_ID_ART, DEP_ID_DEPARTAMENTO) VALUES (:valor, " +
                    ":cantidad, :id_articulo, :id_departamento)", Conec.Connect());


                command.Parameters.Add("valor", OracleDbType.Int32, 100).Value = valor;
                command.Parameters.Add("cantidad", OracleDbType.Int32, 100).Value = cantidad;
                command.Parameters.Add("id_articulo", OracleDbType.Varchar2, 100).Value = id_articulo;
                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Artículo agregado al departamento", "Agregar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("El artículo ya existe en el departamento","Error");
            }
        }

        public void addArticulo(string nombre_articulo, string descripcion, string id_categoria)
        {
            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO INVENTARIO " +
                    "(ID_ARTICULO, NOMBRE_ARTICULO, DESCRIPCION, CATEGORIA_ID_CATEGORIA) VALUES (to_char(seq_id_art.nextval), " +
                    ":nombre_articulo, :descripcion, :id_categoria)", Conec.Connect());

                command.Parameters.Add("nombre_articulo", OracleDbType.Varchar2, 100).Value = nombre_articulo;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = descripcion;
                command.Parameters.Add("id_categoria", OracleDbType.Varchar2, 100).Value = id_categoria;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Artículo agregado exitosamente", "Agregar");

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
                    "CATEGORIA_ID_CATEGORIA = :id_categoria " +
                    "WHERE ID_ARTICULO = :id_articulo", Conec.Connect());

                command.Parameters.Add("nombre_articulo", OracleDbType.Varchar2, 100).Value = nombre_articulo;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = descripcion;
                command.Parameters.Add("id_categoria", OracleDbType.Varchar2, 100).Value = id_categoria;
                command.Parameters.Add("id_articulo", OracleDbType.Varchar2, 100).Value = id_articulo;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Artículo editado exitosamente", "Editar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar Artículo: " + ex);
            }
        }

        public void editFoto(string descripcion, string url_imagen, string imagen, string id_foto)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE FOTO " +
                    "SET URL_IMAGEN = :url_imagen, DESCRIPCION = :descripcion, " +
                    "IMAGEN = :imagen " +
                    "WHERE ID_FOTO = :id_foto", Conec.Connect());

                command.Parameters.Add("url_imagen", OracleDbType.Varchar2, 100).Value = url_imagen;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = descripcion;
                command.Parameters.Add("imagen", OracleDbType.Varchar2, 16000000).Value = imagen;
                command.Parameters.Add("id_foto", OracleDbType.Varchar2, 100).Value = id_foto;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Foto editada exitosamente","Editar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar Foto: " + ex);
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
                command.Parameters.Add("caducidad_licencia", OracleDbType.Varchar2, 100).Value = caducidad_licencia.ToString("dd/MM/yyyy HH:mm");
                command.Parameters.Add("disponibilidad", OracleDbType.Varchar2, 100).Value = disponibilidad;
                command.Parameters.Add("sueldo", OracleDbType.Int32, 100).Value = sueldo;
                command.Parameters.Add("rut_conductor", OracleDbType.Varchar2, 100).Value = rut_conductor;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Conductor editado exitosamente","Editar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar Conductor: " + ex);
            }
        }

        public void editVehiculo(string patente, string temp_patente, string disponibilidad, string modelo, string id_estado, int capacidad, string descripcion)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE VEHICULO " +
                    "SET PATENTE = :patente, " +
                    "DISPONIBILIDAD = :disponibilidad, MODELO = :modelo, " +
                    "ESTADO_VEHICULO_ID_ESTADO_VEHI = :id_estado, " +
                    "CAPACIDAD = :capacidad, DESCRIPCION = :descripcion " +
                    "WHERE PATENTE = :temp_patente", Conec.Connect());

                command.Parameters.Add("patente", OracleDbType.Varchar2, 100).Value = patente;
                command.Parameters.Add("disponibilidad", OracleDbType.Varchar2, 100).Value = disponibilidad;
                command.Parameters.Add("modelo", OracleDbType.Varchar2, 100).Value = modelo;
                command.Parameters.Add("id_estado", OracleDbType.Varchar2, 100).Value = id_estado;
                command.Parameters.Add("capacidad", OracleDbType.Int32, 100).Value = capacidad;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 500).Value = descripcion;
                command.Parameters.Add("temp_patente", OracleDbType.Varchar2, 100).Value = temp_patente;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Vehiculo editado exitosamente","Editar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar Vehiculo: " + ex);
            }
        }

        public void editCategoria(string id_categoria, string categoria, string descripcion)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE CATEGORIA " +
                    "SET CATEGORIA = :categoria, DESCRIPCION = :descripcion " +
                    "WHERE ID_CATEGORIA = :id_categoria", Conec.Connect());

                command.Parameters.Add("categoria", OracleDbType.Varchar2, 100).Value = categoria;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 500).Value = descripcion;
                command.Parameters.Add("id_categoria", OracleDbType.Varchar2, 100).Value = id_categoria;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Categoría editada exitosamente","Editar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar Categoría: " + ex);
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

                MessageBox.Show("Artículo eliminado exitosamente","Eliminar");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar artículo: " + ex);
            }
        }

        public void deleteMulta(string id_multa)
        {
            try
            {

                OracleCommand command = new OracleCommand("DELETE FROM MULTA " +
                    "WHERE ID_MULTA = :id_multa", Conec.Connect());

                command.Parameters.Add("id_multa", OracleDbType.Varchar2, 100).Value = id_multa;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Multa eliminada exitosamente","Eliminar");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar multa: " + ex);
            }
        }


        public void deleteFoto(string id_foto)
        {
            try
            {
                OracleCommand command = new OracleCommand("DELETE FROM FOTO " +
                    "WHERE ID_FOTO = :id_foto", Conec.Connect());

                command.Parameters.Add("id_foto", OracleDbType.Varchar2, 100).Value = id_foto;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Foto eliminada exitosamente","Eliminar");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar Foto: " + ex);
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

                MessageBox.Show("Vehiculo eliminado exitosamente","Eliminar");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar vehiculo: " + ex);
            }
        }

        public void deleteCategoria(string id_categoria)
        {
            try
            {

                OracleCommand command = new OracleCommand("DELETE FROM CATEGORIA " +
                    "WHERE ID_CATEGORIA = :id_categoria", Conec.Connect());

                command.Parameters.Add("id_categoria", OracleDbType.Varchar2, 100).Value = id_categoria;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Categoría eliminada exitosamente","Eliminar");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar categoría: " + ex);
            }
        }

        public void deleteConductor(string rut_conductor)
        {
            try
            {
                OracleCommand command = new OracleCommand("DELETE FROM CONDUCTOR " +
                    "WHERE RUT_CONDUCTOR = :rut_conductor", Conec.Connect());

                command.Parameters.Add("rut_conductor", OracleDbType.Varchar2, 100).Value = rut_conductor;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Conductor eliminado exitosamente","Eliminar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar categoría: " + ex);
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
                command.Parameters.Add("fecha_inicio", OracleDbType.Varchar2, 100).Value = fecha_inicio.ToString("dd/MM/yyyy HH:mm");
                command.Parameters.Add("fecha_termino", OracleDbType.Varchar2, 100).Value = fecha_termino.ToString("dd/MM/yyyy HH:mm");
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

                MessageBox.Show("Departamento eliminado exitosamente","Eliminar");

                deleteFotoPrincipal(id_departamento);

            }
            catch (Exception ex)
            {
                MessageBox.Show("El Departamento no se pudo eliminar", "Error");
            }
        }

        public void deleteFotoPrincipal(string id_departamento)
        {
            try
            {

                OracleCommand command = new OracleCommand("DELETE FROM FOTO_MUESTRA " +
                    "WHERE DEPARTAMENTO_ID_DEPARTAMENTO = :id_departamento", Conec.Connect());

                command.Parameters.Add("id_departamento", OracleDbType.Varchar2, 100).Value = id_departamento;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                //MessageBox.Show("Departamento eliminado exitosamente", "Eliminar");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en deleteFotoPrincipal() " + ex);
            }
        }

        public void editMulta(string id_multa, string descripcion, int costo)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE MULTA " +
                    "SET DESCRIPCION = :descripcion, COSTO = :costo " +
                    "WHERE ID_MULTA = :id_multa", Conec.Connect());

                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 200).Value = descripcion;
                command.Parameters.Add("costo", OracleDbType.Int32, 100).Value = costo;
                command.Parameters.Add("id_multa", OracleDbType.Varchar2, 100).Value = id_multa;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Multa editada exitosamente", "Editar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar multa: " + ex);
            }
        }


        public void PagarMulta(string id_multa)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE MULTA " +
                    "SET PAGADA = :pagada, FECHA_PAGO = :fecha_pago " +
                    "WHERE ID_MULTA = :id_multa", Conec.Connect());

                command.Parameters.Add("pagada", OracleDbType.Varchar2, 100).Value = "Y";
                command.Parameters.Add("fecha_pago", OracleDbType.Varchar2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                command.Parameters.Add("id_multa", OracleDbType.Varchar2, 100).Value = id_multa;
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Multa pagada exitosamente","Pagar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al pagar multa: " + ex);
            }
        }

        public void deleteUbicacion(string id_ubicacion)
        {
            try
            {
                OracleCommand command = new OracleCommand("DELETE FROM UBICACION " +
                    "WHERE ID_UBICACION = :id_ubicacion", Conec.Connect());

                command.Parameters.Add("id_ubicacion", OracleDbType.Varchar2, 100).Value = id_ubicacion;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                //MessageBox.Show("Ubicación eliminada");

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al eliminar Ubicación: " + ex);
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

                MessageBox.Show("Mantención eliminada exitosamente","Eliminar");

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

        public void fromStringToPhoto(string stringPhoto, Image ImgImagen)
        {
            try
            {
                byte[] binaryData = Convert.FromBase64String(stringPhoto);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                Image img = new Image();
                ImgImagen.Source = bi;
            }
            catch (Exception ex)
            {
                MessageBox.Show("string vacio: " + ex);
            }
        }

        public string ConvertImageToBase64String(byte[] image_array)
        {
            try
            {
                string base64ImageRepresentation = Convert.ToBase64String(image_array);
                return base64ImageRepresentation;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error en ConvertImageToBase64String(byte[] image_array)");
                string base64ImageRepresentation = "";
                return base64ImageRepresentation;
            }
        }

        public void Usuario(string _usuario)
        {
            try
            {
                user_login = _usuario;
            }
            catch (Exception ex)
            {
            }
        }
        public void TipoUsuario(string _usertype_login)
        {
            try
            {
                usertype_login = _usertype_login;
            }
            catch (Exception ex)
            {
            }
        }

        public static string user_login { get; set; }
        public static string usertype_login { get; set; }






        //


        public DataTable ReservaData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT RES.NRO_RESERVA, RES.TOTAL_PERSONAS, " +
                "RES.FECHA_RESERVA, RD.RESERVA_INICIO, RES.VALOR_SERVICIOS_EXTRA, RES.VALOR_DIAS, RES.VALOR_TOTAL, " +
                "CLI.NOMBRES, CLI.APELLIDOS, " +
                "RES.CLIENTE_RUT_CLIENTE, RES.CANTIDAD_NINOS, RES.CANTIDAD_ADULTOS " +
                "FROM RESERVA RES " +
                "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                "INNER JOIN CLIENTE CLI ON CLI.RUT_CLIENTE = RES.CLIENTE_RUT_CLIENTE " +
                "LEFT JOIN CHECK_IN CI ON CI.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                "WHERE NOT EXISTS " +
                    "(SELECT NULL " +
                    "FROM CHECK_IN " +
                    "WHERE CI.RESERVA_NRO_RESERVA = RES.NRO_RESERVA)", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error en ReservaData()" + ex);
                DataTable dt = null;
                return dt;
            }

        }


        public DataTable CheckInData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT  CI.RESERVA_NRO_RESERVA, " +
                "CI.ID_CHECKIN, CLI.RUT_CLIENTE, CLI.NOMBRES, CLI.APELLIDOS, " +
                "CI.PAGO_ESTADIA, CI.CONDICION_DEPARTAMENTO, CI.HORA_INGRESO, RD.RESERVA_INICIO, " +
                "RD.RESERVA_TERMINO, CI.ACTIVO, CI.ANOTACIONES, REGA.CONTENIDO, CI.REGALO_ID_REGALO " +
                "FROM CHECK_IN CI " +
                "INNER JOIN REGALO REGA ON REGA.ID_REGALO = CI.REGALO_ID_REGALO " +
                "INNER JOIN RESERVA RES ON RES.NRO_RESERVA = CI.RESERVA_NRO_RESERVA " +
                "INNER JOIN CLIENTE CLI ON(CLI.RUT_CLIENTE = RES.CLIENTE_RUT_CLIENTE) " +
                "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                "WHERE CI.ACTIVO = 'Y'", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("check in data error" + ex);
                DataTable dt = null;
                return dt;
            }
        }


        public DataTable dtestadoNroReservaInData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT NRO_RESERVA FROM RESERVA", Conec.Connect());
                OracleDataReader dr = command.ExecuteReader();
                OracleDataAdapter da = new OracleDataAdapter(command);
                //DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                da = new OracleDataAdapter(command);
                da.Fill(dt);


                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error en dtestadoNroReservaInData()" + ex);
                DataTable dt = null;
                return dt;
            }

        }


        public string EstDepCantidad(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(ID_DEPARTAMENTO) " +
                    "FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE UBI.REGION_ID_REGION = :id_region", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }

        public string EstDepBuenEstado(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(ID_DEPARTAMENTO) " +
                    "FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE UBI.REGION_ID_REGION = :id_region", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }

        public string EstDepPrecioPromedio(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT ROUND(AVG(ARRIENDO_DIARIO), 0) FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE UBI.REGION_ID_REGION = :id_region AND ARRIENDO_DIARIO != 0", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }

        public string EstDepPrecioMasAlto(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT MAX(ARRIENDO_DIARIO) FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE UBI.REGION_ID_REGION = :id_region AND ARRIENDO_DIARIO != 0", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }

        public string EstDepPrecioMasBajo(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT MIN(ARRIENDO_DIARIO) FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE UBI.REGION_ID_REGION = :id_region AND ARRIENDO_DIARIO != 0", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }

        public string EstDepValorInventarioTotal(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT SUM(VALOR_INVENTARIO) FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE UBI.REGION_ID_REGION = :id_region AND ARRIENDO_DIARIO != 0", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }

        public string EstDepValorInventarioPromedio(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT ROUND(AVG(VALOR_INVENTARIO), 0) FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE UBI.REGION_ID_REGION = :id_region AND ARRIENDO_DIARIO != 0", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }


        public string EstResReservasCantidad(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(NRO_RESERVA) " +
                    "FROM RESERVA RES " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE UBI.REGION_ID_REGION = :id_region", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }

        public string EstResReservasAgendadasCantidad(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(RES.NRO_RESERVA), RES.TOTAL_PERSONAS, " + 
                    "RES.FECHA_RESERVA, RD.RESERVA_INICIO, RES.VALOR_SERVICIOS_EXTRA, " +
                    "RES.VALOR_DIAS, RES.VALOR_TOTAL, " +
                    "CLI.NOMBRES, CLI.APELLIDOS, " +
                    "RES.CLIENTE_RUT_CLIENTE, RES.CANTIDAD_NINOS, RES.CANTIDAD_ADULTOS " +
                    "FROM RESERVA RES " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN CLIENTE CLI ON CLI.RUT_CLIENTE = RES.CLIENTE_RUT_CLIENTE " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "LEFT JOIN CHECK_IN CI ON CI.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "WHERE UBI.REGION_ID_REGION = :id_region " +
                    "AND NOT EXISTS " +
                    "(SELECT NULL " +
                    "FROM CHECK_IN " +
                    "WHERE CI.RESERVA_NRO_RESERVA = RES.NRO_RESERVA)" +
                    "GROUP BY RES.TOTAL_PERSONAS, " +
                    "RES.FECHA_RESERVA, RD.RESERVA_INICIO, RES.VALOR_SERVICIOS_EXTRA, " +
                    "RES.VALOR_DIAS, RES.VALOR_TOTAL, " +
                    "CLI.NOMBRES, CLI.APELLIDOS, " +
                    "RES.CLIENTE_RUT_CLIENTE, RES.CANTIDAD_NINOS, RES.CANTIDAD_ADULTOS", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }


        public string EstResReservasActualesCantidad(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(CI.RESERVA_NRO_RESERVA), " +
                    "CI.ID_CHECKIN, CLI.RUT_CLIENTE, CLI.NOMBRES, CLI.APELLIDOS, " +
                    "CI.PAGO_ESTADIA, CI.CONDICION_DEPARTAMENTO, CI.HORA_INGRESO, RD.RESERVA_INICIO, " +
                    "RD.RESERVA_TERMINO, CI.ACTIVO, CI.ANOTACIONES, REGA.CONTENIDO, CI.REGALO_ID_REGALO " +
                    "FROM CHECK_IN CI " +
                    "INNER JOIN REGALO REGA ON REGA.ID_REGALO = CI.REGALO_ID_REGALO " +
                    "INNER JOIN RESERVA RES ON RES.NRO_RESERVA = CI.RESERVA_NRO_RESERVA " +
                    "INNER JOIN CLIENTE CLI ON(CLI.RUT_CLIENTE = RES.CLIENTE_RUT_CLIENTE) " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE CI.ACTIVO = 'Y' AND UBI.REGION_ID_REGION = :id_region " +
                    "GROUP BY CI.ID_CHECKIN, CLI.RUT_CLIENTE, CLI.NOMBRES, CLI.APELLIDOS, " +
                    "CI.PAGO_ESTADIA, CI.CONDICION_DEPARTAMENTO, CI.HORA_INGRESO, RD.RESERVA_INICIO, " +
                    "RD.RESERVA_TERMINO, CI.ACTIVO, CI.ANOTACIONES, REGA.CONTENIDO, CI.REGALO_ID_REGALO ", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }


        public string EstResReservasFinalizadasCantidad(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(RES.NRO_RESERVA), " +
                    "CLI.RUT_CLIENTE, CLI.NOMBRES, " +
                    "CLI.APELLIDOS, RES.FECHA_RESERVA, " +
                    "RD.RESERVA_INICIO, RD.RESERVA_TERMINO, " +
                    "CO.ACTIVO " +
                    "FROM RESERVA RES " +
                    "INNER JOIN CHECK_OUT CO ON CO.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN CLIENTE CLI ON CLI.RUT_CLIENTE = RES.CLIENTE_RUT_CLIENTE " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE CO.ACTIVO = 'N' AND UBI.REGION_ID_REGION = :id_region " +
                    "GROUP BY CLI.RUT_CLIENTE, CLI.NOMBRES, CLI.APELLIDOS, RES.FECHA_RESERVA, " +
                    "RD.RESERVA_INICIO, RD.RESERVA_TERMINO, CO.ACTIVO ", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }

        public string EstResIngresosReserva(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT SUM(MONTO) " +
                    "FROM PAGO_RESERVA PR " +
                    "INNER JOIN PAGO PAG ON PAG.ID_PAGO = PR.PAGO_ID_PAGO " +
                    "INNER JOIN RESERVA RES ON RES.NRO_RESERVA = PR.RESERVA_NRO_RESERVA " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE PR.DESCRIPCION = 'Reserva' AND UBI.REGION_ID_REGION = :id_region", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }

        public string EstResIngresosCheckIn(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT SUM(MONTO) " +
                    "FROM PAGO_RESERVA PR " +
                    "INNER JOIN PAGO PAG ON PAG.ID_PAGO = PR.PAGO_ID_PAGO " +
                    "INNER JOIN RESERVA RES ON RES.NRO_RESERVA = PR.RESERVA_NRO_RESERVA " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE PR.DESCRIPCION = 'Estadía' AND UBI.REGION_ID_REGION = :id_region", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }

        public string EstResCostosMultas(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT SUM(MONTO) " +
                    "FROM PAGO_RESERVA PR " +
                    "INNER JOIN PAGO PAG ON PAG.ID_PAGO = PR.PAGO_ID_PAGO " +
                    "INNER JOIN RESERVA RES ON RES.NRO_RESERVA = PR.RESERVA_NRO_RESERVA " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE PR.DESCRIPCION = 'Multa' AND UBI.REGION_ID_REGION = :id_region", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }

        public string EstResCostoReservaTotal(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT SUM(MONTO) " +
                    "FROM PAGO_RESERVA PR " +
                    "INNER JOIN PAGO PAG ON PAG.ID_PAGO = PR.PAGO_ID_PAGO " +
                    "INNER JOIN RESERVA RES ON RES.NRO_RESERVA = PR.RESERVA_NRO_RESERVA " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE UBI.REGION_ID_REGION = :id_region", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }







        ///
        public string TEstDepCantidad(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(ID_DEPARTAMENTO) " +
                    "FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION ", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }

        public string TEstDepBuenEstado(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(ID_DEPARTAMENTO) " +
                    "FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION ", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }

        public string TEstDepPrecioPromedio(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT ROUND(AVG(ARRIENDO_DIARIO), 0) FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE ARRIENDO_DIARIO != 0", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }

        public string TEstDepPrecioMasAlto(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT MAX(ARRIENDO_DIARIO) FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE ARRIENDO_DIARIO != 0", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }

        public string TEstDepPrecioMasBajo(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT MIN(ARRIENDO_DIARIO) FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE ARRIENDO_DIARIO != 0", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }

        public string TEstDepValorInventarioTotal(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT SUM(VALOR_INVENTARIO) FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE ARRIENDO_DIARIO != 0", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }

        public string TEstDepValorInventarioPromedio(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT ROUND(AVG(VALOR_INVENTARIO), 0) FROM DEPARTAMENTO DEP " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE ARRIENDO_DIARIO != 0", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }
        }


        public string TEstResReservasCantidad(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(NRO_RESERVA) " +
                    "FROM RESERVA RES " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION ", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }

        public string TEstResReservasAgendadasCantidad(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(RES.NRO_RESERVA), RES.TOTAL_PERSONAS, " +
                    "RES.FECHA_RESERVA, RD.RESERVA_INICIO, RES.VALOR_SERVICIOS_EXTRA, " +
                    "RES.VALOR_DIAS, RES.VALOR_TOTAL, " +
                    "CLI.NOMBRES, CLI.APELLIDOS, " +
                    "RES.CLIENTE_RUT_CLIENTE, RES.CANTIDAD_NINOS, RES.CANTIDAD_ADULTOS " +
                    "FROM RESERVA RES " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN CLIENTE CLI ON CLI.RUT_CLIENTE = RES.CLIENTE_RUT_CLIENTE " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "LEFT JOIN CHECK_IN CI ON CI.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "WHERE NOT EXISTS " +
                    "(SELECT NULL " +
                    "FROM CHECK_IN " +
                    "WHERE CI.RESERVA_NRO_RESERVA = RES.NRO_RESERVA)" +
                    "GROUP BY RES.TOTAL_PERSONAS, " +
                    "RES.FECHA_RESERVA, RD.RESERVA_INICIO, RES.VALOR_SERVICIOS_EXTRA, " +
                    "RES.VALOR_DIAS, RES.VALOR_TOTAL, " +
                    "CLI.NOMBRES, CLI.APELLIDOS, " +
                    "RES.CLIENTE_RUT_CLIENTE, RES.CANTIDAD_NINOS, RES.CANTIDAD_ADULTOS", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }


        public string TEstResReservasActualesCantidad(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(CI.RESERVA_NRO_RESERVA), " +
                    "CI.ID_CHECKIN, CLI.RUT_CLIENTE, CLI.NOMBRES, CLI.APELLIDOS, " +
                    "CI.PAGO_ESTADIA, CI.CONDICION_DEPARTAMENTO, CI.HORA_INGRESO, RD.RESERVA_INICIO, " +
                    "RD.RESERVA_TERMINO, CI.ACTIVO, CI.ANOTACIONES, REGA.CONTENIDO, CI.REGALO_ID_REGALO " +
                    "FROM CHECK_IN CI " +
                    "INNER JOIN REGALO REGA ON REGA.ID_REGALO = CI.REGALO_ID_REGALO " +
                    "INNER JOIN RESERVA RES ON RES.NRO_RESERVA = CI.RESERVA_NRO_RESERVA " +
                    "INNER JOIN CLIENTE CLI ON(CLI.RUT_CLIENTE = RES.CLIENTE_RUT_CLIENTE) " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE CI.ACTIVO = 'Y'" +
                    "GROUP BY CI.ID_CHECKIN, CLI.RUT_CLIENTE, CLI.NOMBRES, CLI.APELLIDOS, " +
                    "CI.PAGO_ESTADIA, CI.CONDICION_DEPARTAMENTO, CI.HORA_INGRESO, RD.RESERVA_INICIO, " +
                    "RD.RESERVA_TERMINO, CI.ACTIVO, CI.ANOTACIONES, REGA.CONTENIDO, CI.REGALO_ID_REGALO ", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }


        public string TEstResReservasFinalizadasCantidad(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT COUNT(RES.NRO_RESERVA), " +
                    "CLI.RUT_CLIENTE, CLI.NOMBRES, " +
                    "CLI.APELLIDOS, RES.FECHA_RESERVA, " +
                    "RD.RESERVA_INICIO, RD.RESERVA_TERMINO, " +
                    "CO.ACTIVO " +
                    "FROM RESERVA RES " +
                    "INNER JOIN CHECK_OUT CO ON CO.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN CLIENTE CLI ON CLI.RUT_CLIENTE = RES.CLIENTE_RUT_CLIENTE " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE CO.ACTIVO = 'N'" +
                    "GROUP BY CLI.RUT_CLIENTE, CLI.NOMBRES, CLI.APELLIDOS, RES.FECHA_RESERVA, " +
                    "RD.RESERVA_INICIO, RD.RESERVA_TERMINO, CO.ACTIVO ", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }

        public string TEstResIngresosReserva(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT SUM(MONTO) " +
                    "FROM PAGO_RESERVA PR " +
                    "INNER JOIN PAGO PAG ON PAG.ID_PAGO = PR.PAGO_ID_PAGO " +
                    "INNER JOIN RESERVA RES ON RES.NRO_RESERVA = PR.RESERVA_NRO_RESERVA " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE PR.DESCRIPCION = 'Reserva'", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }

        public string TEstResIngresosCheckIn(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT SUM(MONTO) " +
                    "FROM PAGO_RESERVA PR " +
                    "INNER JOIN PAGO PAG ON PAG.ID_PAGO = PR.PAGO_ID_PAGO " +
                    "INNER JOIN RESERVA RES ON RES.NRO_RESERVA = PR.RESERVA_NRO_RESERVA " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE PR.DESCRIPCION = 'Estadía'", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }

        public string TEstResCostosMultas(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT SUM(MONTO) " +
                    "FROM PAGO_RESERVA PR " +
                    "INNER JOIN PAGO PAG ON PAG.ID_PAGO = PR.PAGO_ID_PAGO " +
                    "INNER JOIN RESERVA RES ON RES.NRO_RESERVA = PR.RESERVA_NRO_RESERVA " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION " +
                    "WHERE PR.DESCRIPCION = 'Multa'", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }

        public string TEstResCostoReservaTotal(string id_region)
        {
            try
            {
                DataTable dt = new DataTable();

                OracleCommand command = new OracleCommand("SELECT SUM(MONTO) " +
                    "FROM PAGO_RESERVA PR " +
                    "INNER JOIN PAGO PAG ON PAG.ID_PAGO = PR.PAGO_ID_PAGO " +
                    "INNER JOIN RESERVA RES ON RES.NRO_RESERVA = PR.RESERVA_NRO_RESERVA " +
                    "INNER JOIN RESERVA_DEPTO RD ON RD.RESERVA_NRO_RESERVA = RES.NRO_RESERVA " +
                    "INNER JOIN DEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = RD.DEPARTAMENTO_ID_DEPARTAMENTO " +
                    "INNER JOIN UBICACION UBI ON UBI.ID_UBICACION = DEP.UBICACION_ID_UBICACION ", Conec.Connect());

                command.Parameters.Add("id_region", OracleDbType.Varchar2, 100).Value = id_region;

                OracleDataAdapter da = new OracleDataAdapter(command);
                da.Fill(dt);

                string valor = dt.Rows[0][0].ToString();

                return valor;
            }
            catch (Exception ex)
            {
                string valor = "0";
                return valor;
            }

        }


        /// 







        public DataTable dtestadoRegaloInData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT ID_REGALO, CONTENIDO FROM REGALO", Conec.Connect());
                OracleDataReader dr = command.ExecuteReader();
                OracleDataAdapter da = new OracleDataAdapter(command);
                //DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                da = new OracleDataAdapter(command);
                da.Fill(dt);


                return dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("error en dtestadoRegaloInData()" + ex);
                DataTable dt = null;
                return dt;
            }

        }

        public DataTable ClientesData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT CLI.RUT_CLIENTE, CLI.NOMBRES, CLI.APELLIDOS, CLI.TELEFONO," +
                    "CLI.EMAIL, CLI.CONTRASENA " +
                    "FROM CLIENTE CLI " +
                    "WHERE CLI.RUT_CLIENTE != '0'", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("error en ClientesData()" + ex);
                DataTable dt = null;
                return dt;
            }
        }


        public void deleteCliente(string rut_cliente)
        {
            try
            {

                OracleCommand command = new OracleCommand("DELETE FROM CLIENTE " +
                    "WHERE RUT_CLIENTE = :rut_cliente", Conec.Connect());

                command.Parameters.Add("rut_cliente", OracleDbType.Varchar2, 100).Value = rut_cliente;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Cliente eliminado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar empleado: " + ex);
            }
        }


        public void editCliente(string rut_cliente, string nombres, string apellidos, int telefono, string email, string contrasena)
        {
            //editEstado();


            try
            {
                //MessageBox.Show("id_estado: " + id_estado);
                OracleCommand command = new OracleCommand("UPDATE CLIENTE " +
                    "SET NOMBRES = :nombres, APELLIDOS = :apellidos, " +
                    "TELEFONO = :telefono, EMAIL = :email, CONTRASENA = :contrasena " +
                    "WHERE RUT_CLIENTE = :rut_cliente", Conec.Connect());


                //MessageBox.Show("reservado: " + reservado);
                //MessageBox.Show("metros_cuadrados: " + metros_cuadrados.ToString());

                command.Parameters.Add("nombres", OracleDbType.Varchar2, 100).Value = nombres;
                command.Parameters.Add("apellidos", OracleDbType.Varchar2, 100).Value = apellidos;
                command.Parameters.Add("telefono", OracleDbType.Int32, 100).Value = telefono;
                command.Parameters.Add("email", OracleDbType.Varchar2, 100).Value = email;
                command.Parameters.Add("contrasena", OracleDbType.Varchar2, 100).Value = contrasena;
                command.Parameters.Add("rut_cliente", OracleDbType.Varchar2, 100).Value = rut_cliente;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Cliente agregado");
                //Departamento dep = new Departamento();
                //dep.

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar cliente: " + ex);
            }
        }



        public void newClientes(string rut_cliente, string nombres, string apellidos, int telefono, string email, string contrasena)
        {
            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO CLIENTE " +
                    "(RUT_CLIENTE, NOMBRES, APELLIDOS, TELEFONO, EMAIL, CONTRASENA) VALUES  (:rut_cliente, :nombres, :apellidos, :telefono, :email, :contrasena) ", Conec.Connect());


                command.Parameters.Add("rut_cliente", OracleDbType.Varchar2, 100).Value = rut_cliente;
                command.Parameters.Add("nombres", OracleDbType.Varchar2, 100).Value = nombres;
                command.Parameters.Add("apellidos", OracleDbType.Varchar2, 100).Value = apellidos;
                command.Parameters.Add("telefono", OracleDbType.Int32, 100).Value = telefono;
                command.Parameters.Add("email", OracleDbType.Varchar2, 100).Value = email;
                command.Parameters.Add("contrasena", OracleDbType.Varchar2, 100).Value = contrasena;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                MessageBox.Show("Cliente Creado");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar cliente: " + ex);
            }
        }


        public DataTable EmpleadosData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT EMP.ID_EMPLEADO," +
                    "EMP.NOMBRES, EMP.APELLIDOS, EMP.ANNO_CONTRATACION AS AÑO_CONTRATACION, " +
                    "CAR.NOMBRE AS CARGO, EMP.SUELDO, " +
                    "EMP.CARGO_ID_CARGO AS ID_CARGO, EMP.ACCESO_USERNAME AS USERNAME " +
                    "FROM EMPLEADO EMP " +
                    "INNER JOIN CARGO CAR ON CAR.ID_CARGO = EMP.CARGO_ID_CARGO " +
                    "WHERE EMP.ID_EMPLEADO != '0'", Conec.Connect());
                OracleDataAdapter da = new OracleDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("error en EmpleadosData()" + ex);
                DataTable dt = null;
                return dt;
            }

        }


        public void deleteEmpleado(string id_empleado)
        {
            try
            {

                OracleCommand command = new OracleCommand("DELETE FROM EMPLEADO " +
                    "WHERE ID_EMPLEADO = :id_empleado", Conec.Connect());

                command.Parameters.Add("id_empleado", OracleDbType.Varchar2, 100).Value = id_empleado;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Empleado eliminado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar empleado: " + ex);
            }
        }

        public DataTable dtCargoEmpleadoData()
        {
            try
            {
                OracleCommand command = new OracleCommand("SELECT ID_CARGO, NOMBRE FROM CARGO", Conec.Connect());
                OracleDataReader dr = command.ExecuteReader();
                OracleDataAdapter da = new OracleDataAdapter(command);
                //DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                da = new OracleDataAdapter(command);
                da.Fill(dt);

                return dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("error en dtCargoEmpleadoData()" + ex);
                DataTable dt = null;
                return dt;
            }
        }


        public void newEmpleado(string nombres, string apellidos, DateTime anno_contratacion, int sueldo, string id_cargo, string acceso_username)
        {

            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO EMPLEADO " +
                    "(ID_EMPLEADO, NOMBRES, APELLIDOS, ANNO_CONTRATACION, " +
                    "SUELDO, " +
                    "CARGO_ID_CARGO, ACCESO_USERNAME) VALUES (to_char(seq_id_emp.nextval), " +
                    ":nombres, :apellidos, :anno_contratacion, :sueldo, " +
                    ":cargo_id_cargo, :acceso_username)", Conec.Connect());

                //select to_char(seq_id_dep.nextval,'FM00') from dual;


                command.Parameters.Add("nombres", OracleDbType.Varchar2, 100).Value = nombres;
                command.Parameters.Add("apellidos", OracleDbType.Varchar2, 100).Value = apellidos;
                command.Parameters.Add("anno_contratacion", OracleDbType.Varchar2, 100).Value = anno_contratacion.ToString("dd/MM/yyyy HH:mm"); ;
                command.Parameters.Add("sueldo", OracleDbType.Int32, 100).Value = sueldo;
                command.Parameters.Add("cargo_id_cargo", OracleDbType.Varchar2, 100).Value = id_cargo;
                command.Parameters.Add("acceso_username", OracleDbType.Varchar2, 100).Value = acceso_username;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Empleado agregado");
                //Departamento dep = new Departamento();
                //dep.

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Empleado: " + ex);
            }
        }



        public void newAcceso(string username, string contrasena, string email)
        {
            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO ACCESO " +
                    "(USERNAME, CONTRASENA, EMAIL, TOKEN) VALUES (:username, :contrasena, :email, :token) ", Conec.Connect());



                command.Parameters.Add("username", OracleDbType.Varchar2, 100).Value = username;
                command.Parameters.Add("contrasena", OracleDbType.Varchar2, 100).Value = contrasena;
                command.Parameters.Add("email", OracleDbType.Varchar2, 100).Value = email;
                command.Parameters.Add("token", OracleDbType.Varchar2, 300).Value = "AZ";

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                MessageBox.Show("Acceso agregado");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar Acceso: " + ex);
            }
        }

        public void newCargo(string nombre, string descripcion)
        {
            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO CARGO " +
                    "(ID_CARGO, NOMBRE, DESCRIPCION) VALUES (to_char(seq_id_car.nextval), " +
                    ":nombre, :descripcion)", Conec.Connect());

                command.Parameters.Add("nombre", OracleDbType.Varchar2, 100).Value = nombre;
                command.Parameters.Add("descripcion", OracleDbType.Varchar2, 100).Value = descripcion;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                MessageBox.Show("Cargo Creado");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar ubicación: " + ex);
            }
        }


        public bool newCheckIn(string condicion_departamento, int pago_estadia, int reserva_nro_reserva, string firma_cliente, string anotaciones, string id_regalo)
        {

            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO CHECK_IN " +
                    "(ID_CHECKIN, CONDICION_DEPARTAMENTO, HORA_INGRESO, PAGO_ESTADIA, " +
                    "RESERVA_NRO_RESERVA, FIRMA_CONFORMIDAD, REGALO_ID_REGALO, ACTIVO, ANOTACIONES) VALUES (to_char(seq_id_check.nextval)," +
                    ":condicion_departamento, :hora_ingreso, :pago_estadia, :reserva_nro_reserva, :firma_conformidad, :regalo_id_regalo, :activo, :anotaciones) ", Conec.Connect());


                command.Parameters.Add("condicion_departamento", OracleDbType.Varchar2, 500).Value = condicion_departamento;
                command.Parameters.Add("hora_ingreso", OracleDbType.Varchar2, 100).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                command.Parameters.Add("pago_estadia", OracleDbType.Int32, 100).Value = pago_estadia;
                command.Parameters.Add("reserva_nro_reserva", OracleDbType.Int32, 100).Value = reserva_nro_reserva;
                command.Parameters.Add("firma_conformidad", OracleDbType.Varchar2, 400000000).Value = firma_cliente;
                command.Parameters.Add("regalo_id_regalo", OracleDbType.Varchar2, 100).Value = id_regalo;
                command.Parameters.Add("activo", OracleDbType.Varchar2, 1).Value = "Y";
                command.Parameters.Add("anotaciones", OracleDbType.Varchar2, 500).Value = anotaciones;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                MessageBox.Show("Check In Creado");

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar check in: " + ex);
                return false;
            }
        }


        public DataTable RegalosData()
        {
            OracleCommand command = new OracleCommand("SELECT REGA.ID_REGALO, REGA.CONTENIDO," +
                "REGA.VALOR " +
                "FROM REGALO REGA " +
                "WHERE REGA.ID_REGALO != '0'", Conec.Connect());
            OracleDataAdapter da = new OracleDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }


        public void deleteRegalo(string id_regalo)
        {
            try
            {
                OracleCommand command = new OracleCommand("DELETE FROM REGALO " +
                    "WHERE ID_REGALO = :id_regalo", Conec.Connect());

                command.Parameters.Add("id_checkin", OracleDbType.Varchar2, 100).Value = id_regalo;

                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Regalo eliminado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar regalo: " + ex);
            }
        }


        public void newRegalo(string contenido, int valor)
        {
            try
            {

                OracleCommand command = new OracleCommand("INSERT INTO REGALO " +
                    "(ID_REGALO, CONTENIDO, VALOR) VALUES (to_char(seq_id_rega.nextval)," +
                    ":contenido, :valor) ", Conec.Connect());


                command.Parameters.Add("contenido", OracleDbType.Varchar2, 500).Value = contenido;
                command.Parameters.Add("valor", OracleDbType.Int32, 100).Value = valor;


                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);
                MessageBox.Show("Regalo Creado");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar Regalo: " + ex);
            }
        }


        public void editEmpleado(string id_empleado, string nombres, string apellidos, DateTime anno_contratacion, int sueldo, string idCargo)
        {
            try
            {
                OracleCommand command = new OracleCommand("UPDATE EMPLEADO " +
                    "SET NOMBRES = :nombres, APELLIDOS = :apellidos, ANNO_CONTRATACION = :anno_contratacion, " +
                    "SUELDO = :sueldo, CARGO_ID_CARGO = :idCargo " +
                    "WHERE ID_EMPLEADO = :id_empleado", Conec.Connect());

                command.Parameters.Add("nombres", OracleDbType.Varchar2, 100).Value = nombres;
                command.Parameters.Add("apellidos", OracleDbType.Varchar2, 100).Value = apellidos;
                command.Parameters.Add("anno_contratacion", OracleDbType.Varchar2, 100).Value = anno_contratacion.ToString("dd/MM/yyyy HH:mm");
                command.Parameters.Add("sueldo", OracleDbType.Int32, 100).Value = sueldo;
                command.Parameters.Add("idCargo", OracleDbType.Varchar2, 100).Value = idCargo;
                command.Parameters.Add("id_empleado", OracleDbType.Varchar2, 100).Value = id_empleado;
                //MessageBox.Show("id_empleado: " + id_empleado);
                command.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(command);

                MessageBox.Show("Empleado editado exitosamente", "Editar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar empleado: ");
            }
        }

    }
}
