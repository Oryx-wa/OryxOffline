(function () {
    angular.module('app').controller('app.views.items.index', [
        '$scope', 'abp.services.app.item',
        function ($scope, itemService) {
            var vm = this;

            vm.items = [];

            vm.loadItems = function () {
                abp.ui.setBusy(null,
                    itemService.getItemsList({}).success(function (data) {
                        vm.items = data.items;
                    })
                );
            }

            vm.loadItems();
        }
    ]);
})();
