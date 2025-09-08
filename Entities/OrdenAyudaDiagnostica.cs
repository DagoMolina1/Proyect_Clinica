using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Entities {
    class OrdenAyudaDiagnostica {
        public int IdOrdenAyuda { get; set; }
        public int IdOrden { get; set; }
        public int IdAyuda { get; set; }
        public int Cantidad { get; set; }
    }
}