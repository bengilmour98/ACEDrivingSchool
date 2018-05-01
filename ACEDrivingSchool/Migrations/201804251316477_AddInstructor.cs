namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstructor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "TransmissionType", c => c.String());
            AddColumn("dbo.AspNetUsers", "NumberOfStudents", c => c.Int());
            AddColumn("dbo.Lessons", "InstructorId", c => c.Int(nullable: false));
            AddColumn("dbo.Lessons", "Instructors_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Lessons", "Instructors_Id");
            AddForeignKey("dbo.Lessons", "Instructors_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "Instructors_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Lessons", new[] { "Instructors_Id" });
            DropColumn("dbo.Lessons", "Instructors_Id");
            DropColumn("dbo.Lessons", "InstructorId");
            DropColumn("dbo.AspNetUsers", "NumberOfStudents");
            DropColumn("dbo.AspNetUsers", "TransmissionType");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
