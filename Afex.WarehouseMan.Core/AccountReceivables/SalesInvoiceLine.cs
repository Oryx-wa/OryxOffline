using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Afex.WarehouseMan.Common;
using Afex.WarehouseMan.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables
{
    public class SalesInvoiceLine : CreationAuditedEntity
    {
        public SalesInvoiceLine()
        {
            Status = PurchaseOrderStatus.Open;
            PostingDate = Clock.Now;
        }

        public int SalesInvoiceId { get; set; } //Foreign Key

        public int? SalesInvoiceDocEntryId { get; set; } //Foreign Key

        public int RowNumber { get; set; }

        [MaxLength(10), Column("Status")]
        public string StatusString
        {
            get { return Status.ToString(); }
            private set { Status = value.ParseEnum<PurchaseOrderStatus>(); }
        }//create enum Field

        [NotMapped]
        public PurchaseOrderStatus Status { get; set; }

        public int ItemId { get; set; } //Foreign Key

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal? Discount { get; set; }

        public decimal Price { get; set; }

        public decimal LineTotal { get; set; }

        public DateTime PostingDate { get; set; }

        #region Navigation Properties

        public virtual SalesInvoice SalesInvoice { get; set; }
        public virtual Item Item { get; set; }

        #endregion
    }
}
