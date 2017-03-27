using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SampleLTE.MultiTenancy.Dto;

namespace SampleLTE.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
