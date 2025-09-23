namespace ClinicaIPS_U.Domain.Entities {
    public class OrdenProcedimiento {
        public int IdOrdenProcedimiento { get; set; }
        public int IdOrden { get; set; }
        public int NumeroItem { get; set; }
        public int IdProcedimiento { get; set; }
        public string NombreProcedimiento { get; set; }
        public int Veces { get; set; }
        public string Frecuencia { get; set; }
        public bool RequiereEspecialista { get; set; }
        public int? IdEspecialidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal Subtotal => Veces * CostoUnitario;
    }
}
