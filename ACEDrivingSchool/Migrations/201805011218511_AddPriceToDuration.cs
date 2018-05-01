namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceToDuration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Durations", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Durations", "Price");
        }
    }
}
