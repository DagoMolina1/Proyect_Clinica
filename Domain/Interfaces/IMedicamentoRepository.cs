using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces
{
    internal class IMedicamentoRepository
    {
        void Add(Medicamento medicamento);
        void Update(Medicamento medicamento);
        void Delete(int idMedicamento);
        Medicamento GetById(int idMedicamento);
        List<Medicamento> GetAll();
    }
}
