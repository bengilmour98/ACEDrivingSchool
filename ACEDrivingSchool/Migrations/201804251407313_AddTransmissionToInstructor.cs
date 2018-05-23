namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransmissionToInstructor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructors", "TransmissionTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Instructors", "TransmissionTypeId");
            AddForeignKey("dbo.Instructors", "TransmissionTypeId", "dbo.TransmissionTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Instructors", "TransmissionType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instructors", "TransmissionType", c => c.String());
            DropForeignKey("dbo.Instructors", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropIndex("dbo.Instructors", new[] { "TransmissionTypeId" });
            DropColumn("dbo.Instructors", "TransmissionTypeId");
        }
    }
}
