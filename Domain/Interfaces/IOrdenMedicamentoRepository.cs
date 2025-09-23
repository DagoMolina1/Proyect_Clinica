using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces {
    public interface IOrdenMedicamentoRepository {
        void Add(OrdenMedicamento ordenMedicamento);
        void Update(OrdenMedicamento ordenMedicamento);
        void Delete(int idOrdenAyuda);
        OrdenMedicamento GetById(int idOrdenAyuda);
        List<OrdenMedicamento> GetByOrden(int idOrden);
    }
}