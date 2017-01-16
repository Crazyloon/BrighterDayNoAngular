// app-products

(function () {
    "use strict";

    // get existing module (an object to add our controller to)
    angular.module("app-productDetails")
        .controller("productDetailsController", productDetailsController);

    function productDetailsController($routeParams, $http) {
        var vm = this; // ViewModel - 'this' is the object that is returned from the controller

        // Globals (aka useful for multiple functions in this file [not actually 'global'])
        vm.errorMessage = "";
        vm.isBusy = true;
        vm.productCode = $routeParams.productCode;

        /*Get a list of products for browsing*/
        // browse product-card description text limit...
        vm.descriptionLimit = 120;

        // single product item
        vm.product = {}
        
        let productUrl = "/api/products/" + vm.productCode;

        // Call the API to get a single product by its product code
        $http.get(productUrl)
        .then(function (response) {
            //success
            angular.copy(response.data, vm.product);
        }, function (error) {
            //fail
            vm.errorMessage = "That product could not be found " + error;
        })
        .finally(function () {
            vm.isBusy = false;
        });
    }
})();