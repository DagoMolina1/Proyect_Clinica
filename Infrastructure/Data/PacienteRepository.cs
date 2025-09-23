using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;
using ClinicaIPS_U.Domain.ValueObjects;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class PacienteRepository : IPacienteRepository {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(Paciente paciente) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO Pacientes (cedula, nombreCompleto, fechaNacimiento, genero, direccion, telefono, correo)
                                 VALUES (@cedula, @nombre, @fecha, @genero, @direccion, @telefono, @correo)";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@cedula", paciente.Cedula.Value);
                    cmd.Parameters.AddWithValue("@nombre", paciente.NombreCompleto);
                    cmd.Parameters.AddWithValue("@fecha", paciente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@genero", paciente.Genero ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", paciente.Direccion?.Value ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", paciente.Telefono.Value);
                    cmd.Parameters.AddWithValue("@correo", paciente.Correo?.Value ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Paciente paciente) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE Pacientes 
                                 SET nombreCompleto=@nombre, fechaNacimiento=@fecha, genero=@genero,
                                     direccion=@direccion, telefono=@telefono, correo=@correo
                                 WHERE cedula=@cedula";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@cedula", paciente.Cedula.Value);
                    cmd.Parameters.AddWithValue("@nombre", paciente.NombreCompleto);
                    cmd.Parameters.AddWithValue("@fecha", paciente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@genero", paciente.Genero ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", paciente.Direccion?.Value ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", paciente.Telefono.Value);
                    cmd.Parameters.AddWithValue("@correo", paciente.Correo?.Value ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string cedula) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM Pacientes WHERE cedula=@cedula";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.ExecuteNonQuery();
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
                        if (reader.Read()) {
                            return new Paciente {
                                IdPaciente = (int)reader["idPaciente"],
                                Cedula = new DocumentoIdentidad(reader["cedula"].ToString()),
                                NombreCompleto = reader["nombreCompleto"].ToString(),
                                FechaNacimiento = (DateTime)reader["fechaNacimiento"],
                                Genero = reader["genero"]?.ToString(),
                                Direccion = new Direccion(reader["direccion"]?.ToString() ?? ""),
                                Telefono = new Telefono(reader["telefono"].ToString()),
                                Correo = new Email(reader["correo"]?.ToString() ?? "correo@fake.com")
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Paciente> GetAll() {
            var lista = new List<Paciente>();
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Pacientes";
                using (var cmd = new SqlCommand(query, conn)) {
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            lista.Add(new Paciente {
                                IdPaciente = (int)reader["idPaciente"],
                                Cedula = new DocumentoIdentidad(reader["cedula"].ToString()),
                                NombreCompleto = reader["nombreCompleto"].ToString(),
                                FechaNacimiento = (DateTime)reader["fechaNacimiento"],
                                Genero = reader["genero"]?.ToString(),
                                Direccion = new Direccion(reader["direccion"]?.ToString() ?? ""),
                                Telefono = new Telefono(reader["telefono"].ToString()),
                                Correo = new Email(reader["correo"]?.ToString() ?? "correo@fake.com")
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}