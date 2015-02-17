using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebM.Models
{
    public class Doctor
    {

        public int DoctorId { get; set; }

        [Display(Name = "Doctor's Name")]
        public string Name { get; set; }

        [Display(Name = "Doctor's Degree")]
        public string Degree { get; set; }

        [Display(Name = "Doctor's Speciality")]
        public string Speciality { get; set; }

        public int CenterId { get; set; }



    }
}