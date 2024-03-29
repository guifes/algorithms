using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProblemSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                var result = Result.distributeList(i);
                var resultHeavy = Result.distributeHeavyList(i);

                var valid = true;

                if (result.Count != resultHeavy.Count)
                {
                    valid = false;
                }
                else
                {
                    for (int j = 0; j < i; j++)
                        if (result[j] != resultHeavy[j])
                            valid = false;
                }

                if (!valid)
                {
                    Console.WriteLine("Invalid result");
                    continue;
                }

                var sw = new Stopwatch();

                sw.Start();

                Result.distribute(i);

                sw.Stop();

                Console.WriteLine("Elapsed for distribute = {0}", sw.Elapsed);

                sw = new Stopwatch();

                sw.Start();

                Result.distributeHeavy(i);

                sw.Stop();

                Console.WriteLine("Elapsed for distributeHeavy = {0}", sw.Elapsed);
            }

            Console.ReadLine();
        }
    }

    class Result
    {
        public static void distribute(int n)
        {
            Console.Write($"{n}: ");

            var count = 0;
            var loop = 0;
            var f = 2;

            while (count < n)
            {
                int i = f / 2;

                if (loop > 0)
                {
                    int v0 = 3 * (int)(Math.Pow(2, loop - 1) - 1);
                    int v1 = n - (4 + v0);
                    int v2 = v1 % (int)(Math.Pow(2, loop));
                    int v3 = v2 + 1;
                    int v4 = 2 * v3;

                    i = v4;
                }

                while (i <= n)
                {
                    count++;

                    if (count <= n - 1)
                    {
                        Console.Write($"{i} ");
                    }
                    else
                    {
                        int pos = (int)(Math.Floor(Math.Log(n) / Math.Log(2)));
                        int p = (int)(Math.Pow(2, pos));
                        i = (n - p) * 2;
                        if (i == 0)
                            i = p;

                        Console.WriteLine($"<{i}>");
                    }

                    i += f;
                }

                loop++;
                f *= 2;
            }

            Console.WriteLine();
        }

        public static List<int> distributeList(int n)
        {
            var result = new List<int>();

            var count = 0;
            var loop = 0;
            var f = 2;

            while (count < n)
            {
                int i = f / 2;

                if (loop > 0)
                {
                    int v0 = 3 * (int)(Math.Pow(2, loop - 1) - 1);
                    int v1 = n - (4 + v0);
                    int v2 = v1 % (int)(Math.Pow(2, loop));
                    int v3 = v2 + 1;
                    int v4 = 2 * v3;

                    i = v4;
                }

                while (i <= n)
                {
                    count++;

                    if (count <= n - 1)
                    {
                        result.Add(i);
                    }
                    else
                    {
                        int pos = (int)(Math.Floor(Math.Log(n) / Math.Log(2)));
                        int p = (int)(Math.Pow(2, pos));
                        i = (n - p) * 2;
                        if (i == 0)
                            i = p;
                        
                        result.Add(i);
                    }

                    i += f;
                }

                loop++;
                f *= 2;
            }

            return result;
        }

        public static void distributeHeavy(int n)
        {
            Console.Write($"{n}: ");

            LinkedList<int> list = new LinkedList<int>();

            for (int i = 1; i <= n; i++)
                list.AddLast(i);

            while (list.Count > 1)
            {
                var first = list.First.Value;

                Console.Write($"{first} ");

                list.RemoveFirst();
                var second = list.First.Value;
                list.RemoveFirst();
                list.AddLast(second);
            }

            Console.Write($"<{list.First.Value}>");
            Console.WriteLine();
        }

        public static List<int> distributeHeavyList(int n)
        {
            var result = new List<int>();

            LinkedList<int> list = new LinkedList<int>();

            for (int i = 1; i <= n; i++)
                list.AddLast(i);

            while (list.Count > 1)
            {
                var first = list.First.Value;

                result.Add(first);

                list.RemoveFirst();
                var second = list.First.Value;
                list.RemoveFirst();
                list.AddLast(second);
            }

            result.Add(list.First.Value);

            return result;
        }

        public static void distributeHeavyDebug(int n)
        {
            Console.Write($"{n}: ");

            LinkedList<int> list = new LinkedList<int>();

            for(int i = 1; i <= n; i++)
                list.AddLast(i);

            int last = 0;

            while(list.Count > 1)
            {
                var first = list.First.Value;

                if(first < last)
                    Console.Write($"{first} ");

                last = first;
                
                list.RemoveFirst();
                var second = list.First.Value;
                list.RemoveFirst();
                list.AddLast(second);
            }

            Console.Write($"<{list.First.Value}>");
            Console.WriteLine();
        }
    }
}

// 1 -> 2 4
// 2 -> 2 4 6 8
// 3 -> 2 4 6 8 10 12 14 16
// 4 -> 2 4 6 8 10 12 14 16 18 20 22 24 26 28 30 32

// 1 -> 0 1
// 2 -> 0 1 2 3
// 3 -> 0 1 2 3 4 5 6
// 4 -> 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15

// 1 -> 4    -> 0                        
// 2 -> 7    -> 3   3
// 3 -> 13   -> 9      6
// 4 -> 25   -> 21        12
// 5 -> 49   -> 45           24
// 6 -> 97   -> 93              48
// 7 -> 193  -> 189                 96