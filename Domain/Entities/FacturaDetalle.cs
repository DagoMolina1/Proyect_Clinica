using System;
using System.Collections.Generic;

namespace ClinicaIPS_U.Domain.Entities {
    public class FacturaDetalle {
        public string NombrePaciente { get; set; }
        public string CedulaPaciente { get; set; }
        public int EdadPaciente { get; set; }
        public string NombreMedicoTratante { get; set; }
        public string NombreAseguradora { get; set; }
        public string NumeroPoliza { get; set; }
        public bool PolizaActiva { get; set; }
        public int DiasVigencia { get; set; }
        public DateTime FechaFinPoliza { get; set; }
        public decimal Copago { get; set; }
        public decimal TotalServicios { get; set; }
        public decimal ValorCoberturaAseguradora { get; set; }
        public decimal ValorPaciente { get; set; }
        public List<OrdenMedicamento> Medicamentos { get; set; } = new List<OrdenMedicamento>();
        public List<OrdenProcedimiento> Procedimientos { get; set; } = new List<OrdenProcedimiento>();
        public List<OrdenAyudaDiagnostica> AyudasDiagnosticas { get; set; } = new List<OrdenAyudaDiagnostica>();
    }
}
