namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveInstructorFromLesson : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "Instructors_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Lessons", new[] { "Instructors_Id" });
            DropColumn("dbo.Lessons", "InstructorId");
            DropColumn("dbo.Lessons", "Instructors_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Instructors_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Lessons", "InstructorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "Instructors_Id");
            AddForeignKey("dbo.Lessons", "Instructors_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
