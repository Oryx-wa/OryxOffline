namespace Afex.WarehouseMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoodsReceiptDocEntryOptionalForeignKey : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.GoodsReceiptLines", new[] { "GoodsReceiptDocEntryId" });
            AlterColumn("dbo.GoodsReceiptLines", "GoodsReceiptDocEntryId", c => c.Int());
            CreateIndex("dbo.GoodsReceiptLines", "GoodsReceiptDocEntryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.GoodsReceiptLines", new[] { "GoodsReceiptDocEntryId" });
            AlterColumn("dbo.GoodsReceiptLines", "GoodsReceiptDocEntryId", c => c.Int(nullable: false));
            CreateIndex("dbo.GoodsReceiptLines", "GoodsReceiptDocEntryId");
        }
    }
}
