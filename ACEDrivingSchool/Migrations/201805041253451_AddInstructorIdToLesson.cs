namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstructorIdToLesson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "InstructorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "InstructorId");
        }
    }
}
