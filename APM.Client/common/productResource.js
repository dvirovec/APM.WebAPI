(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("productResource",
                ["$resource",
                 "appSettings",
                    productResource])
    function productResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/Product/:id", null,
            { 'update': { method: 'PUT' } }            
        );
    }
}());

