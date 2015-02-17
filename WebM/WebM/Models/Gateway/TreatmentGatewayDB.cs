using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebM.Models.Gateway
{
    public class TreatmentGatewayDB
    {
        private SqlConnection aConnection;
        private SqlCommand aCommand;

        private string connectionString;
        public TreatmentGatewayDB()
        {
            aConnection = new DatabaseConnectionGateway().DatabaseConnection(aConnection);
        }



        public void AddPrescription(Prescription aPrescription)
        {
            string insertCommandString = "INSERT INTO Prescriptions VALUES('" + aPrescription.Date + "','" + aPrescription.VoterId + "','" + aPrescription.Observation + "','" + aPrescription.Dose + "','" + aPrescription.BeforeAfter + "','" + aPrescription.QuantityGiven + "','" + aPrescription.Note + "','" + aPrescription.DiseaseId + "','" + aPrescription.PatientId + "','" + aPrescription.DoctorId + "','" + aPrescription.MedicineId + "');";
            aConnection.Open();
            aCommand = new SqlCommand(insertCommandString, aConnection);
            aCommand.ExecuteNonQuery();
            aConnection.Close();
            return;
        }
        public int GetDistrictId(int centerId)
        {
            string selectQuery = "SELECT District FROM Centers WHERE CenterId=" + centerId + ";";
            aConnection.Open();
            aCommand = new SqlCommand(selectQuery, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();
            string districtName = "";
            if (aReader.Read())
            {

                districtName = aReader["District"].ToString();

            }
            aReader.Close();
            aConnection.Close();




            string selectQueryi = "SELECT DistrictId FROM Districts WHERE Name = '" + districtName + "';";
            aConnection.Open();
            aCommand = new SqlCommand(selectQueryi, aConnection);
            SqlDataReader bReader = aCommand.ExecuteReader();
            int districtId = 0;
            if (bReader.Read())
            {

                districtId = Convert.ToInt32(bReader["DistrictId"].ToString());

            }
            bReader.Close();
            aConnection.Close();
            return districtId;
        }

        public void ReduceMedicineStock(int quantityGiven, int medicineId, int centerId)
        {
            string selectQuery = "SELECT MedicineQuantity FROM CenterMedicines WHERE CenterId=" + centerId + "AND MedicineId=" + medicineId + ";";
            aConnection.Open();
            aCommand = new SqlCommand(selectQuery, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();
            int medicineQuantity = 0;
            if (aReader.Read())
            {

                medicineQuantity = Convert.ToInt32(aReader["MedicineQuantity"].ToString());

            }
            aReader.Close();
            aConnection.Close();




            int newMedicineQuantity = medicineQuantity - quantityGiven;

            if (newMedicineQuantity>0)
            {
                string updateQuery = "UPDATE CenterMedicines SET MedicineQuantity = " + newMedicineQuantity + "  WHERE CenterId=" + centerId + "AND MedicineId=" + medicineId + ";";
                aConnection.Open();
                aCommand = new SqlCommand(updateQuery, aConnection);
                SqlDataReader cReader = aCommand.ExecuteReader();

                cReader.Close();
                aConnection.Close();  
            }






           
            return;
        }
    }
}