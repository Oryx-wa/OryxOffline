(function () {
    angular.module('app').controller('app.views.sales.addARInvoice', [
        '$scope', '$location', '$state', 'abp.services.app.salesInvoice', 'abp.services.app.businessPartner',
        'abp.services.app.item',
        function ($scope, $location, $state, salesInvoiceService, bizPartnerService, itemService) {
            var vm = this;

            $scope.lineItems = [];

            vm.salesInvoice = {
                cardCode: '',
                docNum: '',
                totalAmount: '',
                remarks: '',
                salesInvoiceLines: $scope.lineItems
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

            //$scope.displayValue = function () {
            //    debugger;
            //    alert(vm.salesInvoice.cardCode);
            //}

            $scope.rowNum = 1;

            $scope.addNew = function (lineItem) {
                $scope.lineItems.push({
                    'rowNumber': $scope.rowNum++,
                    'item.id': '',
                    ['item.itemName']: '',
                    'quantity': 1,
                    ['item.unitPrice']: ''
                });
            };

            //$scope.itemArray = [
            //    { id: 1, name: 'first' },
            //    { id: 2, name: 'second' },
            //    { id: 3, name: 'third' },
            //    { id: 4, name: 'fourth' },
            //    { id: 5, name: 'fifth' },
            //];

            //$scope.selectedItem = $scope.itemArray[0];

            $scope.getTotal = function () {
                var total = 0;

                for (var i = 0; i < $scope.lineItems.length; i++) {
                    var lineItem = $scope.lineItems[i];
                    total += (lineItem.quantity * lineItem.item.unitPrice);
                    vm.salesInvoice.totalAmount = total;
                }

                return total;
            }

            $scope.getLineTotal = function (lineItem) {
                var total = 0;
                if (lineItem.item == null)
                    return total;
                total = lineItem.quantity * lineItem.item.unitPrice;
                return total;
            }

            $scope.getRowNum = function () {
                var rowNum = 0;
            }

            vm.businessPartners = [];
            function getBizPartners() {
                bizPartnerService.getBusinessPartners().success(function (data) {
                    vm.businessPartners = data.items;
                })
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
                debugger;
                salesInvoiceService.createAsync(vm.salesInvoice).success(function () {
                    abp.notify.success(App.localize('SavedSuccessfully'));
                    $location.path('/salesInvoices');
                }).finally(function () {
                    abp.ui.clearBusy();
                })
            };
            
        }
    ]);
})();
