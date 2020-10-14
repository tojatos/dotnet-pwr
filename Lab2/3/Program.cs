using System;

namespace _3
{
    class Program
    {
        static int ReadInt()
        {
            bool set = false;
            bool finished = false;
            string tmp_string = "";
            char x = ' ';
            while(!(set && finished))
            {
                x = Console.ReadKey().KeyChar;
                if (Char.IsWhiteSpace(x)) {
                    if (set) finished = true;
                    continue;
                }
                set = true;
                tmp_string += x;
            }
            return int.Parse(tmp_string);
        }

        static void Main(string[] args)
        {
            int n = ReadInt();
            Console.WriteLine();
            int biggest = int.MinValue;
            int second_biggest = int.MinValue;

            while (n-- != 0) {
                int tmp = ReadInt();
                if (tmp > second_biggest) {
                    if (tmp == biggest) continue;
                    if (tmp > biggest) {
                        second_biggest = biggest;
                        biggest = tmp;
                    }
                    else {
                        second_biggest = tmp;
                    }
                }
            }
            Console.WriteLine();
            if (second_biggest == int.MinValue) Console.WriteLine("brak rozwiązania");
            else Console.WriteLine(second_biggest);
        }
    }
}
