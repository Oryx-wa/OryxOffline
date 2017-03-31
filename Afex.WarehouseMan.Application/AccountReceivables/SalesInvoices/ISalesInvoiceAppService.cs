using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Afex.WarehouseMan.AccountReceivables.SalesInvoices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.AccountReceivables.SalesInvoices
{
    public interface ISalesInvoiceAppService : IApplicationService
    {
        Task CreateAsync(CreateSalesInvoiceInput input);

        Task UpdateAsync(UpdateSalesInvoiceInput input);

        IEnumerable<SalesInvoice> GetSalesInvoices();

        PagedResultDto<SalesInvoiceDto> GetSalesInvoicesPaged(SalesInvoiceListInput input);

        Task<SalesInvoiceDto> GetAsync(EntityDto input);

        Task<SalesInvoiceDto> GetSalesInvoiceByNo(string no);

        //ICollection<SalesInvoiceHeader> GetSalesInvoicesByCustomerId(int customerId, SalesInvoiceStatus status);

        //IEnumerable<SalesInvoiceHeader> GetCustomerInvoices(int customerId);

        PagedResultDto<SalesInvoiceDto> GetCustomerInvoicesPaged(EntityDto input);

        //Task SaveSalesInvoice(SalesInvoiceDto salesInvoice, SalesOrderDto salesOrder);

        //Task SaveSalesInvoice(SaveSalesInvoiceInput input);

        Task PostSalesInvoice(EntityDto input);
    }
}
