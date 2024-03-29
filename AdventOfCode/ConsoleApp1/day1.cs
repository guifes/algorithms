using System;
using System.IO;

class Day1
{
    public static void Solution(string file)
    {
      string[] lines = File.ReadAllLines(file);  

      int[] input = new int[lines.Length];
      
      for (int i = 0; i < lines.Length; i++)
        input[i] = int.Parse(lines[i]);

      Array.Sort(input);

      var value_i = 0;
      var value_j = 0;
      var value_k = 0;
      var ended = false;
      for(int i = 0; i < input.Length && !ended; i++)
      {
        value_i = input[i];

        for(int j = i + 1; j < input.Length && !ended; j++)
        {
          value_j = input[j];

          if(value_i + value_j >= 2020)
          break;

          for(int k = j + 1; k < input.Length && !ended; k++)
          {
            value_k = input[k];

            if(value_i + value_j + value_k == 2020)
              ended = true;
          }
        }
      }

      Console.WriteLine(value_i);
      Console.WriteLine(value_j);
      Console.WriteLine(value_k);
      Console.WriteLine(value_i * value_j * value_k);
    }
}