using System;
using System.Collections.Generic;
using System.Linq;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;

namespace ClinicaIPS_U.Domain.Services {
    public class OrdenService {
        private readonly IOrdenRepository _ordenRepository;
        private readonly IOrdenMedicamentoRepository _ordenMedRepository;
        private readonly IOrdenProcedimientoRepository _ordenProcRepository;
        private readonly IOrdenAyudaDiagnosticaRepository _ordenAyudaRepository;

        public OrdenService(
            IOrdenRepository ordenRepository,
            IOrdenMedicamentoRepository ordenMedRepository,
            IOrdenProcedimientoRepository ordenProcRepository,
            IOrdenAyudaDiagnosticaRepository ordenAyudaRepository) {
            _ordenRepository = ordenRepository;
            _ordenMedRepository = ordenMedRepository;
            _ordenProcRepository = ordenProcRepository;
            _ordenAyudaRepository = ordenAyudaRepository;
        }

        // CRUD de Órdenes Generales
        public void RegistrarOrden(Orden orden) {
            if (orden.IdOrden <= 0 || orden.IdOrden > 999999) {
                throw new ArgumentException("El número de orden debe tener máximo 6 dígitos.");
            }
            _ordenRepository.Add(orden);
        }

        public void ActualizarOrden(Orden orden) => _ordenRepository.Update(orden);

        public void EliminarOrden(int idOrden) => _ordenRepository.Delete(idOrden);

        public Orden BuscarOrden(int idOrden) => _ordenRepository.GetById(idOrden);

        public List<Orden> ListarOrdenes() => _ordenRepository.GetAll();

        public List<Orden> ListarOrdenesPorPaciente(int idPaciente) => _ordenRepository.GetByPaciente(idPaciente);

        // Orden de Medicamentos
        public void RegistrarOrdenMedicamento(OrdenMedicamento ordenMedicamento) {
            ValidarNumeroItemDisponible(ordenMedicamento.IdOrden, ordenMedicamento.NumeroItem);
            AsegurarQueNoExistenAyudasDiagnosticas(ordenMedicamento.IdOrden);
            if (ordenMedicamento.NumeroItem <= 0) {
                throw new ArgumentException("El número de ítem debe ser mayor a cero.");
            }
            _ordenMedRepository.Add(ordenMedicamento);
        }

        public void ActualizarOrdenMedicamento(OrdenMedicamento ordenMedicamento) {
            ValidarNumeroItemDisponible(ordenMedicamento.IdOrden, ordenMedicamento.NumeroItem, excluirMedicamentoId: ordenMedicamento.IdOrdenMedicamento);
            _ordenMedRepository.Update(ordenMedicamento);
        }

        public void EliminarOrdenMedicamento(int idOrdenMedicamento) => _ordenMedRepository.Delete(idOrdenMedicamento);

        public OrdenMedicamento BuscarOrdenMedicamento(int idOrdenMedicamento) => _ordenMedRepository.GetById(idOrdenMedicamento);

        public List<OrdenMedicamento> ListarMedicamentosPorOrden(int idOrden) => _ordenMedRepository.GetByOrden(idOrden);

        // Orden de Procedimientos
        public void RegistrarOrdenProcedimiento(OrdenProcedimiento ordenProcedimiento) {
            ValidarNumeroItemDisponible(ordenProcedimiento.IdOrden, ordenProcedimiento.NumeroItem);
            AsegurarQueNoExistenAyudasDiagnosticas(ordenProcedimiento.IdOrden);
            if (ordenProcedimiento.NumeroItem <= 0) {
                throw new ArgumentException("El número de ítem debe ser mayor a cero.");
            }
            _ordenProcRepository.Add(ordenProcedimiento);
        }

        public void ActualizarOrdenProcedimiento(OrdenProcedimiento ordenProcedimiento) {
            ValidarNumeroItemDisponible(ordenProcedimiento.IdOrden, ordenProcedimiento.NumeroItem, excluirProcedimientoId: ordenProcedimiento.IdOrdenProcedimiento);
            _ordenProcRepository.Update(ordenProcedimiento);
        }

        public void EliminarOrdenProcedimiento(int idOrdenProcedimiento) => _ordenProcRepository.Delete(idOrdenProcedimiento);

        public OrdenProcedimiento BuscarOrdenProcedimiento(int idOrdenProcedimiento) => _ordenProcRepository.GetById(idOrdenProcedimiento);

        public List<OrdenProcedimiento> ListarProcedimientosPorOrden(int idOrden) => _ordenProcRepository.GetByOrden(idOrden);

        // Orden de Ayudas Diagnósticas
        public void RegistrarOrdenAyuda(OrdenAyudaDiagnostica ordenAyuda) {
            if (_ordenMedRepository.GetByOrden(ordenAyuda.IdOrden).Any() || _ordenProcRepository.GetByOrden(ordenAyuda.IdOrden).Any()) {
                throw new InvalidOperationException("No se pueden registrar ayudas diagnósticas en una orden que ya contiene medicamentos o procedimientos.");
            }
            ValidarNumeroItemDisponible(ordenAyuda.IdOrden, ordenAyuda.NumeroItem);
            if (ordenAyuda.NumeroItem <= 0) {
                throw new ArgumentException("El número de ítem debe ser mayor a cero.");
            }
            _ordenAyudaRepository.Add(ordenAyuda);
        }

        public void ActualizarOrdenAyuda(OrdenAyudaDiagnostica ordenAyuda) {
            ValidarNumeroItemDisponible(ordenAyuda.IdOrden, ordenAyuda.NumeroItem, excluirAyudaId: ordenAyuda.IdOrdenAyuda);
            _ordenAyudaRepository.Update(ordenAyuda);
        }

        public void EliminarOrdenAyuda(int idOrdenAyuda) => _ordenAyudaRepository.Delete(idOrdenAyuda);

        public OrdenAyudaDiagnostica BuscarOrdenAyuda(int idOrdenAyuda) => _ordenAyudaRepository.GetById(idOrdenAyuda);

        public List<OrdenAyudaDiagnostica> ListarAyudasPorOrden(int idOrden) => _ordenAyudaRepository.GetByOrden(idOrden);

        private void ValidarNumeroItemDisponible(int idOrden, int numeroItem, int? excluirMedicamentoId = null, int? excluirProcedimientoId = null, int? excluirAyudaId = null) {
            if (_ordenMedRepository.GetByOrden(idOrden).Any(m => m.NumeroItem == numeroItem && m.IdOrdenMedicamento != excluirMedicamentoId)) {
                throw new InvalidOperationException("Ya existe un medicamento con el mismo número de ítem en esta orden.");
            }

            if (_ordenProcRepository.GetByOrden(idOrden).Any(p => p.NumeroItem == numeroItem && p.IdOrdenProcedimiento != excluirProcedimientoId)) {
                throw new InvalidOperationException("Ya existe un procedimiento con el mismo número de ítem en esta orden.");
            }

            if (_ordenAyudaRepository.GetByOrden(idOrden).Any(a => a.NumeroItem == numeroItem && a.IdOrdenAyuda != excluirAyudaId)) {
                throw new InvalidOperationException("Ya existe una ayuda diagnóstica con el mismo número de ítem en esta orden.");
            }
        }

        private void AsegurarQueNoExistenAyudasDiagnosticas(int idOrden) {
            if (_ordenAyudaRepository.GetByOrden(idOrden).Any()) {
                throw new InvalidOperationException("No se pueden registrar medicamentos o procedimientos cuando la orden contiene ayudas diagnósticas en estudio.");
            }
        }
    }
}
