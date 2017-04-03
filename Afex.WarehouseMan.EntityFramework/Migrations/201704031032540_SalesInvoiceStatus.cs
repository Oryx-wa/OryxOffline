namespace Afex.WarehouseMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesInvoiceStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesInvoices", "Status", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SalesInvoices", "Status", c => c.String(maxLength: 1));
        }
    }
}
