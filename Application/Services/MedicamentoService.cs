using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;

namespace ClinicaIPS_U.Application.Services {
    public class MedicamentoService {
        private readonly IMedicamentoRepository _medicamentoRepository;

        public MedicamentoService(IMedicamentoRepository medicamentoRepository) {
            _medicamentoRepository = medicamentoRepository;
        }

        public void Registrar(Medicamento medicamento) => _medicamentoRepository.Add(medicamento);

        public void Actualizar(Medicamento medicamento) => _medicamentoRepository.Update(medicamento);

        public void Eliminar(int idMedicamento) => _medicamentoRepository.Delete(idMedicamento);

        public Medicamento BuscarPorId(int idMedicamento) => _medicamentoRepository.GetById(idMedicamento);

        public List<Medicamento> Listar() => _medicamentoRepository.GetAll();
    }
}
