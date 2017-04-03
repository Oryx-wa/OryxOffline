(function () {
    'use strict';

    angular.module('app').controller('app.views.goodsReceipts.index', [
        '$scope', 'abp.services.app.goodsReceipt',
        function ($scope, goodsReceiptService) {
            var vm = this;

            vm.goodsReceipts = [];

            function loadGoodsReceipts() {
                abp.ui.setBusy(null,
                    goodsReceiptService.getGoodsReceiptsPaged({}).success(function (data) {
                        vm.goodsReceipts = data.items;
                    })
                );
            }

            loadGoodsReceipts();
        }
    ]);
})();
