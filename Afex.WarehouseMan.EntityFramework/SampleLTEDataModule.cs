﻿using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Afex.WarehouseMan.EntityFramework;

namespace Afex.WarehouseMan
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(SampleLTECoreModule))]
    public class SampleLTEDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SampleLTEDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
