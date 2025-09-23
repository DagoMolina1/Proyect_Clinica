using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;

namespace ClinicaIPS_U.Domain.Services {
    public class UsuarioService {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Registrar(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.UsuarioLogin))
                throw new System.Exception("El usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.Contraseña))
                throw new System.Exception("La contraseña es obligatoria.");

            _usuarioRepository.Add(usuario);
        }

        public void Actualizar(Usuario usuario) => _usuarioRepository.Update(usuario);

        public void Eliminar(string cedula) => _usuarioRepository.Delete(cedula);

        public Usuario BuscarPorCedula(string cedula) => _usuarioRepository.GetByCedula(cedula);

        public Usuario Login(string usuario, string contraseña) => _usuarioRepository.GetByLogin(usuario, contraseña);

        public List<Usuario> Listar() => _usuarioRepository.GetAll();
    }
}
