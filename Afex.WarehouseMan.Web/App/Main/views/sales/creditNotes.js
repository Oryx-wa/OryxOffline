(function () {
    'use strict';

    angular.module('app').controller('app.views.creditNotes.index', [
        '$scope', 'abp.services.app.creditMemo',
        function ($scope, creditNoteService) {
            var vm = this;

            vm.creditNotes = [];

            function loadCreditNotes() {
                abp.ui.setBusy(null,
                    creditNoteService.getCreditNotesPaged({}).success(function (data) {
                        vm.creditNotes = data.items;
                    })
                );
            }

            loadCreditNotes();
        }
    ]);
})();
