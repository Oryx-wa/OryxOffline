using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Afex.WarehouseMan.AccountReceivables.CreditMemoLines.Dto;
using Afex.WarehouseMan.BusinessPartners.Dto;
using Afex.WarehouseMan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables.CreditMemos.Dto
{
    [AutoMapFrom(typeof(CreditMemo))]
    public class CreditMemoDto : CreationAuditedEntityDto
    {
        #region ctors

        public CreditMemoDto()
        {
            CreditMemoLines = new HashSet<CreditMemoLineDto>();
        }

        #endregion

        #region Properties

        public int DocEntryId { get; set; }

        public int DocNum { get; set; }

        public string DocTypeString { get; set; } //create enum field

        public bool? Cancelled { get; set; }

        public bool? Printed { get; set; }
        
        public string StatusString { get; private set; }

        public PurchaseOrderStatus? Status { get; set; }

        public int CardCode { get; set; }

        public DateTime? DatePosted { get; set; }

        public DateTime? DueDate { get; set; }


        public string Remarks { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<CreditMemoLineDto> CreditMemoLines { get; set; }
        public virtual BusinessPartnerDto BusinessPartner { get; set; }

        #endregion
    }
}
