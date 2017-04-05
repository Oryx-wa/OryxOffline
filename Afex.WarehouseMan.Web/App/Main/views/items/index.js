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

            $scope.toggleEdit = function (sp) {
                sp.showEdit = sp.showEdit ? false : true;
            };

            vm.save = function (item) {
                abp.ui.setBusy();
                itemService.updateAsync(item).success(function () {
                    abp.notify.success('Saved successfully');
                    vm.loadItems();
                }).finally(function () {
                    abp.ui.clearBusy();
                });
            };

            vm.delete = function (item) {
                abp.message.confirm(
                    'Item would be deleted. This operation is not reversible!',
                    'Are you sure?',
                    function (isConfirmed) {
                        if (isConfirmed) {
                            abp.ui.setBusy();
                            itemService.deleteAsync({
                                id: item.id
                            }).success(function () {
                                abp.notify.success('Item Deleted!');
                                vm.loadItems();
                            }).finally(function () {
                                abp.ui.clearBusy();
                            });
                        }
                    }
                );

            };

            vm.itemGroups = [];
            function getGroupList() {
                itemService.getItemGroupsList().success(function (result) {
                    vm.itemGroups = result.items;
                });
            };

            getGroupList();
        }
    ]);
})();
