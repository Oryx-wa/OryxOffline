using Abp.Domain.Entities.Auditing;
using SampleLTE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLTE.Items
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
