using System.Collections.Generic;
using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces {
    public interface IPacienteRepository {
        void Add(Paciente paciente);
        void Update(Paciente paciente);
        void Delete(string cedula);
        Paciente GetByCedula(string cedula);
        Paciente GetById(int idPaciente);
        List<Paciente> GetAll();
    }
}
