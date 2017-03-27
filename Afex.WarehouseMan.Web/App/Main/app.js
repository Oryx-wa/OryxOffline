(function () {
    'use strict';
    
    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

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
                    .state('customers', {
                        url: '/customers',
                        templateUrl: '/App/Main/views/customers/index.cshtml',
                        menu: 'Customers' //Matches to name of 'Users' menu in SampleLTENavigationProvider
                    })
                    .state('newCustomer', {
                        url: '/customers/newCustomer',
                        templateUrl: '/App/Main/views/customers/newCustomer.cshtml',
                        menu: 'Customers' //Matches to name of 'Users' menu in SampleLTENavigationProvider
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