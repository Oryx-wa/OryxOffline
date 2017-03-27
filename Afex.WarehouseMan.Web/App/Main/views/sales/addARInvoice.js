(function () {
    angular.module('app').controller('app.views.sales.addARInvoice', [
        '$scope',
        function ($scope) {

            $scope.listItems = [{
                "itemNo": "A123",
                "product": "Pampers Maxi",
                "quantity": 3,
                "unitPrice": 345
            },
            {
                "itemNo": "A456",
                "product": "Paper Roll",
                "quantity": 10,
                "unitPrice": 645
            }];

            $scope.remove = function () {
                var newDataList = [];
                $scope.selectedAll = false;
                angular.forEach($scope.listItems, function (selected) {
                    if (!selected.selected) {
                        newDataList.push(selected);
                    }
                });
                $scope.listItems = newDataList;
            };

            $scope.checkAll = function () {
                if (!$scope.selectedAll) {
                    $scope.selectedAll = true;
                } else {
                    $scope.selectedAll = false;
                }
                angular.forEach($scope.listItems, function (listItem) {
                    listItem.selected = $scope.selectedAll;
                });
            };

            $scope.addNew = function (listItem) {
                $scope.listItems.push({
                    'itemNo': '',
                    'product': '',
                    'quantity': '',
                    'unitPrice': ''
                });
               
            };
        }
    ]);
})();
