using System;
using System.IO;
using System.Text;

namespace Encoding_Streaming
{
	class Program
	{
		static void Main(string[] args)
		{
			string path1 = Directory.GetCurrentDirectory();
			var path2 = Path.GetFullPath(Path.Combine(path1, @"..\..\..\location\"));

			using (StreamWriter sw = File.AppendText(@$"{path2}Champagne-Supernova"))
			{
				sw.WriteLine("In a Champagne Supernova in the skyyyy");
			}


			using (StreamReader sr = File.OpenText(@$"{path2}Champagne-Supernova"))

			{
				//The variable ‘s’ will be used to read all the data from the file
				string s = "";
				//We then use the stream reader method ReadLine to read each line from the stream buffer
				while ((s = sr.ReadLine()) != null)
				{
					//As a result, each line will be transferred from the file to the buffer, then the 			
					//string line will be transferred from the buffer to the variable ‘s’
					Console.WriteLine(s);
				}


			}
		}
	}
}
