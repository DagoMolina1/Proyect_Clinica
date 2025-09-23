using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces {
    public interface IProcedimientoRepository {
        void Add(Procedimiento procedimiento);
        void Update(Procedimiento procedimiento);
        void Delete(int idProcedimiento);
        Procedimiento GetById(int idProcedimiento);
        List<Procedimiento> GetAll();
    }
}