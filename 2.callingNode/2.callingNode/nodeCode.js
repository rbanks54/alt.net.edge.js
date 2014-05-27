var http = require('http');

// ReSharper disable once ReturnFromGlobalScopetWithValue
return function(dotNetData, dotNetCallback) {
    var str = '';

    var options = {        
      hostname: 'httpssss://www.google.com'  
    };

    var callback = function(response) {
        response.on('data', function (chunk) {
            dotNetData.onMessage(chunk, function (error, result) {
                if (error) throw error;
                str += result;
                dotNetCallback(null,result);
            });
        });
    };

    http.get(options, callback)
        .on('error', function() {
            dotNetCallback(null, 'error');
        });
};