using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Afex.WarehouseMan.Common;
using Afex.WarehouseMan.Items.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables.SalesInvoices.Dto
{
    [AutoMapFrom(typeof(SalesInvoiceLine))]
    public class SalesInvoiceLineDto : CreationAuditedEntityDto
    {
        public int SalesInvoiceId { get; set; }

        public int? SalesInvoiceDocEntryId { get; set; } 

        public int RowNumber { get; set; }
        
        public string StatusString { get; private set; }
        
        public PurchaseOrderStatus Status { get; set; }

        public int ItemId { get; set; } 

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal? Discount { get; set; }

        public decimal Price { get; set; }

        public decimal LineTotal { get; set; }

        public DateTime PostingDate { get; set; }

        #region Navigation Properties

        public virtual SalesInvoiceDto SalesInvoice { get; set; }
        public virtual ItemDto Item { get; set; }

        #endregion
    }
}
