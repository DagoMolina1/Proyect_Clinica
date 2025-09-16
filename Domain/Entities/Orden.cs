using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Domain
    .Entities {
    class Orden {
        public int IdOrden { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
    }
}