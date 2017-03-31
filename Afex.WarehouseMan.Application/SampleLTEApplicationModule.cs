using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Afex.WarehouseMan
{
    [DependsOn(typeof(SampleLTECoreModule), typeof(AbpAutoMapperModule))]
    public class SampleLTEApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            //{
            //    //Add your custom AutoMapper mappings here...
            //    //mapper.CreateMap<,>()
            //});
            Configuration.Modules.AbpAutoMapper().Configurators.Add(z => z.ForAllMaps((zz, yy) => zz.MaxDepth = 5));
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
