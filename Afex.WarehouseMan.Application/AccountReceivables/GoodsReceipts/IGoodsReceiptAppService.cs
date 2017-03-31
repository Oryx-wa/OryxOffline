using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Afex.WarehouseMan.AccountReceivables.GoodsReceipts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables.GoodsReceipts
{
    public interface IGoodsReceiptAppService : IApplicationService
    {
        Task CreateAsync(CreateGoodsReceiptInput input);

        Task UpdateAsync(UpdateGoodsReceiptInput input);

        PagedResultDto<GoodsReceiptDto> GetGoodsReceiptsPaged(GoodsReceiptListInput input);

        Task<GoodsReceiptDto> GetAsync(EntityDto input);
    }
}
