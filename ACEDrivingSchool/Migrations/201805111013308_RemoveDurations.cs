namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDurations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "DurationId", "dbo.Durations");
            DropIndex("dbo.Lessons", new[] { "DurationId" });
            AddColumn("dbo.Lessons", "Duration", c => c.Int(nullable: false));
            DropColumn("dbo.Lessons", "DurationId");
            DropTable("dbo.Durations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Durations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Lessons", "DurationId", c => c.Int(nullable: false));
            DropColumn("dbo.Lessons", "Duration");
            CreateIndex("dbo.Lessons", "DurationId");
            AddForeignKey("dbo.Lessons", "DurationId", "dbo.Durations", "Id", cascadeDelete: true);
        }
    }
}
