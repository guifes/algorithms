using System;
using System.Collections.Generic;
using System.IO;

class Day5
{
    public static void Solution1(string file)
    {
        string[] lines = File.ReadAllLines(file);

        List<int> ids = new List<int>(lines.Length);

        var highestId = 0;

        foreach (var line in lines)
        {
            int top = 127;
            int bottom = 0;
            int row = 0;
            int col = 0;

            foreach (var c in line.Substring(0, 7))
            {
                if(top - bottom <= 1)
                {
                    if (c == 'F')
                    {
                        row = bottom;
                    }
                    else if (c == 'B')
                    {
                        row = top;
                    }
                }
                else
                {
                    if (c == 'F')
                    {
                        top -= (top - bottom + 1) / 2;
                    }
                    else if (c == 'B')
                    {
                        bottom += (top - bottom + 1) / 2;
                    }
                }
            }

            top = 7;
            bottom = 0;

            foreach (var c in line.Substring(7, 3))
            {
                if (top - bottom <= 1)
                {
                    if (c == 'L')
                    {
                        col = bottom;
                    }
                    else if (c == 'R')
                    {
                        col = top;
                    }
                }
                else
                {
                    if (c == 'L')
                    {
                        top -= (top - bottom + 1) / 2;
                    }
                    else if (c == 'R')
                    {
                        bottom += (top - bottom + 1) / 2;
                    }
                }
            }

            highestId = Math.Max(highestId, (row * 8) + col);

            Console.WriteLine(highestId);
        }
    }

    public static void Solution2(string file)
    {
        string[] lines = File.ReadAllLines(file);

        List<int> ids = new List<int>(lines.Length);

        foreach (var line in lines)
        {
            int top = 127;
            int bottom = 0;
            int row = 0;
            int col = 0;

            foreach (var c in line.Substring(0, 7))
            {
                if (top - bottom <= 1)
                {
                    if (c == 'F')
                    {
                        row = bottom;
                    }
                    else if (c == 'B')
                    {
                        row = top;
                    }
                }
                else
                {
                    if (c == 'F')
                    {
                        top -= (top - bottom + 1) / 2;
                    }
                    else if (c == 'B')
                    {
                        bottom += (top - bottom + 1) / 2;
                    }
                }
            }

            top = 7;
            bottom = 0;

            foreach (var c in line.Substring(7, 3))
            {
                if (top - bottom <= 1)
                {
                    if (c == 'L')
                    {
                        col = bottom;
                    }
                    else if (c == 'R')
                    {
                        col = top;
                    }
                }
                else
                {
                    if (c == 'L')
                    {
                        top -= (top - bottom + 1) / 2;
                    }
                    else if (c == 'R')
                    {
                        bottom += (top - bottom + 1) / 2;
                    }
                }
            }

            ids.Add((row * 8) + col);
        }

        ids.Sort();
        int counter = ids[0];

        for (int i = 0; i < ids.Count; i++)
        {
            if(counter != ids[i])
            {
                Console.WriteLine(counter);
            }
            else
            {
                counter++;
            }
        }
    }
}