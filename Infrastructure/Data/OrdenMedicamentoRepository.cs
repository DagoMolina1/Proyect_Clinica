using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaIPS_U.Infrastructure.Data {
    public class OrdenMedicamentoRepository : IOrdenMedicamentoRepository
    {
        private readonly ConexionDB conexion = new ConexionDB();

        public void Add(OrdenMedicamento orden)
        {
            using (var conn = conexion.GetConexion())
            {
                conn.Open();
                string query = @"INSERT INTO OrdenMedicamento (idOrden, idMedicamento, cantidad)
                                 VALUES (@idOrden, @idMedicamento, @cantidad)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idOrden", orden.IdOrden);
                    cmd.Parameters.AddWithValue("@idMedicamento", orden.IdMedicamento);
                    cmd.Parameters.AddWithValue("@cantidad", orden.Cantidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(OrdenMedicamento orden)
        {
            using (var conn = conexion.GetConexion())
            {
                conn.Open();
                string query = @"UPDATE OrdenMedicamento 
                                 SET idOrden=@idOrden, idMedicamento=@idMedicamento, cantidad=@cantidad
                                 WHERE idOrdenMedicamento=@idOrdenMedicamento";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idOrdenMedicamento", orden.IdOrdenMedicamento);
                    cmd.Parameters.AddWithValue("@idOrden", orden.IdOrden);
                    cmd.Parameters.AddWithValue("@idMedicamento", orden.IdMedicamento);
                    cmd.Parameters.AddWithValue("@cantidad", orden.Cantidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idOrdenMedicamento)
        {
            using (var conn = conexion.GetConexion())
            {
                conn.Open();
                string query = "DELETE FROM OrdenMedicamento WHERE idOrdenMedicamento=@id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idOrdenMedicamento);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public OrdenMedicamento GetById(int idOrdenMedicamento)
        {
            using (var conn = conexion.GetConexion())
            {
                conn.Open();
                string query = "SELECT * FROM OrdenMedicamento WHERE idOrdenMedicamento=@id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idOrdenMedicamento);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new OrdenMedicamento
                            {
                                IdOrdenMedicamento = (int)reader["idOrdenMedicamento"],
                                IdOrden = (int)reader["idOrden"],
                                IdMedicamento = (int)reader["idMedicamento"],
                                Cantidad = (int)reader["cantidad"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<OrdenMedicamento> GetByOrden(int idOrden)
        {
            var lista = new List<OrdenMedicamento>();
            using (var conn = conexion.GetConexion())
            {
                conn.Open();
                string query = "SELECT * FROM OrdenMedicamento WHERE idOrden=@idOrden";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idOrden", idOrden);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new OrdenMedicamento
                            {
                                IdOrdenMedicamento = (int)reader["idOrdenMedicamento"],
                                IdOrden = (int)reader["idOrden"],
                                IdMedicamento = (int)reader["idMedicamento"],
                                Cantidad = (int)reader["cantidad"]
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}