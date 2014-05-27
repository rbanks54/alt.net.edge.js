// Overview of edge.js: http://tjanczuk.github.com/edge

var edge = require('edge');
var http = require('http');
var util = require('util');

var convertKilograms = edge.func('service.csx');

http.createServer(function(req,res) {
	convertKilograms(123, function (error, result) {
		if (error) throw error;
		res.end('Called convert, result:' + util.inspect(result,null));
	});
}).listen(process.env.PORT || 3000);
