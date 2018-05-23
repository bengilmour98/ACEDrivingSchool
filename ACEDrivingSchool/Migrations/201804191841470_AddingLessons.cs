namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLessons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Durations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        DateOfLesson = c.DateTime(nullable: false),
                        TimeOfLesson = c.DateTime(nullable: false),
                        DurationId = c.Byte(nullable: false),
                        LessonTypeId = c.Byte(nullable: false),
                        TransmissionTypeId = c.Byte(nullable: false),
                        Cost = c.Double(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        Durations_Id = c.Int(),
                        LessonTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Durations", t => t.Durations_Id)
                .ForeignKey("dbo.LessonTypes", t => t.LessonTypes_Id)
                .ForeignKey("dbo.TransmissionTypes", t => t.TransmissionTypeId, cascadeDelete: true)
                .Index(t => t.TransmissionTypeId)
                .Index(t => t.Durations_Id)
                .Index(t => t.LessonTypes_Id);
            
            CreateTable(
                "dbo.LessonTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransmissionTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.Lessons", "LessonTypes_Id", "dbo.LessonTypes");
            DropForeignKey("dbo.Lessons", "Durations_Id", "dbo.Durations");
            DropIndex("dbo.Lessons", new[] { "LessonTypes_Id" });
            DropIndex("dbo.Lessons", new[] { "Durations_Id" });
            DropIndex("dbo.Lessons", new[] { "TransmissionTypeId" });
            DropTable("dbo.TransmissionTypes");
            DropTable("dbo.LessonTypes");
            DropTable("dbo.Lessons");
            DropTable("dbo.Durations");
        }
    }
}
