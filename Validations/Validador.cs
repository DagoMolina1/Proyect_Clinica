using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace ClinicaIPS_U.Validations {
    public static class Validador {
        //Validar correo electrónico
        public static bool EsCorreoValido(string correo) {
            if (string.IsNullOrEmpty(correo)) return false;
            return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        //Validar teléfono (10 dígitos)
        public static bool EsTelefonoValido(string telefono) {
            return !string.IsNullOrEmpty(telefono) &&
                   telefono.Length == 10 &&
                   long.TryParse(telefono, out _);
        }

        //Validar cédula
        public static bool EsCedulaValida(string cedula) {
            return !string.IsNullOrEmpty(cedula) &&
                   cedula.Length >= 6 &&
                   cedula.Length <= 15 &&
                   long.TryParse(cedula, out _);
        }

        //Validar contraseña (mínimo 8, 1 mayúscula, 1 número, 1 carácter especial)
        public static bool EsContraseñaValida(string contraseña) {
            if (string.IsNullOrEmpty(contraseña) || contraseña.Length < 8)
                return false;

            bool tieneMayuscula = Regex.IsMatch(contraseña, @"[A-Z]");
            bool tieneNumero = Regex.IsMatch(contraseña, @"[0-9]");
            bool tieneEspecial = Regex.IsMatch(contraseña, @"[!@#$%^&*(),.?""{}|<>]");

            return tieneMayuscula && tieneNumero && tieneEspecial;
        }

        //Validar edad (ejemplo: máximo 150 años)
        public static bool EsFechaNacimientoValida(DateTime fecha) {
            int edad = DateTime.Now.Year - fecha.Year;
            if (fecha > DateTime.Now.AddYears(-edad)) edad--; // Ajuste si aún no cumplió
            return edad > 0 && edad <= 150;
        }
    }
}