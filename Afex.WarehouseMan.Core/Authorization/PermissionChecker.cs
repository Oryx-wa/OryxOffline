using Abp.Authorization;
using Afex.WarehouseMan.Authorization.Roles;
using Afex.WarehouseMan.MultiTenancy;
using Afex.WarehouseMan.Users;

namespace Afex.WarehouseMan.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
