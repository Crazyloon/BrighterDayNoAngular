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
        });

})();