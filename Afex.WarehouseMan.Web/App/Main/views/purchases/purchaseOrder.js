(function () {
    'use strict';

    angular.module('app').controller('app.views.purchaseOrders.detail', [
        '$scope', '$state', '$stateParams', 'abp.services.app.purchaseOrder',
        function ($scope, $state, $stateParams, purchaseOrderService) {
            var vm = this;

            function loadPurchaseOrder() {
                purchaseOrderService.getAsync({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.purchaseOrder = result;
                });
            }

            loadPurchaseOrder();
        }
    ]);
})();
