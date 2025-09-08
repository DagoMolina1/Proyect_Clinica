using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Data;
using ClinicaIPS_U.Entities;

namespace ClinicaIPS_U.Business {
    class UsuarioBL {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        public void RegistrarUsuario(Usuario usuario) {
            if (string.IsNullOrEmpty(usuario.Cedula))
                throw new Exception("La cédula es obligatoria.");

            if (usuario.FechaNacimiento > DateTime.Now)
                throw new Exception("La fecha de nacimiento no puede ser en el futuro.");

            if (string.IsNullOrEmpty(usuario.UsuarioLogin) || usuario.UsuarioLogin.Length < 4)
                throw new Exception("El usuario debe tener al menos 4 caracteres.");

            if (string.IsNullOrEmpty(usuario.Contraseña) || usuario.Contraseña.Length < 8)
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");

            usuarioDAL.InsertarUsuario(usuario);
        }

        public List<Usuario> ObtenerUsuarios() {
            return usuarioDAL.ObtenerUsuarios();
        }

        public void ActualizarUsuario(Usuario usuario) {
            usuarioDAL.ActualizarUsuario(usuario);
        }

        public void EliminarUsuario(string cedula) {
            usuarioDAL.EliminarUsuario(cedula);
        }
    }
}