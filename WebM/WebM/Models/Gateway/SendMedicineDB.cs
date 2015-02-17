using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebM.Models;

namespace WebM.Models.Gateway
{
    public class SendMedicineDB
    {
        private SqlConnection aConnection;
        private SqlCommand aCommand;

        private string connectionString;
        public SendMedicineDB()
        {
            aConnection = new DatabaseConnectionGateway().DatabaseConnection(aConnection);
        }

        public int FindMedicineId(int medicineId)
        {
            string selectQuery = "SELECT * FROM CenterMedicines WHERE MedicineId=" + medicineId + ";";
            aConnection.Open();
            aCommand = new SqlCommand(selectQuery, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();

            int mId = 0;
            if (aReader.Read())
            {

                mId = Convert.ToInt32(aReader["MedicineId"].ToString());

            }

            aReader.Close();
            aConnection.Close();
            return mId;
        }

        public int FindCenterId(int centerId)
        {
            string selectQuery = "SELECT * FROM CenterMedicines WHERE CenterId=" + centerId + ";";
            aConnection.Open();
            aCommand = new SqlCommand(selectQuery, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();


            int cId = 0;
            if (aReader.Read())
            {

                cId = Convert.ToInt32(aReader["CenterId"].ToString());

            }

            aReader.Close();
            aConnection.Close();
            return cId;
        }

        public void UpdateData(CenterMedicine aCenterMedicine)
        {
            string selectQuery = "UPDATE CenterMedicines SET MedicineQuantity = " + aCenterMedicine.MedicineQuantity + "WHERE CenterId=" + aCenterMedicine.CenterId + "AND MedicineId=" + aCenterMedicine.MedicineId + ";";
            aConnection.Open();
            aCommand = new SqlCommand(selectQuery, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();

            aReader.Close();
            aConnection.Close();
            return;
        }

        public int FindQuantity(CenterMedicine aCenterMedicine)
        {
            string selectQuery = "SELECT * FROM CenterMedicines WHERE CenterId=" + aCenterMedicine.CenterId + " AND MedicineId=" + aCenterMedicine.MedicineId + ";";
            aConnection.Open();
            aCommand = new SqlCommand(selectQuery, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();


            int qId = 0;
            if (aReader.Read())
            {

                qId = Convert.ToInt32(aReader["MedicineQuantity"].ToString());

            }

            aReader.Close();
            aConnection.Close();
            return qId;
        }
    }
}