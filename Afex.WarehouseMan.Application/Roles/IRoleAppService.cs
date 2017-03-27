using System.Threading.Tasks;
using Abp.Application.Services;
using SampleLTE.Roles.Dto;

namespace SampleLTE.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
