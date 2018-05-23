namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLessonWithIdFix : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Durations", t => t.DurationId, cascadeDelete: true)
                .ForeignKey("dbo.LessonTypes", t => t.LessonTypeId, cascadeDelete: true)
                .ForeignKey("dbo.TransmissionTypes", t => t.TransmissionTypeId, cascadeDelete: true)
                .Index(t => t.DurationId)
                .Index(t => t.LessonTypeId)
                .Index(t => t.TransmissionTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.Lessons", "LessonTypeId", "dbo.LessonTypes");
            DropForeignKey("dbo.Lessons", "DurationId", "dbo.Durations");
            DropIndex("dbo.Lessons", new[] { "TransmissionTypeId" });
            DropIndex("dbo.Lessons", new[] { "LessonTypeId" });
            DropIndex("dbo.Lessons", new[] { "DurationId" });
            DropTable("dbo.Lessons");
        }
    }
}
