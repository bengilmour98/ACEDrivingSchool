namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTransmission : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropIndex("dbo.Lessons", new[] { "TransmissionTypeId" });
            DropColumn("dbo.Lessons", "TransmissionTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "TransmissionTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "TransmissionTypeId");
            AddForeignKey("dbo.Lessons", "TransmissionTypeId", "dbo.TransmissionTypes", "Id", cascadeDelete: true);
        }
    }
}
