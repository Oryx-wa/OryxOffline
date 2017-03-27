using Abp.Authorization;
using SampleLTE.Authorization.Roles;
using SampleLTE.MultiTenancy;
using SampleLTE.Users;

namespace SampleLTE.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
