using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Day4
{
    public static void Solution1(string file)
    {
      string[] lines = File.ReadAllLines(file);  

      HashSet<string> items = new HashSet<string>();

      int valid = 0;
      
      foreach(string line in lines)
      {
            if (line.Length > 0)
            {
                var things = line.Split(' ');

                foreach (string thing in things)
                {
                    var components = thing.Split(":");

                    items.Add(components[0]);
                }
            }
            else
            {
                if (
                    items.Contains("byr") &&
                    items.Contains("iyr") &&
                    items.Contains("eyr") &&
                    items.Contains("hgt") &&
                    items.Contains("hcl") &&
                    items.Contains("ecl") &&
                    items.Contains("pid")
                )
                {
                    valid++;
                }

                items.Clear();
            }
      }

      Console.WriteLine(valid);
    }

    public static void Solution2(string file)
    {
        string[] lines = File.ReadAllLines(file);

        HashSet<string> items = new HashSet<string>();

        int valid = 0;

        foreach (string line in lines)
        {
            if (line.Length > 0)
            {
                var things = line.Split(' ');

                foreach (string thing in things)
                {
                    var components = thing.Split(":");
                    bool validated = false;

                    switch(components[0])
                    {
                        case "byr":
                            {
                                if (components[1].Length == 4 && int.TryParse(components[1], out int number))
                                {
                                    validated = number >= 1920 && number <= 2002;
                                }
                                break;
                            }
                        case "iyr":
                            {
                                if (components[1].Length == 4 && int.TryParse(components[1], out int number))
                                {
                                    validated = number >= 2010 && number <= 2020;
                                }
                                break;
                            }
                        case "eyr":
                            {
                                if (components[1].Length == 4 && int.TryParse(components[1], out int number))
                                {
                                    validated = number >= 2020 && number <= 2030;
                                }
                                break;
                            }
                        case "hgt":
                            {
                                int number;

                                if (components[1].IndexOf("cm") >= 0 && int.TryParse(components[1].Substring(0, components[1].Length - 2), out number))
                                {
                                    validated = number >= 150 && number <= 193;
                                }
                                else if (components[1].IndexOf("in") >= 0 && int.TryParse(components[1].Substring(0, components[1].Length - 2), out number))
                                {
                                    validated = number >= 59 && number <= 76;
                                }
                                break;
                            }
                        case "hcl":
                            {
                                if (components[1].Length == 7 && components[1].IndexOf("#") == 0)
                                {
                                    validated = true;

                                    foreach(var c in components[1].Substring(1, 6))
                                    {
                                        validated &= ((c >= '0') && (c <= '9')) || ((c >= 'a' && c <= 'f'));
                                    }
                                }
                                break;
                            }
                        case "ecl":
                            {
                                if (components[1].Length == 3)
                                {
                                    validated =
                                        components[1] == "amb" ||
                                        components[1] == "blu" ||
                                        components[1] == "brn" ||
                                        components[1] == "gry" ||
                                        components[1] == "grn" ||
                                        components[1] == "hzl" ||
                                        components[1] == "oth";
                                }
                                break;
                            }
                        case "pid":
                            {
                                if (components[1].Length == 9)
                                {
                                    validated = true;

                                    foreach (var c in components[1].Substring(1, 6))
                                    {
                                        validated &= (c >= '0') && (c <= '9');
                                    }
                                }
                                break;
                            }
                    }

                    if(validated)
                        items.Add(components[0]);
                }
            }
            else
            {
                if (
                    items.Contains("byr") &&
                    items.Contains("iyr") &&
                    items.Contains("eyr") &&
                    items.Contains("hgt") &&
                    items.Contains("hcl") &&
                    items.Contains("ecl") &&
                    items.Contains("pid")
                )
                {
                    valid++;
                }

                items.Clear();
            }
        }

        Console.WriteLine(valid);
    }
}