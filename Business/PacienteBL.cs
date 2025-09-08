using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Data;
using ClinicaIPS_U.Entities;

namespace ClinicaIPS_U.Business {
    class PacienteBL {
        private PacienteDAL pacienteDAL = new PacienteDAL();

        public void RegistrarPaciente(Paciente paciente)  {
            //Validaciones de negocio
            if (string.IsNullOrEmpty(paciente.Cedula))
                throw new Exception("La cédula es obligatoria.");

            if (paciente.FechaNacimiento > DateTime.Now)
                throw new Exception("La fecha de nacimiento no puede ser en el futuro.");

            if (paciente.Telefono.Length != 10)
                throw new Exception("El teléfono debe tener 10 dígitos.");

            //Si todo está bien, se envía a la capa de datos
            pacienteDAL.InsertarPaciente(paciente);
        }
        public List<Paciente> ObtenerPacientes()
        {
            return pacienteDAL.ObtenerPacientes();
        }

        public void ActualizarPaciente(Paciente paciente) {
            if (string.IsNullOrEmpty(paciente.Cedula))
                throw new Exception("La cédula es obligatoria para actualizar.");

            pacienteDAL.ActualizarPaciente(paciente);
        }

        public void EliminarPaciente(string cedula) {
            if (string.IsNullOrEmpty(cedula))
                throw new Exception("Debe indicar la cédula del paciente a eliminar.");

            pacienteDAL.EliminarPaciente(cedula);
        }
    }
}