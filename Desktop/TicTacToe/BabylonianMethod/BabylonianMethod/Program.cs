using System;

namespace BabylonianMethod
{
    class Program
    {
        static float squareRoot(int number)
        {
            float x = number; // 1 step - start with arbitary number(closer to the number the better)
            float y = 1; // 2 step - Initialize y-1;

            float ac = 0.000001f; // 0.000001 is accuracy level
            while (x - y > ac) 
            {
                x = (x + y) / 2; //3 step - get the next aproximation for root using AVG of x and y
                y = number / x; //4 step - set y number/x
            }
            return x;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Square root of {0} is {1}",n,squareRoot(n));


        }
    }
}
