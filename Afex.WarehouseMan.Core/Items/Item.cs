using Abp.Domain.Entities.Auditing;
using SampleLTE.AccountPayables;
using SampleLTE.AccountReceivables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLTE.Items
{
    public class Item : CreationAuditedEntity
    {
        #region ctors

        public Item()
        {
            SalesInvoiceLines = new HashSet<SalesInvoiceLine>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            GoodsReceiptLines = new HashSet<GoodsReceiptLine>();
            CreditMemoLines = new HashSet<CreditMemoLine>();
            //PurchaseInvoiceLines = new HashSet<PurchaseInvoiceLine>();
            //InventoryControlJournals = new HashSet<InventoryControlJournal>();


        }

        #endregion

        #region Properties

        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public int? ItemGroupId { get; set; }

        public int QuantityInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal UnitCost { get; set; }

        public string Remarks { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ItemGroup ItemGroup { get; set; }

        public virtual ICollection<SalesInvoiceLine> SalesInvoiceLines { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual ICollection<GoodsReceiptLine> GoodsReceiptLines { get; set; }
        public virtual ICollection<CreditMemoLine> CreditMemoLines { get; set; }

        #endregion
    }
}
