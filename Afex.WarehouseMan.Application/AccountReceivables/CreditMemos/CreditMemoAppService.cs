using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Afex.WarehouseMan.AccountReceivables.CreditMemos.Dto;
using Abp.Domain.Repositories;
using Afex.WarehouseMan.Items;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Extensions;
using Abp.Linq.Extensions;

namespace Afex.WarehouseMan.AccountReceivables.CreditMemos
{
    public class CreditMemoAppService : ICreditMemoAppService
    {
        private readonly IRepository<CreditMemo> _creditNoteRepo;
        private readonly IRepository<Item> _itemRepo;

        public CreditMemoAppService(IRepository<CreditMemo> creditNoteRepo,
            IRepository<Item> itemRepo)
        {
            _creditNoteRepo = creditNoteRepo;
            _itemRepo = itemRepo;
        }

        public async Task CreateAsync(CreateCreditMemoInput input)
        {
            var creditNote = new CreditMemo
            {
                DocEntryId = input.DocEntryId,
                DocNum = input.DocNum,
                CardCode = input.CardCode,
                ContactPerson = input.ContactPerson,
                TotalAmount = input.TotalAmount,
                Remarks = input.Remarks
            };

            foreach(var lineItem in input.CreditMemoLines)
            {
                var item = await _itemRepo.GetAsync(lineItem.Item.Id);

                item.QuantityInStock = item.QuantityInStock + lineItem.Quantity;

                creditNote.CreditMemoLines.Add(new CreditMemoLine
                {
                    CreditMemoId = creditNote.Id,
                    CreditMemoDocEntryId = creditNote.DocEntryId,
                    RowNumber = lineItem.RowNumber,
                    ItemId = item.Id,
                    Description = lineItem.Item.ItemName,
                    Quantity = lineItem.Quantity,
                    Price = lineItem.Item.UnitPrice,
                    LineTotal = lineItem.Quantity * lineItem.Item.UnitPrice
                });

                await _itemRepo.UpdateAsync(item);
            }

            await _creditNoteRepo.InsertAsync(creditNote);
        }

        public async Task<CreditMemoDto> GetAsync(EntityDto input)
        {
            var creditNote = await _creditNoteRepo.GetAll()
                .Include(b => b.BusinessPartner)
                .Include(g => g.CreditMemoLines)
                .Where(s => s.Id == input.Id)
                .FirstOrDefaultAsync();

            return creditNote.MapTo<CreditMemoDto>();
        }

        public PagedResultDto<CreditMemoDto> GetCreditNotesPaged(CreditMemoListInput input)
        {
            var creditNotes = _creditNoteRepo.GetAll()
                .Include(b => b.BusinessPartner)
                .Include(g => g.CreditMemoLines)
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), s => s.DocNum.Equals(input.Filter))
                .OrderBy(c => c.Id)
                .PageBy(input)
                .ToList();

            return new PagedResultDto<CreditMemoDto>
            {
                TotalCount = creditNotes.Count,
                Items = creditNotes.MapTo<List<CreditMemoDto>>()
            };
        }

        public Task UpdateAsync(UpdateCreditMemoInput input)
        {
            throw new NotImplementedException();
        }
    }
}
