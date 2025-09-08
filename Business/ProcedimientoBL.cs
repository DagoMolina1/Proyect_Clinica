using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Data;
using ClinicaIPS_U.Entities;

namespace ClinicaIPS_U.Business {
    class ProcedimientoBL {
        private ProcedimientoDAL procedimientoDAL = new ProcedimientoDAL();

        public void RegistrarProcedimiento(Procedimiento procedimiento) {
            if (string.IsNullOrEmpty(procedimiento.Nombre))
                throw new Exception("El nombre del procedimiento es obligatorio.");

            if (procedimiento.Costo <= 0)
                throw new Exception("El costo debe ser mayor a 0.");

            procedimientoDAL.InsertarProcedimiento(procedimiento);
        }

        public List<Procedimiento> ObtenerProcedimientos() {
            return procedimientoDAL.ObtenerProcedimientos();
        }

        public void ActualizarProcedimiento(Procedimiento procedimiento) {
            procedimientoDAL.ActualizarProcedimiento(procedimiento);
        }

        public void EliminarProcedimiento(int id) {
            procedimientoDAL.EliminarProcedimiento(id);
        }
    }
}