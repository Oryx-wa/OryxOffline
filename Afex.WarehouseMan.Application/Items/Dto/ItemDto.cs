using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Afex.WarehouseMan.AccountPayables.Dto;
using Afex.WarehouseMan.AccountReceivables.CreditMemoLines.Dto;
using Afex.WarehouseMan.AccountReceivables.GoodsReceipts.Dto;
using Afex.WarehouseMan.AccountReceivables.SalesInvoices.Dto;
using Afex.WarehouseMan.Items.Groups.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.Items.Dto
{
    [AutoMapFrom(typeof(Item))]
    public class ItemDto : CreationAuditedEntityDto
    {
        #region ctors

        public ItemDto()
        {
            SalesInvoiceLines = new HashSet<SalesInvoiceLineDto>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLineDto>();
            GoodsReceiptLines = new HashSet<GoodsReceiptLineDto>();
            CreditMemoLines = new HashSet<CreditMemoLineDto>();
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

        public virtual ItemGroupDto ItemGroup { get; set; }

        public virtual ICollection<SalesInvoiceLineDto> SalesInvoiceLines { get; set; }
        public virtual ICollection<PurchaseOrderLineDto> PurchaseOrderLines { get; set; }
        public virtual ICollection<GoodsReceiptLineDto> GoodsReceiptLines { get; set; }
        public virtual ICollection<CreditMemoLineDto> CreditMemoLines { get; set; }

        #endregion
    }
}
