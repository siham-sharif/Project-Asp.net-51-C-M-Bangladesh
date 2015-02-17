using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebM.Models;



namespace WebM.Models
{
    public class CenterMedicine
    {
        public int CenterMedicineId { get; set; }
        public double MedicineQuantity { get; set; }

     

        public virtual Center Center { get; set; }
        public int CenterId { get; set; }
        public virtual Medicine Medicine { get; set; }
        public int MedicineId { get; set; }
    }
}