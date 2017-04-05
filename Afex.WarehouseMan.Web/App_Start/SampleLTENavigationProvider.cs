﻿using Abp.Application.Navigation;
using Abp.Localization;
using Afex.WarehouseMan.Authorization;

namespace Afex.WarehouseMan.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class SampleLTENavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", SampleLTEConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "#tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "AccountReceivables",
                        L("AccountReceivables"),
                        icon: "fa fa-industry",
                        requiredPermissionName: PermissionNames.Pages_Users
                        ).AddItem(new MenuItemDefinition("SalesInvoices",
                            L("SalesInvoices"),
                            url: "#salesInvoices"
                            )
                        ).AddItem(new MenuItemDefinition("GoodsReceipts",
                            L("GoodsReceipts"),
                            url: "#goodsReceipts"
                            )
                        ).AddItem(new MenuItemDefinition("CreditNotes",
                            L("CreditNotes"),
                            url: "#creditNotes"
                            )
                        ).AddItem(
                            new MenuItemDefinition("Customers",
                            L("Customers"),
                            url: "#customers"
                            )
                        ).AddItem(
                            new MenuItemDefinition("Items",
                            L("Items"),
                            url: "#items"
                            )
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "AccountPayables",
                        L("AccountPayables"),
                        icon: "fa fa-anchor",
                        requiredPermissionName: PermissionNames.Pages_Users
                        ).AddItem(
                            new MenuItemDefinition(
                                "PurchaseOrders",
                                L("PurchaseOrders"),
                                url: "#purchaseOrders"
                                )
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", SampleLTEConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SampleLTEConsts.LocalizationSourceName);
        }
    }
}
