using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Afex.WarehouseMan.BusinessPartners;
using Afex.WarehouseMan.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables
{
    public class CreditMemo : CreationAuditedEntity
    {
        #region ctors

        public CreditMemo()
        {
            DocumentType = DocumentTypes.Item;
            DatePosted = Clock.Now;
            DueDate = Clock.Now;
            Cancelled = false;
            Printed = false;
            Status = PurchaseOrderStatus.Open;
            CreditMemoLines = new HashSet<CreditMemoLine>();
        }

        #endregion

        #region Properties

        public int? DocEntryId { get; set; }

        public string DocNum { get; set; }

        [MaxLength(30), Column("DocumentType")]
        public string DocTypeString
        {
            get { return DocumentType.ToString(); }
            private set { DocumentType = value.ParseEnum<DocumentTypes>(); }
        }//create enum field

        [NotMapped]
        public DocumentTypes DocumentType { get; set; }

        public bool? Cancelled { get; set; }

        public bool? Printed { get; set; }

        [MaxLength(30), Column("Status")]
        public string StatusString
        {
            get { return Status.ToString(); }
            private set { Status = value.ParseEnum<PurchaseOrderStatus>(); }
        }//create enum Field

        [NotMapped]
        public PurchaseOrderStatus? Status { get; set; }

        public int CardCode { get; set; }

        public DateTime? DatePosted { get; set; }

        public DateTime? DueDate { get; set; }

        [MaxLength(100)]
        public string ContactPerson { get; set; }

        public decimal? TotalAmount { get; set; }

        public string Remarks { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<CreditMemoLine> CreditMemoLines { get; set; }
        public virtual BusinessPartner BusinessPartner { get; set; }

        #endregion
    }
}
