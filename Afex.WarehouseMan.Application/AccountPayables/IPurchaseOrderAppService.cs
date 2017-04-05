using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Afex.WarehouseMan.AccountPayables.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountPayables
{
    public interface IPurchaseOrderAppService : IApplicationService
    {
        Task CreateAsync(CreatePurchaseOrderInput input);

        Task UpdateAsync(UpdatePurchaseOrderInput input);

        PagedResultDto<PurchaseOrderDto> GetPurchaseOrdersPaged(PurchaseOrderListInput input);

        Task<PurchaseOrderDto> GetAsync(EntityDto input);
    }
}
