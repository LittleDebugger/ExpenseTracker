var staticDataService = (function getStaticData() {
    var that = {};

    var loaded = false;
    var data;

    that.getStaticData = function () {
        var deferred = $.Deferred();

        if (loaded) {
            deferred.resolve(data);
        }
        else {
            dataService.get("api/staticData", function (staticData) {
                data = staticData;
                loaded = true;
                deferred.resolve(staticData);
            });
        }
        
        return deferred.promise();
    }

    return that;
})();
