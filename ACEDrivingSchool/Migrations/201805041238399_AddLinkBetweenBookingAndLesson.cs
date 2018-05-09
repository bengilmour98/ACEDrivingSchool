namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLinkBetweenBookingAndLesson : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.AspNetUsers");
            DropIndex("dbo.Bookings", new[] { "LessonId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropPrimaryKey("dbo.Bookings");
            AddColumn("dbo.Bookings", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Lessons", "BookingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "CustomerId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Bookings", "Id");
            CreateIndex("dbo.Bookings", "CustomerId");
            CreateIndex("dbo.Lessons", "BookingId");
            AddForeignKey("dbo.Lessons", "BookingId", "dbo.Bookings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "CustomerId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Bookings", "LessonId");
            DropColumn("dbo.Lessons", "Cost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Cost", c => c.Double(nullable: false));
            AddColumn("dbo.Bookings", "LessonId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Lessons", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Lessons", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropPrimaryKey("dbo.Bookings");
            AlterColumn("dbo.Bookings", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Lessons", "BookingId");
            DropColumn("dbo.Bookings", "Id");
            AddPrimaryKey("dbo.Bookings", new[] { "LessonId", "CustomerId" });
            CreateIndex("dbo.Bookings", "CustomerId");
            CreateIndex("dbo.Bookings", "LessonId");
            AddForeignKey("dbo.Bookings", "CustomerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "LessonId", "dbo.Lessons", "Id", cascadeDelete: true);
        }
    }
}
