using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.ValueObjects;

namespace ClinicaIPS_U.Domain.Entities {
    public class Usuario {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public DocumentoIdentidad Cedula { get; set; }
        public Email Correo { get; set; }
        public Telefono Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Direccion Direccion { get; set; }
        public string Rol { get; set; }
        public string UsuarioLogin { get; set; }
        public string Contraseña { get; set; } //Esto se puedee migrar a un VO más adelante (PasswordHash)
    }
}