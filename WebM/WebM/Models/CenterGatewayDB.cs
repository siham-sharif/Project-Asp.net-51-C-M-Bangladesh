using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using WebM.Models;


namespace WebM.Models
{
    public class CenterGatewayDB : DbContext
    {
        public CenterGatewayDB()
            : base("CommunityMedicineBangladesh")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Thana> Thanas { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<CenterMedicine> CenterMedicines { get; set; }

        public DbSet<Report> Reports { get; set; }





    }
}