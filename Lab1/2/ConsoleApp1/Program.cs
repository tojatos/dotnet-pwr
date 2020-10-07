using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            for(int i = 1; i <= size; ++i)
            {
                int spaces = size - i;
                Console.Write(new string(' ', spaces));
                Console.Write(new string('X', i));
                Console.WriteLine();
            }
        }
    }
}
