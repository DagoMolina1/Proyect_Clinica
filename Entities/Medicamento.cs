using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Entities {
    class Medicamento {
        public int IdMedicamento { get; set; }
        public string Nombre { get; set; }
        public string Dosis { get; set; }
        public decimal Costo { get; set; }
    }
}