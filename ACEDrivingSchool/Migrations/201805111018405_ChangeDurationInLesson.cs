namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDurationInLesson : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lessons", "Duration", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lessons", "Duration", c => c.Int(nullable: false));
        }
    }
}
