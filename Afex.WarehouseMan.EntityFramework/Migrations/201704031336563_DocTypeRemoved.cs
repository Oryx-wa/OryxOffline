namespace Afex.WarehouseMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocTypeRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SalesInvoices", "DocType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesInvoices", "DocType", c => c.String(maxLength: 10));
        }
    }
}
