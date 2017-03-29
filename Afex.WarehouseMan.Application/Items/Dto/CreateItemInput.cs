using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.Items.Dto
{
    public class CreateItemInput
    {
        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public int? ItemGroupId { get; set; }

        public int QuantityInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal UnitCost { get; set; }

        public string Remarks { get; set; }
    }
}
