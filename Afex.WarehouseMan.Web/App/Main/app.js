(function () {
    'use strict';
    
    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',
        'ui.select',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');

            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('salesInvoices', {
                        url: '/salesInvoices',
                        templateUrl: '/App/Main/views/sales/arInvoices.cshtml',
                        menu: 'SalesInvoices' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('addSalesInvoice', {
                        url: '/salesInvoices/addNew',
                        templateUrl: '/App/Main/views/sales/addARInvoice.cshtml',
                        menu: 'SalesInvoices' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('salesInvoiceDetail', {
                        url: '/salesInvoices/:id',
                        templateUrl: '/App/Main/views/sales/arInvoice.cshtml',
                        menu: 'SalesInvoices' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('customers', {
                        url: '/customers',
                        templateUrl: '/App/Main/views/customers/index.cshtml',
                        menu: 'Customers' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('newCustomer', {
                        url: '/customers/newCustomer',
                        templateUrl: '/App/Main/views/customers/newCustomer.cshtml',
                        menu: 'Customers' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('items', {
                        url: '/items',
                        templateUrl: '/App/Main/views/items/index.cshtml',
                        menu: 'Items' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('newItem', {
                        url: '/items/newItem',
                        templateUrl: '/App/Main/views/items/newitem.cshtml',
                        menu: 'Items' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('goodsReceipts', {
                        url: '/goodsReceipts',
                        templateUrl: '/App/Main/views/sales/goodsReceipts.cshtml',
                        menu: 'GoodsReceipts' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('newGoodsReceipt', {
                        url: '/goodsReceipts/addNew',
                        templateUrl: '/App/Main/views/sales/addGoodsReceipt.cshtml',
                        menu: 'GoodsReceipts' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('goodsReceiptDetail', {
                        url: '/goodsReceipts/:id',
                        templateUrl: '/App/Main/views/sales/goodsReceipt.cshtml',
                        menu: 'GoodsReceipts' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('purchaseOrders', {
                        url: '/purchaseOrders',
                        templateUrl: '/App/Main/views/purchases/purchaseOrders.cshtml',
                        menu: 'PurchaseOrders' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('newPurchaseOrder', {
                        url: '/purchaseOrders/addNew',
                        templateUrl: '/App/Main/views/purchases/addPurchaseOrder.cshtml',
                        menu: 'PurchaseOrders' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('purchaseOrderDetail', {
                        url: '/purchaseOrders/:id',
                        templateUrl: '/App/Main/views/purchases/purchaseOrder.cshtml',
                        menu: 'PurchaseOrders' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('creditNotes', {
                        url: '/creditNotes',
                        templateUrl: '/App/Main/views/sales/creditNotes.cshtml',
                        menu: 'CreditNotes' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('newCreditNote', {
                        url: '/creditNotes/addNew',
                        templateUrl: '/App/Main/views/sales/addCreditNote.cshtml',
                        menu: 'CreditNotes' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('creditNoteDetail', {
                        url: '/creditNotes/:id',
                        templateUrl: '/App/Main/views/sales/creditNote.cshtml',
                        menu: 'CreditNotes' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    });
                $urlRouterProvider.otherwise('/');
            }

            if (abp.auth.hasPermission('Pages.Tenants')) {
                $stateProvider
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in SampleLTENavigationProvider
                    });
                $urlRouterProvider.otherwise('/');
            }

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in SampleLTENavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in SampleLTENavigationProvider
                });
        }
    ]);
})();