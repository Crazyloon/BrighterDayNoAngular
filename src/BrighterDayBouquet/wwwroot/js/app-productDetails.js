// app-productDetails.js

(function () {
    "use strict";

    // Create the products module for angular
    angular.module("app-productDetails", ["simpleControls", "ngRoute"])
        .config(function ($routeProvider) {
            // A route for a specific product, viewed by it's product code (Product.ProductCode)
            $routeProvider.when("/:productCode", {
                controller: "productDetailsController",
                controllerAs: "vm",
                templateUrl: "/views/productDetailsView.html"
            });
        });

})();