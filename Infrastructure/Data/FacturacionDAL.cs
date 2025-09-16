using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Entities;
using System.Data.SqlClient;

namespace ClinicaIPS_U.Data {
    internal class FacturacionDAL {
        private ConexionDB conexion = new ConexionDB();

        // CREATE
        public void InsertarFactura(Facturacion factura) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO Facturacion (Fecha, Copago, Total, IdPaciente, IdMedico, IdSeguro) 
                                 VALUES (@Fecha, @Copago, @Total, @IdPaciente, @IdMedico, @IdSeguro)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Fecha", factura.Fecha);
                cmd.Parameters.AddWithValue("@Copago", factura.Copago);
                cmd.Parameters.AddWithValue("@Total", factura.Total);
                cmd.Parameters.AddWithValue("@IdPaciente", factura.IdPaciente);
                cmd.Parameters.AddWithValue("@IdMedico", factura.IdMedico);

                if (factura.IdSeguro.HasValue)
                    cmd.Parameters.AddWithValue("@IdSeguro", factura.IdSeguro.Value);
                else
                    cmd.Parameters.AddWithValue("@IdSeguro", DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        // READ (traer todas las facturas)
        public List<Facturacion> ObtenerFacturas() {
            List<Facturacion> lista = new List<Facturacion>();

            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Facturacion";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    lista.Add(new Facturacion
                    {
                        IdFactura = (int)reader["IdFactura"],
                        Fecha = (DateTime)reader["Fecha"],
                        Copago = (decimal)reader["Copago"],
                        Total = (decimal)reader["Total"],
                        IdPaciente = (int)reader["IdPaciente"],
                        IdMedico = (int)reader["IdMedico"],
                        IdSeguro = reader["IdSeguro"] != DBNull.Value ? (int?)reader["IdSeguro"] : null
                    });
                }
            }

            return lista;
        }

        // UPDATE
        public void ActualizarFactura(Facturacion factura) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE Facturacion 
                                 SET Fecha=@Fecha, Copago=@Copago, Total=@Total, 
                                     IdPaciente=@IdPaciente, IdMedico=@IdMedico, IdSeguro=@IdSeguro
                                 WHERE IdFactura=@IdFactura";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdFactura", factura.IdFactura);
                cmd.Parameters.AddWithValue("@Fecha", factura.Fecha);
                cmd.Parameters.AddWithValue("@Copago", factura.Copago);
                cmd.Parameters.AddWithValue("@Total", factura.Total);
                cmd.Parameters.AddWithValue("@IdPaciente", factura.IdPaciente);
                cmd.Parameters.AddWithValue("@IdMedico", factura.IdMedico);

                if (factura.IdSeguro.HasValue)
                    cmd.Parameters.AddWithValue("@IdSeguro", factura.IdSeguro.Value);
                else
                    cmd.Parameters.AddWithValue("@IdSeguro", DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void EliminarFactura(int idFactura) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM Facturacion WHERE IdFactura=@IdFactura";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdFactura", idFactura);
                cmd.ExecuteNonQuery();
            }
        }
    }
}