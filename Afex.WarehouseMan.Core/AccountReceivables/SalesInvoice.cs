using Abp.Domain.Entities.Auditing;
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
    public class SalesInvoice : CreationAuditedEntity
    {
        #region ctors

        public SalesInvoice()
        {
            SalesInvoiceLines = new HashSet<SalesInvoiceLine>();
        } 

        #endregion

        #region Properties

        public int DocEntryId { get; set; }

        public int DocNum { get; set; }

        public string DocTypeString { get; set; } //create enum field

        public bool Cancelled { get; set; }

        public bool Printed { get; set; }

        [MaxLength(1), Column("Status")]
        public string StatusString
        {
            get { return Status.ToString(); }
            private set { Status = value.ParseEnum<PurchaseOrderStatus>(); }
        }//create enum Field

        [NotMapped]
        public PurchaseOrderStatus Status { get; set; }

        public DateTime PostingDate { get; set; }

        public DateTime DueDate { get; set; }

        public int CardCode { get; set; } //Foreign key

        public decimal TotalAmount { get; set; }

        public string Remarks { get; set; }

        #endregion

        #region Navigation Properties

        public virtual BusinessPartner BusinessPartner { get; set; }

        public virtual ICollection<SalesInvoiceLine> SalesInvoiceLines { get; set; }
       
        #endregion
    }
}
