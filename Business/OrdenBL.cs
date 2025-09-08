using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Data;
using ClinicaIPS_U.Entities;

namespace ClinicaIPS_U.Business {
    internal class OrdenBL {
        private OrdenDAL ordenDAL = new OrdenDAL();

        public void RegistrarOrden(Orden orden) {
            if (orden.IdPaciente <= 0)
                throw new Exception("Debe indicar un paciente válido.");

            if (orden.IdMedico <= 0)
                throw new Exception("Debe indicar un médico válido.");

            orden.FechaCreacion = DateTime.Now; // Se asigna automáticamente
            ordenDAL.InsertarOrden(orden);
        }

        public List<Orden> ObtenerOrdenes() {
            return ordenDAL.ObtenerOrdenes();
        }

        public void ActualizarOrden(Orden orden) {
            ordenDAL.ActualizarOrden(orden);
        }

        public void EliminarOrden(int idOrden) {
            ordenDAL.EliminarOrden(idOrden);
        }
    }
}