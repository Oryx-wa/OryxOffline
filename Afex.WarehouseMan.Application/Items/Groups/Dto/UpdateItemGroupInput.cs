using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.Items.Groups.Dto
{
    public class UpdateItemGroupInput : EntityDto
    {
        public int ItemGroupCode { get; set; }

        public string Name { get; set; }
    }
}
