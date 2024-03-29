using System;
using System.IO;

class Day2
{
    public static void Solution(string file)
    {
      string[] lines = File.ReadAllLines(file);  

      int countPasswords = 0;
      foreach(string line in lines)
      {
        string[] split = line.Split(": ");

        string password = split[1];

        split = split[0].Split(" ");

        string character = split[1];

        split = split[0].Split("-");

        int lower = int.Parse(split[0]);
        int upper = int.Parse(split[1]);

        int count = 0;
        foreach(char c in password)
        {
          if(c.ToString() == character)
            count++;
        }

        if(count >= lower && count <= upper)
          countPasswords++;
      }

      Console.WriteLine(countPasswords);
    }

    public static void Solution2(string file)
    {
      string[] lines = File.ReadAllLines(file);  

      int countPasswords = 0;
      foreach(string line in lines)
      {
        string[] split = line.Split(": ");

        string password = split[1];

        split = split[0].Split(" ");

        string character = split[1];

        split = split[0].Split("-");

        int lower = int.Parse(split[0]);
        int upper = int.Parse(split[1]);

        if(
          password[lower - 1].ToString() != password[upper - 1].ToString() &&
          (password[lower - 1].ToString() == character || password[upper - 1].ToString() == character)
        )
        {
          countPasswords++;
        }
      }

      Console.WriteLine(countPasswords);
    }
}