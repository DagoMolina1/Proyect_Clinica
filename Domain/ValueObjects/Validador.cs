using System;
using System.Text.RegularExpressions;

namespace ClinicaIPS_U.Domain.ValueObjects {
    public static class Validador {
        //Validar contraseña (mínimo 8, 1 mayúscula, 1 número, 1 carácter especial)
        public static bool EsContraseñaValida(string contrasena) {
            if (string.IsNullOrEmpty(contrasena) || contrasena.Length < 8)
                return false;

            bool tieneMayuscula = Regex.IsMatch(contrasena, @"[A-Z]");
            bool tieneNumero = Regex.IsMatch(contrasena, @"[0-9]");
            bool tieneEspecial = Regex.IsMatch(contrasena, @"[!@#$%^&*(),.?""{}|<>]");

            return tieneMayuscula && tieneNumero && tieneEspecial;
        }

        //Validar edad (ejemplo: máximo 150 años)
        public static bool EsFechaNacimientoValida(DateTime fecha) {
            int edad = DateTime.Now.Year - fecha.Year;
            if (fecha > DateTime.Now.AddYears(-edad)) edad--;
            return edad > 0 && edad <= 150;
        }
    }
}
