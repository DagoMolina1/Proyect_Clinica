using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Entities;
using System.Data.SqlClient;

namespace ClinicaIPS_U.Data {
    class ProcedimientoDAL {
        private ConexionDB conexion = new ConexionDB();

        // CREATE
        public void InsertarProcedimiento(Procedimiento procedimiento) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "INSERT INTO Procedimientos (Nombre, Costo, RequiereEspecialista, IdEspecialidad) " +
                               "VALUES (@Nombre, @Costo, @RequiereEspecialista, @IdEspecialidad)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", procedimiento.Nombre);
                cmd.Parameters.AddWithValue("@Costo", procedimiento.Costo);
                cmd.Parameters.AddWithValue("@RequiereEspecialista", procedimiento.RequiereEspecialista);
                cmd.Parameters.AddWithValue("@IdEspecialidad", (object)procedimiento.IdEspecialidad ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<Procedimiento> ObtenerProcedimientos() {
            List<Procedimiento> lista = new List<Procedimiento>();

            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Procedimientos";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    lista.Add(new Procedimiento {
                        IdProcedimiento = (int)reader["IdProcedimiento"],
                        Nombre = reader["Nombre"].ToString(),
                        Costo = (decimal)reader["Costo"],
                        RequiereEspecialista = (bool)reader["RequiereEspecialista"],
                        IdEspecialidad = reader["IdEspecialidad"] != DBNull.Value ? (int?)reader["IdEspecialidad"] : null
                    });
                }
            }
            return lista;
        }

        // UPDATE
        public void ActualizarProcedimiento(Procedimiento procedimiento) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "UPDATE Procedimientos SET Nombre=@Nombre, Costo=@Costo, " +
                               "RequiereEspecialista=@RequiereEspecialista, IdEspecialidad=@IdEspecialidad " +
                               "WHERE IdProcedimiento=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", procedimiento.Nombre);
                cmd.Parameters.AddWithValue("@Costo", procedimiento.Costo);
                cmd.Parameters.AddWithValue("@RequiereEspecialista", procedimiento.RequiereEspecialista);
                cmd.Parameters.AddWithValue("@IdEspecialidad", (object)procedimiento.IdEspecialidad ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", procedimiento.IdProcedimiento);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void EliminarProcedimiento(int id) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM Procedimientos WHERE IdProcedimiento=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}