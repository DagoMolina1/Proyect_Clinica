using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces
{
    internal class IOrdenMedicamentoRepository
    {
        void Add(OrdenMedicamento ordenMedicamento);
        void Update(OrdenMedicamento ordenMedicamento);
        void Delete(int idOrden, int idMedicamento);
        OrdenMedicamento GetById(int idOrden, int idMedicamento);
        List<OrdenMedicamento> GetByOrden(int idOrden);
    }
}
