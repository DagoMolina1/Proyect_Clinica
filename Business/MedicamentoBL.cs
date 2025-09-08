using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Data;
using ClinicaIPS_U.Entities;

namespace ClinicaIPS_U.Business {
    class MedicamentoBL {

        private MedicamentoDAL medicamentoDAL = new MedicamentoDAL();

        public void RegistrarMedicamento(Medicamento medicamento) {
            if (string.IsNullOrEmpty(medicamento.Nombre))
                throw new Exception("El nombre del medicamento es obligatorio.");

            if (medicamento.Costo <= 0)
                throw new Exception("El costo debe ser mayor a 0.");

            medicamentoDAL.InsertarMedicamento(medicamento);
        }

        public List<Medicamento> ObtenerMedicamentos() {
            return medicamentoDAL.ObtenerMedicamentos();
        }

        public void ActualizarMedicamento(Medicamento medicamento) {
            medicamentoDAL.ActualizarMedicamento(medicamento);
        }

        public void EliminarMedicamento(int id) {
            medicamentoDAL.EliminarMedicamento(id);
        }
    }
}