namespace SMLApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorFeedBack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "DoctorFeedBack", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "DoctorFeedBack");
        }
    }
}
