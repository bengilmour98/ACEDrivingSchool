namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDurations : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Durations (name) VALUES ('1 hour') ");
            Sql(@"INSERT INTO Durations (name) VALUES ('2 hours') ");
            Sql(@"INSERT INTO Durations (name) VALUES ('10 hours') ");
            Sql(@"INSERT INTO Durations (name) VALUES ('20 hours') ");
            Sql(@"INSERT INTO Durations (name) VALUES ('30 hours') ");
        }
        
        public override void Down()
        {
        }
    }
}
