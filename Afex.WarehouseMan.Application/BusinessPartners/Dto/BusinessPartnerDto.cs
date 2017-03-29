using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Afex.WarehouseMan.AccountPayables.Dto;
using Afex.WarehouseMan.AccountReceivables.CreditMemos.Dto;
using Afex.WarehouseMan.AccountReceivables.GoodsReceipts.Dto;
using Afex.WarehouseMan.AccountReceivables.SalesInvoices.Dto;
using Afex.WarehouseMan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.BusinessPartners.Dto
{
    [AutoMapFrom(typeof(BusinessPartner))]
    public class BusinessPartnerDto : CreationAuditedEntity
    {
        #region ctors

        public BusinessPartnerDto()
        {
            PurchaseOrders = new HashSet<PurchaseOrderDto>();
            SalesInvoices = new HashSet<SalesInvoiceDto>();
            GoodsReceipts = new HashSet<GoodsReceiptDto>();
            CreditMemos = new HashSet<CreditMemoDto>();
        }

        #endregion

        #region Properties

        public string CardCode { get; set; }

        public string CardName { get; set; }

        
        public string CardTypeString { get; private set; }

        public CardTypes? CardType { get; set; }

        public string Location { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string ContactPerson { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<PurchaseOrderDto> PurchaseOrders { get; set; }

        public virtual ICollection<SalesInvoiceDto> SalesInvoices { get; set; }

        public virtual ICollection<GoodsReceiptDto> GoodsReceipts { get; set; }

        public virtual ICollection<CreditMemoDto> CreditMemos { get; set; }

        #endregion
    }
}
