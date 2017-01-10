// app-products

(function () {
    "use strict";

    // get existing module (an object to add our controller to)
    angular.module("app-products")
        .controller("productsController", productsController);

    function productsController($http) {
        var vm = this; // ViewModel - 'this' is the object that is returned from the controller

        vm.products = []; // expose a collection of products
        vm.errorMessage = "";
        vm.isBusy = true;

        // Call to the API to get a list of products
        $http.get("/api/products")
            .then(function (response) {
                // Represents Success
                angular.copy(response.data, vm.trips);
            }, function (error) {
                // Represents Failure
                vm.errorMessage = "Failed to gather products " + error;
            })
            .finally(function () {
                // Always run
                vm.isBusy = false;
            });

        // Something like this should be used on server side after someone clicks a button to add a product
        vm.addToCart = function addToCart() {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/cartItems", vm.newCartItem)
            .then(function (response) {
                // Represents Success
                
            }, function (error) {
                // Represents Failure
                vm.errorMessage = "Failed to add product to cart " + error;
            })
            .finally(function () {
                // Always run
                vm.isBusy = false;
            });
        };

    }

})();