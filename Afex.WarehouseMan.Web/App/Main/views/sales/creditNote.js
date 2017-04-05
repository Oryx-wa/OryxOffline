(function () {
    'use strict';

    angular.module('app').controller('app.views.creditNotes.detail', [
        '$scope', '$state', '$stateParams', 'abp.services.app.creditMemo',
        function ($scope, $state, $stateParams, creditNoteService) {
            var vm = this;

            function loadCreditNote() {
                creditNoteService.getAsync({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.creditNote = result;
                });
            }

            loadCreditNote();
        }
    ]);
})();
