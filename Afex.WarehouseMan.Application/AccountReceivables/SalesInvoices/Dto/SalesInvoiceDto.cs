using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Afex.WarehouseMan.BusinessPartners.Dto;
using Afex.WarehouseMan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables.SalesInvoices.Dto
{
    [AutoMapFrom(typeof(SalesInvoice))]
    public class SalesInvoiceDto : CreationAuditedEntityDto
    {
        #region ctors

        public SalesInvoiceDto()
        {
            SalesInvoiceLines = new HashSet<SalesInvoiceLineDto>();
        }

        #endregion

        #region Properties

        public int DocEntryId { get; set; }

        public int DocNum { get; set; }

        public string DocTypeString { get; set; } 

        public bool Cancelled { get; set; }

        public bool Printed { get; set; }
        
        public string StatusString { get; private set; }
        
        public PurchaseOrderStatus Status { get; set; }

        public DateTime PostingDate { get; set; }

        public DateTime DueDate { get; set; }

        public int CardCode { get; set; } 

        public decimal TotalAmount { get; set; }

        public string Remarks { get; set; }

        #endregion

        #region Navigation Properties

        public virtual BusinessPartnerDto BusinessPartner { get; set; }

        public virtual ICollection<SalesInvoiceLineDto> SalesInvoiceLines { get; set; }

        #endregion
    }
}
