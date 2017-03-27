(function () {
    angular.module('app').controller('app.views.customers.index', [
        '$scope', function ($scope) {
            var vm = this;

            vm.customers = [{
                "customerId": 1,
                "customerCode": "Cus_1",
                "fullName": "John Doe",
                "customerGroup": "Some Group",
                "isActive": true
            },
            {
                "customerId": 2,
                "customerCode": "Cus_2",
                "fullName": "James Blunt",
                "customerGroup": "Some Group",
                "isActive": true
            },
            {
                "customerId": 3,
                "customerCode": "Cus_3",
                "fullName": "Mick Foley",
                "customerGroup": "Some Group",
                "isActive": true
            },
            {
                "customerId": 4,
                "customerCode": "Cus_4",
                "fullName": "Mike Epps",
                "customerGroup": "Some Group",
                "isActive": true
            }];
        }
    ]);
})();
