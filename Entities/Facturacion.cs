using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Entities {
    class Facturacion {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Copago { get; set; }
        public decimal Total { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int? IdSeguro { get; set; }
    }
}