namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RebuildLesson : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "DurationId", "dbo.Durations");
            DropForeignKey("dbo.Lessons", "LessonTypeId", "dbo.LessonTypes");
            DropForeignKey("dbo.Lessons", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropIndex("dbo.Lessons", new[] { "DurationId" });
            DropIndex("dbo.Lessons", new[] { "LessonTypeId" });
            DropIndex("dbo.Lessons", new[] { "TransmissionTypeId" });
            DropTable("dbo.Lessons");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOfLesson = c.DateTime(nullable: false),
                        DurationId = c.Byte(nullable: false),
                        LessonTypeId = c.Byte(nullable: false),
                        TransmissionTypeId = c.Byte(nullable: false),
                        Cost = c.Double(nullable: false),
                        Paid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Lessons", "TransmissionTypeId");
            CreateIndex("dbo.Lessons", "LessonTypeId");
            CreateIndex("dbo.Lessons", "DurationId");
            AddForeignKey("dbo.Lessons", "TransmissionTypeId", "dbo.TransmissionTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessons", "LessonTypeId", "dbo.LessonTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessons", "DurationId", "dbo.Durations", "Id", cascadeDelete: true);
        }
    }
}
