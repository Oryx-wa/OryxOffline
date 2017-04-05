(function () {
    'use strict';

    angular.module('app').controller('app.views.goodsReceipts.detail', [
        '$scope', '$state', '$stateParams', 'abp.services.app.goodsReceipt',
        function ($scope, $state, $stateParams, receiptService) {
            var vm = this;

            function loadReceipt() {
                receiptService.getAsync({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.goodsReceipt = result;
                });
            }

            loadReceipt();
        }
    ]);
})();
