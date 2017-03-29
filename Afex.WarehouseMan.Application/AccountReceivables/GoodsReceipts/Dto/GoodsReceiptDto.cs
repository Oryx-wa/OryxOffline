using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Afex.WarehouseMan.BusinessPartners.Dto;
using Afex.WarehouseMan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables.GoodsReceipts.Dto
{
    [AutoMapFrom(typeof(GoodsReceipt))]
    public class GoodsReceiptDto : CreationAuditedEntityDto
    {
        #region ctors

        public GoodsReceiptDto()
        {
            GoodsReceiptLines = new HashSet<GoodsReceiptLineDto>();
        }

        #endregion

        #region Properties

        public int DocEntryId { get; set; }

        public int DocNum { get; set; }

        public string DocType { get; set; }

        public int CardCode { get; set; } 

        public string StatusString { get; private set; }

        public PurchaseOrderStatus Status { get; set; }

        public DateTime PostingDate { get; set; }

        public DateTime DueDate { get; set; }

        public decimal Amount { get; set; }

        public string Remarks { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<GoodsReceiptLineDto> GoodsReceiptLines { get; set; }
        public virtual BusinessPartnerDto BusinessPartner { get; set; }

        #endregion
    }
}
