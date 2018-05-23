namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDurationsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Durations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DurationOfLesson = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Lessons", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Price", c => c.Double(nullable: false));
            DropTable("dbo.Durations");
        }
    }
}
