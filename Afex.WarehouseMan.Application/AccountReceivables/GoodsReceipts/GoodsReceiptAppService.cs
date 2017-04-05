using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Afex.WarehouseMan.AccountReceivables.GoodsReceipts.Dto;
using Abp.Domain.Repositories;
using Afex.WarehouseMan.BusinessPartners;
using Afex.WarehouseMan.Items;
using System.Data.Entity;
using Abp.Collections.Extensions;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Linq.Extensions;

namespace Afex.WarehouseMan.AccountReceivables.GoodsReceipts
{
    public class GoodsReceiptAppService : SampleLTEAppServiceBase, IGoodsReceiptAppService
    {
        private readonly IRepository<GoodsReceipt> _goodsReceiptRepo;
        private readonly IRepository<BusinessPartner> _businessPartnerRepo;
        private readonly IRepository<Item> _itemRepo;

        public GoodsReceiptAppService(IRepository<GoodsReceipt> goodsReceiptRepo,
            IRepository<BusinessPartner> businessPartnerRepo,
            IRepository<Item> itemRepo)
        {
            _goodsReceiptRepo = goodsReceiptRepo;
            _businessPartnerRepo = businessPartnerRepo;
            _itemRepo = itemRepo;
        }

        public async Task CreateAsync(CreateGoodsReceiptInput input)
        {
            var goodsReceipt = new GoodsReceipt
            {
                DocEntryId = input.DocEntryId,
                DocNum = input.DocNum,
                DocType = input.DocType,
                CardCode = input.CardCode,
                ContactPerson = input.ContactPerson,
                Amount = input.Amount,
                Remarks = input.Remarks
            };

            //decimal totalAmount = 0;

            //var businessPartner = await _businessPartnerRepo.GetAsync(goodsReceipt.CardCode);

            //int rowNumber = 0;
            foreach (var lineItem in input.GoodsReceiptLines)
            {
                //rowNumber++;
                var item = await _itemRepo.GetAsync(lineItem.Item.Id);
                //var lineAmount = lineItem.Quantity * lineItem.Price;

                //totalAmount += lineAmount;

                item.QuantityInStock = item.QuantityInStock + lineItem.Quantity;

                goodsReceipt.GoodsReceiptLines.Add(new GoodsReceiptLine
                {
                    GoodsReceiptId = goodsReceipt.Id,
                    GoodsReceiptDocEntryId = goodsReceipt.DocEntryId,
                    RowNumber = lineItem.RowNumber,
                    Status = Common.PurchaseOrderStatus.Open,
                    ItemId = item.Id,
                    Description = lineItem.Item.ItemName,
                    Quantity = lineItem.Quantity,
                    Price = lineItem.Item.UnitPrice,
                    LineTotal = lineItem.Quantity * lineItem.Item.UnitPrice
                });

                await _itemRepo.UpdateAsync(item);
            }

            await _goodsReceiptRepo.InsertAsync(goodsReceipt);
        }

        public async Task<GoodsReceiptDto> GetAsync(EntityDto input)
        {
            var salesReceipts = await _goodsReceiptRepo.GetAll()
                .Include(b => b.BusinessPartner)
                .Include(g => g.GoodsReceiptLines)
                .Where(s => s.Id == input.Id)
                .FirstOrDefaultAsync();

            return salesReceipts.MapTo<GoodsReceiptDto>();
        }

        public PagedResultDto<GoodsReceiptDto> GetGoodsReceiptsPaged(GoodsReceiptListInput input)
        {
            var goodsReceipts = _goodsReceiptRepo.GetAll()
                .Include(b => b.BusinessPartner)
                .Include(b => b.GoodsReceiptLines)
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), s => s.DocNum.Equals(input.Filter))
                .OrderBy(s => s.Id)
                .PageBy(input)
                .ToList();

            return new PagedResultDto<GoodsReceiptDto>
            {
                TotalCount = goodsReceipts.Count,
                Items = goodsReceipts.MapTo<List<GoodsReceiptDto>>()
            };
        }

        public Task UpdateAsync(UpdateGoodsReceiptInput input)
        {
            throw new NotImplementedException();
        }
    }
}
