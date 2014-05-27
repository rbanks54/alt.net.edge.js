var edge = require('edge');

var hello = edge.func(function () {/*
	using System.Text;

    async (input) => { 
    	var s = new StringBuilder();
    	s.Append("Whassup!");
        return ".NET welcomes " + input.ToString() + ". " + s.ToString(); 
    }
*/});

hello('Node.js', function (error, result) {
    if (error) throw error;
    console.log(result);
});