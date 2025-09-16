using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Entities;
using System.Data.SqlClient;

namespace ClinicaIPS_U.Data {
    internal class OrdenProcedimientoDAL {
        private ConexionDB conexion = new ConexionDB();

        // CREATE
        public void InsertarOrdenProcedimiento(OrdenProcedimiento ordenProc) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"INSERT INTO OrdenProcedimiento 
                                (IdOrden, IdProcedimiento, Repeticiones, Frecuencia) 
                                VALUES (@IdOrden, @IdProcedimiento, @Repeticiones, @Frecuencia)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdOrden", ordenProc.IdOrden);
                cmd.Parameters.AddWithValue("@IdProcedimiento", ordenProc.IdProcedimiento);
                cmd.Parameters.AddWithValue("@Repeticiones", ordenProc.Repeticiones);
                cmd.Parameters.AddWithValue("@Frecuencia", ordenProc.Frecuencia);

                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<OrdenProcedimiento> ObtenerOrdenProcedimientos() {
            List<OrdenProcedimiento> lista = new List<OrdenProcedimiento>();

            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM OrdenProcedimiento";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    lista.Add(new OrdenProcedimiento {
                        IdOrdenProcedimiento = (int)reader["IdOrdenProcedimiento"],
                        IdOrden = (int)reader["IdOrden"],
                        IdProcedimiento = (int)reader["IdProcedimiento"],
                        Repeticiones = (int)reader["Repeticiones"],
                        Frecuencia = reader["Frecuencia"].ToString()
                    });
                }
            }

            return lista;
        }

        // UPDATE
        public void ActualizarOrdenProcedimiento(OrdenProcedimiento ordenProc) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = @"UPDATE OrdenProcedimiento 
                                SET IdOrden=@IdOrden, 
                                    IdProcedimiento=@IdProcedimiento, 
                                    Repeticiones=@Repeticiones, 
                                    Frecuencia=@Frecuencia 
                                WHERE IdOrdenProcedimiento=@IdOrdenProcedimiento";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdOrden", ordenProc.IdOrden);
                cmd.Parameters.AddWithValue("@IdProcedimiento", ordenProc.IdProcedimiento);
                cmd.Parameters.AddWithValue("@Repeticiones", ordenProc.Repeticiones);
                cmd.Parameters.AddWithValue("@Frecuencia", ordenProc.Frecuencia);
                cmd.Parameters.AddWithValue("@IdOrdenProcedimiento", ordenProc.IdOrdenProcedimiento);

                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void EliminarOrdenProcedimiento(int id) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM OrdenProcedimiento WHERE IdOrdenProcedimiento=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}