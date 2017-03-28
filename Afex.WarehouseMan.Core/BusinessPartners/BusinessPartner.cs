using Abp.Domain.Entities.Auditing;
using Afex.WarehouseMan.AccountPayables;
using Afex.WarehouseMan.AccountReceivables;
using Afex.WarehouseMan.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.BusinessPartners
{
    public class BusinessPartner : CreationAuditedEntity
    {
        #region ctors

        public BusinessPartner()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            SalesInvoices = new HashSet<SalesInvoice>();
            GoodsReceipts = new HashSet<GoodsReceipt>();
            CreditMemos = new HashSet<CreditMemo>();
        }

        #endregion

        #region Properties

        public string CardCode { get; set; }

        public string CardName { get; set; }

        [Column("CardType")]
        public string CardTypeString
        {
            get { return CardType.ToString(); }
            private set { CardType = value.ParseEnum<CardTypes>(); }
        }//enum Field to be created here

        [NotMapped]
        public CardTypes? CardType { get; set; }

        public string Location { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string ContactPerson { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        public virtual ICollection<SalesInvoice> SalesInvoices { get; set; }

        public virtual ICollection<GoodsReceipt> GoodsReceipts { get; set; }

        public virtual ICollection<CreditMemo> CreditMemos { get; set; }

        #endregion
    }
}
