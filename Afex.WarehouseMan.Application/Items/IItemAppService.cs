using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Afex.WarehouseMan.Items.Dto;
using Afex.WarehouseMan.Items.Groups.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.Items
{
    public interface IItemAppService : IApplicationService
    {
        Task CreateAsync(CreateItemInput input);

        Task UpdateAsync(UpdateItemInput input);

        Task DeleteAsync(EntityDto input);

        Task<ItemDto> GetAsync(EntityDto input);

        PagedResultDto<ItemDto> GetItemsList(ItemListInput input);

        Task<ListResultDto<ItemDto>> GetAllItems();

        Task CreateItemGroupAsync(CreateItemGroupInput input);

        Task UpdateItemGroupAsync(UpdateItemGroupInput input);

        Task DeleteItemGroupAsync(EntityDto input);

        ListResultDto<ItemGroupDto> GetItemGroupsList();

        Task<ItemGroupDto> GetItemGroupAsync(EntityDto input);
    }
}
