using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces {
    public interface IFacturacionRepository {
        void Add(Facturacion factura);
        void Update(Facturacion factura);
        void Delete(int idFactura);
        Facturacion GetById(int idFactura);
        List<Facturacion> GetAll();
    }
}