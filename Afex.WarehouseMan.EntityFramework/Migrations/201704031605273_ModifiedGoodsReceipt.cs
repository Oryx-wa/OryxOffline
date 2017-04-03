namespace Afex.WarehouseMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedGoodsReceipt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GoodsReceipts", "ContactPerson", c => c.String());
            AlterColumn("dbo.GoodsReceiptLines", "Discount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.GoodsReceipts", "DocEntryId", c => c.Int());
            AlterColumn("dbo.GoodsReceipts", "DocNum", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GoodsReceipts", "DocNum", c => c.Int(nullable: false));
            AlterColumn("dbo.GoodsReceipts", "DocEntryId", c => c.Int(nullable: false));
            AlterColumn("dbo.GoodsReceiptLines", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.GoodsReceipts", "ContactPerson");
        }
    }
}
