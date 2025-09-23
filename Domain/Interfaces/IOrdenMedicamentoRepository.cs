using System.Collections.Generic;
using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces {
    public interface IOrdenMedicamentoRepository {
        void Add(OrdenMedicamento ordenMedicamento);
        void Update(OrdenMedicamento ordenMedicamento);
        void Delete(int idOrdenMedicamento);
        OrdenMedicamento GetById(int idOrdenMedicamento);
        List<OrdenMedicamento> GetByOrden(int idOrden);
    }
}
