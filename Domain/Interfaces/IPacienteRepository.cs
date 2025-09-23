using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces {
    public interface IPacienteRepository {
        void Add(Paciente paciente);
        void Update(Paciente paciente);
        void Delete(string cedula);
        Paciente GetByCedula(string cedula);
        List<Paciente> GetAll();
    }
}