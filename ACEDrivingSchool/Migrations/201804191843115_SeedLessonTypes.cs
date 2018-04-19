namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedLessonTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO LessonTypes (name) VALUES ('Single') ");
            Sql(@"INSERT INTO LessonTypes (name) VALUES ('Block') ");
            
        }
        
        public override void Down()
        {
        }
    }
}
