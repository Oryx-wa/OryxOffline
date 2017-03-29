using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Afex.WarehouseMan.Common;
using Afex.WarehouseMan.Items.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountPayables.Dto
{
    [AutoMapFrom(typeof(PurchaseOrderLine))]
    public class PurchaseOrderLineDto : CreationAuditedEntityDto
    {
        #region Properties

        public int PurchaseOrderId { get; set; } //Foreign Key

        public int PurchaseOrderDocEntryId { get; set; } //Foreign Key

        public int RowNumber { get; set; }
        
        public string StatusString
        {
            get;private set;
        }//create enum Field

        
        public PurchaseOrderStatus Status { get; set; }

        public int ItemId { get; set; } //Foreign Key
        
        public string Description { get; set; }

        public int? Quantity { get; set; }

        public decimal? Discount { get; set; }

        public decimal? Price { get; set; }

        public decimal? LineTotal { get; set; }

        public DateTime? PostingDate { get; set; }

        public DateTime? DueDate { get; set; }

        #endregion

        #region Navigation Properties

        public virtual PurchaseOrderDto PurchaseOrder { get; set; }
        public virtual ItemDto Item { get; set; }

        #endregion
    }
}
