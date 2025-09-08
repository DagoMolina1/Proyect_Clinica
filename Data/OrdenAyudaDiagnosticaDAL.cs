using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Entities;
using System.Data.SqlClient;

namespace ClinicaIPS_U.Data {
    internal class OrdenAyudaDiagnosticaDAL {
        private ConexionDB conexion = new ConexionDB();

        // CREATE
        public void InsertarOrdenAyuda(OrdenAyudaDiagnostica ordenAyuda) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO OrdenAyudaDiagnostica (IdOrden, IdAyuda, Cantidad) 
                                 VALUES (@IdOrden, @IdAyuda, @Cantidad)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdOrden", ordenAyuda.IdOrden);
                cmd.Parameters.AddWithValue("@IdAyuda", ordenAyuda.IdAyuda);
                cmd.Parameters.AddWithValue("@Cantidad", ordenAyuda.Cantidad);
                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<OrdenAyudaDiagnostica> ObtenerOrdenesAyuda() {
            List<OrdenAyudaDiagnostica> lista = new List<OrdenAyudaDiagnostica>();

            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM OrdenAyudaDiagnostica";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    lista.Add(new OrdenAyudaDiagnostica {
                        IdOrdenAyuda = (int)reader["IdOrdenAyuda"],
                        IdOrden = (int)reader["IdOrden"],
                        IdAyuda = (int)reader["IdAyuda"],
                        Cantidad = (int)reader["Cantidad"]
                    });
                }
            }
            return lista;
        }

        // UPDATE
        public void ActualizarOrdenAyuda(OrdenAyudaDiagnostica ordenAyuda) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE OrdenAyudaDiagnostica 
                                 SET IdOrden=@IdOrden, IdAyuda=@IdAyuda, Cantidad=@Cantidad 
                                 WHERE IdOrdenAyuda=@IdOrdenAyuda";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdOrden", ordenAyuda.IdOrden);
                cmd.Parameters.AddWithValue("@IdAyuda", ordenAyuda.IdAyuda);
                cmd.Parameters.AddWithValue("@Cantidad", ordenAyuda.Cantidad);
                cmd.Parameters.AddWithValue("@IdOrdenAyuda", ordenAyuda.IdOrdenAyuda);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void EliminarOrdenAyuda(int id) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM OrdenAyudaDiagnostica WHERE IdOrdenAyuda=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}