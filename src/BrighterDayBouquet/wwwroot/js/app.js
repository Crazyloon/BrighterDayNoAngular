// app.js

(function () {
    "use strict";

    // Create the products module for angular
    let app = angular.module("app", ["simpleControls", "ngRoute"]);

        app.config(function ($routeProvider) {
            // A route for a list of products
            $routeProvider
            .when("/home", {
                controller: "productsController",
                controllerAs: "vm",
                templateUrl: "/views/productsView.html"
            })
            .when("/browse", {
                controller: "productsController",
                controllerAs: "vm",
                templateUrl: "/views/productsView.html"
            })
            .when("/details/:productCode", {
                controller: "productDetailsController",
                controllerAs: "vm",
                templateUrl: "/views/productDetailsView.html"
            });
        });

})();