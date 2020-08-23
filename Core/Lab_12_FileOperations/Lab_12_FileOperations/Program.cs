using System;
using System.Diagnostics;
using System.IO;

namespace Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = Directory.GetCurrentDirectory();
            string path2 = Path.GetFullPath(Path.Combine(path1, @"..\..\..\lyrics\"));

            //string lyrics = File.ReadAllText($@"{path2}Hammer.txt");
            //Console.WriteLine(lyrics);

            //File.WriteAllText($@"{path2}ChampagneSupernova.txt", "In a champagne supernova in the sky");

            //string[] lyrics2 = { "So", "Sally", "Can", "Wait" };
            //File.WriteAllLines($@"{path2}DontLookBackInAnger.txt", lyrics2);

            //string[] dlbin = File.ReadAllLines($@"{path2}DontLookBackInAnger.txt");

            //foreach (var item in dlbin)
            //{
            //    Console.WriteLine(item);
            //}

            //if (!File.Exists($@"{path2}myLyrics.txt"))
            //{
            //    string[] createText = { "Hello", "I'm", "Nish" };
            //    File.WriteAllLines($@"{path2}myLyrics.txt", createText);
            //}

            //string[] readText = File.ReadAllLines($@"{path2}myLyrics.txt");
            //foreach (string s in readText)
            //{
            //    Console.WriteLine(s);
            //}

            //string appendText = "And I'm Happy";
            //File.AppendAllText($@"{path2}myLyrics.txt", appendText);

            //string oldlyrics = $@"{path2}myLyrics.txt";
            //string newlyrics = $@"{path2}newLyrics.txt";

            //File.Copy(oldlyrics, newlyrics, false);
            //File.Delete(oldlyrics);

            //DateTime lastWriteTime = File.GetLastWriteTime($@"{path2}newLyrics.txt");
            //DateTime creationTime = File.GetCreationTime($@"{path2}newLyrics.txt");
            //Console.WriteLine(creationTime);
            //Console.WriteLine(lastWriteTime);


            //var fileinfo = new FileInfo($@"{path2}newLyrics.txt");

            //Console.WriteLine(fileinfo.Directory);
            //Console.WriteLine(fileinfo.Extension);

            //Directory.Delete($@"{path2}");

            //var fileArray = Directory.GetFiles(path2);

            //foreach (string i in fileArray)
            //{
            //    Console.WriteLine(i);
            //}

            int total = 0;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(i);
                total += i;
                Debug.WriteLine($"Debug - the value of i is {i}");
                Trace.WriteLine($"Trace - the value i is {i}");
                File.WriteAllText("logfile.txt", $"Log to text - the value of i is {i} at {DateTime.Now}");
            }
//            Console.WriteLine("Starting app");
//#if DEBUG
//            Console.WriteLine("This is debug code");
//#endif

//#if TEST
//            Console.WriteLine("This is a test");
//#endif

//            Console.WriteLine("Finishing app");

        }
    }

}
