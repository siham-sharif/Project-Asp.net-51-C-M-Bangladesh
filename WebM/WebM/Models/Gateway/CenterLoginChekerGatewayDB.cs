using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebM.Models.Gateway
{
    public class CenterLoginChekerGatewayDB
    {
        private SqlConnection aConnection;
        private SqlCommand aCommand;
        private string connectionString;
        public CenterLoginChekerGatewayDB()
        {
            aConnection = new DatabaseConnectionGateway().DatabaseConnection(aConnection);
        }
        public Center LoginCheck(string centerCode, string centerPassword)
        {
            Center aCenter = new Center();
            //string selectQuery = String.Format("SELECT Code, Password, CenterId" +
            //"FROM Centers " +
            //"WHERE Code = '{0}' AND Password = '{1}'"
            //, centerCode, centerPassword);

            string selectQuery = "SELECT Code, Password, CenterId FROM Centers WHERE Code = '"+centerCode+"' AND Password = '"+centerPassword+"';";

            aConnection.Open();
            aCommand = new SqlCommand(selectQuery, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();
            while (aReader.Read())
            {
                aCenter.Name = aReader["Code"].ToString();
                aCenter.Password = aReader["Password"].ToString();
                aCenter.CenterId = Convert.ToInt32(aReader["CenterId"].ToString());
            }
            aReader.Close();
            aConnection.Close();
            return aCenter;
        }

    }
}