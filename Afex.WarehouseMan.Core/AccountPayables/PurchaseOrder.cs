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

namespace Afex.WarehouseMan.AccountPayables
{
    public class PurchaseOrder : CreationAuditedEntity
    {
        #region ctors

        public PurchaseOrder()
        {
            DocumentType = DocumentTypes.Item;
            PostingDate = Clock.Now;
            DueDate = Clock.Now;
            Cancelled = false;
            Printed = false;
            Status = PurchaseOrderStatus.Open;
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
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

        public int CardCode { get; set; } //Foreign Key

        public decimal? TotalAmount { get; set; }

        [MaxLength(100)]
        public string ContactPerson { get; set; }

        [MaxLength(254)]
        public string Remarks { get; set; }

        public DateTime? PostingDate { get; set; }

        public DateTime? DueDate { get; set; }

        #endregion

        #region Navigation properties

        public virtual BusinessPartner BusinessPartner { get; set; }

        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }

        #endregion
    }
}
