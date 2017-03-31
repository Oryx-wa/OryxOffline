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
    public class GoodsReceipt : CreationAuditedEntity
    {
        #region ctors

        public GoodsReceipt()
        {
            GoodsReceiptLines = new HashSet<GoodsReceiptLine>();
        }

        #endregion

        #region Properties

        public int DocEntryId { get; set; }

        public int DocNum { get; set; }

        public string DocType { get; set; }

        public int CardCode { get; set; } //Foreign Key

        //[MaxLength(1), Column("Status")]
        //public string StatusString
        //{
        //    get { return Status.ToString(); }
        //    private set { Status = value.ParseEnum<PurchaseOrderStatus>(); }
        //}//create enum Field

        //[NotMapped]
        //public PurchaseOrderStatus Status { get; set; }

        //public DateTime PostingDate { get; set; }

        //public DateTime DueDate { get; set; }

        public decimal Amount { get; set; }

        public string Remarks { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<GoodsReceiptLine> GoodsReceiptLines { get; set; }
        public virtual BusinessPartner BusinessPartner { get; set; }

        #endregion
    }
}
