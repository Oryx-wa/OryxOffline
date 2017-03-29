using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables.SalesInvoices.Dto
{
    public class UpdateSalesInvoiceInput : EntityDto
    {
        public int DocEntryId { get; set; }

        public int DocNum { get; set; }

        public string DocTypeString { get; set; }

        //public bool Cancelled { get; set; }

        //public bool Printed { get; set; }

        public DateTime PostingDate { get; set; }

        public DateTime DueDate { get; set; }

        public int CardCode { get; set; }

        public decimal TotalAmount { get; set; }

        public string Remarks { get; set; }

        public virtual ICollection<SalesInvoiceLineDto> SalesInvoiceLines { get; set; }
    }
}
