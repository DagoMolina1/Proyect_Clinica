using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Data;
using ClinicaIPS_U.Entities;

namespace ClinicaIPS_U.Business {
    internal class AyudaDiagnosticaBL {
        private AyudaDiagnosticaDAL ayudaDAL = new AyudaDiagnosticaDAL();

        public void RegistrarAyuda(AyudaDiagnostica ayuda) {
            if (string.IsNullOrEmpty(ayuda.Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (ayuda.Costo <= 0)
                throw new Exception("El costo debe ser mayor a 0.");

            ayudaDAL.InsertarAyuda(ayuda);
        }

        public List<AyudaDiagnostica> ObtenerAyudas() {
            return ayudaDAL.ObtenerAyudas();
        }

        public void ActualizarAyuda(AyudaDiagnostica ayuda) {
            ayudaDAL.ActualizarAyuda(ayuda);
        }

        public void EliminarAyuda(int id) {
            ayudaDAL.EliminarAyuda(id);
        }
    }
}