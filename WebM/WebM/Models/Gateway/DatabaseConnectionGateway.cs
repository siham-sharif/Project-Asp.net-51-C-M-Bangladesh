using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebM.Models.Gateway
{
    public class DatabaseConnectionGateway
    {
        private string connectionString;
        public SqlConnection DatabaseConnection(SqlConnection aConnection)
        {
            connectionString =
                "Server = .; Database = db_Community_Ban; Integrated Security = True;";

            aConnection = new SqlConnection(connectionString);
            return aConnection;
        }
    }
}