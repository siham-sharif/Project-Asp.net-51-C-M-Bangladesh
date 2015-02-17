using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebM.Models;

namespace WebM.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string GenericName { get; set; }
        public double Quantity { get; set; }
        public string QuantityUnit { get; set; }



        public virtual ICollection<CenterMedicine> CenterMedicines { get; set; }
       



    }
}