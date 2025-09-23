using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class ProcedimientoRepository : IProcedimientoRepository {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(Procedimiento procedimiento) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO Procedimientos (nombre, costo, requiereEspecialista, idEspecialidad) 
                                 VALUES (@nombre, @costo, @requiere, @idEsp)";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@nombre", procedimiento.Nombre);
                    cmd.Parameters.AddWithValue("@costo", procedimiento.Costo);
                    cmd.Parameters.AddWithValue("@requiere", procedimiento.RequiereEspecialista);
                    cmd.Parameters.AddWithValue("@idEsp", (object)procedimiento.IdEspecialidad ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Procedimiento procedimiento) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE Procedimientos 
                                 SET nombre=@nombre, costo=@costo, requiereEspecialista=@requiere, idEspecialidad=@idEsp
                                 WHERE idProcedimiento=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", procedimiento.IdProcedimiento);
                    cmd.Parameters.AddWithValue("@nombre", procedimiento.Nombre);
                    cmd.Parameters.AddWithValue("@costo", procedimiento.Costo);
                    cmd.Parameters.AddWithValue("@requiere", procedimiento.RequiereEspecialista);
                    cmd.Parameters.AddWithValue("@idEsp", (object)procedimiento.IdEspecialidad ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idProcedimiento) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM Procedimientos WHERE idProcedimiento=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", idProcedimiento);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Procedimiento GetById(int idProcedimiento) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Procedimientos WHERE idProcedimiento=@id";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@id", idProcedimiento);
                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            return new Procedimiento {
                                IdProcedimiento = (int)reader["idProcedimiento"],
                                Nombre = reader["nombre"].ToString(),
                                Costo = (decimal)reader["costo"],
                                RequiereEspecialista = (bool)reader["requiereEspecialista"],
                                IdEspecialidad = reader["idEspecialidad"] == DBNull.Value ? (int?)null : (int)reader["idEspecialidad"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Procedimiento> GetAll() {
            var lista = new List<Procedimiento>();
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Procedimientos";
                using (var cmd = new SqlCommand(query, conn)) {
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            lista.Add(new Procedimiento {
                                IdProcedimiento = (int)reader["idProcedimiento"],
                                Nombre = reader["nombre"].ToString(),
                                Costo = (decimal)reader["costo"],
                                RequiereEspecialista = (bool)reader["requiereEspecialista"],
                                IdEspecialidad = reader["idEspecialidad"] == DBNull.Value ? (int?)null : (int)reader["idEspecialidad"]
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}