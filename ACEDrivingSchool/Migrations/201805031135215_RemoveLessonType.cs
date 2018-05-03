namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveLessonType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "LessonTypeId", "dbo.LessonTypes");
            DropIndex("dbo.Lessons", new[] { "LessonTypeId" });
            DropColumn("dbo.Lessons", "LessonTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "LessonTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "LessonTypeId");
            AddForeignKey("dbo.Lessons", "LessonTypeId", "dbo.LessonTypes", "Id", cascadeDelete: true);
        }
    }
}
