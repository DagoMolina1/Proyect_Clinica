using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;

namespace ClinicaIPS_U.Application.Services
{
    public class ProcedimientoService
    {
        private readonly IProcedimientoRepository _procedimientoRepository;

        public ProcedimientoService(IProcedimientoRepository procedimientoRepository)
        {
            _procedimientoRepository = procedimientoRepository;
        }

        public void Registrar(Procedimiento procedimiento) => _procedimientoRepository.Add(procedimiento);

        public void Actualizar(Procedimiento procedimiento) => _procedimientoRepository.Update(procedimiento);

        public void Eliminar(int idProcedimiento) => _procedimientoRepository.Delete(idProcedimiento);

        public Procedimiento BuscarPorId(int idProcedimiento) => _procedimientoRepository.GetById(idProcedimiento);

        public List<Procedimiento> Listar() => _procedimientoRepository.GetAll();
    }
}
