using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;

namespace ClinicaIPS_U.Application.Services
{
    public class OrdenService
    {
        private readonly IOrdenRepository _ordenRepository;
        private readonly IOrdenMedicamentoRepository _ordenMedRepository;
        private readonly IOrdenProcedimientoRepository _ordenProcRepository;
        private readonly IOrdenAyudaDiagnosticaRepository _ordenAyudaRepository;

        public OrdenService(
            IOrdenRepository ordenRepository,
            IOrdenMedicamentoRepository ordenMedRepository,
            IOrdenProcedimientoRepository ordenProcRepository,
            IOrdenAyudaDiagnosticaRepository ordenAyudaRepository)
        {
            _ordenRepository = ordenRepository;
            _ordenMedRepository = ordenMedRepository;
            _ordenProcRepository = ordenProcRepository;
            _ordenAyudaRepository = ordenAyudaRepository;
        }

        // CRUD de Órdenes Generales
        public void RegistrarOrden(Orden orden) => _ordenRepository.Add(orden);
        public void ActualizarOrden(Orden orden) => _ordenRepository.Update(orden);
        public void EliminarOrden(int idOrden) => _ordenRepository.Delete(idOrden);
        public Orden BuscarOrden(int idOrden) => _ordenRepository.GetById(idOrden);
        public List<Orden> ListarOrdenes() => _ordenRepository.GetAll();

        // Orden de Medicamentos
        public void RegistrarOrdenMedicamento(OrdenMedicamento om) => _ordenMedRepository.Add(om);
        public List<OrdenMedicamento> ListarMedicamentosPorOrden(int idOrden) => _ordenMedRepository.GetByOrden(idOrden);

        // Orden de Procedimientos
        public void RegistrarOrdenProcedimiento(OrdenProcedimiento op) => _ordenProcRepository.Add(op);
        public List<OrdenProcedimiento> ListarProcedimientosPorOrden(int idOrden) => _ordenProcRepository.GetByOrden(idOrden);

        // Orden de Ayudas Diagnósticas
        public void RegistrarOrdenAyuda(OrdenAyudaDiagnostica oa) => _ordenAyudaRepository.Add(oa);
        public List<OrdenAyudaDiagnostica> ListarAyudasPorOrden(int idOrden) => _ordenAyudaRepository.GetByOrden(idOrden);
    }
}
