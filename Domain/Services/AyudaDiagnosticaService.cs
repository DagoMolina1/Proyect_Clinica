using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;

namespace ClinicaIPS_U.Domain.Services
{
    public class AyudaDiagnosticaService {
        private readonly IAyudaDiagnosticaRepository _ayudaRepository;

        public AyudaDiagnosticaService(IAyudaDiagnosticaRepository ayudaRepository)
        {
            _ayudaRepository = ayudaRepository;
        }

        public void Registrar(AyudaDiagnostica ayuda) => _ayudaRepository.Add(ayuda);

        public void Actualizar(AyudaDiagnostica ayuda) => _ayudaRepository.Update(ayuda);

        public void Eliminar(int idAyuda) => _ayudaRepository.Delete(idAyuda);

        public AyudaDiagnostica BuscarPorId(int idAyuda) => _ayudaRepository.GetById(idAyuda);

        public List<AyudaDiagnostica> Listar() => _ayudaRepository.GetAll();
    }
}
