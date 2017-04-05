namespace Afex.WarehouseMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newPurchaseOrderStructure : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PurchaseOrderLines", new[] { "PurchaseOrderDocEntryId" });
            AddColumn("dbo.PurchaseOrders", "ContactPerson", c => c.String(maxLength: 100));
            AlterColumn("dbo.PurchaseOrderLines", "PurchaseOrderDocEntryId", c => c.Int());
            AlterColumn("dbo.PurchaseOrders", "DocEntryId", c => c.Int());
            AlterColumn("dbo.PurchaseOrders", "DocNum", c => c.String());
            AlterColumn("dbo.PurchaseOrders", "DocumentType", c => c.String(maxLength: 30));
            AlterColumn("dbo.PurchaseOrders", "Status", c => c.String(maxLength: 30));
            CreateIndex("dbo.PurchaseOrderLines", "PurchaseOrderDocEntryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PurchaseOrderLines", new[] { "PurchaseOrderDocEntryId" });
            AlterColumn("dbo.PurchaseOrders", "Status", c => c.String(maxLength: 1));
            AlterColumn("dbo.PurchaseOrders", "DocumentType", c => c.String(maxLength: 1));
            AlterColumn("dbo.PurchaseOrders", "DocNum", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseOrders", "DocEntryId", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseOrderLines", "PurchaseOrderDocEntryId", c => c.Int(nullable: false));
            DropColumn("dbo.PurchaseOrders", "ContactPerson");
            CreateIndex("dbo.PurchaseOrderLines", "PurchaseOrderDocEntryId");
        }
    }
}
