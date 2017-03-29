using System.Threading.Tasks;
using Abp.Application.Services;
using Afex.WarehouseMan.Roles.Dto;

namespace Afex.WarehouseMan.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
