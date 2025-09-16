using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Entities;
using System.Data.SqlClient;

namespace ClinicaIPS_U.Data {
    class MedicamentoDAL {
        private ConexionDB conexion = new ConexionDB();

        // CREATE
        public void InsertarMedicamento(Medicamento medicamento) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "INSERT INTO Medicamentos (Nombre, Dosis, Costo) VALUES (@Nombre, @Dosis, @Costo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", medicamento.Nombre);
                cmd.Parameters.AddWithValue("@Dosis", medicamento.Dosis);
                cmd.Parameters.AddWithValue("@Costo", medicamento.Costo);
                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<Medicamento> ObtenerMedicamentos() {
            List<Medicamento> lista = new List<Medicamento>();

            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Medicamentos";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    lista.Add(new Medicamento {
                        IdMedicamento = (int)reader["IdMedicamento"],
                        Nombre = reader["Nombre"].ToString(),
                        Dosis = reader["Dosis"].ToString(),
                        Costo = (decimal)reader["Costo"]
                    });
                }
            }
            return lista;
        }

        // UPDATE
        public void ActualizarMedicamento(Medicamento medicamento) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "UPDATE Medicamentos SET Nombre=@Nombre, Dosis=@Dosis, Costo=@Costo WHERE IdMedicamento=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", medicamento.Nombre);
                cmd.Parameters.AddWithValue("@Dosis", medicamento.Dosis);
                cmd.Parameters.AddWithValue("@Costo", medicamento.Costo);
                cmd.Parameters.AddWithValue("@Id", medicamento.IdMedicamento);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void EliminarMedicamento(int id) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM Medicamentos WHERE IdMedicamento=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}