using System.Collections.Generic;
using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces {
    public interface IOrdenProcedimientoRepository {
        void Add(OrdenProcedimiento ordenProcedimiento);
        void Update(OrdenProcedimiento ordenProcedimiento);
        void Delete(int idOrdenProcedimiento);
        OrdenProcedimiento GetById(int idOrdenProcedimiento);
        List<OrdenProcedimiento> GetByOrden(int idOrden);
    }
}
