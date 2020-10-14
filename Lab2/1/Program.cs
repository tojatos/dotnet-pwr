using System;

namespace _1
{
    class Program
    {
        private static string GetResult(double a, double b, double c)
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0) return "Równanie nieoznaczone";
                    return "Równanie sprzeczne";
                }
                return string.Format("x = {0:G5}", -c / b);
            }
            double delta = b * b - 4 * a * c;
            if (delta < 0) return "Równanie sprzeczne (delta ujemna)";
            if (delta == 0) {
                return string.Format("x = {0:G5}", -b / 2 * a, 4);
            }
            double sqr_delta = Math.Sqrt(delta);
            double solution1 = (-b - sqr_delta) / (2 * a);
            double solution2 = (-b + sqr_delta) / (2 * a);

            return $"x = {solution1:G5} v x = {solution2:G5}";
        }
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine(GetResult(a, b, c));
        }
    }
}
