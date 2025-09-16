using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces
{
    internal class IOrdenAyudaDiagnosticaRepository
    {
        void Add(OrdenAyudaDiagnostica ordenAyuda);
        void Update(OrdenAyudaDiagnostica ordenAyuda);
        void Delete(int idOrden, int idAyuda);
        OrdenAyudaDiagnostica GetById(int idOrden, int idAyuda);
        List<OrdenAyudaDiagnostica> GetByOrden(int idOrden);
    }
}