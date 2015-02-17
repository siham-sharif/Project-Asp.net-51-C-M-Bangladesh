using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebM.Controllers;

namespace WebM.Models.Gateway
{
    public class ChartDataGateWay
    {


        public List<ChartData> GetAllData(string DistrictId, string dateOne, string dateTwo)
        {
            string conString = ConfigurationManager.ConnectionStrings["CommunityMedicineBangladesh"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = conString;

            string query1 = String.Format("SELECT DiseaseId,COUNT(VoterId) as EffectedPeople FROM Prescriptions " +
                                          "WHERE Prescriptions.VoterId IN " +
                                          "(SELECT VoterId FROM Patients WHERE VoterId IN " +
                                          "(SELECT VoterId FROM Prescriptions WHERE Date BETWEEN" +
                                          " CONVERT(datetime,'" + dateOne + "')  AND CONVERT(datetime,'" + dateTwo + "')) " +
                                          "AND DistrictId = " + DistrictId + ") GROUP BY DiseaseId ;");
            
            sqlConnection.Open();
            SqlCommand aCommand = new SqlCommand(query1, sqlConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();
            List<ChartData> chartDatas = new List<ChartData>();
            while (aReader.Read())
            {
                ChartData aChartData = new ChartData();
                aChartData.DiseaseId = (int) aReader["DiseaseId"];
                aChartData.EffectedPeople = (int)aReader["EffectedPeople"];
                chartDatas.Add(aChartData);
            }
            aReader.Close();
            sqlConnection.Close();

            sqlConnection.Open();
            List<ChartData> chartList = new List<ChartData>();
            foreach (ChartData aChartData in chartDatas)
            {
                string query2 = String.Format("SELECT Name from Diseases where DiseaseId = {0};",aChartData.DiseaseId);
                SqlCommand anCommand = new SqlCommand(query2, sqlConnection);
                SqlDataReader anReader = anCommand.ExecuteReader();
                while (anReader.Read())
                {
                    ChartData anotherChartData = new ChartData();
                    anotherChartData.DiseaseId = aChartData.DiseaseId;
                    anotherChartData.EffectedPeople = aChartData.EffectedPeople;
                    anotherChartData.DiseaseName = anReader["Name"].ToString();
                    chartList.Add(anotherChartData);
                }

                anReader.Close();
            }
            
            sqlConnection.Close();
            return chartList;
        }
    }
}