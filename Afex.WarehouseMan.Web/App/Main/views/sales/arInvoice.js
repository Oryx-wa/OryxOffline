(function () {
    'use strict';

    angular.module('app').controller('app.views.saleInvoices.detail', [
        '$scope', '$state', '$stateParams', 'abp.services.app.salesInvoice',
        function ($scope, $state, $stateParams, invoiceService) {
            var vm = this;

            function loadInvoice() {
                invoiceService.getAsync({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.salesInvoice = result;
                });
            }

            loadInvoice();
        }
    ]);

})();
