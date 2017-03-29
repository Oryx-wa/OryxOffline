using Afex.WarehouseMan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountPayables.Dto
{
    public class CreatePurchaseOrderInput
    {
        public int DocEntryId { get; set; }

        public int DocNum { get; set; }

        public DocumentTypes DocumentType { get; set; }

        //public PurchaseOrderStatus? Status { get; set; }

        public int CardCode { get; set; }

        public decimal? TotalAmount { get; set; }

        public string Remarks { get; set; }

        public DateTime? PostingDate { get; set; }

        public DateTime? DueDate { get; set; }

        public virtual ICollection<PurchaseOrderLineDto> PurchaseOrderLineDto { get; set; }
    }
}
