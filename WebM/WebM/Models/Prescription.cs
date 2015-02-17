using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebM.Models;


namespace WebM.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        public DateTime Date { get; set; }
        public long VoterId { get; set; }
        public string Observation { get; set; }
        public string Dose { get; set; }
        public string BeforeAfter { get; set; }
        public int QuantityGiven { get; set; }
        public string Note { get; set; }
        public int DiseaseId { get; set; }
        public long PatientId { get; set; }
        public int DoctorId { get; set; }
        public int MedicineId { get; set; }



    }
}