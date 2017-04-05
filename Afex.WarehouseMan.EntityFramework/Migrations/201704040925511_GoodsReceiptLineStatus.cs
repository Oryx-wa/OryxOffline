namespace Afex.WarehouseMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoodsReceiptLineStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GoodsReceiptLines", "Status", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GoodsReceiptLines", "Status", c => c.String(maxLength: 1));
        }
    }
}
