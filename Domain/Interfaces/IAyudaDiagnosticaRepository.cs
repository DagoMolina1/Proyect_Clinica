using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces
{
    internal class IAyudaDiagnosticaRepository
    {
        void Add(AyudaDiagnostica ayuda);
        void Update(AyudaDiagnostica ayuda);
        void Delete(int idAyuda);
        AyudaDiagnostica GetById(int idAyuda);
        List<AyudaDiagnostica> GetAll();
    }
}
