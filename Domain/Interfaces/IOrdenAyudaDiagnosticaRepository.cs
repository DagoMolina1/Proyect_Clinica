using System.Collections.Generic;
using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces {
    public interface IOrdenAyudaDiagnosticaRepository {
        void Add(OrdenAyudaDiagnostica ordenAyudaDiagnostica);
        void Update(OrdenAyudaDiagnostica ordenAyudaDiagnostica);
        void Delete(int idOrdenAyuda);
        OrdenAyudaDiagnostica GetById(int idOrdenAyuda);
        List<OrdenAyudaDiagnostica> GetByOrden(int idOrden);
    }
}
