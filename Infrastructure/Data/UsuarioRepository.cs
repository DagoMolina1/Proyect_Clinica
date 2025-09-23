using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;
using ClinicaIPS_U.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class UsuarioRepository : IUsuarioRepository {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(Usuario usuario) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO Usuarios (nombreCompleto, cedula, correo, telefono, fechaNacimiento, direccion, rol, usuarioLogin, contraseña)
                                 VALUES (@nombre, @cedula, @correo, @telefono, @fecha, @direccion, @rol, @usuarioLogin, @contraseña)";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@nombre", usuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@cedula", usuario.Cedula.Value);
                    cmd.Parameters.AddWithValue("@correo", usuario.Correo.Value);
                    cmd.Parameters.AddWithValue("@telefono", usuario.Telefono.Value);
                    cmd.Parameters.AddWithValue("@fecha", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@direccion", usuario.Direccion.Value);
                    cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                    cmd.Parameters.AddWithValue("@usuarioLogin", usuario.UsuarioLogin);
                    cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Usuario usuario) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE Usuarios 
                                 SET nombreCompleto=@nombre, correo=@correo, telefono=@telefono, fechaNacimiento=@fecha, 
                                     direccion=@direccion, rol=@rol, usuarioLogin=@usuarioLogin, contraseña=@contraseña
                                 WHERE cedula=@cedula";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@nombre", usuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@correo", usuario.Correo.Value);
                    cmd.Parameters.AddWithValue("@telefono", usuario.Telefono.Value);
                    cmd.Parameters.AddWithValue("@fecha", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@direccion", usuario.Direccion.Value);
                    cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                    cmd.Parameters.AddWithValue("@usuarioLogin", usuario.UsuarioLogin);
                    cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                    cmd.Parameters.AddWithValue("@cedula", usuario.Cedula.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string cedula) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM Usuarios WHERE cedula=@cedula";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Usuario GetByCedula(string cedula) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Usuarios WHERE cedula=@cedula";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            return new Usuario {
                                IdUsuario = (int)reader["idUsuario"],
                                NombreCompleto = reader["nombreCompleto"].ToString(),
                                Cedula = new DocumentoIdentidad(reader["cedula"].ToString()),
                                Correo = new Email(reader["correo"].ToString()),
                                Telefono = new Telefono(reader["telefono"].ToString()),
                                FechaNacimiento = (DateTime)reader["fechaNacimiento"],
                                Direccion = new Direccion(reader["direccion"].ToString()),
                                Rol = reader["rol"].ToString(),
                                UsuarioLogin = reader["usuarioLogin"].ToString(),
                                Contraseña = reader["contraseña"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Usuario GetByLogin(string usuarioLogin, string contraseña) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Usuarios WHERE usuarioLogin=@usuario AND contraseña=@contraseña";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@usuario", usuarioLogin);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);
                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            return new Usuario {
                                IdUsuario = (int)reader["idUsuario"],
                                NombreCompleto = reader["nombreCompleto"].ToString(),
                                Cedula = new DocumentoIdentidad(reader["cedula"].ToString()),
                                Correo = new Email(reader["correo"].ToString()),
                                Telefono = new Telefono(reader["telefono"].ToString()),
                                FechaNacimiento = (DateTime)reader["fechaNacimiento"],
                                Direccion = new Direccion(reader["direccion"].ToString()),
                                Rol = reader["rol"].ToString(),
                                UsuarioLogin = reader["usuarioLogin"].ToString(),
                                Contraseña = reader["contraseña"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Usuario> GetAll() {
            var lista = new List<Usuario>();
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Usuarios";
                using (var cmd = new SqlCommand(query, conn)) {
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            lista.Add(new Usuario {
                                IdUsuario = (int)reader["idUsuario"],
                                NombreCompleto = reader["nombreCompleto"].ToString(),
                                Cedula = new DocumentoIdentidad(reader["cedula"].ToString()),
                                Correo = new Email(reader["correo"].ToString()),
                                Telefono = new Telefono(reader["telefono"].ToString()),
                                FechaNacimiento = (DateTime)reader["fechaNacimiento"],
                                Direccion = new Direccion(reader["direccion"].ToString()),
                                Rol = reader["rol"].ToString(),
                                UsuarioLogin = reader["usuarioLogin"].ToString(),
                                Contraseña = reader["contraseña"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}