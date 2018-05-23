namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestructureBookingTableAndLessonTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Lessons", new[] { "BookingId" });
            DropPrimaryKey("dbo.Bookings");
            AddColumn("dbo.Bookings", "LessonId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Customer_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Bookings", new[] { "LessonId", "CustomerId" });
            CreateIndex("dbo.Bookings", "LessonId");
            CreateIndex("dbo.Bookings", "Customer_Id");
            AddForeignKey("dbo.Bookings", "Customer_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Bookings", "LessonId", "dbo.Lessons", "Id", cascadeDelete: true);
            DropColumn("dbo.Bookings", "Id");
            DropColumn("dbo.Lessons", "BookingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "BookingId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Bookings", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Bookings", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bookings", new[] { "Customer_Id" });
            DropIndex("dbo.Bookings", new[] { "LessonId" });
            DropPrimaryKey("dbo.Bookings");
            DropColumn("dbo.Bookings", "Customer_Id");
            DropColumn("dbo.Bookings", "CustomerId");
            DropColumn("dbo.Bookings", "LessonId");
            AddPrimaryKey("dbo.Bookings", "Id");
            CreateIndex("dbo.Lessons", "BookingId");
            AddForeignKey("dbo.Lessons", "BookingId", "dbo.Bookings", "Id", cascadeDelete: true);
        }
    }
}
