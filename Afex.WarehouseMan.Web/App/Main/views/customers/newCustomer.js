(function () {
    'use strict';

    angular.module('app').controller('app.views.businessPartner.new', [
        '$scope', '$location', '$state', 'abp.services.app.businessPartner',
        function ($scope, $location, $state, customerService) {
            var vm = this;

            vm.businessPartner = {
                cardCode: '',
                cardName: '',
                cardType: '1',
                isActive: true,
                phone: '',
                email: '',
                contactPersonName: '',
                contactPersonLastName: '',
                contactPhone: '',
                contactEmail: ''
            };

            vm.save = function () {
                abp.ui.setBusy();
                customerService.createAsync(vm.businessPartner).success(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $location.path('/customers');
                }).finally(function () {
                    abp.ui.clearBusy();
                })
            };

            vm.cancel = function () {
                $state.go('customers');
            }
        }
    ]);
})();
