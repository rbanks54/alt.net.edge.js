using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EdgeJs;

namespace _2.callingNode
{
    class Program
    {
        static void Main(string[] args)
        {
            CallNode();
            //StartAServer();
            //Task.Run((Action)GetGoogleHomePage);
            Console.WriteLine("Hit Enter to close");
            Console.ReadLine();
        }

        static async void CallNode()
        {
            var func = Edge.Func(@"
	            return function (data, cb) {
	                cb(null, 'Node.js ' + process.version + ' welcomes ' + data);
	            }
	        ");

            Console.WriteLine(await func(".NET"));
        }

        private static async void StartAServer()
        {
            var createHttpServer = Edge.Func(@"
                var http = require('http');

                return function (port, cb) {
                    var server = http.createServer(function (req, res) {
                        res.end('Hello, world! ' + new Date());
                    }).listen(port, cb);
                };
            ");

            await createHttpServer(8765);
            Console.WriteLine(await new WebClient().DownloadStringTaskAsync("http://localhost:8765"));
        }

        private static async void GetGoogleHomePage()
        {
            var result = "";
            var onMessage = (Func<object, Task<object>>)(async (chunk) =>
            {
                var chunkData = Encoding.Default.GetString((byte[])chunk);
                result += chunkData;
                Console.WriteLine("Response: \n************\n" + chunkData + "\n************\n");
                return "(sent back to node) Received string of length " + chunkData.Length;
            });

            try
            {
                var callHttpUrl = Edge.Func(File.ReadAllText("nodeCode.js"));
                var callbackResult = await callHttpUrl(new {onMessage = onMessage});
                Console.WriteLine("(callback from Node)" + callbackResult.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("oops: " + ex.Message);
                Console.ReadLine();
            }
        }



    }
}
