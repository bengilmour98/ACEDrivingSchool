namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBookingTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Lessons", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropIndex("dbo.Lessons", new[] { "BookingId" });
            AddColumn("dbo.Lessons", "BookingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lessons", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Lessons", "BookingId");
            DropTable("dbo.Bookings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingDate = c.DateTime(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        CustomerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Lessons", "BookingId", c => c.Int(nullable: false));
            DropColumn("dbo.Lessons", "Price");
            DropColumn("dbo.Lessons", "BookingDate");
            CreateIndex("dbo.Lessons", "BookingId");
            CreateIndex("dbo.Bookings", "CustomerId");
            AddForeignKey("dbo.Lessons", "BookingId", "dbo.Bookings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "CustomerId", "dbo.AspNetUsers", "Id");
        }
    }
}
