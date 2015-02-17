using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebM.Models;

namespace WebM.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Voter Id is required")]
        [Display(Name = "Patient's Voter Id")]
        public long VoterId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Patient's Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Patient's Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date Of Birth is required")]
        [Display(Name = "Patient's Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Display(Name = "Patient's Age")]
        public double Age { get; set; }

        public int CenterId { get; set; }

        public int ServiceCount { get; set; }


        public int DistrictId { get; set; }
        public virtual District District { get; set; }









        //[Required(ErrorMessage = "Contact Info is required")]
        //[Display(Name = "Patient's Contact Info")]
        //public string ContactInfo { get; set; }

        //[Required(ErrorMessage = "Gender is required")]
        //[Display(Name = "Patient's Gender")]
        //public string Gender { get; set; }
    }
}