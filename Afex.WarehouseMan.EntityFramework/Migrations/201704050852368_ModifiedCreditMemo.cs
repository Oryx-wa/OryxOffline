namespace Afex.WarehouseMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCreditMemo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CreditMemoLines", new[] { "CreditMemoDocEntryId" });
            RenameColumn(table: "dbo.CreditMemoes", name: "DocTypeString", newName: "DocumentType");
            AddColumn("dbo.CreditMemoes", "ContactPerson", c => c.String(maxLength: 100));
            AddColumn("dbo.CreditMemoes", "TotalAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.CreditMemoes", "DocEntryId", c => c.Int());
            AlterColumn("dbo.CreditMemoes", "DocNum", c => c.String());
            AlterColumn("dbo.CreditMemoes", "DocumentType", c => c.String(maxLength: 30));
            AlterColumn("dbo.CreditMemoes", "Status", c => c.String(maxLength: 30));
            AlterColumn("dbo.CreditMemoLines", "CreditMemoDocEntryId", c => c.Int());
            AlterColumn("dbo.CreditMemoLines", "Status", c => c.String(maxLength: 30));
            AlterColumn("dbo.CreditMemoLines", "Discount", c => c.Decimal(precision: 18, scale: 2));
            CreateIndex("dbo.CreditMemoLines", "CreditMemoDocEntryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CreditMemoLines", new[] { "CreditMemoDocEntryId" });
            AlterColumn("dbo.CreditMemoLines", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CreditMemoLines", "Status", c => c.String(maxLength: 1));
            AlterColumn("dbo.CreditMemoLines", "CreditMemoDocEntryId", c => c.Int(nullable: false));
            AlterColumn("dbo.CreditMemoes", "Status", c => c.String(maxLength: 1));
            AlterColumn("dbo.CreditMemoes", "DocumentType", c => c.String());
            AlterColumn("dbo.CreditMemoes", "DocNum", c => c.Int(nullable: false));
            AlterColumn("dbo.CreditMemoes", "DocEntryId", c => c.Int(nullable: false));
            DropColumn("dbo.CreditMemoes", "TotalAmount");
            DropColumn("dbo.CreditMemoes", "ContactPerson");
            RenameColumn(table: "dbo.CreditMemoes", name: "DocumentType", newName: "DocTypeString");
            CreateIndex("dbo.CreditMemoLines", "CreditMemoDocEntryId");
        }
    }
}
