using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.Common
{
    public enum PartyTypes
    {
        Customer = 1,
        Vendor = 2,
        Contact = 3
    }

    public enum DocumentTypes
    {
        [Display(Name = "Item")]
        I = 1,

        [Display(Name = "Service")]
        S = 2
    }

    public enum PurchaseOrderStatus
    {
        Draft = 0,
        Open = 1,
        PartiallyReceived = 2,
        FullReceived = 3,
        Invoiced = 4,
        Closed = 5
    }

    public enum PurchaseInvoiceStatus
    {
        Draft = 0,
        Open = 1,
        Paid = 2
    }

    public enum ContactTypes
    {
        Customer = 1,
        Vendor = 2,
        Company = 3
    }

    public enum ItemTypes
    {
        Manufactured = 1,
        Purchased,
        Service,
        Charge
    }

    public enum CardTypes
    {
        [Display(Name = "Customer")]
        C = 1,
        [Display(Name = "Vendor")]
        S = 2,
        [Display(Name = "Lead")]
        L = 3
    }

    public enum PaymentTypes
    {
        Prepaymnet = 1,
        Cash,
        AfterNoOfDays,
        DayInTheFollowingMonth
    }

    public enum BankTypes
    {
        CheckingAccount = 1,
        SavingsAccount,
        CashAccount
    }

    public enum SalesInvoiceStatus
    {
        Draft,
        Open = 1,
        Overdue,
        Closed,
        Void
    }

    public enum SalesOrderStatus
    {
        Draft = 0,
        Open = 1,
        Overdue = 2,
        Closed = 3,
        Void = 4,
        PartiallyInvoiced = 5,
        FullyInvoiced = 6
    }

    public enum SalesQuoteStatus
    {
        Draft = 0,
        Open = 1,
        Overdue = 2,
        Closed = 3,
        Void = 4,
        [Display(Name = "Closed - Order Created")]
        ClosedOrderCreated = 5
    }
}
