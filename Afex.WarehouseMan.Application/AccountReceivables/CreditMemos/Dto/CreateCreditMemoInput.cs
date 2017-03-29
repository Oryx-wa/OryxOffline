using Afex.WarehouseMan.AccountReceivables.CreditMemoLines.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables.CreditMemos.Dto
{
    public class CreateCreditMemoInput
    {
        public int DocEntryId { get; set; }

        public int DocNum { get; set; }

        public string DocTypeString { get; set; }

        //public bool? Cancelled { get; set; }

        //public bool? Printed { get; set; }

        //public string StatusString { get; private set; }

        //public PurchaseOrderStatus? Status { get; set; }

        public int CardCode { get; set; }

        public DateTime? DatePosted { get; set; }

        public DateTime? DueDate { get; set; }


        public string Remarks { get; set; }

        public virtual ICollection<CreditMemoLineDto> CreditMemoLines { get; set; }
    }
}
