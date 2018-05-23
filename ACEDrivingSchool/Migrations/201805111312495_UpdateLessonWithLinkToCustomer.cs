namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLessonWithLinkToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "CustomerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Lessons", "CustomerId");
            AddForeignKey("dbo.Lessons", "CustomerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "CustomerId", "dbo.AspNetUsers");
            DropIndex("dbo.Lessons", new[] { "CustomerId" });
            DropColumn("dbo.Lessons", "CustomerId");
        }
    }
}
