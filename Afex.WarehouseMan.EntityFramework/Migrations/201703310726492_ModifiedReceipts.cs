namespace Afex.WarehouseMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedReceipts : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GoodsReceipts", "Status");
            DropColumn("dbo.GoodsReceipts", "PostingDate");
            DropColumn("dbo.GoodsReceipts", "DueDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GoodsReceipts", "DueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.GoodsReceipts", "PostingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.GoodsReceipts", "Status", c => c.String(maxLength: 1));
        }
    }
}
