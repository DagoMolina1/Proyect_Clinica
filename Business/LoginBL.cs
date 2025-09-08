using ClinicaIPS_U.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Business {
    internal class LoginBL {
        private ConexionDB conexion = new ConexionDB();

        public string ValidarUsuario(string usuario, string contraseña) {
            using (SqlConnection conn = conexion.GetConexion())
            {
                conn.Open();
                string query = "SELECT rol FROM Usuarios WHERE usuarioLogin=@usuario AND contraseña=@contraseña";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);

                var rol = cmd.ExecuteScalar();
                return rol?.ToString(); // Devuelve el rol si existe
            }
        }
    }
}