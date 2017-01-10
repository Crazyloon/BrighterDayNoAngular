// simpleControls.js
(function () {
    "use strict";

    angular.module("simpleControls", [])
        .directive("waitCursor", waitCursor);

    function waitCursor() {
        return {
            scope: {
                show: "=displayWhen" // consumer of this directive will use an attribute named: display-when
            },
            restrict: "E", // Restricts it to only the element style (called as: <wait-cursor></wait-cursor>)
            templateUrl: "/views/waitCursor.html"
        };
    }

})();