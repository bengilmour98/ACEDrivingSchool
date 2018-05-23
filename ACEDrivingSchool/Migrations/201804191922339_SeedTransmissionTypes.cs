namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTransmissionTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO TransmissionTypes (id, name) VALUES (1, 'Automatic') ");
            Sql(@"INSERT INTO TransmissionTypes (id, name) VALUES (2, 'Manual') ");
        }
        
        public override void Down()
        {
        }
    }
}
