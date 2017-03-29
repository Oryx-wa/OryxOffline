using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Afex.WarehouseMan.BusinessPartners.Dto;
using Afex.WarehouseMan.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountPayables.Dto
{
    [AutoMapFrom(typeof(PurchaseOrder))]
    public class PurchaseOrderDto : CreationAuditedEntityDto
    {
        #region ctors

        public PurchaseOrderDto()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLineDto>();
        }

        #endregion

        #region Properties

        public int DocEntryId { get; set; }

        public int DocNum { get; set; }

        public string DocTypeString
        {
            get;private set;
        }
        
        public DocumentTypes DocumentType { get; set; }

        public bool? Cancelled { get; set; }

        public bool? Printed { get; set; }

        
        public string StatusString
        {
            get;
            private set;
        }
        
        public PurchaseOrderStatus? Status { get; set; }

        public int CardCode { get; set; } 

        public decimal? TotalAmount { get; set; }
        
        public string Remarks { get; set; }

        public DateTime? PostingDate { get; set; }

        public DateTime? DueDate { get; set; }

        #endregion

        #region Navigation properties

        public virtual BusinessPartnerDto BusinessPartner { get; set; }

        public virtual ICollection<PurchaseOrderLineDto> PurchaseOrderLines { get; set; }

        #endregion
    }
}
