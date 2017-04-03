using Afex.WarehouseMan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables.SalesInvoices.Dto
{
    public class CreateSalesInvoiceInput
    {
        public int? DocEntryId { get; set; }

        public int? DocNum { get; set; }

        public DocumentTypes? DocType { get; set; }

        //public bool Cancelled { get; set; }

        //public bool Printed { get; set; }

        //public DateTime PostingDate { get; set; }

        //public DateTime DueDate { get; set; }

        public int CardCode { get; set; }

        public decimal TotalAmount { get; set; }

        public string Remarks { get; set; }

        public virtual ICollection<SalesInvoiceLine> SalesInvoiceLines { get; set; }
    }
}
