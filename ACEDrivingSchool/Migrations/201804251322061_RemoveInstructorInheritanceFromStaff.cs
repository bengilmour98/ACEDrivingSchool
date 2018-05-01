namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveInstructorInheritanceFromStaff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TransmissionType = c.String(),
                        NumberOfStudents = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "TransmissionType");
            DropColumn("dbo.AspNetUsers", "NumberOfStudents");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "NumberOfStudents", c => c.Int());
            AddColumn("dbo.AspNetUsers", "TransmissionType", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropTable("dbo.Instructors");
        }
    }
}
