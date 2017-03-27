namespace SampleLTE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions");
            DropForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers");
            CreateTable(
                "dbo.BusinessPartners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardCode = c.String(),
                        CardName = c.String(),
                        CardType = c.String(),
                        Location = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        ContactPerson = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CreditMemoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocEntryId = c.Int(nullable: false),
                        DocNum = c.Int(nullable: false),
                        DocTypeString = c.String(),
                        Cancelled = c.Boolean(),
                        Printed = c.Boolean(),
                        Status = c.String(maxLength: 1),
                        CardCode = c.Int(nullable: false),
                        DatePosted = c.DateTime(),
                        DueDate = c.DateTime(),
                        Remarks = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        BusinessPartner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessPartners", t => t.CardCode)
                .ForeignKey("dbo.BusinessPartners", t => t.BusinessPartner_Id)
                .Index(t => t.CardCode)
                .Index(t => t.BusinessPartner_Id);
            
            CreateTable(
                "dbo.CreditMemoLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreditMemoId = c.Int(nullable: false),
                        CreditMemoDocEntryId = c.Int(nullable: false),
                        RowNumber = c.Int(nullable: false),
                        Status = c.String(maxLength: 1),
                        ItemId = c.Int(nullable: false),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PostingDate = c.DateTime(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Item_Id = c.Int(),
                        CreditMemo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditMemoes", t => t.CreditMemoDocEntryId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.CreditMemoes", t => t.CreditMemo_Id)
                .Index(t => t.CreditMemoDocEntryId)
                .Index(t => t.ItemId)
                .Index(t => t.Item_Id)
                .Index(t => t.CreditMemo_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemCode = c.String(),
                        ItemName = c.String(),
                        ItemGroupId = c.Int(nullable: false),
                        QuantityInStock = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        ItemGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemGroups", t => t.ItemGroup_Id)
                .ForeignKey("dbo.ItemGroups", t => t.ItemGroupId)
                .Index(t => t.ItemGroupId)
                .Index(t => t.ItemGroup_Id);
            
            CreateTable(
                "dbo.GoodsReceiptLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoodsReceiptId = c.Int(nullable: false),
                        GoodsReceiptDocEntryId = c.Int(nullable: false),
                        RowNumber = c.Int(nullable: false),
                        Status = c.String(maxLength: 1),
                        ItemId = c.Int(nullable: false),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        GoodsReceipt_Id = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GoodsReceipts", t => t.GoodsReceipt_Id)
                .ForeignKey("dbo.GoodsReceipts", t => t.GoodsReceiptDocEntryId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.GoodsReceiptDocEntryId)
                .Index(t => t.ItemId)
                .Index(t => t.GoodsReceipt_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.GoodsReceipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocEntryId = c.Int(nullable: false),
                        DocNum = c.Int(nullable: false),
                        DocType = c.String(),
                        CardCode = c.Int(nullable: false),
                        Status = c.String(maxLength: 1),
                        PostingDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        BusinessPartner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessPartners", t => t.CardCode)
                .ForeignKey("dbo.BusinessPartners", t => t.BusinessPartner_Id)
                .Index(t => t.CardCode)
                .Index(t => t.BusinessPartner_Id);
            
            CreateTable(
                "dbo.ItemGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemGroupCode = c.Int(nullable: false),
                        Name = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseOrderLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseOrderId = c.Int(nullable: false),
                        PurchaseOrderDocEntryId = c.Int(nullable: false),
                        RowNumber = c.Int(nullable: false),
                        Status = c.String(maxLength: 1),
                        ItemId = c.Int(nullable: false),
                        Description = c.String(maxLength: 254),
                        Quantity = c.Int(),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        Price = c.Decimal(precision: 18, scale: 2),
                        LineTotal = c.Decimal(precision: 18, scale: 2),
                        PostingDate = c.DateTime(),
                        DueDate = c.DateTime(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        PurchaseOrder_Id = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrder_Id)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderDocEntryId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.PurchaseOrderDocEntryId)
                .Index(t => t.ItemId)
                .Index(t => t.PurchaseOrder_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocEntryId = c.Int(nullable: false),
                        DocNum = c.Int(nullable: false),
                        DocumentType = c.String(maxLength: 1),
                        Cancelled = c.Boolean(),
                        Printed = c.Boolean(),
                        Status = c.String(maxLength: 1),
                        CardCode = c.Int(nullable: false),
                        TotalAmount = c.Decimal(precision: 18, scale: 2),
                        Remarks = c.String(maxLength: 254),
                        PostingDate = c.DateTime(),
                        DueDate = c.DateTime(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        BusinessPartner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessPartners", t => t.CardCode)
                .ForeignKey("dbo.BusinessPartners", t => t.BusinessPartner_Id)
                .Index(t => t.CardCode)
                .Index(t => t.BusinessPartner_Id);
            
            CreateTable(
                "dbo.SalesInvoiceLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesInvoiceId = c.Int(nullable: false),
                        SalesInvoiceDocEntryId = c.Int(nullable: false),
                        RowNumber = c.Int(nullable: false),
                        Status = c.String(maxLength: 1),
                        ItemId = c.Int(nullable: false),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PostingDate = c.DateTime(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        SalesInvoice_Id = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.SalesInvoices", t => t.SalesInvoice_Id)
                .ForeignKey("dbo.SalesInvoices", t => t.SalesInvoiceDocEntryId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.SalesInvoiceDocEntryId)
                .Index(t => t.ItemId)
                .Index(t => t.SalesInvoice_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.SalesInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocEntryId = c.Int(nullable: false),
                        DocNum = c.Int(nullable: false),
                        DocTypeString = c.String(),
                        Cancelled = c.Boolean(nullable: false),
                        Printed = c.Boolean(nullable: false),
                        Status = c.String(maxLength: 1),
                        PostingDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        CardCode = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        BusinessPartner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessPartners", t => t.CardCode)
                .ForeignKey("dbo.BusinessPartners", t => t.BusinessPartner_Id)
                .Index(t => t.CardCode)
                .Index(t => t.BusinessPartner_Id);
            
            AddForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions", "Id");
            AddForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles", "Id");
            AddForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions");
            DropForeignKey("dbo.SalesInvoices", "BusinessPartner_Id", "dbo.BusinessPartners");
            DropForeignKey("dbo.PurchaseOrders", "BusinessPartner_Id", "dbo.BusinessPartners");
            DropForeignKey("dbo.GoodsReceipts", "BusinessPartner_Id", "dbo.BusinessPartners");
            DropForeignKey("dbo.CreditMemoes", "BusinessPartner_Id", "dbo.BusinessPartners");
            DropForeignKey("dbo.CreditMemoLines", "CreditMemo_Id", "dbo.CreditMemoes");
            DropForeignKey("dbo.CreditMemoLines", "ItemId", "dbo.Items");
            DropForeignKey("dbo.SalesInvoiceLines", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.SalesInvoiceLines", "SalesInvoiceDocEntryId", "dbo.SalesInvoices");
            DropForeignKey("dbo.SalesInvoiceLines", "SalesInvoice_Id", "dbo.SalesInvoices");
            DropForeignKey("dbo.SalesInvoices", "CardCode", "dbo.BusinessPartners");
            DropForeignKey("dbo.SalesInvoiceLines", "ItemId", "dbo.Items");
            DropForeignKey("dbo.PurchaseOrderLines", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.PurchaseOrderLines", "PurchaseOrderDocEntryId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrderLines", "PurchaseOrder_Id", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "CardCode", "dbo.BusinessPartners");
            DropForeignKey("dbo.PurchaseOrderLines", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "ItemGroupId", "dbo.ItemGroups");
            DropForeignKey("dbo.Items", "ItemGroup_Id", "dbo.ItemGroups");
            DropForeignKey("dbo.GoodsReceiptLines", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.GoodsReceiptLines", "ItemId", "dbo.Items");
            DropForeignKey("dbo.GoodsReceiptLines", "GoodsReceiptDocEntryId", "dbo.GoodsReceipts");
            DropForeignKey("dbo.GoodsReceiptLines", "GoodsReceipt_Id", "dbo.GoodsReceipts");
            DropForeignKey("dbo.GoodsReceipts", "CardCode", "dbo.BusinessPartners");
            DropForeignKey("dbo.CreditMemoLines", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.CreditMemoLines", "CreditMemoDocEntryId", "dbo.CreditMemoes");
            DropForeignKey("dbo.CreditMemoes", "CardCode", "dbo.BusinessPartners");
            DropIndex("dbo.SalesInvoices", new[] { "BusinessPartner_Id" });
            DropIndex("dbo.SalesInvoices", new[] { "CardCode" });
            DropIndex("dbo.SalesInvoiceLines", new[] { "Item_Id" });
            DropIndex("dbo.SalesInvoiceLines", new[] { "SalesInvoice_Id" });
            DropIndex("dbo.SalesInvoiceLines", new[] { "ItemId" });
            DropIndex("dbo.SalesInvoiceLines", new[] { "SalesInvoiceDocEntryId" });
            DropIndex("dbo.PurchaseOrders", new[] { "BusinessPartner_Id" });
            DropIndex("dbo.PurchaseOrders", new[] { "CardCode" });
            DropIndex("dbo.PurchaseOrderLines", new[] { "Item_Id" });
            DropIndex("dbo.PurchaseOrderLines", new[] { "PurchaseOrder_Id" });
            DropIndex("dbo.PurchaseOrderLines", new[] { "ItemId" });
            DropIndex("dbo.PurchaseOrderLines", new[] { "PurchaseOrderDocEntryId" });
            DropIndex("dbo.GoodsReceipts", new[] { "BusinessPartner_Id" });
            DropIndex("dbo.GoodsReceipts", new[] { "CardCode" });
            DropIndex("dbo.GoodsReceiptLines", new[] { "Item_Id" });
            DropIndex("dbo.GoodsReceiptLines", new[] { "GoodsReceipt_Id" });
            DropIndex("dbo.GoodsReceiptLines", new[] { "ItemId" });
            DropIndex("dbo.GoodsReceiptLines", new[] { "GoodsReceiptDocEntryId" });
            DropIndex("dbo.Items", new[] { "ItemGroup_Id" });
            DropIndex("dbo.Items", new[] { "ItemGroupId" });
            DropIndex("dbo.CreditMemoLines", new[] { "CreditMemo_Id" });
            DropIndex("dbo.CreditMemoLines", new[] { "Item_Id" });
            DropIndex("dbo.CreditMemoLines", new[] { "ItemId" });
            DropIndex("dbo.CreditMemoLines", new[] { "CreditMemoDocEntryId" });
            DropIndex("dbo.CreditMemoes", new[] { "BusinessPartner_Id" });
            DropIndex("dbo.CreditMemoes", new[] { "CardCode" });
            DropTable("dbo.SalesInvoices");
            DropTable("dbo.SalesInvoiceLines");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PurchaseOrderLines");
            DropTable("dbo.ItemGroups");
            DropTable("dbo.GoodsReceipts");
            DropTable("dbo.GoodsReceiptLines");
            DropTable("dbo.Items");
            DropTable("dbo.CreditMemoLines");
            DropTable("dbo.CreditMemoes");
            DropTable("dbo.BusinessPartners");
            AddForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions", "Id", cascadeDelete: true);
        }
    }
}
