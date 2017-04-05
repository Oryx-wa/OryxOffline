(function () {
    'use strict';

    angular.module('app').controller('app.views.purchaseOrders.index', [
        '$scope', 'abp.services.app.purchaseOrder',
        function ($scope, purchaseOrderService) {
            var vm = this;

            vm.purchaseOrders = [];

            function loadPurchaseOrders() {
                abp.ui.setBusy(null,
                    purchaseOrderService.getPurchaseOrdersPaged({}).success(function (data) {
                        vm.purchaseOrders = data.items;
                    })
                );
            }

            loadPurchaseOrders();
        }
    ]);
})();
