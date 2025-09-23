using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class FacturacionRepository : IFacturacionRepository {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(Facturacion factura) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO Facturacion (fecha, copago, total, idPaciente, idMedico, idSeguro)
                                 VALUES (@fecha, @copago, @total, @idPaciente, @idMedico, @idSeguro)";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@fecha", factura.Fecha);
                    cmd.Parameters.AddWithValue("@copago", factura.Copago);
                    cmd.Parameters.AddWithValue("@total", factura.Total);
                    cmd.Parameters.AddWithValue("@idPaciente", factura.IdPaciente);
                    cmd.Parameters.AddWithValue("@idMedico", factura.IdMedico);
                    cmd.Parameters.AddWithValue("@idSeguro", (object)factura.IdSeguro ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Facturacion factura) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE Facturacion 
                                 SET fecha=@fecha, copago=@copago, total=@total, 
                                     idPaciente=@idPaciente, idMedico=@idMedico, idSeguro=@idSeguro
                                 WHERE idFactura=@idFactura";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idFactura", factura.IdFactura);
                    cmd.Parameters.AddWithValue("@fecha", factura.Fecha);
                    cmd.Parameters.AddWithValue("@copago", factura.Copago);
                    cmd.Parameters.AddWithValue("@total", factura.Total);
                    cmd.Parameters.AddWithValue("@idPaciente", factura.IdPaciente);
                    cmd.Parameters.AddWithValue("@idMedico", factura.IdMedico);
                    cmd.Parameters.AddWithValue("@idSeguro", (object)factura.IdSeguro ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idFactura) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM Facturacion WHERE idFactura=@idFactura";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Facturacion GetById(int idFactura) {
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Facturacion WHERE idFactura=@idFactura";
                using (var cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);
                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            return new Facturacion {
                                IdFactura = (int)reader["idFactura"],
                                Fecha = (DateTime)reader["fecha"],
                                Copago = (decimal)reader["copago"],
                                Total = (decimal)reader["total"],
                                IdPaciente = (int)reader["idPaciente"],
                                IdMedico = (int)reader["idMedico"],
                                IdSeguro = reader["idSeguro"] == DBNull.Value ? (int?)null : (int)reader["idSeguro"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Facturacion> GetAll() {
            var lista = new List<Facturacion>();
            using (var conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Facturacion";
                using (var cmd = new SqlCommand(query, conn)) {
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            lista.Add(new Facturacion {
                                IdFactura = (int)reader["idFactura"],
                                Fecha = (DateTime)reader["fecha"],
                                Copago = (decimal)reader["copago"],
                                Total = (decimal)reader["total"],
                                IdPaciente = (int)reader["idPaciente"],
                                IdMedico = (int)reader["idMedico"],
                                IdSeguro = reader["idSeguro"] == DBNull.Value ? (int?)null : (int)reader["idSeguro"]
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}