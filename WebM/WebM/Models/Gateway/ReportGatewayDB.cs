using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebM.Models.Gateway
{
    public class ReportGatewayDB
    {

        private SqlConnection aConnection;
        private SqlCommand aCommand;
        private string connectionString;

        private List<Report> reports = new List<Report>();
        private List<District> districts = new List<District>();
        private CenterGatewayDB db = new CenterGatewayDB();
        private List<MedicineStock> medicineStockslList = new List<MedicineStock>();


        public ReportGatewayDB()
        {
            aConnection = new DatabaseConnectionGateway().DatabaseConnection(aConnection);
        }



        public void Add(Prescription aPrescription)
        {
            string insertString = "INSERT INTO Prescriptions VALUES('" + aPrescription.Date + "','" + aPrescription.VoterId + "','" + aPrescription.Observation + "','" + aPrescription.Dose + "','" + aPrescription.BeforeAfter + "','" + aPrescription.QuantityGiven + "','" + aPrescription.Note + "','" + aPrescription.PatientId + "','" + aPrescription.DoctorId + "','" + aPrescription.DiseaseId + "','" + aPrescription.MedicineId + "');";
            aConnection.Open();
            aCommand = new SqlCommand(insertString, aConnection);
            aCommand.ExecuteNonQuery();
            aConnection.Close();
            return;
        }

        public List<Report> Search(string diseaseId, string dateOne, string dateTwo)
        {



            districts = db.Districts.ToList();

            int patientNumber = 0;
            int i = 0;

            foreach (District district in districts)
            {
                string selectQuery = "SELECT COUNT(DISTINCT(VoterId)) FROM Patients WHERE VoterId IN " +
                                         "(SELECT DISTINCT(VoterId) FROM Prescriptions " +
                                         "WHERE DiseaseId = " + diseaseId + " AND Date BETWEEN CONVERT(datetime,'" + dateOne + "')" +
                                        " AND CONVERT(datetime,'" + dateTwo + "')) " +
                                     "AND DistrictId = " + district.DistrictId + " ;";
                aConnection.Open();
                aCommand = new SqlCommand(selectQuery, aConnection);
                SqlDataReader aReader = aCommand.ExecuteReader();
                aReader.Read();

                if (aReader.HasRows)
                {
                    patientNumber = Convert.ToInt32(aReader[0].ToString());
                }
                aReader.Close();
                aConnection.Close();


                Report aReport = new Report();
                aReport.ReportId = ++i;
                aReport.DistrictId = district.DistrictId;
                aReport.TotalPatient = patientNumber;
                aReport.DistrictName = district.Name;
                aReport.AffectedPopulationPercentage = (patientNumber * 100) / Convert.ToDouble(district.Population);


                reports.Add(aReport);
            }
            return reports;
        }



        public List<long> SearchMapData(string diseaseId, string dateOne, string dateTwo)
        {

            long bar = 0, ctg = 0, dhk = 0, khu = 0, raj = 0, rang = 0, slt = 0;

            List<District> districts = new List<District>();
            List<Report> reportList = new List<Report>();
            List<long> TotalEffectedPeople = new List<long>();
            districts = db.Districts.ToList();

            int patientNumber = 0;

            foreach (District district in districts)
            {
                string selectQuery = "SELECT COUNT(DISTINCT(VoterId)) FROM Patients WHERE VoterId IN " +
                                         "(SELECT DISTINCT(VoterId) FROM Prescriptions " +
                                         "WHERE DiseaseId = " + diseaseId + " AND Date BETWEEN CONVERT(datetime,'" + dateOne + "')" +
                                        " AND CONVERT(datetime,'" + dateTwo + "')) " +
                                     "AND DistrictId = " + district.DistrictId + " ;";
                aConnection.Open();
                aCommand = new SqlCommand(selectQuery, aConnection);
                SqlDataReader aReader = aCommand.ExecuteReader();
                aReader.Read();

                if (aReader.HasRows)
                {
                    patientNumber = Convert.ToInt32(aReader[0].ToString());
                }
                aReader.Close();
                aConnection.Close();

                Report aReport = new Report();
                aReport.DistrictId = district.DistrictId;
                aReport.TotalPatient = patientNumber;
                aReport.DistrictName = district.Name;
                aReport.AffectedPopulationPercentage = (patientNumber * 100) / Convert.ToDouble(district.Population);
                reportList.Add(aReport);
            }
            aConnection.Open();

            foreach (Report aReport in reportList)
            {
                string selectQuery = string.Format("Select DivAndDis.DivisionId FROM DivAndDis WHERE DivAndDis.DistrictId = {0};", aReport.DistrictId);
                aCommand = new SqlCommand(selectQuery, aConnection);
                SqlDataReader anReader = aCommand.ExecuteReader();


                while (anReader.Read())
                {
                    int divisionId = (int)anReader["DivisionId"];


                    switch (divisionId)
                    {
                        case 1:
                            bar += aReport.TotalPatient;
                            break;
                        case 2:
                            ctg += aReport.TotalPatient;
                            break;
                        case 3:
                            dhk += aReport.TotalPatient;
                            break;
                        case 4:
                            khu += aReport.TotalPatient;
                            break;
                        case 5:
                            raj += aReport.TotalPatient;
                            break;
                        case 6:
                            rang += aReport.TotalPatient;
                            break;
                        case 7:
                            slt += aReport.TotalPatient;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                }
                anReader.Close();



            }
            TotalEffectedPeople.Add(bar);
            TotalEffectedPeople.Add(ctg);
            TotalEffectedPeople.Add(dhk);
            TotalEffectedPeople.Add(khu);
            TotalEffectedPeople.Add(raj);
            TotalEffectedPeople.Add(rang);
            TotalEffectedPeople.Add(slt);
            aConnection.Close();
            return TotalEffectedPeople;
        }
        public List<MedicineStock> GetMedicineStock(int centerId)
        {

            string selectQuery = "SELECT GenericName,MedicineQuantity FROM Medicines JOIN CenterMedicines ON Medicines.MedicineId = CenterMedicines.MedicineId WHERE CenterId = '" + centerId + "' ;";
            aConnection.Open();
            aCommand = new SqlCommand(selectQuery, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();

            while (aReader.Read())
            {
                MedicineStock aStock = new MedicineStock();

                aStock.MedicineName = aReader["GenericName"].ToString();
                aStock.MedicineQuantity = Convert.ToDouble(aReader["MedicineQuantity"].ToString());

                medicineStockslList.Add(aStock);
            }
            aReader.Close();
            aConnection.Close();

            return medicineStockslList;
        }
    }
}