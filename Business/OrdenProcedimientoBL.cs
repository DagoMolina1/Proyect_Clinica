using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Data;
using ClinicaIPS_U.Entities;

namespace ClinicaIPS_U.Business {
    internal class OrdenProcedimientoBL {
        private OrdenProcedimientoDAL ordenProcedimientoDAL = new OrdenProcedimientoDAL();

        public void RegistrarOrdenProcedimiento(OrdenProcedimiento ordenProc) {
            if (ordenProc.Repeticiones <= 0)
                throw new Exception("Las repeticiones deben ser mayores que 0.");

            if (string.IsNullOrEmpty(ordenProc.Frecuencia))
                throw new Exception("Debe especificar la frecuencia del procedimiento.");

            ordenProcedimientoDAL.InsertarOrdenProcedimiento(ordenProc);
        }

        public List<OrdenProcedimiento> ObtenerOrdenProcedimientos() {
            return ordenProcedimientoDAL.ObtenerOrdenProcedimientos();
        }

        public void ActualizarOrdenProcedimiento(OrdenProcedimiento ordenProc) {
            if (ordenProc.IdOrdenProcedimiento <= 0)
                throw new Exception("Debe especificar un Id válido para actualizar.");

            ordenProcedimientoDAL.ActualizarOrdenProcedimiento(ordenProc);
        }

        public void EliminarOrdenProcedimiento(int id) {
            if (id <= 0)
                throw new Exception("Debe especificar un Id válido para eliminar.");

            ordenProcedimientoDAL.EliminarOrdenProcedimiento(id);
        }
    }
}