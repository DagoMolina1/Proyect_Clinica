using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Entities;
using System.Data.SqlClient;

namespace ClinicaIPS_U.Data {
    internal class AyudaDiagnosticaDAL {
        private ConexionDB conexion = new ConexionDB();

        // CREATE
        public void InsertarAyuda(AyudaDiagnostica ayuda) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "INSERT INTO AyudasDiagnosticas (Nombre, Costo) VALUES (@Nombre, @Costo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", ayuda.Nombre);
                cmd.Parameters.AddWithValue("@Costo", ayuda.Costo);
                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<AyudaDiagnostica> ObtenerAyudas() {
            List<AyudaDiagnostica> lista = new List<AyudaDiagnostica>();

            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM AyudasDiagnosticas";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    lista.Add(new AyudaDiagnostica {
                        IdAyuda = (int)reader["IdAyuda"],
                        Nombre = reader["Nombre"].ToString(),
                        Costo = (decimal)reader["Costo"]
                    });
                }
            }
            return lista;
        }

        // UPDATE
        public void ActualizarAyuda(AyudaDiagnostica ayuda) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "UPDATE AyudasDiagnosticas SET Nombre=@Nombre, Costo=@Costo WHERE IdAyuda=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", ayuda.Nombre);
                cmd.Parameters.AddWithValue("@Costo", ayuda.Costo);
                cmd.Parameters.AddWithValue("@Id", ayuda.IdAyuda);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void EliminarAyuda(int id) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM AyudasDiagnosticas WHERE IdAyuda=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}