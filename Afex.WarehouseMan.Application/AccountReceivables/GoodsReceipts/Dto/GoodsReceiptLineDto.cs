using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Afex.WarehouseMan.Common;
using Afex.WarehouseMan.Items.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables.GoodsReceipts.Dto
{
    [AutoMapFrom(typeof(GoodsReceiptLine))]
    public class GoodsReceiptLineDto : CreationAuditedEntityDto
    {
        #region Properties

        public int GoodsReceiptId { get; set; } //Foreign Key

        public int? GoodsReceiptDocEntryId { get; set; } //Foreign Key

        public int RowNumber { get; set; }
        
        public string StatusString { get; private set; }
        
        public PurchaseOrderStatus Status { get; set; }

        public int ItemId { get; set; } //Foreign Key

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal? Discount { get; set; }

        public decimal Price { get; set; }

        public decimal LineTotal { get; set; }

        #endregion

        #region Navigation Properties

        public virtual GoodsReceiptDto GoodsReceipt { get; set; }
        public virtual ItemDto Item { get; set; }

        #endregion
    }
}
