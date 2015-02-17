namespace WebM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(),
                        DistrictId = c.Int(nullable: false),
                        TotalPatient = c.Int(nullable: false),
                        AffectedPopulationPercentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ReportId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reports");
        }
    }
}
