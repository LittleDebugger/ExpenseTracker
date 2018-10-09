var dataService = (function dataService() {
    var that = {};

    function callServer(httpMethod, url, json, successCallback, errorCallBack) {
        console.log('HTTP ' + httpMethod + ', URL: ' + url + ', DATA: ' + json);

        $.ajax({
            url: url,
            type: httpMethod,
            data: json,
            contentType: "application/json",
            dataType: json == null ? null : "json",
            success: function (data) {
                console.log('Response: ' + JSON.stringify(data));
                if (successCallback != null) {
                    successCallback(data);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log('ERROR Calling server. Status: ' + textStatus + ' - Error.' + errorThrown);
                alert("There was an error. Please contact support.");
                if (errorCallBack != null) {
                    errorCallBack();
                }
            }
        })
    }

    that.get = function (url, successCallback, errorCallBack) {
        callServer('get', url, null, successCallback, errorCallBack);
    }

    that.post = function (url, json, successCallback, errorCallBack) {
        callServer('post', url, json, successCallback, errorCallBack);
    }

    that.put = function (url, json, successCallback, errorCallBack) {
        callServer('put', url, json, successCallback, errorCallBack);
    }

    that.delete = function (url, successCallback, errorCallBack) {
        callServer('delete', url, null, successCallback, errorCallBack);
    }

    return that;
})();
