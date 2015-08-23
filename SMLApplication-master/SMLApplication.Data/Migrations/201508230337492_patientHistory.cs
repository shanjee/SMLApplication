namespace SMLApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "PatientHistory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "PatientHistory");
        }
    }
}
