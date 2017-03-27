using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using SampleLTE.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace SampleLTE.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SampleLTE.EntityFramework.SampleLTEDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SampleLTE";
        }

        protected override void Seed(SampleLTE.EntityFramework.SampleLTEDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
