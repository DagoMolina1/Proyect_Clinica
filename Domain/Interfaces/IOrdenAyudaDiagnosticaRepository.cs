using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces {
    public interface IOrdenAyudaDiagnosticaRepository {
        void Add(OrdenAyudaDiagnostica ordenAyuda);
        void Update(OrdenAyudaDiagnostica ordenAyuda);
        void Delete(int idOrdenAyuda);
        OrdenAyudaDiagnostica GetById(int idOrdenAyuda);
        List<OrdenAyudaDiagnostica> GetByOrden(int idOrden);
    }
}