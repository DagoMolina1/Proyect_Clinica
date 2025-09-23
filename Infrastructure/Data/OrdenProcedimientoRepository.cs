using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class OrdenProcedimientoRepository : IOrdenProcedimientoRepository {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(OrdenProcedimiento orden) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO OrdenProcedimiento (idOrden, numeroItem, idProcedimiento, nombreProcedimiento, veces, frecuencia, requiereEspecialista, idEspecialidad, costoUnitario)
                                 VALUES (@idOrden, @numeroItem, @idProcedimiento, @nombre, @veces, @frecuencia, @requiereEspecialista, @idEspecialidad, @costo)";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idOrden", orden.IdOrden);
                    cmd.Parameters.AddWithValue("@numeroItem", orden.NumeroItem);
                    cmd.Parameters.AddWithValue("@idProcedimiento", orden.IdProcedimiento);
                    cmd.Parameters.AddWithValue("@nombre", orden.NombreProcedimiento);
                    cmd.Parameters.AddWithValue("@veces", orden.Veces);
                    cmd.Parameters.AddWithValue("@frecuencia", orden.Frecuencia ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@requiereEspecialista", orden.RequiereEspecialista);
                    cmd.Parameters.AddWithValue("@idEspecialidad", (object)orden.IdEspecialidad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@costo", orden.CostoUnitario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(OrdenProcedimiento orden) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE OrdenProcedimiento
                                 SET idOrden=@idOrden, numeroItem=@numeroItem, idProcedimiento=@idProcedimiento, nombreProcedimiento=@nombre,
                                     veces=@veces, frecuencia=@frecuencia, requiereEspecialista=@requiereEspecialista, idEspecialidad=@idEspecialidad, costoUnitario=@costo
                                 WHERE idOrdenProcedimiento=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", orden.IdOrdenProcedimiento);
                    cmd.Parameters.AddWithValue("@idOrden", orden.IdOrden);
                    cmd.Parameters.AddWithValue("@numeroItem", orden.NumeroItem);
                    cmd.Parameters.AddWithValue("@idProcedimiento", orden.IdProcedimiento);
                    cmd.Parameters.AddWithValue("@nombre", orden.NombreProcedimiento);
                    cmd.Parameters.AddWithValue("@veces", orden.Veces);
                    cmd.Parameters.AddWithValue("@frecuencia", orden.Frecuencia ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@requiereEspecialista", orden.RequiereEspecialista);
                    cmd.Parameters.AddWithValue("@idEspecialidad", (object)orden.IdEspecialidad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@costo", orden.CostoUnitario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idOrdenProcedimiento) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM OrdenProcedimiento WHERE idOrdenProcedimiento=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", idOrdenProcedimiento);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public OrdenProcedimiento GetById(int idOrdenProcedimiento) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM OrdenProcedimiento WHERE idOrdenProcedimiento=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", idOrdenProcedimiento);
                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            return Mapear(reader);
                        }
                    }
                }
            }
            return null;
        }

        public List<OrdenProcedimiento> GetByOrden(int idOrden) {
            var lista = new List<OrdenProcedimiento>();
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM OrdenProcedimiento WHERE idOrden=@idOrden";
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

        private static OrdenProcedimiento Mapear(SqlDataReader reader) {
            return new OrdenProcedimiento {
                IdOrdenProcedimiento = (int)reader["idOrdenProcedimiento"],
                IdOrden = (int)reader["idOrden"],
                NumeroItem = (int)reader["numeroItem"],
                IdProcedimiento = (int)reader["idProcedimiento"],
                NombreProcedimiento = reader["nombreProcedimiento"].ToString(),
                Veces = (int)reader["veces"],
                Frecuencia = reader["frecuencia"]?.ToString(),
                RequiereEspecialista = (bool)reader["requiereEspecialista"],
                IdEspecialidad = reader["idEspecialidad"] == DBNull.Value ? (int?)null : (int)reader["idEspecialidad"],
                CostoUnitario = (decimal)reader["costoUnitario"]
            };
        }
    }
}
