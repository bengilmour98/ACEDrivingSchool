namespace ACEDrivingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserDetailsToAspnetUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecondName", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressLine1", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressLine2", c => c.String());
            AddColumn("dbo.AspNetUsers", "Postcode", c => c.String());
            AddColumn("dbo.AspNetUsers", "HomePhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "MobilePhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "DrivingLicenceNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Credit", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Credit");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "DrivingLicenceNumber");
            DropColumn("dbo.AspNetUsers", "MobilePhoneNumber");
            DropColumn("dbo.AspNetUsers", "HomePhoneNumber");
            DropColumn("dbo.AspNetUsers", "Postcode");
            DropColumn("dbo.AspNetUsers", "AddressLine2");
            DropColumn("dbo.AspNetUsers", "AddressLine1");
            DropColumn("dbo.AspNetUsers", "SecondName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
