using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Afex.WarehouseMan.AccountPayables.Dto;
using Abp.Domain.Repositories;
using Afex.WarehouseMan.Items;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Extensions;
using Abp.Linq.Extensions;

namespace Afex.WarehouseMan.AccountPayables
{
    public class PurchaseOrderAppService : IPurchaseOrderAppService
    {
        private readonly IRepository<PurchaseOrder> _purchaseOrderRepo;
        private readonly IRepository<Item> _itemRepo;

        public PurchaseOrderAppService(IRepository<PurchaseOrder> purchaseOrderRepo,
            IRepository<Item> itemRepo)
        {
            _purchaseOrderRepo = purchaseOrderRepo;
            _itemRepo = itemRepo;
        }

        public async Task CreateAsync(CreatePurchaseOrderInput input)
        {
            var purchaseOrder = new PurchaseOrder
            {
                DocEntryId = input.DocEntryId,
                DocNum = input.DocNum,
                CardCode = input.CardCode,
                TotalAmount = input.TotalAmount,
                Remarks = input.Remarks
            };

            foreach (var lineItem in input.PurchaseOrderLines)
            {
                //var item = await _itemRepo.GetAsync(lineItem.Item.Id);

                //item.QuantityInStock = item.QuantityInStock + lineItem.Quantity.Value;
                purchaseOrder.PurchaseOrderLines.Add(new PurchaseOrderLine
                {
                    PurchaseOrderId = purchaseOrder.Id,
                    PurchaseOrderDocEntryId = purchaseOrder.DocEntryId,
                    RowNumber = lineItem.RowNumber,
                    ItemId = lineItem.Item.Id,
                    Description = lineItem.Item.ItemName,
                    Quantity = lineItem.Quantity,
                    Price = lineItem.Item.UnitPrice,
                    LineTotal = lineItem.Quantity * lineItem.Item.UnitPrice
                });
            }

            await _purchaseOrderRepo.InsertAsync(purchaseOrder);
        }

        public async Task<PurchaseOrderDto> GetAsync(EntityDto input)
        {
            var purchaseOrder = await _purchaseOrderRepo.GetAll()
                .Include(b => b.BusinessPartner)
                .Include(g => g.PurchaseOrderLines)
                .Where(s => s.Id == input.Id)
                .FirstOrDefaultAsync();

            return purchaseOrder.MapTo<PurchaseOrderDto>();
        }

        public PagedResultDto<PurchaseOrderDto> GetPurchaseOrdersPaged(PurchaseOrderListInput input)
        {
            var purchaseOrders = _purchaseOrderRepo.GetAll()
                .Include(b => b.BusinessPartner)
                .Include(g => g.PurchaseOrderLines)
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), s => s.DocNum.Equals(input.Filter))
                .OrderBy(s => s.Id)
                .PageBy(input)
                .ToList();

            return new PagedResultDto<PurchaseOrderDto>
            {
                TotalCount = purchaseOrders.Count,
                Items = purchaseOrders.MapTo<List<PurchaseOrderDto>>()
            };
        }

        public Task UpdateAsync(UpdatePurchaseOrderInput input)
        {
            throw new NotImplementedException();
        }
    }
}
