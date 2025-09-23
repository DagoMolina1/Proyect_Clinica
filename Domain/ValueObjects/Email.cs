using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace ClinicaIPS_U.Domain.ValueObjects {
    public class Email {
        public string Value { get; private set; }

        public Email(string value) {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El correo no puede estar vacío.");

            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El correo no tiene un formato válido.");

            Value = value;
        }

        public override string ToString() => Value;
    }
}