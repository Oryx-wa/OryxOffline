using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Afex.WarehouseMan.Items.Dto;
using Abp.Domain.Repositories;
using Afex.WarehouseMan.Items.Groups.Dto;
using Abp.AutoMapper;
using System.Data.Entity;
using Abp.Collections.Extensions;
using Abp.Extensions;
using Abp.Linq.Extensions;

namespace Afex.WarehouseMan.Items
{
    public class ItemAppService : SampleLTEAppServiceBase, IItemAppService
    {
        private readonly IRepository<Item> _itemRepo;
        private readonly IRepository<ItemGroup> _itemGroupRepo;

        public ItemAppService(IRepository<Item> itemRepo, IRepository<ItemGroup> itemGroupRepo)
        {
            _itemGroupRepo = itemGroupRepo;
            _itemRepo = itemRepo;
        }

        public async Task CreateAsync(CreateItemInput input)
        {
            if (input.ItemGroupId.HasValue)
            {
                var itemGroup = await _itemGroupRepo.GetAsync(input.ItemGroupId.Value);
                itemGroup.Items.Add(new Item
                {
                    ItemCode = input.ItemCode,
                    ItemName = input.ItemName,
                    ItemGroupId = input.ItemGroupId,
                    QuantityInStock = input.QuantityInStock,
                    UnitPrice = input.UnitPrice,
                    UnitCost = input.UnitCost,
                    Remarks = input.Remarks
                });

                await _itemGroupRepo.UpdateAsync(itemGroup);
            }
            else
            {
                var item = new Item
                {
                    ItemCode = input.ItemCode,
                    ItemName = input.ItemName,
                    ItemGroupId = input.ItemGroupId,
                    QuantityInStock = input.QuantityInStock,
                    UnitPrice = input.UnitPrice,
                    UnitCost = input.UnitCost,
                    Remarks = input.Remarks
                };

                await _itemRepo.InsertAsync(item);
            }
            
        }

        public async Task DeleteAsync(EntityDto input)
        {
            await _itemRepo.DeleteAsync(input.Id);
        }

        public IEnumerable<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public async Task<ItemDto> GetAsync(EntityDto input)
        {
            var item = await _itemRepo.GetAll()
                .Include(i => i.ItemGroup)
                .Where(i => i.Id == input.Id)
                .FirstOrDefaultAsync();

            return item.MapTo<ItemDto>();
        }

        public PagedResultDto<ItemDto> GetItemsList(ItemListInput input)
        {
            var itemList = _itemRepo.GetAll()
                .Include(g => g.ItemGroup)
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), i => i.ItemCode.Equals(input.Filter) || 
                    i.ItemName.Contains(input.Filter))
                .OrderBy(i => i.Id)
                .PageBy(input)
                .ToList();

            return new PagedResultDto<ItemDto>
            {
                TotalCount = itemList.Count,
                Items = itemList.MapTo<List<ItemDto>>()
            };
        }

        public async Task UpdateAsync(UpdateItemInput input)
        {
            var item = await _itemRepo.GetAsync(input.Id);

            if (item != null)
            {
                item.ItemCode = input.ItemCode;
                item.ItemName = input.ItemName;
                item.ItemGroupId = input.ItemGroupId;
                item.QuantityInStock = input.QuantityInStock;
                item.UnitPrice = input.UnitPrice;
                item.UnitCost = input.UnitCost;
                item.Remarks = input.Remarks;

                await _itemRepo.UpdateAsync(item);
            }
        }

        public async Task CreateItemGroupAsync(CreateItemGroupInput input)
        {
            var itemGroup = new ItemGroup
            {
                ItemGroupCode = input.ItemGroupCode,
                Name = input.Name
            };

            await _itemGroupRepo.InsertAsync(itemGroup);
        }

        public async Task UpdateItemGroupAsync(UpdateItemGroupInput input)
        {
            var itemGroup = await _itemGroupRepo.GetAsync(input.Id);
            if (itemGroup != null)
            {
                itemGroup.ItemGroupCode = input.ItemGroupCode;
                itemGroup.Name = input.Name;

                await _itemGroupRepo.UpdateAsync(itemGroup);
            }
        }

        public async Task DeleteItemGroupAsync(EntityDto input)
        {
            await _itemGroupRepo.DeleteAsync(input.Id);
        }

        public ListResultDto<ItemGroupDto> GetItemGroupsList()
        {
            var itemGroups = _itemGroupRepo.GetAll()
                .Include(ig => ig.Items)
                .OrderBy(ig => ig.Id)
                .ToList();

            return new ListResultDto<ItemGroupDto>(itemGroups.MapTo<List<ItemGroupDto>>());
        }

        public async Task<ItemGroupDto> GetItemGroupAsync(EntityDto input)
        {
            var itemGroup = await _itemGroupRepo.GetAll()
                .Include(ig => ig.Items)
                .Where(ig => ig.Id == input.Id)
                .FirstOrDefaultAsync();

            return itemGroup.MapTo<ItemGroupDto>();
        }
    }
}
