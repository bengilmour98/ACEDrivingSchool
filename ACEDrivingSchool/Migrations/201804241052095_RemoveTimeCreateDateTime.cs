namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTimeCreateDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "DateTimeOfLesson", c => c.DateTime(nullable: false));
            DropColumn("dbo.Lessons", "DateOfLesson");
            DropColumn("dbo.Lessons", "TimeOfLesson");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "TimeOfLesson", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lessons", "DateOfLesson", c => c.DateTime(nullable: false));
            DropColumn("dbo.Lessons", "DateTimeOfLesson");
        }
    }
}
