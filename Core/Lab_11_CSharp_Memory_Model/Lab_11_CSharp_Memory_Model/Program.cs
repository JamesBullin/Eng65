using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_11_CSharp_Memory_Model
{
	class Program
	{
		static void Main(string[] args)
		{
            //int nish = 4;
            //int huthaifa = 1;

            //var terrence = new int[] { 1, 2 };
            //var diogo = new string[] { "Hello", "World" };


            //Console.WriteLine("Diogo Array:");
            //foreach (var item in diogo)
            //{
            //    Console.WriteLine(item);
            //}

            //{
            //    int fazal = 3;
            //    nish = terrence[0];
            //    _ = diogo[1];
            //}

            //var james2 = terrence[1];
            //var vinay = diogo;

            //vinay[0] = "Goodbye";

            //Console.WriteLine();
            //Console.WriteLine("Diogo Array Updated:");
            //foreach (var item in diogo)
            //{
            //    Console.WriteLine(item);
            //}


            ////Declare a stack:
            //Stack<string> stack01 = new Stack<string>();
            ////Push(i.e.add) item off the top of a stack.
            // stack01.Push("nish");
            // stack01.Push("mandal");
            //// Pop(i.e.remove) item off the top of a stack.
            //Console.WriteLine(stack01.Pop()); 
           
            int nish = 3;

            Add(nish);
            Console.WriteLine(nish);
            Add(ref nish);
            Console.WriteLine(nish);

            StringBuilder sb = new StringBuilder("hello");

        }

        public static void Add(object obj)
        {
           
        }

        public static void Add(int x)
        {
            x++;
        }

        public static void Add(ref int x)
        {
            x++;
        }
    }




}
