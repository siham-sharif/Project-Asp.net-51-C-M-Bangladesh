using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebM.Models
{
    [Serializable]
    public class MedicineStock
    {
        public string MedicineName { get; set; }
        public double  MedicineQuantity { get; set; }
    }
}