using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Domain.ValueObjects {
    public class Direccion {
        public string Value { get; private set; }
        public Direccion(string value) {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("La dirección no puede estar vacía.");

            if (value.Length < 5)
                throw new ArgumentException("La dirección es demasiado corta.");

            Value = value;
        }

        public override string ToString() => Value;
    }
}