using System;
using System.Collections.Generic;
using System.IO;

class Day6
{
    public static void Solution1(string file)
    {
        string[] lines = File.ReadAllLines(file);

        Dictionary<char, int> answers = new Dictionary<char, int>();

        int total = 0;
        int linesCount = 0;

        foreach(var line in lines)
        {
            if(line.Length > 0)
            {
                linesCount++;
                
                foreach (var c in line)
                {
                    int value;
                    if (answers.ContainsKey(c))
                    {
                        value = answers[c] + 1;
                        answers.Remove(c);
                    }
                    else
                    {
                        value = 1;
                    }

                    answers.Add(c, value);
                }
            }
            else
            {
                foreach(var kvp in answers)
                    if(kvp.Value == linesCount)
                        total++;
                
                answers.Clear();
                linesCount = 0;
            }
        }

        foreach (var kvp in answers)
            if (kvp.Value == linesCount)
                total++;

        Console.WriteLine(total);
    }

    public static void Solution2(string file)
    {
        string[] lines = File.ReadAllLines(file);

    }
}