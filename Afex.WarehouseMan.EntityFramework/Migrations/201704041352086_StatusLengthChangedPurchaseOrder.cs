namespace Afex.WarehouseMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusLengthChangedPurchaseOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseOrderLines", "Status", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseOrderLines", "Status", c => c.String(maxLength: 1));
        }
    }
}
