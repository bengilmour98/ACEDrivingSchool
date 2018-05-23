namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditIdS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "DurationId", "dbo.Durations");
            DropForeignKey("dbo.Lessons", "LessonTypeId", "dbo.LessonTypes");
            DropForeignKey("dbo.Lessons", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropIndex("dbo.Lessons", new[] { "DurationId" });
            DropIndex("dbo.Lessons", new[] { "LessonTypeId" });
            DropIndex("dbo.Lessons", new[] { "TransmissionTypeId" });
            DropPrimaryKey("dbo.Durations");
            DropPrimaryKey("dbo.LessonTypes");
            DropPrimaryKey("dbo.TransmissionTypes");
            AlterColumn("dbo.Durations", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Lessons", "DurationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Lessons", "LessonTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Lessons", "TransmissionTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.LessonTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TransmissionTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Durations", "Id");
            AddPrimaryKey("dbo.LessonTypes", "Id");
            AddPrimaryKey("dbo.TransmissionTypes", "Id");
            CreateIndex("dbo.Lessons", "DurationId");
            CreateIndex("dbo.Lessons", "LessonTypeId");
            CreateIndex("dbo.Lessons", "TransmissionTypeId");
            AddForeignKey("dbo.Lessons", "DurationId", "dbo.Durations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessons", "LessonTypeId", "dbo.LessonTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessons", "TransmissionTypeId", "dbo.TransmissionTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.Lessons", "LessonTypeId", "dbo.LessonTypes");
            DropForeignKey("dbo.Lessons", "DurationId", "dbo.Durations");
            DropIndex("dbo.Lessons", new[] { "TransmissionTypeId" });
            DropIndex("dbo.Lessons", new[] { "LessonTypeId" });
            DropIndex("dbo.Lessons", new[] { "DurationId" });
            DropPrimaryKey("dbo.TransmissionTypes");
            DropPrimaryKey("dbo.LessonTypes");
            DropPrimaryKey("dbo.Durations");
            AlterColumn("dbo.TransmissionTypes", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.LessonTypes", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Lessons", "TransmissionTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Lessons", "LessonTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Lessons", "DurationId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Durations", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.TransmissionTypes", "Id");
            AddPrimaryKey("dbo.LessonTypes", "Id");
            AddPrimaryKey("dbo.Durations", "Id");
            CreateIndex("dbo.Lessons", "TransmissionTypeId");
            CreateIndex("dbo.Lessons", "LessonTypeId");
            CreateIndex("dbo.Lessons", "DurationId");
            AddForeignKey("dbo.Lessons", "TransmissionTypeId", "dbo.TransmissionTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessons", "LessonTypeId", "dbo.LessonTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessons", "DurationId", "dbo.Durations", "Id", cascadeDelete: true);
        }
    }
}
