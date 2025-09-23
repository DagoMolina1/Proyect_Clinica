using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class MedicamentoRepository : IMedicamentoRepository {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(Medicamento medicamento) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO Medicamentos (nombre, dosis, costo) 
                                 VALUES (@nombre, @dosis, @costo)";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@nombre", medicamento.Nombre);
                    cmd.Parameters.AddWithValue("@dosis", medicamento.Dosis ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@costo", medicamento.Costo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Medicamento medicamento) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE Medicamentos 
                                 SET nombre=@nombre, dosis=@dosis, costo=@costo 
                                 WHERE idMedicamento=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", medicamento.IdMedicamento);
                    cmd.Parameters.AddWithValue("@nombre", medicamento.Nombre);
                    cmd.Parameters.AddWithValue("@dosis", medicamento.Dosis ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@costo", medicamento.Costo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idMedicamento) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM Medicamentos WHERE idMedicamento=@id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idMedicamento);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Medicamento GetById(int idMedicamento) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Medicamentos WHERE idMedicamento=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", idMedicamento);
                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            return new Medicamento {
                                IdMedicamento = (int)reader["idMedicamento"],
                                Nombre = reader["nombre"].ToString(),
                                Dosis = reader["dosis"]?.ToString(),
                                Costo = (decimal)reader["costo"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Medicamento> GetAll() {
            var lista = new List<Medicamento>();
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Medicamentos";
                using (var cmd = new SqlCommand(query, conn)) {
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            lista.Add(new Medicamento {
                                IdMedicamento = (int)reader["idMedicamento"],
                                Nombre = reader["nombre"].ToString(),
                                Dosis = reader["dosis"]?.ToString(),
                                Costo = (decimal)reader["costo"]
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}