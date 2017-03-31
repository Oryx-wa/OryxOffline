using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Afex.WarehouseMan.BusinessPartners.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.BusinessPartners
{
    public interface IBusinessPartnerAppService : IApplicationService
    {
        Task CreateAsync(CreateBusinessPartnerInput input);

        Task UpdateAsync(UpdateBusinessPartnerInput input);

        Task DeleteAsync(EntityDto input);

        BusinessPartnerDto Get(EntityDto input);

        IEnumerable<BusinessPartnerDto> GetCustomers();

        PagedResultDto<BusinessPartnerDto> GetBusinessPartnersPaged(BusinessPartnerListInput input);
    }
}
