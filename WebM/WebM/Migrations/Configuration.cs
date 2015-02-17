using System.Collections.Generic;
using WebM.Models;

namespace WebM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebM.Models.CenterGatewayDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebM.Models.CenterGatewayDB context)
        {
//            List<District> DistrictList = new List<District>
//{
//new District() {Name="Dhaka", Population=797027},
//new District() {Name="Chittagong", Population=506932},
//new District() {Name="Barisal", Population=647019},
//new District() {Name="Jhalokati", Population=976144},
//new District() {Name="Patuakhali", Population=568449},
//new District() {Name="Pirojpur", Population=606721},
//new District() {Name="Bandarban", Population=852626},
//new District() {Name="Brahmanbaria", Population=913795},
//new District() {Name="Chandpur", Population=988814},
//new District() {Name="Bhola", Population=550629},
//new District() {Name="Comilla", Population=724027},
//new District() {Name="Cox's Bazar", Population=718677},
//new District() {Name="Feni District", Population=520642},
//new District() {Name="Khagrachhari", Population=708257},
//new District() {Name="Lakshmipur", Population=613709},
//new District() {Name="Noakhali", Population=844431},
//new District() {Name="Rangamati", Population=663414},
//new District() {Name="Barguna", Population=992509},
//new District() {Name="Faridpur", Population=582331},
//new District() {Name="Gazipur", Population=662829},
//new District() {Name="Gopalganj", Population=767057},
//new District() {Name="Jamalpur", Population=883897},
//new District() {Name="Kishoreganj", Population=737872},
//new District() {Name="Madaripur", Population=667090},
//new District() {Name="Manikganj", Population=581818},
//new District() {Name="Munshiganj", Population=609386},
//new District() {Name="Mymensingh", Population=963880},
//new District() {Name="Narayanganj", Population=802410},
//new District() {Name="Narsingdi", Population=731591},
//new District() {Name="Netrakona", Population=746026},
//new District() {Name="Rajbari", Population=969800},
//new District() {Name="Shariatpur", Population=564340},
//new District() {Name="Sherpur", Population=861451},
//new District() {Name="Tangail", Population=959856},
//new District() {Name="Bagerhat", Population=512273},
//new District() {Name="Chuadanga", Population=922982},
//new District() {Name="Jessore", Population=966252},
//new District() {Name="Jhenaidah", Population=572978},
//new District() {Name="Khulna", Population=514393},
//new District() {Name="Kushtia", Population=657210},
//new District() {Name="Magura", Population=739968},
//new District() {Name="Meherpur", Population=560572},
//new District() {Name="Narail", Population=845281},
//new District() {Name="Satkhira", Population=988230},
//new District() {Name="Bogra", Population=702400},
//new District() {Name="Joypurhat", Population=968108},
//new District() {Name="Naogaon", Population=722090},
//new District() {Name="Natore", Population=917706},
//new District() {Name="Chapainawabganj", Population=866237},
//new District() {Name="Pabna", Population=880276},
//new District() {Name="Rajshahi", Population=728889},
//new District() {Name="Sirajganj", Population=803354},
//new District() {Name="Dinajpur", Population=698883},
//new District() {Name="Gaibandha", Population=558230},
//new District() {Name="Kurigram", Population=839577},
//new District() {Name="Lalmonirhat", Population=913129},
//new District() {Name="Nilphamari", Population=769060},
//new District() {Name="Panchagarh", Population=979929},
//new District() {Name="Rangpur", Population=894326},
//new District() {Name="Thakurgaon", Population=959062},
//new District() {Name="Habiganj", Population=642841},
//new District() {Name="Moulvibazar", Population=550216},
//new District() {Name="Sunamganj", Population=682204},
//new District() {Name="Sylhet", Population=742788}
//};
//            DistrictList.ForEach(s => context.Districts.AddOrUpdate(s));
//            List<Thana> ThanaList = new List<Thana>
//{
//new Thana() { Name ="Adabor", DistrictId=1},
//new Thana() { Name ="Badda", DistrictId=1},
//new Thana() { Name ="Bangsal", DistrictId=1},
//new Thana() { Name ="Cantonment", DistrictId=1},
//new Thana() { Name ="Chowkbazar", DistrictId=1},
//new Thana() { Name ="Pahartali", DistrictId=2},
//new Thana() { Name ="Panchlaish", DistrictId=2},
//new Thana() { Name ="Chandgaon", DistrictId=2},
//new Thana() { Name ="Bandar", DistrictId=2},
//new Thana() { Name ="Patenga", DistrictId=2},
//new Thana() { Name ="Khulshi", DistrictId=2},
//new Thana() { Name ="Muladi", DistrictId=3},
//new Thana() { Name ="Babuganj", DistrictId=3},
//new Thana() { Name ="Agailjhara", DistrictId=3},
//new Thana() { Name ="Bakerganj", DistrictId=3},
//new Thana() { Name ="Banaripara", DistrictId=3},
//new Thana() { Name ="Gaurnadi", DistrictId=3},
//new Thana() { Name ="Hizla", DistrictId=3},
//new Thana() { Name ="Mehendiganj", DistrictId=3}
//};
//            ThanaList.ForEach(s => context.Thanas.AddOrUpdate(s));
//            List<Disease> DiseaseList = new List<Disease>
//{
//new Disease() { Name ="Dengue Fever",Description = "Belly piain",PreferredDrugs= "Saline",TreatmentProcedure = "Take rest"},
//new Disease() { Name ="Malaria",Description = "Belly piain",PreferredDrugs = "Saline",TreatmentProcedure = "Take rest"},
//new Disease() { Name ="Tuberculosis",Description = "Belly piain",PreferredDrugs= "Saline",TreatmentProcedure = "Take rest"},
//new Disease() { Name ="Leprosy",Description = "Belly piain",PreferredDrugs = "Saline",TreatmentProcedure = "Take rest"},
//new Disease() { Name ="SARS",Description = "Belly piain",PreferredDrugs = "Saline",TreatmentProcedure = "Take rest"},
//new Disease() { Name ="Filariasis",Description = "Belly piain",PreferredDrugs ="Saline",TreatmentProcedure = "Take rest"}
//};
//            DiseaseList.ForEach(s => context.Diseases.AddOrUpdate(s));
//            List<Medicine> MedicineList = new List<Medicine>
//{
//new Medicine() { GenericName = "Napa Xtra",Quantity = 500,QuantityUnit = "mg"},
//new Medicine() { GenericName = "Metril",Quantity = 400,QuantityUnit = "mg"},
//new Medicine() { GenericName = "Oral Saline",Quantity = 500,QuantityUnit = "ml"},
//new Medicine() { GenericName = "Chiprosine",Quantity = 500,QuantityUnit = "mg"},
//new Medicine() { GenericName = "Antacid",Quantity = 30,QuantityUnit = "mg"}
//};
//            MedicineList.ForEach(s => context.Medicines.AddOrUpdate(s));
//            context.SaveChanges();
        }
    }
}
