using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class OrdenAyudaDiagnosticaRepository : IOrdenAyudaDiagnosticaRepository {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(OrdenAyudaDiagnostica ordenAyuda) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO OrdenAyudaDiagnostica (idOrden, idAyuda, cantidad)
                                 VALUES (@idOrden, @idAyuda, @cantidad)";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idOrden", ordenAyuda.IdOrden);
                    cmd.Parameters.AddWithValue("@idAyuda", ordenAyuda.IdAyuda);
                    cmd.Parameters.AddWithValue("@cantidad", ordenAyuda.Cantidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(OrdenAyudaDiagnostica ordenAyuda) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE OrdenAyudaDiagnostica 
                                 SET idOrden=@idOrden, idAyuda=@idAyuda, cantidad=@cantidad
                                 WHERE idOrdenAyuda=@idOrdenAyuda";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idOrdenAyuda", ordenAyuda.IdOrdenAyuda);
                    cmd.Parameters.AddWithValue("@idOrden", ordenAyuda.IdOrden);
                    cmd.Parameters.AddWithValue("@idAyuda", ordenAyuda.IdAyuda);
                    cmd.Parameters.AddWithValue("@cantidad", ordenAyuda.Cantidad);
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
                            return new OrdenAyudaDiagnostica {
                                IdOrdenAyuda = (int)reader["idOrdenAyuda"],
                                IdOrden = (int)reader["idOrden"],
                                IdAyuda = (int)reader["idAyuda"],
                                Cantidad = (int)reader["cantidad"]
                            };
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
                            lista.Add(new OrdenAyudaDiagnostica {
                                IdOrdenAyuda = (int)reader["idOrdenAyuda"],
                                IdOrden = (int)reader["idOrden"],
                                IdAyuda = (int)reader["idAyuda"],
                                Cantidad = (int)reader["cantidad"]
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}