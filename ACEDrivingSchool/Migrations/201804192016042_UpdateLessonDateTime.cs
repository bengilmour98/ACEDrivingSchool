namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLessonDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lessons", "DateOfLesson", c => c.DateTime());
            AlterColumn("dbo.Lessons", "TimeOfLesson", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lessons", "TimeOfLesson", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Lessons", "DateOfLesson", c => c.DateTime(nullable: false));
        }
    }
}
