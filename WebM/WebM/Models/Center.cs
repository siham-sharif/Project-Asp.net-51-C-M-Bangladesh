using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebM.Models;


namespace WebM.Models
{
    [Serializable]
    public class Center
    {

        public int CenterId { get; set; }


        [Display(Name = "Center Name")]
        public string Name { get; set; }


        [Display(Name = "Center Code")]
        public string Code { get; set; }
        [Display(Name = "Center Password")]
        public string Password { get; set; }

        [Display(Name = "District Name")]
        public string District { get; set; }

        [Display(Name = "Thana Name")]
        public string Thana { get; set; }



        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<CenterMedicine> CenterMedicines { get; set; }




    }
}