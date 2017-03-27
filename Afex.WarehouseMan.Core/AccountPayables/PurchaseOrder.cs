using Abp.Domain.Entities.Auditing;
using SampleLTE.BusinessPartners;
using SampleLTE.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLTE.AccountPayables
{
    public class PurchaseOrder : CreationAuditedEntity
    {
        #region ctors

        public PurchaseOrder()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
        }

        #endregion

        #region Properties

        public int DocEntryId { get; set; }

        public int DocNum { get; set; }

        [MaxLength(1), Column("DocumentType")]
        public string DocTypeString
        {
            get { return DocumentType.ToString(); }
            private set { DocumentType = value.ParseEnum<DocumentTypes>(); }
        }//create enum field

        [NotMapped]
        public DocumentTypes DocumentType { get; set; }

        public bool? Cancelled { get; set; }

        public bool? Printed { get; set; }

        [MaxLength(1), Column("Status")]
        public string StatusString
        {
            get { return Status.ToString(); }
            private set { Status = value.ParseEnum<PurchaseOrderStatus>(); }
        }//create enum Field

        [NotMapped]
        public PurchaseOrderStatus? Status { get; set; }

        public int CardCode { get; set; } //Foreign Key

        public decimal? TotalAmount { get; set; }

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
