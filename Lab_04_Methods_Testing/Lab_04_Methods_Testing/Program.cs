using System;
using System.IO;

namespace Lab_04_Methods_Testing
{
    class Program
    {

        public static void Main(string[] args)
        {
            //var results = DoThis(10, "Hello guys");
            //var results2 = DoThis(10);

            //OrderPizza(pineapple: true, anchioves: true, grapes: false);

            //var result = DoThis(10, "Hello Eng65", out int a);
            //Console.WriteLine(a);

            //int number = 10;
            //Add(number);
            //Console.WriteLine(number);

            //Add(ref number);
            //Console.WriteLine(number);

            //var myTuple = (fName: "Nish", lName: "Mandal", age: 30);
            //Console.WriteLine(myTuple);
            //Console.WriteLine(myTuple.lName);

            //var game = "Animal Crossing";
            //var rating = 3;

            //var mytuple2 = (game, rating);

            //Console.WriteLine(mytuple2);

            //var results = DoThat(11, "Here's a string");
            //Console.WriteLine(results);
            //Console.WriteLine(results.Item1);


            //var (square, greatherThan10) = DoThat(5, "Hello");
            //Console.WriteLine(greatherThan10);

            var product = TripleCalc(2, 3, 4, out int sum);
            Console.WriteLine(product + " : " + sum);
            var tuple = TripleCalc(4, 5, 6);
            Console.WriteLine(tuple.product + " : " + tuple.sum);


        }

        public static int TripleCalc(int a, int b, int c, out int sum)
        {
            sum = a + b + c;
            return a * b * c;
        }

        public static (int sum, int product) TripleCalc(int a, int b, int c)
        {
            return (a + b + c, a * b * c);
        }

        //public static (int , bool) DoThat(int x, string y)
        //{
        //    Console.WriteLine(y);
        //    var z = (x > 10);
        //    return (x * x, z);

        //}

        //static void Add(int num)
        //{
        //    num++;
        //}

        //static void Add(ref int num)
        //{
        //    num++;
        //}
        //public static int DoThis(int x, string y, out int z)
        //{
        //    Console.WriteLine(y);
        //    z =  65;
        //    return x * x;
        //}

        //public static void OrderPizza(bool anchioves, bool pineapple, bool mushrooms = false, bool grapes = true)
        //{
        //    if (anchioves == true && pineapple == true && mushrooms == true)
        //        Console.WriteLine("Delicious");
        //    if (anchioves == true && pineapple == false && mushrooms == true)
        //        Console.WriteLine("Where's the pineapple");
        //    if (anchioves == false && pineapple == false && mushrooms == false)
        //        Console.WriteLine("Isn't this just flat bread?");
        //    if (anchioves == true && pineapple == true && mushrooms == false)
        //        Console.WriteLine("Mushrooms only?!");
        //    if (anchioves == true && pineapple == true && mushrooms == false && grapes == false)
        //        Console.WriteLine("Who puts grapes on a pizza?!");

        //}

        //public static int DoThis(int x, string y = "Default Value")
        //{
        //    Console.WriteLine(y);
        //    return x * x;

        //}
    }



}
