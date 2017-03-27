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

namespace SampleLTE.AccountReceivables
{
    public class CreditMemo : CreationAuditedEntity
    {
        #region ctors

        public CreditMemo()
        {
            CreditMemoLines = new HashSet<CreditMemoLine>();
        }

        #endregion

        #region Properties

        public int DocEntryId { get; set; }

        public int DocNum { get; set; }

        public string DocTypeString { get; set; } //create enum field

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

        public int CardCode { get; set; }

        public DateTime? DatePosted { get; set; }

        public DateTime? DueDate { get; set; }


        public string Remarks { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<CreditMemoLine> CreditMemoLines { get; set; }
        public virtual BusinessPartner BusinessPartner { get; set; }

        #endregion
    }
}
