using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Entities;
using System.Data.SqlClient;

namespace ClinicaIPS_U.Data {
    class UsuarioDAL {
        private ConexionDB conexion = new ConexionDB();

        // CREATE
        public void InsertarUsuario(Usuario usuario) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO Usuarios 
                                (NombreCompleto, Cedula, Correo, Telefono, FechaNacimiento, Direccion, Rol, UsuarioLogin, Contraseña)
                                VALUES (@NombreCompleto, @Cedula, @Correo, @Telefono, @FechaNacimiento, @Direccion, @Rol, @UsuarioLogin, @Contraseña)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@Cedula", usuario.Cedula);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@UsuarioLogin", usuario.UsuarioLogin);
                cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);

                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<Usuario> ObtenerUsuarios() {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Usuarios";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    lista.Add(new Usuario {
                        IdUsuario = (int)reader["IdUsuario"],
                        NombreCompleto = reader["NombreCompleto"].ToString(),
                        Cedula = reader["Cedula"].ToString(),
                        Correo = reader["Correo"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                        Direccion = reader["Direccion"].ToString(),
                        Rol = reader["Rol"].ToString(),
                        UsuarioLogin = reader["UsuarioLogin"].ToString(),
                        Contraseña = reader["Contraseña"].ToString()
                    });
                }
            }

            return lista;
        }

        // UPDATE
        public void ActualizarUsuario(Usuario usuario) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE Usuarios SET 
                                NombreCompleto=@NombreCompleto, Correo=@Correo, Telefono=@Telefono, 
                                FechaNacimiento=@FechaNacimiento, Direccion=@Direccion, Rol=@Rol, 
                                UsuarioLogin=@UsuarioLogin, Contraseña=@Contraseña
                                WHERE Cedula=@Cedula";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@UsuarioLogin", usuario.UsuarioLogin);
                cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                cmd.Parameters.AddWithValue("@Cedula", usuario.Cedula);

                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void EliminarUsuario(string cedula) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM Usuarios WHERE Cedula=@Cedula";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Cedula", cedula);

                cmd.ExecuteNonQuery();
            }
        }
    }
}