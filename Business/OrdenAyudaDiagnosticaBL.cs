using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Data;
using ClinicaIPS_U.Entities;

namespace ClinicaIPS_U.Business {
    internal class OrdenAyudaDiagnosticaBL{
        private OrdenAyudaDiagnosticaDAL ordenAyudaDAL = new OrdenAyudaDiagnosticaDAL();

        public void RegistrarOrdenAyuda(OrdenAyudaDiagnostica ordenAyuda) {
            if (ordenAyuda.Cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor a 0.");

            ordenAyudaDAL.InsertarOrdenAyuda(ordenAyuda);
        }

        public List<OrdenAyudaDiagnostica> ObtenerOrdenesAyuda() {
            return ordenAyudaDAL.ObtenerOrdenesAyuda();
        }

        public void ActualizarOrdenAyuda(OrdenAyudaDiagnostica ordenAyuda) {
            ordenAyudaDAL.ActualizarOrdenAyuda(ordenAyuda);
        }

        public void EliminarOrdenAyuda(int id) {
            ordenAyudaDAL.EliminarOrdenAyuda(id);
        }
    }
}