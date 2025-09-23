using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;

namespace ClinicaIPS_U.Domain.Services {
    public class FacturacionService {
        private readonly IFacturacionRepository _facturacionRepository;

        public FacturacionService(IFacturacionRepository facturacionRepository) {
            _facturacionRepository = facturacionRepository;
        }

        public void Registrar(Facturacion factura) => _facturacionRepository.Add(factura);

        public void Actualizar(Facturacion factura) => _facturacionRepository.Update(factura);

        public void Eliminar(int idFactura) => _facturacionRepository.Delete(idFactura);

        public Facturacion BuscarPorId(int idFactura) => _facturacionRepository.GetById(idFactura);

        public List<Facturacion> Listar() => _facturacionRepository.GetAll();
    }

}
