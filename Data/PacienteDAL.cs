using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicaIPS_U.Entities;
using System.Data.SqlClient;

namespace ClinicaIPS_U.Data {
    class PacienteDAL {
        private ConexionDB conexion = new ConexionDB();

        // CREATE
        public void InsertarPaciente(Paciente paciente) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "INSERT INTO Pacientes (Cedula, NombreCompleto, FechaNacimiento, Genero, Direccion, Telefono, Correo) " +
                               "VALUES (@Cedula, @Nombre, @Fecha, @Genero, @Direccion, @Telefono, @Correo)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Cedula", paciente.Cedula);
                cmd.Parameters.AddWithValue("@Nombre", paciente.NombreCompleto);
                cmd.Parameters.AddWithValue("@Fecha", paciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Genero", paciente.Genero);
                cmd.Parameters.AddWithValue("@Direccion", paciente.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@Correo", paciente.Correo);

                cmd.ExecuteNonQuery();
            }
        }

        // READ (ejemplo: obtener todos los pacientes)
        public List<Paciente> ObtenerPacientes() {
            List<Paciente> lista = new List<Paciente>();

            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "SELECT * FROM Pacientes";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    lista.Add(new Paciente {
                        IdPaciente = (int)reader["IdPaciente"],
                        Cedula = reader["Cedula"].ToString(),
                        NombreCompleto = reader["NombreCompleto"].ToString(),
                        FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                        Genero = reader["Genero"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Correo = reader["Correo"].ToString()
                    });
                }
            }
            return lista;
        }

        // UPDATE
        public void ActualizarPaciente(Paciente paciente) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "UPDATE Pacientes SET NombreCompleto=@Nombre, FechaNacimiento=@Fecha, Genero=@Genero, " +
                               "Direccion=@Direccion, Telefono=@Telefono, Correo=@Correo WHERE Cedula=@Cedula";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Cedula", paciente.Cedula);
                cmd.Parameters.AddWithValue("@Nombre", paciente.NombreCompleto);
                cmd.Parameters.AddWithValue("@Fecha", paciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Genero", paciente.Genero);
                cmd.Parameters.AddWithValue("@Direccion", paciente.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@Correo", paciente.Correo);

                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void EliminarPaciente(string cedula) {
            using (SqlConnection conn = conexion.GetConexion()) {
                conn.Open();
                string query = "DELETE FROM Pacientes WHERE Cedula=@Cedula";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Cedula", cedula);
                cmd.ExecuteNonQuery();
            }
        }
    }
}