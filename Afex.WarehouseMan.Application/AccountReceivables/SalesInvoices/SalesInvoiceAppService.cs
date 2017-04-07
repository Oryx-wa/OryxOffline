using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Afex.WarehouseMan.AccountReceivables.SalesInvoices.Dto;
using Abp.Domain.Repositories;
using Afex.WarehouseMan.BusinessPartners;
using Afex.WarehouseMan.Items;
using Abp.Timing;
using System.Data.Entity;
using Abp.Collections.Extensions;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.AutoMapper;
using Abp.Runtime.Validation;

namespace Afex.WarehouseMan.AccountReceivables.SalesInvoices
{
    public class SalesInvoiceAppService : ISalesInvoiceAppService
    {
        private readonly IRepository<SalesInvoice> _salesInvoiceRepo;
        private readonly IRepository<BusinessPartner> _businessPartnerRepo;
        private readonly IRepository<Item> _itemRepo;
        private readonly IItemAppService _itemService;
        

        public SalesInvoiceAppService(IRepository<SalesInvoice> salesInvoiceRepo,
            IRepository<BusinessPartner> businessPartnerRepo,
            IRepository<Item> itemRepo,
            IItemAppService itemService)
        {
            _salesInvoiceRepo = salesInvoiceRepo;
            _businessPartnerRepo = businessPartnerRepo;
            _itemRepo = itemRepo;
            _itemService = itemService;
        }

        //[DisableValidation]
        public async Task CreateAsync(CreateSalesInvoiceInput input)
        {
            var salesInvoice = new SalesInvoice
            {
                DocEntryId = input.DocEntryId,
                DocNum = input.DocNum,
                PostingDate = Clock.Now,
                DueDate = Clock.Now,
                CardCode = input.CardCode,
                Status = Common.PurchaseOrderStatus.Open,
                TotalAmount = input.TotalAmount,
                Remarks = input.Remarks,
                //SalesInvoiceLines = input.SalesInvoiceLines
            };

            //decimal totalAmount = 0;

            var businessPartner = await _businessPartnerRepo.GetAsync(salesInvoice.CardCode);

            //int rowNumber = 0;
            foreach (var lineItem in input.SalesInvoiceLines)
            {
                //rowNumber++;
                var item = await _itemRepo.GetAsync(lineItem.Item.Id);
                //var lineAmount = lineItem.Quantity * lineItem.Item.UnitPrice;

                //totalAmount += lineAmount;

                item.QuantityInStock = item.QuantityInStock - lineItem.Quantity;

                salesInvoice.SalesInvoiceLines.Add(new SalesInvoiceLine
                {
                    SalesInvoiceId = salesInvoice.Id,
                    SalesInvoiceDocEntryId = salesInvoice.DocEntryId,
                    RowNumber = lineItem.RowNumber,
                    //Status = Common.PurchaseOrderStatus.Open,
                    ItemId = item.Id,
                    Description = lineItem.Item.ItemName,
                    Quantity = lineItem.Quantity,
                    //Discount = 0,
                    Price = lineItem.Item.UnitPrice,
                    LineTotal = lineItem.Quantity * lineItem.Item.UnitPrice,
                    //PostingDate = Clock.Now
                });

                await _itemRepo.UpdateAsync(item);
            }

            await _salesInvoiceRepo.InsertAsync(salesInvoice);
        }

        public async Task<SalesInvoiceDto> GetAsync(EntityDto input)
        {
            var salesInvoice = await _salesInvoiceRepo.GetAll()
               .Include(inv => inv.BusinessPartner)
               .Include(inv => inv.SalesInvoiceLines)
               .Where(inv => inv.Id == input.Id)
               .FirstOrDefaultAsync();

            return salesInvoice.MapTo<SalesInvoiceDto>();
        }

        public PagedResultDto<SalesInvoiceDto> GetCustomerInvoicesPaged(EntityDto input)
        {
            throw new NotImplementedException();
        }

        public Task<SalesInvoiceDto> GetSalesInvoiceByNo(string no)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesInvoice> GetSalesInvoices()
        {
            throw new NotImplementedException();
        }

        public PagedResultDto<SalesInvoiceDto> GetSalesInvoicesPaged(SalesInvoiceListInput input)
        {
            var salesInvoices = _salesInvoiceRepo.GetAll()
               .Include(inv => inv.BusinessPartner)
               .Include(inv => inv.SalesInvoiceLines)
               .WhereIf(!input.Filter.IsNullOrWhiteSpace(), inv => inv.DocNum.Equals(int.Parse(input.Filter)))
               .OrderBy(inv => inv.Id)
               .PageBy(input)
               .ToList();

            return new PagedResultDto<SalesInvoiceDto>
            {
                TotalCount = salesInvoices.Count,
                Items = salesInvoices.MapTo<List<SalesInvoiceDto>>()
            };
        }

        public Task PostSalesInvoice(EntityDto input)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateSalesInvoiceInput input)
        {
            throw new NotImplementedException();
        }
    }
}
