using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class OrdenProcedimientoRepository : IOrdenProcedimientoRepository
    {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(OrdenProcedimiento orden)
        {
            using (var conn = conexion.GetConexion())
            {
                conn.Open();
                string query = @"INSERT INTO OrdenProcedimiento (idOrden, idProcedimiento, repeticiones, frecuencia)
                                 VALUES (@idOrden, @idProcedimiento, @repeticiones, @frecuencia)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idOrden", orden.IdOrden);
                    cmd.Parameters.AddWithValue("@idProcedimiento", orden.IdProcedimiento);
                    cmd.Parameters.AddWithValue("@repeticiones", orden.Repeticiones);
                    cmd.Parameters.AddWithValue("@frecuencia", (object)orden.Frecuencia ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(OrdenProcedimiento orden)
        {
            using (var conn = conexion.GetConexion())
            {
                conn.Open();
                string query = @"UPDATE OrdenProcedimiento 
                                 SET idOrden=@idOrden, idProcedimiento=@idProcedimiento, repeticiones=@repeticiones, frecuencia=@frecuencia
                                 WHERE idOrdenProcedimiento=@idOrdenProcedimiento";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idOrdenProcedimiento", orden.IdOrdenProcedimiento);
                    cmd.Parameters.AddWithValue("@idOrden", orden.IdOrden);
                    cmd.Parameters.AddWithValue("@idProcedimiento", orden.IdProcedimiento);
                    cmd.Parameters.AddWithValue("@repeticiones", orden.Repeticiones);
                    cmd.Parameters.AddWithValue("@frecuencia", (object)orden.Frecuencia ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idOrdenProcedimiento)
        {
            using (var conn = conexion.GetConexion())
            {
                conn.Open();
                string query = "DELETE FROM OrdenProcedimiento WHERE idOrdenProcedimiento=@id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idOrdenProcedimiento);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public OrdenProcedimiento GetById(int idOrdenProcedimiento)
        {
            using (var conn = conexion.GetConexion())
            {
                conn.Open();
                string query = "SELECT * FROM OrdenProcedimiento WHERE idOrdenProcedimiento=@id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idOrdenProcedimiento);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new OrdenProcedimiento
                            {
                                IdOrdenProcedimiento = (int)reader["idOrdenProcedimiento"],
                                IdOrden = (int)reader["idOrden"],
                                IdProcedimiento = (int)reader["idProcedimiento"],
                                Repeticiones = (int)reader["repeticiones"],
                                Frecuencia = reader["frecuencia"]?.ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<OrdenProcedimiento> GetByOrden(int idOrden)
        {
            var lista = new List<OrdenProcedimiento>();
            using (var conn = conexion.GetConexion())
            {
                conn.Open();
                string query = "SELECT * FROM OrdenProcedimiento WHERE idOrden=@idOrden";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idOrden", idOrden);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new OrdenProcedimiento
                            {
                                IdOrdenProcedimiento = (int)reader["idOrdenProcedimiento"],
                                IdOrden = (int)reader["idOrden"],
                                IdProcedimiento = (int)reader["idProcedimiento"],
                                Repeticiones = (int)reader["repeticiones"],
                                Frecuencia = reader["frecuencia"]?.ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}