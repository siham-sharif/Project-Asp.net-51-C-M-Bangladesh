using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebM.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        [Display(Name = "District Name")]
        public string DistrictName { get; set; }
        public int DistrictId { get; set; }
        [Display(Name = "Total Patient")]
        public int TotalPatient { get; set; }
        [Display(Name = "Affected Population Percentage")]
        public double AffectedPopulationPercentage { get; set; }
    }
}