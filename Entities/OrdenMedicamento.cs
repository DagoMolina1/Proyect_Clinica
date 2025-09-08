using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Entities {
    class OrdenMedicamento {
        public int IdOrdenMedicamento { get; set; }
        public int IdOrden { get; set; }
        public int IdMedicamento { get; set; }
        public int Cantidad { get; set; }
    }
}