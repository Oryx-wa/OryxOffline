using System.Data.Common;
using Abp.Zero.EntityFramework;
using SampleLTE.Authorization.Roles;
using SampleLTE.MultiTenancy;
using SampleLTE.Users;
using SampleLTE.Items;
using System.Data.Entity;
using SampleLTE.Common;
using SampleLTE.AccountPayables;
using SampleLTE.AccountReceivables;
using System.Data.Entity.ModelConfiguration.Conventions;
using SampleLTE.BusinessPartners;

namespace SampleLTE.EntityFramework
{
    public class SampleLTEDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        public IDbSet<Item> Items { get; set; }

        public IDbSet<ItemGroup> ItemCategories { get; set; }

        public IDbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public IDbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }

        public IDbSet<SalesInvoice> SalesInvoices { get; set; }

        public IDbSet<SalesInvoiceLine> SalesInvoiceLines { get; set; }

        public IDbSet<CreditMemo> CreditMemos { get; set; }

        public IDbSet<CreditMemoLine> CreditMemoLines { get; set; }

        public IDbSet<GoodsReceipt> GoodsReceipts { get; set; }

        public IDbSet<GoodsReceiptLine> GoodsReceiptLines { get; set; }

        public IDbSet<BusinessPartner> BusinessPartners { get; set; }





        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public SampleLTEDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in SampleLTEDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of SampleLTEDbContext since ABP automatically handles it.
         */
        public SampleLTEDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SampleLTEDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<PurchaseOrder>()
                .HasRequired(p => p.BusinessPartner).WithMany().HasForeignKey(p => p.CardCode);

            modelBuilder.Entity<PurchaseOrderLine>()
               .HasRequired(p => p.PurchaseOrder).WithMany().HasForeignKey(p => p.PurchaseOrderId);
            modelBuilder.Entity<PurchaseOrderLine>()
                .HasRequired(p => p.PurchaseOrder).WithMany().HasForeignKey(p => p.PurchaseOrderDocEntryId);
            modelBuilder.Entity<PurchaseOrderLine>()
                .HasRequired(p => p.Item).WithMany().HasForeignKey(p => p.ItemId);

            modelBuilder.Entity<CreditMemo>()
                .HasRequired(c => c.BusinessPartner).WithMany().HasForeignKey(c => c.CardCode);

            modelBuilder.Entity<CreditMemoLine>()
                .HasRequired(c => c.CreditMemo).WithMany().HasForeignKey(c => c.CreditMemoId);
            modelBuilder.Entity<CreditMemoLine>()
                .HasRequired(c => c.CreditMemo).WithMany().HasForeignKey(c => c.CreditMemoDocEntryId);
            modelBuilder.Entity<CreditMemoLine>()
                .HasRequired(c => c.Item).WithMany().HasForeignKey(c => c.ItemId);

            modelBuilder.Entity<GoodsReceipt>()
                .HasRequired(c => c.BusinessPartner).WithMany().HasForeignKey(c => c.CardCode);

            modelBuilder.Entity<GoodsReceiptLine>()
                .HasRequired(c => c.GoodsReceipt).WithMany().HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<GoodsReceiptLine>()
                .HasRequired(c => c.GoodsReceipt).WithMany().HasForeignKey(c => c.GoodsReceiptDocEntryId);
            modelBuilder.Entity<GoodsReceiptLine>()
                .HasRequired(c => c.Item).WithMany().HasForeignKey(c => c.ItemId);

            modelBuilder.Entity<SalesInvoice>()
                .HasRequired(c => c.BusinessPartner).WithMany().HasForeignKey(c => c.CardCode);

            modelBuilder.Entity<SalesInvoiceLine>()
                .HasRequired(c => c.SalesInvoice).WithMany().HasForeignKey(c => c.SalesInvoiceId);
            modelBuilder.Entity<SalesInvoiceLine>()
                .HasRequired(c => c.SalesInvoice).WithMany().HasForeignKey(c => c.SalesInvoiceDocEntryId);
            modelBuilder.Entity<SalesInvoiceLine>()
                .HasRequired(c => c.Item).WithMany().HasForeignKey(c => c.ItemId);

            modelBuilder.Entity<Item>()
                .HasRequired(c => c.ItemGroup).WithMany().HasForeignKey(c => c.ItemGroupId);
        }
    }
}
