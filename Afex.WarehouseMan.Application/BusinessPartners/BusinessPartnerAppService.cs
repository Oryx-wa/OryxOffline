using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Afex.WarehouseMan.BusinessPartners.Dto;
using Abp.Domain.Repositories;
using System.Linq.Expressions;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Extensions;
using Abp.Linq.Extensions;

namespace Afex.WarehouseMan.BusinessPartners
{
    public class BusinessPartnerAppService : SampleLTEAppServiceBase, IBusinessPartnerAppService
    {
        private readonly IRepository<BusinessPartner> _businessPartnerRepo;

        public BusinessPartnerAppService(IRepository<BusinessPartner> businessPartnerRepo)
        {
            _businessPartnerRepo = businessPartnerRepo;
        }

        public async Task CreateAsync(CreateBusinessPartnerInput input)
        {
            var businessPartner = new BusinessPartner
            {
                CardCode = input.CardCode,
                CardName = input.CardName,
                CardType = input.CardType,
                Location = input.Location,
                State = input.State,
                Country = input.Country,
                Phone = input.Phone,
                Email = input.Email,
                Website = input.Website,
                IsActive = input.IsActive,
                ContactPersonName = input.ContactPersonName,
                ContactPersonLastName = input.ContactPersonLastName,
                ContactEmail = input.ContactEmail,
                ContactPhone = input.ContactPhone
            };

            await _businessPartnerRepo.InsertAsync(businessPartner);
        }

        public Task DeleteAsync(EntityDto input)
        {
            throw new NotImplementedException();
        }

        public BusinessPartnerDto Get(EntityDto input)
        {
            Expression<Func<BusinessPartner, object>>[] includeProperties =
            {
                b => b.PurchaseOrders,
                b => b.SalesInvoices,
                b => b.GoodsReceipts,
                b => b.CreditMemos
            };

            var businessPartner = _businessPartnerRepo.GetAllIncluding(includeProperties)
                .Where(b => b.Id == input.Id).FirstOrDefault();

            return businessPartner.MapTo<BusinessPartnerDto>();
        }

        public PagedResultDto<BusinessPartnerDto> GetBusinessPartnersPaged(BusinessPartnerListInput input)
        {
            Expression<Func<BusinessPartner, object>>[] includeProperties =
            {
                b => b.PurchaseOrders,
                b => b.SalesInvoices,
                b => b.GoodsReceipts,
                b => b.CreditMemos
            };

            var businessPartners = _businessPartnerRepo.GetAllIncluding(includeProperties)
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), b => b.CardCode.Equals(input.Filter) || b.CardName.Contains(input.Filter))
                .OrderBy(b => b.Id)
                .PageBy(input).ToList();

            return new PagedResultDto<BusinessPartnerDto>
            {
                TotalCount = businessPartners.Count,
                Items = businessPartners.MapTo<List<BusinessPartnerDto>>()
            };
        }

        public IEnumerable<BusinessPartnerDto> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UpdateBusinessPartnerInput input)
        {
            var businessPartner = await _businessPartnerRepo.GetAsync(input.Id);

            if (businessPartner != null)
            {
                businessPartner.CardCode = input.CardCode;
                businessPartner.CardName = input.CardName;
                businessPartner.CardType = input.CardType;
                businessPartner.Location = input.Location;
                businessPartner.State = input.State;
                businessPartner.Country = input.Country;
                businessPartner.Phone = input.Phone;
                businessPartner.Email = input.Email;
                businessPartner.Website = input.Website;
                businessPartner.ContactPersonName = input.ContactPersonName;
                businessPartner.ContactPersonLastName = input.ContactPersonLastName;
                businessPartner.ContactEmail = input.ContactEmail;
                businessPartner.ContactPhone = input.ContactPhone;

                await _businessPartnerRepo.UpdateAsync(businessPartner);
            }
        }
    }
}
