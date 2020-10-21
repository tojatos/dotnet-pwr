using System;

namespace Lab3
{
    class Program
    {
        static void zad1a() {
            void printMatrix(int[,] matrix, int n, int m) {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(matrix[i,j]);
                        Console.Write(' ');
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i,j] = new Random().Next();

            printMatrix(matrix, n, m);

            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int tmp = matrix[i,j];
                    matrix[i,j] = matrix[n-i-1,j];
                    matrix[n-i-1,j] = tmp;
                }
            }

            printMatrix(matrix, n, m);

        }
        static void zad1b() {
            void printMatrix(int[][] matrix, int n, int m) {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(matrix[i][j]);
                        Console.Write(' ');
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
                matrix[i] = new int[m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i][j] = new Random().Next();

            printMatrix(matrix, n, m);

            for (int i = 0; i < n / 2; i++)
            {
                int[] tmp = matrix[i];
                matrix[i] = matrix[n-i-1];
                matrix[n-i-1] = tmp;
            }

            printMatrix(matrix, n, m);

        }
        static void zad2() {
            void printTuple((string, string, int) t) {
                Console.WriteLine(t);
                Console.WriteLine($"{t.Item1} {t.Item2} {t.Item3}");
                var (name, surname, age) = t;
                Console.WriteLine($"{name} {surname} {age}");
            }

            (string, string, int) userData = (Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()));
            printTuple(userData);
        }
        static void zad3() {
            int @class = 5;
            Console.WriteLine(@class);
        }
        static void zad4() {
            int[] arr = new int[] {4, 5, 3, -1, 3, 32, -43};

            Console.WriteLine(string.Join(' ', Array.FindAll(arr, item => item < 0)));

            int[] arrCopy = (int[])arr.Clone();

            Array.Sort(arrCopy);
            Console.WriteLine(string.Join(' ', arrCopy));

            Console.WriteLine(Array.BinarySearch(arrCopy, -43));
            Console.WriteLine(Array.BinarySearch(arrCopy, 3));
            Console.WriteLine(Array.BinarySearch(arrCopy, 0));

            Array.Reverse(arr);
            Console.WriteLine(string.Join(' ', arr));

            Array.Clear(arr, 3, 2);
            Console.WriteLine(string.Join(' ', arr));

            Array.Clear(arr, 0, arr.Length);
            Console.WriteLine(string.Join(' ', arr));
        }
        static void zad5() {
            var userData = new {name = Console.ReadLine(), surname = Console.ReadLine(), age = int.Parse(Console.ReadLine())};
            Console.WriteLine(userData);
            Console.WriteLine($"{userData.name} {userData.surname} {userData.age}");
        }
        static void Main(string[] args)
        {
            // zad1a();
            // zad1b();
            // zad2();
            // zad3();
            // zad4();
            // zad5();
        }
    }
}
