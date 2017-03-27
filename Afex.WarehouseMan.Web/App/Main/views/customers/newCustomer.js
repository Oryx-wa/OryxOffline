(function () {
    'use strict';

    angular
        .module('app')
        .controller('newCustomer', newCustomer);

    newCustomer.$inject = ['$location']; 

    function newCustomer($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'newCustomer';

        activate();

        function activate() { }
    }
})();
