using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialisation
{
	class Program
	{
		static void Main(string[] args)
		{


			IFormatter formatter = new BinaryFormatter();
			using (var stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None))
			{
				// create an instance which we are about to serialize (think 'flat pack a wardrobe')
				var obj = new MyClass();
				obj.n1 = 1;
				obj.n2 = 24;
				obj.str = "Some String";

				// serialize the instance into binary.  Then stream it to the binary file as a stream.
				formatter.Serialize(stream, obj);
			}

			using (var stream02 = File.OpenRead("MyFile.bin"))
			{
				// read back our data as a stream from the binary file, and convert it back into an instance of the MyClass and name it instance01
				var myNEWobject = formatter.Deserialize(stream02) as MyClass;
				Console.WriteLine(myNEWobject.str);
			}

		}
	}

	[Serializable]
	public class MyClass
	{
		//[NonSerialized]
		public int n1 = 0;
		public int n2 = 0;
		public string str = null;
	}

}
