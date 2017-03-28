using Abp.Domain.Entities.Auditing;
using Afex.WarehouseMan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.Items
{
    public class ItemGroup : CreationAuditedEntity
    {
        #region ctors

        public ItemGroup()
        {
            Items = new HashSet<Item>();
        }

        #endregion

        #region Properties

        public int ItemGroupCode { get; set; }

        public string Name { get; set; }

        #endregion

        #region Navigation Properties
        
        public virtual ICollection<Item> Items { get; set; }

        #endregion
    }
}
