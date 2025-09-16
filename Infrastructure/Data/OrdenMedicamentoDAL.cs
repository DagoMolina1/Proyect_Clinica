using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Entities;
using System.Data.SqlClient;

namespace ClinicaIPS_U.Data {
    internal class OrdenMedicamentoDAL {

        private ConexionDB conexion = new ConexionDB();

        // CREATE
        public void InsertarOrdenMedicamento(OrdenMedicamento ordenMedicamento) {
            using (SqlConnection conn = conexion.GetConexion())
            {
                conn.Open();
                string query = "INSERT INTO OrdenMedicamentos (IdOrden, IdMedicamento, Cantidad) " +
                               "VALUES (@IdOrden, @IdMedicamento, @Cantidad)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdOrden", ordenMedicamento.IdOrden);
                cmd.Parameters.AddWithValue("@IdMedicamento", ordenMedicamento.IdMedicamento);
                cmd.Parameters.AddWithValue("@Cantidad", ordenMedicamento.Cantidad);
                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<OrdenMedicamento> ObtenerOrdenMedicamentos() {
            List<OrdenMedicamento> lista = new List<OrdenMedicamento>();

            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM OrdenMedicamentos";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    lista.Add(new OrdenMedicamento {
                        IdOrdenMedicamento = (int)reader["IdOrdenMedicamento"],
                        IdOrden = (int)reader["IdOrden"],
                        IdMedicamento = (int)reader["IdMedicamento"],
                        Cantidad = (int)reader["Cantidad"]
                    });
                }
            }
            return lista;
        }

        // UPDATE
        public void ActualizarOrdenMedicamento(OrdenMedicamento ordenMedicamento) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "UPDATE OrdenMedicamentos SET IdOrden=@IdOrden, IdMedicamento=@IdMedicamento, Cantidad=@Cantidad " +
                               "WHERE IdOrdenMedicamento=@IdOrdenMedicamento";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdOrden", ordenMedicamento.IdOrden);
                cmd.Parameters.AddWithValue("@IdMedicamento", ordenMedicamento.IdMedicamento);
                cmd.Parameters.AddWithValue("@Cantidad", ordenMedicamento.Cantidad);
                cmd.Parameters.AddWithValue("@IdOrdenMedicamento", ordenMedicamento.IdOrdenMedicamento);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void EliminarOrdenMedicamento(int id) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM OrdenMedicamentos WHERE IdOrdenMedicamento=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}