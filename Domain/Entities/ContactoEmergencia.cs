using ClinicaIPS_U.Domain.ValueObjects;

namespace ClinicaIPS_U.Domain.Entities {
    public class ContactoEmergencia {
        public int IdContacto { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Relacion { get; set; }
        public Telefono TelefonoEmergencia { get; set; }
        public int IdPaciente { get; set; }
    }
}
