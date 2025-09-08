using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Entities;
using System.Data.SqlClient;

namespace ClinicaIPS_U.Data {
    internal class OrdenDAL {
        private ConexionDB conexion = new ConexionDB();

        // CREATE
        public void InsertarOrden(Orden orden) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "INSERT INTO Ordenes (FechaCreacion, IdPaciente, IdMedico) " +
                               "VALUES (@FechaCreacion, @IdPaciente, @IdMedico)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FechaCreacion", orden.FechaCreacion);
                cmd.Parameters.AddWithValue("@IdPaciente", orden.IdPaciente);
                cmd.Parameters.AddWithValue("@IdMedico", orden.IdMedico);
                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<Orden> ObtenerOrdenes() {
            List<Orden> lista = new List<Orden>();

            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Ordenes";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    lista.Add(new Orden {
                        IdOrden = (int)reader["IdOrden"],
                        FechaCreacion = (DateTime)reader["FechaCreacion"],
                        IdPaciente = (int)reader["IdPaciente"],
                        IdMedico = (int)reader["IdMedico"]
                    });
                }
            }
            return lista;
        }

        // UPDATE
        public void ActualizarOrden(Orden orden) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "UPDATE Ordenes SET FechaCreacion=@Fecha, IdPaciente=@IdPaciente, IdMedico=@IdMedico " +
                               "WHERE IdOrden=@IdOrden";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Fecha", orden.FechaCreacion);
                cmd.Parameters.AddWithValue("@IdPaciente", orden.IdPaciente);
                cmd.Parameters.AddWithValue("@IdMedico", orden.IdMedico);
                cmd.Parameters.AddWithValue("@IdOrden", orden.IdOrden);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void EliminarOrden(int id) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM Ordenes WHERE IdOrden=@IdOrden";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdOrden", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}