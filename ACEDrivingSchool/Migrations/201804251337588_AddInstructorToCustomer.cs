namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstructorToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AssignedInstructor", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AssignedInstructor");
        }
    }
}
