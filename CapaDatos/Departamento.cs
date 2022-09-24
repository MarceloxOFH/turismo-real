using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Departamento
    {
        private string id_departamento;
        private string nombre;
        private int arriendo_diario;
        private string reservado;
        private int habitaciones;
        private int baños;
        private string descripción;
        private int valoración;
        private int metros_cuadrados;
        private int valor_inventario;
        private DateTime último_inventario;
        private string ubicación_id_ubicación;
        private string estado_departamento_id_estado;

        public string Id_Departamento { get => id_departamento; set => id_departamento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Arriendo_Diario { get => arriendo_diario; set => arriendo_diario = value; }

        public string Reservado { get => reservado; set => reservado = value; }
        public int Habitaciones { get => habitaciones; set => habitaciones = value; }
        public int Baños { get => baños; set => baños = value; }
        public string Descripción { get => descripción; set => descripción = value; }

        public int Valoración { get => valoración; set => valoración = value; }

        public int Metros_Cuadrados { get => metros_cuadrados; set => metros_cuadrados = value; }

        public int Valor_Inventario { get => valor_inventario; set => valor_inventario = value; }

        public DateTime Último_Inventario { get => último_inventario; set => último_inventario = value; }

        public string Ubicación_Id_Ubicación { get => ubicación_id_ubicación; set => ubicación_id_ubicación = value; }

        public string Estado_Departamento_Id_Estado { get => estado_departamento_id_estado; set => estado_departamento_id_estado = value; }










    }
}
