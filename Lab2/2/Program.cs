using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"{Convert.ToString(a, 2)} {Convert.ToString(b, 2)}");
            Console.WriteLine(string.Format("{0:X} {1:X}", ~a, ~b));
            Console.WriteLine(string.Format("{0:X}", a & b));
            Console.WriteLine(string.Format("{0:X}", a | b));
        }
    }
}
