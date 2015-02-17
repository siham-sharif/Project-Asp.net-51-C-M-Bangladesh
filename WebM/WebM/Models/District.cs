using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebM.Models;
namespace WebM.Models
{
    public class District
    {
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public double Population { get; set; }


        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Thana> Thanas { get; set; }
    }
}