using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;

namespace ClinicaIPS_U.Domain.Services {
    public class PacienteService {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository) {
            _pacienteRepository = pacienteRepository;
        }

        public void Registrar(Paciente paciente) {
            if (string.IsNullOrWhiteSpace(paciente.NombreCompleto))
                throw new System.Exception("El nombre es obligatorio.");
            if (paciente.FechaNacimiento > System.DateTime.Now)
                throw new System.Exception("La fecha de nacimiento no puede ser futura.");

            _pacienteRepository.Add(paciente);
        }

        public void Actualizar(Paciente paciente) => _pacienteRepository.Update(paciente);

        public void Eliminar(string cedula) => _pacienteRepository.Delete(cedula);

        public Paciente BuscarPorCedula(string cedula) => _pacienteRepository.GetByCedula(cedula);

        public List<Paciente> Listar() => _pacienteRepository.GetAll();
    }
}