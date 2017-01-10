// app-products.js

(function () {
    "use strict";

    // Create the products module for angular
    angular.module("app-products", ["simpleControls", "ngRoute"])
        .config(function ($routeProvider) {
            // A route for a list of products
            $routeProvider.when("/", {
                controller: "productsController",
                controllerAs: "vm",
                templateUrl: "/views/productsView.html"
            });

            // A route for a specific product, viewed by it's product code (Product.ProductCode)
            $routeProvider.when("product/:productCode", {
                controller: "productsController",
                controllerAs: "vm",
                templateUrl: "/views/productsView.html"
            });
        });

})();