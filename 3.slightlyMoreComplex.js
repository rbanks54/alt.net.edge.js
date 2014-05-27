var edge = require('edge');

var hello = edge.func('3.slightlyMoreComplex.cs');

var param = {
	firstPart: 'Node.js',
	secondPart: 'This is slightly more interesting'
};

hello(param, function (error, result) {
    if (error) throw error;
    console.log(result.resultString);
    console.log(result.resultLength);
});