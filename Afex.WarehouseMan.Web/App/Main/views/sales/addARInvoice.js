(function () {
    angular.module('app').controller('app.views.sales.addARInvoice', [
        '$scope',
        function ($scope) {

            $scope.lineItems = [];

            $scope.totalAmount = 0;

            $scope.remove = function () {
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

            $scope.addNew = function (lineItem) {
                $scope.lineItems.push({
                    'itemNo': '',
                    'product': '',
                    'quantity': '',
                    'unitPrice': ''
                });
                

            };

           
        }
    ]);
})();
