using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Data;
using ClinicaIPS_U.Entities;

namespace ClinicaIPS_U.Business {
    internal class OrdenMedicamentoBL {
        private OrdenMedicamentoDAL ordenMedicamentoDAL = new OrdenMedicamentoDAL();

        public void RegistrarOrdenMedicamento(OrdenMedicamento ordenMedicamento) {
            if (ordenMedicamento.Cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor que 0.");

            ordenMedicamentoDAL.InsertarOrdenMedicamento(ordenMedicamento);
        }

        public List<OrdenMedicamento> ObtenerOrdenMedicamentos() {
            return ordenMedicamentoDAL.ObtenerOrdenMedicamentos();
        }

        public void ActualizarOrdenMedicamento(OrdenMedicamento ordenMedicamento) {
            ordenMedicamentoDAL.ActualizarOrdenMedicamento(ordenMedicamento);
        }

        public void EliminarOrdenMedicamento(int id) {
            ordenMedicamentoDAL.EliminarOrdenMedicamento(id);
        }
    }
}