using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;

namespace ClinicaIPS_U.Domain.Interfaces {
    public interface IUsuarioRepository {
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(string cedula);
        Usuario GetByCedula(string cedula);
        Usuario GetByLogin(string usuarioLogin, string contraseña);
        List<Usuario> GetAll();
    }
}