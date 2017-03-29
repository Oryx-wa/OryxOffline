using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Afex.WarehouseMan.EntityFramework;

namespace Afex.WarehouseMan.Migrator
{
    [DependsOn(typeof(SampleLTEDataModule))]
    public class SampleLTEMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<SampleLTEDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}