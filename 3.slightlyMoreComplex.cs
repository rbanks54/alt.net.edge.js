using System.Text;
using System.Threading.Tasks;

//Tip: Don't use namespaces. Edge will not be able to find the method if you do
//namespace MyCode{ 

	//Convention requires a class named StartUp and an async method 'Invoke' returning a Task<>
	public class Startup { 
		public async Task<object> Invoke(dynamic input)  
		{
			var s = new StringBuilder();
			s.Append(input.secondPart); //Note the casing of 'secondPart' here
			var resultText = ".NET welcomes " + input.firstPart.ToString() + ". " + s.ToString();
			var result = new {
				resultString = resultText,
				resultLength = new DoStuff().GetLength(resultText)
			};
			return result;
		}
	}

	public class DoStuff {
		public int GetLength(string s)
		{
			if (string.IsNullOrEmpty(s)) return 0;
			return s.Length;
		}
	}
//}