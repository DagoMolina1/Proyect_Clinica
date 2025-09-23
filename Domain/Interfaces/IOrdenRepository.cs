using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces {
    public interface IOrdenRepository {
        void Add(Orden orden);
        void Update(Orden orden);
        void Delete(int idOrden);
        Orden GetById(int idOrden);
        List<Orden> GetAll();
    }
}