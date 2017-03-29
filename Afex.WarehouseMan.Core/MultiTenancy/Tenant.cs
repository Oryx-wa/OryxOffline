using Abp.MultiTenancy;
using Afex.WarehouseMan.Users;

namespace Afex.WarehouseMan.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}