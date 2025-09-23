using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class OrdenAyudaDiagnosticaRepository : IOrdenAyudaDiagnosticaRepository {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(OrdenAyudaDiagnostica orden) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO OrdenAyudaDiagnostica (idOrden, numeroItem, idAyuda, nombreAyuda, cantidad, requiereEspecialista, idEspecialidad, costoUnitario)
                                 VALUES (@idOrden, @numeroItem, @idAyuda, @nombreAyuda, @cantidad, @requiereEspecialista, @idEspecialidad, @costo)";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idOrden", orden.IdOrden);
                    cmd.Parameters.AddWithValue("@numeroItem", orden.NumeroItem);
                    cmd.Parameters.AddWithValue("@idAyuda", orden.IdAyuda);
                    cmd.Parameters.AddWithValue("@nombreAyuda", orden.NombreAyuda);
                    cmd.Parameters.AddWithValue("@cantidad", orden.Cantidad);
                    cmd.Parameters.AddWithValue("@requiereEspecialista", orden.RequiereEspecialista);
                    cmd.Parameters.AddWithValue("@idEspecialidad", (object)orden.IdEspecialidad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@costo", orden.CostoUnitario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(OrdenAyudaDiagnostica orden) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE OrdenAyudaDiagnostica
                                 SET idOrden=@idOrden, numeroItem=@numeroItem, idAyuda=@idAyuda, nombreAyuda=@nombreAyuda,
                                     cantidad=@cantidad, requiereEspecialista=@requiereEspecialista, idEspecialidad=@idEspecialidad, costoUnitario=@costo
                                 WHERE idOrdenAyuda=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", orden.IdOrdenAyuda);
                    cmd.Parameters.AddWithValue("@idOrden", orden.IdOrden);
                    cmd.Parameters.AddWithValue("@numeroItem", orden.NumeroItem);
                    cmd.Parameters.AddWithValue("@idAyuda", orden.IdAyuda);
                    cmd.Parameters.AddWithValue("@nombreAyuda", orden.NombreAyuda);
                    cmd.Parameters.AddWithValue("@cantidad", orden.Cantidad);
                    cmd.Parameters.AddWithValue("@requiereEspecialista", orden.RequiereEspecialista);
                    cmd.Parameters.AddWithValue("@idEspecialidad", (object)orden.IdEspecialidad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@costo", orden.CostoUnitario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idOrdenAyuda) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM OrdenAyudaDiagnostica WHERE idOrdenAyuda=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", idOrdenAyuda);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public OrdenAyudaDiagnostica GetById(int idOrdenAyuda) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM OrdenAyudaDiagnostica WHERE idOrdenAyuda=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", idOrdenAyuda);
                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            return Mapear(reader);
                        }
                    }
                }
            }
            return null;
        }

        public List<OrdenAyudaDiagnostica> GetByOrden(int idOrden) {
            var lista = new List<OrdenAyudaDiagnostica>();
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM OrdenAyudaDiagnostica WHERE idOrden=@idOrden";
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

        private static OrdenAyudaDiagnostica Mapear(SqlDataReader reader) {
            return new OrdenAyudaDiagnostica {
                IdOrdenAyuda = (int)reader["idOrdenAyuda"],
                IdOrden = (int)reader["idOrden"],
                NumeroItem = (int)reader["numeroItem"],
                IdAyuda = (int)reader["idAyuda"],
                NombreAyuda = reader["nombreAyuda"].ToString(),
                Cantidad = (int)reader["cantidad"],
                RequiereEspecialista = (bool)reader["requiereEspecialista"],
                IdEspecialidad = reader["idEspecialidad"] == DBNull.Value ? (int?)null : (int)reader["idEspecialidad"],
                CostoUnitario = (decimal)reader["costoUnitario"]
            };
        }
    }
}
