namespace Afex.WarehouseMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocTypeUnmapped : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SalesInvoices", "DocType1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesInvoices", "DocType1", c => c.Int());
        }
    }
}
