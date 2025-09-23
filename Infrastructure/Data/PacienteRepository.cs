using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;
using ClinicaIPS_U.Domain.ValueObjects;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class PacienteRepository : IPacienteRepository {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(Paciente paciente) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                using (var tran = conn.BeginTransaction()) {
                    try {
                        string queryPaciente = @"INSERT INTO Pacientes (cedula, nombreCompleto, fechaNacimiento, genero, direccion, telefono, correo, usuarioPortal, contrasenaPortal)
                                                    VALUES (@cedula, @nombre, @fecha, @genero, @direccion, @telefono, @correo, @usuarioPortal, @contrasenaPortal);
                                                SELECT CAST(SCOPE_IDENTITY() AS INT);";
                        int idPaciente;
                        using (var cmd = new SqlCommand(queryPaciente, conn, tran)) {
                            cmd.Parameters.AddWithValue("@cedula", paciente.Cedula.Value);
                            cmd.Parameters.AddWithValue("@nombre", paciente.NombreCompleto);
                            cmd.Parameters.AddWithValue("@fecha", paciente.FechaNacimiento);
                            cmd.Parameters.AddWithValue("@genero", (object)paciente.Genero ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@direccion", paciente.Direccion?.Value ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@telefono", paciente.Telefono.Value);
                            cmd.Parameters.AddWithValue("@correo", paciente.Correo?.Value ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@usuarioPortal", paciente.UsuarioPortal);
                            cmd.Parameters.AddWithValue("@contrasenaPortal", paciente.ContrasenaPortal);
                            idPaciente = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        if (paciente.ContactoEmergencia != null) {
                            string queryContacto = @"INSERT INTO ContactosEmergencia (idPaciente, nombres, apellidos, relacion, telefono)
                                                      VALUES (@idPaciente, @nombres, @apellidos, @relacion, @telefono)";
                            using (var cmdContacto = new SqlCommand(queryContacto, conn, tran)) {
                                cmdContacto.Parameters.AddWithValue("@idPaciente", idPaciente);
                                cmdContacto.Parameters.AddWithValue("@nombres", paciente.ContactoEmergencia.Nombres);
                                cmdContacto.Parameters.AddWithValue("@apellidos", paciente.ContactoEmergencia.Apellidos);
                                cmdContacto.Parameters.AddWithValue("@relacion", paciente.ContactoEmergencia.Relacion);
                                cmdContacto.Parameters.AddWithValue("@telefono", paciente.ContactoEmergencia.TelefonoEmergencia.Value);
                                cmdContacto.ExecuteNonQuery();
                            }
                        }

                        if (paciente.SeguroMedico != null) {
                            string querySeguro = @"INSERT INTO SegurosMedicos (idPaciente, nombreCompania, numeroPoliza, estado, vigencia)
                                                    VALUES (@idPaciente, @nombreCompania, @numeroPoliza, @estado, @vigencia)";
                            using (var cmdSeguro = new SqlCommand(querySeguro, conn, tran)) {
                                cmdSeguro.Parameters.AddWithValue("@idPaciente", idPaciente);
                                cmdSeguro.Parameters.AddWithValue("@nombreCompania", paciente.SeguroMedico.NombreCompania);
                                cmdSeguro.Parameters.AddWithValue("@numeroPoliza", paciente.SeguroMedico.NumeroPoliza);
                                cmdSeguro.Parameters.AddWithValue("@estado", paciente.SeguroMedico.Estado);
                                cmdSeguro.Parameters.AddWithValue("@vigencia", paciente.SeguroMedico.Vigencia);
                                cmdSeguro.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(Paciente paciente) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                using (var tran = conn.BeginTransaction()) {
                    try {
                        string queryPaciente = @"UPDATE Pacientes
                                                SET nombreCompleto=@nombre, fechaNacimiento=@fecha, genero=@genero,
                                                    direccion=@direccion, telefono=@telefono, correo=@correo,
                                                    usuarioPortal=@usuarioPortal, contrasenaPortal=@contrasenaPortal
                                                WHERE cedula=@cedula";
                        using (var cmd = new SqlCommand(queryPaciente, conn, tran)) {
                            cmd.Parameters.AddWithValue("@cedula", paciente.Cedula.Value);
                            cmd.Parameters.AddWithValue("@nombre", paciente.NombreCompleto);
                            cmd.Parameters.AddWithValue("@fecha", paciente.FechaNacimiento);
                            cmd.Parameters.AddWithValue("@genero", (object)paciente.Genero ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@direccion", paciente.Direccion?.Value ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@telefono", paciente.Telefono.Value);
                            cmd.Parameters.AddWithValue("@correo", paciente.Correo?.Value ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@usuarioPortal", paciente.UsuarioPortal);
                            cmd.Parameters.AddWithValue("@contrasenaPortal", paciente.ContrasenaPortal);
                            cmd.ExecuteNonQuery();
                        }

                        int idPaciente = ObtenerIdPacientePorCedula(conn, tran, paciente.Cedula.Value);

                        string deleteContacto = "DELETE FROM ContactosEmergencia WHERE idPaciente=@idPaciente";
                        using (var cmdDeleteContacto = new SqlCommand(deleteContacto, conn, tran)) {
                            cmdDeleteContacto.Parameters.AddWithValue("@idPaciente", idPaciente);
                            cmdDeleteContacto.ExecuteNonQuery();
                        }

                        if (paciente.ContactoEmergencia != null) {
                            string insertContacto = @"INSERT INTO ContactosEmergencia (idPaciente, nombres, apellidos, relacion, telefono)
                                                       VALUES (@idPaciente, @nombres, @apellidos, @relacion, @telefono)";
                            using (var cmdContacto = new SqlCommand(insertContacto, conn, tran)) {
                                cmdContacto.Parameters.AddWithValue("@idPaciente", idPaciente);
                                cmdContacto.Parameters.AddWithValue("@nombres", paciente.ContactoEmergencia.Nombres);
                                cmdContacto.Parameters.AddWithValue("@apellidos", paciente.ContactoEmergencia.Apellidos);
                                cmdContacto.Parameters.AddWithValue("@relacion", paciente.ContactoEmergencia.Relacion);
                                cmdContacto.Parameters.AddWithValue("@telefono", paciente.ContactoEmergencia.TelefonoEmergencia.Value);
                                cmdContacto.ExecuteNonQuery();
                            }
                        }

                        string deleteSeguro = "DELETE FROM SegurosMedicos WHERE idPaciente=@idPaciente";
                        using (var cmdDeleteSeguro = new SqlCommand(deleteSeguro, conn, tran)) {
                            cmdDeleteSeguro.Parameters.AddWithValue("@idPaciente", idPaciente);
                            cmdDeleteSeguro.ExecuteNonQuery();
                        }

                        if (paciente.SeguroMedico != null) {
                            string insertSeguro = @"INSERT INTO SegurosMedicos (idPaciente, nombreCompania, numeroPoliza, estado, vigencia)
                                                     VALUES (@idPaciente, @nombreCompania, @numeroPoliza, @estado, @vigencia)";
                            using (var cmdSeguro = new SqlCommand(insertSeguro, conn, tran)) {
                                cmdSeguro.Parameters.AddWithValue("@idPaciente", idPaciente);
                                cmdSeguro.Parameters.AddWithValue("@nombreCompania", paciente.SeguroMedico.NombreCompania);
                                cmdSeguro.Parameters.AddWithValue("@numeroPoliza", paciente.SeguroMedico.NumeroPoliza);
                                cmdSeguro.Parameters.AddWithValue("@estado", paciente.SeguroMedico.Estado);
                                cmdSeguro.Parameters.AddWithValue("@vigencia", paciente.SeguroMedico.Vigencia);
                                cmdSeguro.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(string cedula) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                using (var tran = conn.BeginTransaction()) {
                    try {
                        int idPaciente = ObtenerIdPacientePorCedula(conn, tran, cedula);

                        string deleteContacto = "DELETE FROM ContactosEmergencia WHERE idPaciente=@idPaciente";
                        using (var cmdDeleteContacto = new SqlCommand(deleteContacto, conn, tran)) {
                            cmdDeleteContacto.Parameters.AddWithValue("@idPaciente", idPaciente);
                            cmdDeleteContacto.ExecuteNonQuery();
                        }

                        string deleteSeguro = "DELETE FROM SegurosMedicos WHERE idPaciente=@idPaciente";
                        using (var cmdDeleteSeguro = new SqlCommand(deleteSeguro, conn, tran)) {
                            cmdDeleteSeguro.Parameters.AddWithValue("@idPaciente", idPaciente);
                            cmdDeleteSeguro.ExecuteNonQuery();
                        }

                        string deletePaciente = "DELETE FROM Pacientes WHERE cedula=@cedula";
                        using (var cmdDeletePaciente = new SqlCommand(deletePaciente, conn, tran)) {
                            cmdDeletePaciente.Parameters.AddWithValue("@cedula", cedula);
                            cmdDeletePaciente.ExecuteNonQuery();
                        }

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public Paciente GetById(int idPaciente) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Pacientes WHERE idPaciente=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", idPaciente);
                    using (var reader = cmd.ExecuteReader()) {
                        if (!reader.Read()) {
                            return null;
                        }
                        var paciente = MapearPaciente(reader);
                        paciente.ContactoEmergencia = ObtenerContacto(conn, paciente.IdPaciente);
                        paciente.SeguroMedico = ObtenerSeguro(conn, paciente.IdPaciente);
                        return paciente;
                    }
                }
            }
        }

        public Paciente GetByCedula(string cedula) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Pacientes WHERE cedula=@cedula";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    using (var reader = cmd.ExecuteReader()) {
                        if (!reader.Read()) {
                            return null;
                        }

                        var paciente = MapearPaciente(reader);
                        paciente.ContactoEmergencia = ObtenerContacto(conn, paciente.IdPaciente);
                        paciente.SeguroMedico = ObtenerSeguro(conn, paciente.IdPaciente);
                        return paciente;
                    }
                }
            }
        }

        public List<Paciente> GetAll() {
            var lista = new List<Paciente>();
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Pacientes";
                using (var cmd = new SqlCommand(query, conn)) {
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            var paciente = MapearPaciente(reader);
                            paciente.ContactoEmergencia = ObtenerContacto(conn, paciente.IdPaciente);
                            paciente.SeguroMedico = ObtenerSeguro(conn, paciente.IdPaciente);
                            lista.Add(paciente);
                        }
                    }
                }
            }
            return lista;
        }

        private static int ObtenerIdPacientePorCedula(SqlConnection conn, SqlTransaction tran, string cedula) {
            string query = "SELECT idPaciente FROM Pacientes WHERE cedula=@cedula";
            using (var cmd = new SqlCommand(query, conn, tran)) {
                cmd.Parameters.AddWithValue("@cedula", cedula);
                var result = cmd.ExecuteScalar();
                if (result == null) {
                    throw new InvalidOperationException("Paciente no encontrado");
                }
                return Convert.ToInt32(result);
            }
        }

        private static Paciente MapearPaciente(SqlDataReader reader) {
            return new Paciente {
                IdPaciente = (int)reader["idPaciente"],
                Cedula = new DocumentoIdentidad(reader["cedula"].ToString()),
                NombreCompleto = reader["nombreCompleto"].ToString(),
                FechaNacimiento = (DateTime)reader["fechaNacimiento"],
                Genero = reader["genero"]?.ToString(),
                Direccion = new Direccion(reader["direccion"]?.ToString() ?? string.Empty),
                Telefono = new Telefono(reader["telefono"].ToString()),
                Correo = reader["correo"] == DBNull.Value ? null : new Email(reader["correo"].ToString()),
                UsuarioPortal = reader["usuarioPortal"].ToString(),
                ContrasenaPortal = reader["contrasenaPortal"].ToString()
            };
        }

        private static ContactoEmergencia ObtenerContacto(SqlConnection conn, int idPaciente) {
            string query = "SELECT TOP 1 * FROM ContactosEmergencia WHERE idPaciente=@id";
            using (var cmd = new SqlCommand(query, conn)) {
                cmd.Parameters.AddWithValue("@id", idPaciente);
                using (var reader = cmd.ExecuteReader()) {
                    if (reader.Read()) {
                        return new ContactoEmergencia {
                            IdContacto = (int)reader["idContacto"],
                            Nombres = reader["nombres"].ToString(),
                            Apellidos = reader["apellidos"].ToString(),
                            Relacion = reader["relacion"].ToString(),
                            TelefonoEmergencia = new Telefono(reader["telefono"].ToString()),
                            IdPaciente = idPaciente
                        };
                    }
                }
            }
            return null;
        }

        private static SeguroMedico ObtenerSeguro(SqlConnection conn, int idPaciente) {
            string query = "SELECT TOP 1 * FROM SegurosMedicos WHERE idPaciente=@id";
            using (var cmd = new SqlCommand(query, conn)) {
                cmd.Parameters.AddWithValue("@id", idPaciente);
                using (var reader = cmd.ExecuteReader()) {
                    if (reader.Read()) {
                        return new SeguroMedico {
                            IdSeguro = (int)reader["idSeguro"],
                            NombreCompania = reader["nombreCompania"].ToString(),
                            NumeroPoliza = reader["numeroPoliza"].ToString(),
                            Estado = (bool)reader["estado"],
                            Vigencia = (DateTime)reader["vigencia"],
                            IdPaciente = idPaciente
                        };
                    }
                }
            }
            return null;
        }
    }
}
