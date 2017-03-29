using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables.GoodsReceipts.Dto
{
    public class CreateGoodsReceiptInput
    {
        public int DocEntryId { get; set; }

        public int DocNum { get; set; }

        public string DocType { get; set; }

        public int CardCode { get; set; }

        public DateTime PostingDate { get; set; }

        public DateTime DueDate { get; set; }

        public decimal Amount { get; set; }

        public string Remarks { get; set; }

        public virtual ICollection<GoodsReceiptLineDto> GoodsReceiptLines { get; set; }
    }
}
