using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ClinicaIPS_U.Data {
    class ConexionDB {
        /*private readonly string cadenaConexion = "Server=DESKTOP-2NRTOVAMSSQLSERVER01;Database=ClinicaIPS;Trusted_Connection=True;";*/
        private readonly string cadenaConexion = "Server=DESKTOP-2NRTOVA\\MSSQLSERVER01;Database=ClinicaIPS;Trusted_Connection=True;";
        public SqlConnection GetConexion() {
            return new SqlConnection(cadenaConexion);
        }
    }
}