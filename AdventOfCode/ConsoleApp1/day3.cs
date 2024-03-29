using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Day3
{
    private static int CheckSlope(string[] lines, int offsetX, int offsetY)
    {
      var treeCount = 0;

      for(int x = offsetX, y = offsetY; y < lines.Length; x += offsetX, y += offsetY)
      {
        string line = lines[y];
        char c = line[x % line.Length];

        if(c == '#')
          treeCount++;
      }

      return treeCount;
    }
    public static void Solution1(string file)
    {
      string[] lines = File.ReadAllLines(file);  

      List<int> checks = new List<int>(5);

      checks.Add(CheckSlope(lines, 1, 1));
      checks.Add(CheckSlope(lines, 3, 1));
      checks.Add(CheckSlope(lines, 5, 1));
      checks.Add(CheckSlope(lines, 7, 1));
      checks.Add(CheckSlope(lines, 1, 2));

      int result = checks.Aggregate(1, (buffer, next) => buffer * next);

      Console.WriteLine(result);
    }

    public static void Solution2(string file)
    {
      string[] lines = File.ReadAllLines(file);  

      
    }
}