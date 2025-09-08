using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Entities {
    class OrdenProcedimiento {
        public int IdOrdenProcedimiento { get; set; }  
        public int IdOrden { get; set; }  
        public int IdProcedimiento { get; set; } 
        public int Repeticiones { get; set; }   
        public string Frecuencia { get; set; }
    }
}