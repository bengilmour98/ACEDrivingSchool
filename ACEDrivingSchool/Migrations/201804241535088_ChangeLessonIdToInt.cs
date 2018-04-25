namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLessonIdToInt : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Lessons");
            AlterColumn("dbo.Lessons", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Lessons", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Lessons");
            AlterColumn("dbo.Lessons", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Lessons", "Id");
        }
    }
}
