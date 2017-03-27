(function () {
    angular.module('app').controller('app.views.arInvoices.index', [
        '$scope', 'abp.services.app.user',
        function ($scope, arService) {
            var vm = this;

            vm.salesInvoices = [{
                "itemNo": "A123",
                "customer": "John Doe",
                "product": "Pampers Maxi",
                "unitPrice": "NGN349.99",
                "datePosted": "01/03/2017"
            },
            {
                "itemNo": "A456",
                "customer": "James Blunt",
                "product": "Paper Roll",
                "unitPrice": "NGN599.99",
                "datePosted": "01/03/2017"
            },
            {
                "itemNo": "A789",
                "customer": "Mick Foley",
                "product": "Duracell Batteries",
                "unitPrice": "NGN1299.99",
                "datePosted": "03/03/2017"
            },
            {
                "itemNo": "B012",
                "customer": "Mike Epps",
                "product": "Ragolis Water Maxi",
                "unitPrice": "NGN349.99",
                "datePosted": "04/03/2017"
            }];
            
        }
    ]);
})();
