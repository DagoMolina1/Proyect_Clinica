using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class OrdenMedicamentoRepository : IOrdenMedicamentoRepository {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(OrdenMedicamento orden) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO OrdenMedicamento (idOrden, numeroItem, idMedicamento, nombreMedicamento, dosis, duracionTratamiento, cantidad, costoUnitario)
                                 VALUES (@idOrden, @numeroItem, @idMedicamento, @nombre, @dosis, @duracion, @cantidad, @costo)";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idOrden", orden.IdOrden);
                    cmd.Parameters.AddWithValue("@numeroItem", orden.NumeroItem);
                    cmd.Parameters.AddWithValue("@idMedicamento", orden.IdMedicamento);
                    cmd.Parameters.AddWithValue("@nombre", orden.NombreMedicamento);
                    cmd.Parameters.AddWithValue("@dosis", orden.Dosis ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@duracion", orden.DuracionTratamiento ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidad", orden.Cantidad);
                    cmd.Parameters.AddWithValue("@costo", orden.CostoUnitario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(OrdenMedicamento orden) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE OrdenMedicamento
                                 SET idOrden=@idOrden, numeroItem=@numeroItem, idMedicamento=@idMedicamento, nombreMedicamento=@nombre,
                                     dosis=@dosis, duracionTratamiento=@duracion, cantidad=@cantidad, costoUnitario=@costo
                                 WHERE idOrdenMedicamento=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", orden.IdOrdenMedicamento);
                    cmd.Parameters.AddWithValue("@idOrden", orden.IdOrden);
                    cmd.Parameters.AddWithValue("@numeroItem", orden.NumeroItem);
                    cmd.Parameters.AddWithValue("@idMedicamento", orden.IdMedicamento);
                    cmd.Parameters.AddWithValue("@nombre", orden.NombreMedicamento);
                    cmd.Parameters.AddWithValue("@dosis", orden.Dosis ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@duracion", orden.DuracionTratamiento ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidad", orden.Cantidad);
                    cmd.Parameters.AddWithValue("@costo", orden.CostoUnitario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idOrdenMedicamento) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM OrdenMedicamento WHERE idOrdenMedicamento=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", idOrdenMedicamento);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public OrdenMedicamento GetById(int idOrdenMedicamento) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM OrdenMedicamento WHERE idOrdenMedicamento=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", idOrdenMedicamento);
                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            return Mapear(reader);
                        }
                    }
                }
            }
            return null;
        }

        public List<OrdenMedicamento> GetByOrden(int idOrden) {
            var lista = new List<OrdenMedicamento>();
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM OrdenMedicamento WHERE idOrden=@idOrden";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idOrden", idOrden);
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            lista.Add(Mapear(reader));
                        }
                    }
                }
            }
            return lista;
        }

        private static OrdenMedicamento Mapear(SqlDataReader reader) {
            return new OrdenMedicamento {
                IdOrdenMedicamento = (int)reader["idOrdenMedicamento"],
                IdOrden = (int)reader["idOrden"],
                NumeroItem = (int)reader["numeroItem"],
                IdMedicamento = (int)reader["idMedicamento"],
                NombreMedicamento = reader["nombreMedicamento"].ToString(),
                Dosis = reader["dosis"]?.ToString(),
                DuracionTratamiento = reader["duracionTratamiento"]?.ToString(),
                Cantidad = (int)reader["cantidad"],
                CostoUnitario = (decimal)reader["costoUnitario"]
            };
        }
    }
}
