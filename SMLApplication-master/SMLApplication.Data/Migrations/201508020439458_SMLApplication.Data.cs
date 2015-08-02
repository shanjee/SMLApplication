namespace SMLApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMLApplicationData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Bookingdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Bookings", new[] { "PatientId" });
            DropIndex("dbo.Bookings", new[] { "DoctorId" });
            DropForeignKey("dbo.Bookings", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Bookings", "DoctorId", "dbo.Doctors");
            DropTable("dbo.Bookings");
        }
    }
}
