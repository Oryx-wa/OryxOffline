namespace Afex.WarehouseMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedDB : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SalesInvoiceLines", new[] { "SalesInvoiceDocEntryId" });
            RenameColumn(table: "dbo.SalesInvoices", name: "DocTypeString", newName: "DocType");
            AddColumn("dbo.SalesInvoices", "DocType1", c => c.Int());
            AlterColumn("dbo.SalesInvoiceLines", "SalesInvoiceDocEntryId", c => c.Int());
            AlterColumn("dbo.SalesInvoiceLines", "Status", c => c.String(maxLength: 10));
            AlterColumn("dbo.SalesInvoiceLines", "Discount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.SalesInvoices", "DocEntryId", c => c.Int());
            AlterColumn("dbo.SalesInvoices", "DocNum", c => c.Int());
            AlterColumn("dbo.SalesInvoices", "DocType", c => c.String(maxLength: 10));
            CreateIndex("dbo.SalesInvoiceLines", "SalesInvoiceDocEntryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SalesInvoiceLines", new[] { "SalesInvoiceDocEntryId" });
            AlterColumn("dbo.SalesInvoices", "DocType", c => c.String());
            AlterColumn("dbo.SalesInvoices", "DocNum", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesInvoices", "DocEntryId", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesInvoiceLines", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SalesInvoiceLines", "Status", c => c.String(maxLength: 1));
            AlterColumn("dbo.SalesInvoiceLines", "SalesInvoiceDocEntryId", c => c.Int(nullable: false));
            DropColumn("dbo.SalesInvoices", "DocType1");
            RenameColumn(table: "dbo.SalesInvoices", name: "DocType", newName: "DocTypeString");
            CreateIndex("dbo.SalesInvoiceLines", "SalesInvoiceDocEntryId");
        }
    }
}
