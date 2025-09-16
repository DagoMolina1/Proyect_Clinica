using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces
{
    internal class IOrdenProcedimientoRepository
    {
        void Add(OrdenProcedimiento ordenProcedimiento);
        void Update(OrdenProcedimiento ordenProcedimiento);
        void Delete(int idOrden, int idProcedimiento);
        OrdenProcedimiento GetById(int idOrden, int idProcedimiento);
        List<OrdenProcedimiento> GetByOrden(int idOrden);
    }
}
