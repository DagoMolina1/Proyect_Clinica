using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class AyudaDiagnosticaRepository : IAyudaDiagnosticaRepository {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(AyudaDiagnostica ayuda) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO AyudasDiagnosticas (nombre, costo) 
                                 VALUES (@nombre, @costo)";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@nombre", ayuda.Nombre);
                    cmd.Parameters.AddWithValue("@costo", ayuda.Costo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(AyudaDiagnostica ayuda) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE AyudasDiagnosticas 
                                 SET nombre=@nombre, costo=@costo
                                 WHERE idAyuda=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", ayuda.IdAyuda);
                    cmd.Parameters.AddWithValue("@nombre", ayuda.Nombre);
                    cmd.Parameters.AddWithValue("@costo", ayuda.Costo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idAyuda) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM AyudasDiagnosticas WHERE idAyuda=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", idAyuda);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AyudaDiagnostica GetById(int idAyuda) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM AyudasDiagnosticas WHERE idAyuda=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", idAyuda);
                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            return new AyudaDiagnostica {
                                IdAyuda = (int)reader["idAyuda"],
                                Nombre = reader["nombre"].ToString(),
                                Costo = (decimal)reader["costo"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<AyudaDiagnostica> GetAll() {
            var lista = new List<AyudaDiagnostica>();
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM AyudasDiagnosticas";
                using (var cmd = new SqlCommand(query, conn)) {
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            lista.Add(new AyudaDiagnostica {
                                IdAyuda = (int)reader["idAyuda"],
                                Nombre = reader["nombre"].ToString(),
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