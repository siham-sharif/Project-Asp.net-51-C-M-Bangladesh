using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebM.Models.Gateway;

namespace WebM.Models.GatewayDB
{
    public class MedicineGatewayDB
    {
        private SqlConnection aConnection;
        private SqlCommand aCommand;

        private string connectionString;
        public MedicineGatewayDB()
        {
            aConnection = new DatabaseConnectionGateway().DatabaseConnection(aConnection);
        }

        public string CheckUnique(string genericName, string quantity, string unitQuantity)
        {
            string selectQuery = "SELECT * FROM Medicines WHERE GenericName='" + genericName + "' AND Quantity =" + quantity + " AND QuantityUnit = '" + unitQuantity + "';";
            aConnection.Open();
            aCommand = new SqlCommand(selectQuery, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();
            aReader.Read();

            if (aReader.HasRows)
            {
                return "false";
            }
            aReader.Close();
            aConnection.Close();
            return "true";
        }
    }
}