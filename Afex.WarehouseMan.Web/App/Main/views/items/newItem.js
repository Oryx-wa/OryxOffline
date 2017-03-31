(function () {
    'use strict';

    angular.module('app').controller('app.views.items.new', [
         '$scope', '$location', '$state', 'abp.services.app.item',
         function ($scope, $location, $state, itemService) {
             var vm = this;

             vm.item = {
                 itemCode: '',
                 itemName: '',
                 itemGroupId: 1,
                 quantityInStock: 5,
                 unitPrice: 0.00,
                 unitCost: 0.00,
                 remarks: ''
             };

             vm.save = function () {
                 abp.ui.setBusy();
                 itemService.createAsync(vm.item).success(function () {
                     abp.notify.info(App.localize('SavedSuccessfully'));
                     $location.path('/items');
                 }).finally(function () {
                     abp.ui.clearBusy();
                 })
             }

             vm.itemGroups = [];
             vm.loadGroups = function getGroupList() {
                 itemService.getItemGroupsList().success(function (result) {
                     vm.itemGroups = result.items;
                 })
             };

             vm.loadGroups();
         }
    ]);

})();
