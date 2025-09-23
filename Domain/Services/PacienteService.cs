using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;
using ClinicaIPS_U.Validations;

namespace ClinicaIPS_U.Domain.Services {
    public class PacienteService {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository) {
            _pacienteRepository = pacienteRepository;
        }

        public void Registrar(Paciente paciente) {
            ValidarPaciente(paciente);
            _pacienteRepository.Add(paciente);
        }

        public void Actualizar(Paciente paciente) {
            ValidarPaciente(paciente);
            _pacienteRepository.Update(paciente);
        }

        public void Eliminar(string cedula) => _pacienteRepository.Delete(cedula);

        public Paciente BuscarPorCedula(string cedula) => _pacienteRepository.GetByCedula(cedula);
        public Paciente BuscarPorId(int idPaciente) => _pacienteRepository.GetById(idPaciente);

        public List<Paciente> Listar() => _pacienteRepository.GetAll();

        private static void ValidarPaciente(Paciente paciente) {
            if (paciente == null) {
                throw new ArgumentNullException(nameof(paciente));
            }

            if (string.IsNullOrWhiteSpace(paciente.NombreCompleto)) {
                throw new ArgumentException("El nombre completo es obligatorio.");
            }

            if (!Validador.EsFechaNacimientoValida(paciente.FechaNacimiento)) {
                throw new ArgumentException("La fecha de nacimiento no es válida. El paciente debe tener entre 0 y 150 años.");
            }

            if (string.IsNullOrWhiteSpace(paciente.UsuarioPortal) || paciente.UsuarioPortal.Length > 15 || !Regex.IsMatch(paciente.UsuarioPortal, @"^[A-Za-z0-9]+$")) {
                throw new ArgumentException("El usuario del portal debe ser alfanumérico y tener máximo 15 caracteres.");
            }

            if (!Validador.EsContraseñaValida(paciente.ContrasenaPortal)) {
                throw new ArgumentException("La contraseña del portal debe tener al menos 8 caracteres, una mayúscula, un número y un carácter especial.");
            }

            if (paciente.ContactoEmergencia == null) {
                throw new ArgumentException("Debe registrar un contacto de emergencia.");
            }

            if (string.IsNullOrWhiteSpace(paciente.ContactoEmergencia.Nombres) || string.IsNullOrWhiteSpace(paciente.ContactoEmergencia.Apellidos)) {
                throw new ArgumentException("El contacto de emergencia debe tener nombres y apellidos.");
            }

            if (string.IsNullOrWhiteSpace(paciente.ContactoEmergencia.Relacion)) {
                throw new ArgumentException("Debe especificar la relación del contacto de emergencia.");
            }

            if (paciente.SeguroMedico != null) {
                if (string.IsNullOrWhiteSpace(paciente.SeguroMedico.NombreCompania)) {
                    throw new ArgumentException("Debe indicar el nombre de la compañía de seguros.");
                }

                if (string.IsNullOrWhiteSpace(paciente.SeguroMedico.NumeroPoliza)) {
                    throw new ArgumentException("Debe indicar el número de póliza.");
                }

                if (paciente.SeguroMedico.Vigencia <= paciente.FechaNacimiento) {
                    throw new ArgumentException("La vigencia de la póliza debe ser posterior a la fecha de nacimiento.");
                }
            }
        }
    }
}
