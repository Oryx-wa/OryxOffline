﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountPayables.Dto
{
    public class PurchaseOrderListInput : IPagedResultRequest
    {
        public const int DefaultPageSize = 10;

        [Range(1, int.MaxValue)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public string Filter { get; set; }

        public PurchaseOrderListInput()
        {
            MaxResultCount = DefaultPageSize;
        }
    }
}
