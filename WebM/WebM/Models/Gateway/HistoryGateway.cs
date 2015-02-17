using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebM.Models.Gateway
{
    public class HistoryGateway
    {
        private SqlConnection aConnection;
        private SqlCommand aCommand;

        private string connectionString;
        public HistoryGateway()
        {
            aConnection = new DatabaseConnectionGateway().DatabaseConnection(aConnection);
        }

        

        public List<PatientHistory> GetAllPatientHistories(long voterId)
        {
            string selectQuery = String.Format("SELECT Centers.Name ,Centers.Code  FROM Centers " +
                                               "INNER JOIN Patients ON Centers.CenterId=Patients.CenterId " +
                                               "where Patients.VoterId = '{0}'",voterId);
            aConnection.Open();
            aCommand = new SqlCommand(selectQuery, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();
            List<PatientHistory> patientHistorieList = new List<PatientHistory>();
            while (aReader.Read())
            {
                PatientHistory aPatientHistory = new PatientHistory();
                aPatientHistory.CenterName = aReader["Name"].ToString();
                aPatientHistory.CenterName = aReader["Code"].ToString();
                patientHistorieList.Add(aPatientHistory);
            }

            aReader.Close();
            aConnection.Close();
            return patientHistorieList;
            
        }
    }
}