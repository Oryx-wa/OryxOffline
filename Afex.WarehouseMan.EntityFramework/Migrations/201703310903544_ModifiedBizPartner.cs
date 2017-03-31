namespace Afex.WarehouseMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedBizPartner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BusinessPartners", "IsActive", c => c.String());
            AddColumn("dbo.BusinessPartners", "ContactPersonName", c => c.String());
            AddColumn("dbo.BusinessPartners", "ContactPersonLastName", c => c.String());
            AddColumn("dbo.BusinessPartners", "ContactEmail", c => c.String());
            AddColumn("dbo.BusinessPartners", "ContactPhone", c => c.String());
            DropColumn("dbo.BusinessPartners", "ContactPerson");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BusinessPartners", "ContactPerson", c => c.String());
            DropColumn("dbo.BusinessPartners", "ContactPhone");
            DropColumn("dbo.BusinessPartners", "ContactEmail");
            DropColumn("dbo.BusinessPartners", "ContactPersonLastName");
            DropColumn("dbo.BusinessPartners", "ContactPersonName");
            DropColumn("dbo.BusinessPartners", "IsActive");
        }
    }
}
