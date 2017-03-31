(function () {
    angular.module('app').controller('app.views.customers.index', [
        '$scope', 'abp.services.app.businessPartner', function ($scope, customerService) {
            var vm = this;

            vm.businessPartners = [];

            vm.loadBusinessPartners = function () {
                abp.ui.setBusy(null,
                    customerService.getBusinessPartnersPaged({}).success(function (data) {
                        vm.businessPartners = data.items;
                    })
                );
            }

            vm.loadBusinessPartners();
            //vm.customers = [{
            //    "customerId": 1,
            //    "customerCode": "Cus_1",
            //    "fullName": "John Doe",
            //    "customerGroup": "Some Group",
            //    "isActive": true
            //},
            //{
            //    "customerId": 2,
            //    "customerCode": "Cus_2",
            //    "fullName": "James Blunt",
            //    "customerGroup": "Some Group",
            //    "isActive": true
            //},
            //{
            //    "customerId": 3,
            //    "customerCode": "Cus_3",
            //    "fullName": "Mick Foley",
            //    "customerGroup": "Some Group",
            //    "isActive": true
            //},
            //{
            //    "customerId": 4,
            //    "customerCode": "Cus_4",
            //    "fullName": "Mike Epps",
            //    "customerGroup": "Some Group",
            //    "isActive": true
            //}];
        }
    ]);
})();
