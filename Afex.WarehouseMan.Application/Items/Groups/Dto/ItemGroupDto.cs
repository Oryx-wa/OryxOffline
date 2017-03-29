using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Afex.WarehouseMan.Items.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.Items.Groups.Dto
{
    [AutoMapFrom(typeof(ItemGroup))]
    public class ItemGroupDto : CreationAuditedEntityDto
    {
        #region ctors

        public ItemGroupDto()
        {
            Items = new HashSet<ItemDto>();
        }

        #endregion

        #region Properties

        public int ItemGroupCode { get; set; }

        public string Name { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<ItemDto> Items { get; set; }

        #endregion
    }
}
