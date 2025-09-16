using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces
{
    internal class IFacturacionRepository
    {
        void Add(Factura factura);
        void Update(Factura factura);
        void Delete(int idFactura);
        Factura GetById(int idFactura);
        List<Factura> GetAll();
    }
}
