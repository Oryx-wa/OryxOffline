﻿using Abp.Domain.Entities.Auditing;
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
    public class CreditMemoLine : CreationAuditedEntity
    {
        public CreditMemoLine()
        {
            PostingDate = Clock.Now;
            Status = PurchaseOrderStatus.Open;
        }

        #region Properties

        public int CreditMemoId { get; set; } //Foreign Key

        public int? CreditMemoDocEntryId { get; set; } //Foreign Key

        public int RowNumber { get; set; }

        [MaxLength(30), Column("Status")]
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

        #endregion

        #region Navigation Properties

        public virtual CreditMemo CreditMemo { get; set; }
        public virtual Item Item { get; set; }

        #endregion
    }
}
