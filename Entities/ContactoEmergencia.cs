using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Entities {
    class ContactoEmergencia {
        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Relacion { get; set; }
        public string TelefonoEmergencia { get; set; }
        public int IdPaciente { get; set; }
    }
}