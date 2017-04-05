(function () {
    'use strict';

    angular.module('app').controller('app.views.purchaseOrders.addPurchaseOrder', [
        '$scope', '$location', '$state', 'abp.services.app.purchaseOrder', 'abp.services.app.businessPartner',
        'abp.services.app.item',
        function ($scope, $location, $state, purchaseOrderService, bizPartnerService, itemService) {
            var vm = this;

            $scope.lineItems = [];

            vm.purchaseOrder = {
                cardCode: 1,
                docNum: '',
                totalAmount: '',
                contactPerson: '',
                remarks: '',
                purchaseOrderLines: $scope.lineItems
            };

            $scope.remove = function () {
                //debugger;
                var newDataList = [];
                $scope.selectedAll = false;
                angular.forEach($scope.lineItems, function (selected) {
                    if (!selected.selected) {
                        newDataList.push(selected);
                    }
                });
                $scope.lineItems = newDataList;
            };

            $scope.checkAll = function () {
                if (!$scope.selectedAll) {
                    $scope.selectedAll = true;
                } else {
                    $scope.selectedAll = false;
                }
                angular.forEach($scope.lineItems, function (lineItem) {
                    lineItem.selected = $scope.selectedAll;
                });
            };

            $scope.rowNum = 1;

            $scope.addNew = function (lineItem) {
                $scope.lineItems.push({
                    'rowNumber': $scope.rowNum++,
                    'quantity': 1
                });

                //$scope.getTotal();
            };

            $scope.getTotal = function () {
                var total = 0;

                for (var i = 0; i < $scope.lineItems.length; i++) {
                    var lineItem = $scope.lineItems[i];
                    total += (lineItem.quantity * lineItem.item.unitPrice);
                    vm.purchaseOrder.totalAmount = total;
                }

                return total;
            }

            $scope.getLineTotal = function (lineItem) {
                var total = 0;
                if (!lineItem.item.unitPrice)
                    return total;
                total = lineItem.quantity * lineItem.item.unitPrice;
                return total;
            }

            vm.businessPartners = [];
            function getBizPartners() {
                bizPartnerService.getBusinessPartners().success(function (data) {
                    vm.businessPartners = data.items;
                });
            };

            getBizPartners();

            vm.items = [];
            function getItems() {
                itemService.getAllItems().success(function (result) {
                    vm.items = result.items;
                });
            };

            getItems();

            vm.save = function () {
                abp.ui.setBusy();
                purchaseOrderService.createAsync(vm.purchaseOrder).success(function () {
                    abp.notify.success(App.localize('SavedSuccessfully'));
                    $location.path('/purchaseOrders');
                }).finally(function () {
                    abp.ui.clearBusy();
                })
            };
        }
    ]);

})();
