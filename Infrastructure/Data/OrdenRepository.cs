using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class OrdenRepository : IOrdenRepository {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(Orden orden) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO Ordenes (idOrden, fechaCreacion, idPaciente, idMedico) 
                                 VALUES (@idOrden, @fecha, @idPaciente, @idMedico)";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idOrden", orden.IdOrden);
                    cmd.Parameters.AddWithValue("@fecha", orden.FechaCreacion);
                    cmd.Parameters.AddWithValue("@idPaciente", orden.IdPaciente);
                    cmd.Parameters.AddWithValue("@idMedico", orden.IdMedico);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Orden orden) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE Ordenes SET fechaCreacion=@fecha, idPaciente=@idPaciente, idMedico=@idMedico
                                 WHERE idOrden=@idOrden";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idOrden", orden.IdOrden);
                    cmd.Parameters.AddWithValue("@fecha", orden.FechaCreacion);
                    cmd.Parameters.AddWithValue("@idPaciente", orden.IdPaciente);
                    cmd.Parameters.AddWithValue("@idMedico", orden.IdMedico);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idOrden) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM Ordenes WHERE idOrden=@idOrden";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idOrden", idOrden);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Orden GetById(int idOrden) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Ordenes WHERE idOrden=@idOrden";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idOrden", idOrden);
                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            return new Orden {
                                IdOrden = (int)reader["idOrden"],
                                FechaCreacion = (DateTime)reader["fechaCreacion"],
                                IdPaciente = (int)reader["idPaciente"],
                                IdMedico = (int)reader["idMedico"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Orden> GetAll() {
            var lista = new List<Orden>();
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Ordenes";
                using (var cmd = new SqlCommand(query, conn)) {
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            lista.Add(new Orden {
                                IdOrden = (int)reader["idOrden"],
                                FechaCreacion = (DateTime)reader["fechaCreacion"],
                                IdPaciente = (int)reader["idPaciente"],
                                IdMedico = (int)reader["idMedico"]
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}