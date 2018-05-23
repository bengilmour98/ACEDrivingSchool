namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixLesson : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lessons", "DateTimeOfLesson", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lessons", "DateTimeOfLesson", c => c.DateTime(nullable: false));
        }
    }
}
