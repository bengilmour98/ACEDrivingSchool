namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingByteIssuesForLesson : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "Durations_Id", "dbo.Durations");
            DropForeignKey("dbo.Lessons", "LessonTypes_Id", "dbo.LessonTypes");
            DropIndex("dbo.Lessons", new[] { "Durations_Id" });
            DropIndex("dbo.Lessons", new[] { "LessonTypes_Id" });
            DropColumn("dbo.Lessons", "DurationId");
            DropColumn("dbo.Lessons", "LessonTypeId");
            RenameColumn(table: "dbo.Lessons", name: "Durations_Id", newName: "DurationId");
            RenameColumn(table: "dbo.Lessons", name: "LessonTypes_Id", newName: "LessonTypeId");
            DropPrimaryKey("dbo.Durations");
            DropPrimaryKey("dbo.LessonTypes");
            AlterColumn("dbo.Durations", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Lessons", "DurationId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Lessons", "LessonTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.LessonTypes", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Durations", "Id");
            AddPrimaryKey("dbo.LessonTypes", "Id");
            CreateIndex("dbo.Lessons", "DurationId");
            CreateIndex("dbo.Lessons", "LessonTypeId");
            AddForeignKey("dbo.Lessons", "DurationId", "dbo.Durations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessons", "LessonTypeId", "dbo.LessonTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "LessonTypeId", "dbo.LessonTypes");
            DropForeignKey("dbo.Lessons", "DurationId", "dbo.Durations");
            DropIndex("dbo.Lessons", new[] { "LessonTypeId" });
            DropIndex("dbo.Lessons", new[] { "DurationId" });
            DropPrimaryKey("dbo.LessonTypes");
            DropPrimaryKey("dbo.Durations");
            AlterColumn("dbo.LessonTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Lessons", "LessonTypeId", c => c.Int());
            AlterColumn("dbo.Lessons", "DurationId", c => c.Int());
            AlterColumn("dbo.Durations", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.LessonTypes", "Id");
            AddPrimaryKey("dbo.Durations", "Id");
            RenameColumn(table: "dbo.Lessons", name: "LessonTypeId", newName: "LessonTypes_Id");
            RenameColumn(table: "dbo.Lessons", name: "DurationId", newName: "Durations_Id");
            AddColumn("dbo.Lessons", "LessonTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Lessons", "DurationId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Lessons", "LessonTypes_Id");
            CreateIndex("dbo.Lessons", "Durations_Id");
            AddForeignKey("dbo.Lessons", "LessonTypes_Id", "dbo.LessonTypes", "Id");
            AddForeignKey("dbo.Lessons", "Durations_Id", "dbo.Durations", "Id");
        }
    }
}
