﻿using Afex.WarehouseMan.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Afex.WarehouseMan.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly SampleLTEDbContext _context;

        public InitialHostDbBuilder(SampleLTEDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
