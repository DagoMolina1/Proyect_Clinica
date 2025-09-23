using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces {
    public interface IOrdenProcedimientoRepository {
        void Add(OrdenProcedimiento ordenProcedimiento);
        void Update(OrdenProcedimiento ordenProcedimiento);
        void Delete(int idOrdenAyuda);
        OrdenProcedimiento GetById(int idOrdenAyuda);
        List<OrdenProcedimiento> GetByOrden(int idOrden);
    }
}