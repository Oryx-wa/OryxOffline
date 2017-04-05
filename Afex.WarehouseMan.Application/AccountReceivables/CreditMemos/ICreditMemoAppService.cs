using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Afex.WarehouseMan.AccountReceivables.CreditMemos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables.CreditMemos
{
    public interface ICreditMemoAppService : IApplicationService
    {
        Task CreateAsync(CreateCreditMemoInput input);

        Task UpdateAsync(UpdateCreditMemoInput input);

        PagedResultDto<CreditMemoDto> GetCreditNotesPaged(CreditMemoListInput input);

        Task<CreditMemoDto> GetAsync(EntityDto input);
    }
}
