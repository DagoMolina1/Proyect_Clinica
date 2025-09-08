using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Data;
using ClinicaIPS_U.Entities;

namespace ClinicaIPS_U.Business {
    /*class FacturacionBL {

        private FacturacionDAL facturacionDAL = new FacturacionDAL();

        public void GenerarFactura(Facturacion factura, decimal totalServicios, bool polizaActiva, decimal copagosAcumulados) {
            // Reglas del documento
            if (polizaActiva) {
                if (copagosAcumulados >= 1000000) {
                    factura.Copago = 0; // aseguradora paga todo
                } else {
                    factura.Copago = 50000;
                }
                factura.Total = totalServicios;
            } else {
                factura.Copago = totalServicios; // paciente paga todo
                factura.Total = totalServicios;
            }
            facturacionDAL.InsertarFactura(factura);
        }
    }*/
    internal class FacturacionBL {
        private FacturacionDAL facturacionDAL = new FacturacionDAL();

        public void GenerarFactura(Facturacion factura, decimal totalServicios, bool polizaActiva, decimal copagosAcumulados) {
            // 📌 Lógica de negocio
            if (polizaActiva) {
                if (copagosAcumulados >= 1000000) {
                    factura.Copago = 0;
                } else {
                    factura.Copago = 50000; // Copago fijo, por ejemplo
                }

                factura.Total = totalServicios;
            } else {
                factura.Copago = totalServicios; // Paga todo
                factura.Total = totalServicios;
            }

            factura.Fecha = DateTime.Now;

            facturacionDAL.InsertarFactura(factura);
        }

        public List<Facturacion> ObtenerFacturas() {
            return facturacionDAL.ObtenerFacturas();
        }

        public void ActualizarFactura(Facturacion factura) {
            facturacionDAL.ActualizarFactura(factura);
        }

        public void EliminarFactura(int idFactura) {
            facturacionDAL.EliminarFactura(idFactura);
        }
    }
}