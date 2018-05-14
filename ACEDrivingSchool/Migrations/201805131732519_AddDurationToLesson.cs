namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDurationToLesson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "DurationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "DurationId");
            AddForeignKey("dbo.Lessons", "DurationId", "dbo.Durations", "Id", cascadeDelete: true);
            DropColumn("dbo.Lessons", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Duration", c => c.String(nullable: false));
            DropForeignKey("dbo.Lessons", "DurationId", "dbo.Durations");
            DropIndex("dbo.Lessons", new[] { "DurationId" });
            DropColumn("dbo.Lessons", "DurationId");
        }
    }
}
