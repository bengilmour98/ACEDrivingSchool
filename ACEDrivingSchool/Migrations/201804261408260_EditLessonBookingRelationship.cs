namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditLessonBookingRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "LessonId", "dbo.Lessons");
            DropIndex("dbo.Bookings", new[] { "LessonId" });
            AddColumn("dbo.Lessons", "BookingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "BookingId");
            AddForeignKey("dbo.Lessons", "BookingId", "dbo.Bookings", "Id", cascadeDelete: true);
            DropColumn("dbo.Bookings", "LessonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "LessonId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Lessons", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Lessons", new[] { "BookingId" });
            DropColumn("dbo.Lessons", "BookingId");
            CreateIndex("dbo.Bookings", "LessonId");
            AddForeignKey("dbo.Bookings", "LessonId", "dbo.Lessons", "Id", cascadeDelete: true);
        }
    }
}
