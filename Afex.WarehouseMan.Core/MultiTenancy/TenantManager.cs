using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Afex.WarehouseMan.Editions;
using Afex.WarehouseMan.Users;

namespace Afex.WarehouseMan.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore
            ) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore
            )
        {
        }
    }
}