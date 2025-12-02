using System;
using System.IO;
using System.Text.RegularExpressions;

public class Program
{
    public static void Task1()
    {
        var content = File.ReadAllText("in.txt");
        content = content.Replace("\n", "");
        var tab = content.Split(",");
        long res = 0;

        foreach(var elem in tab)
        {
            var match = Regex.Match(elem, "(\\d+)-(\\d+)");
            var a = long.Parse(match.Groups[1].Value);
            var b = long.Parse(match.Groups[2].Value);
            var startA = a;
            var p = a.ToString();
            var q = b.ToString();
            var half = p.Substring(0, p.Length / 2);

            while(a < b)
            {
                if(p.Length % 2 == 1)
                {
                    a = (long)(Math.Pow(10, p.Length));
                    p = a.ToString();
                    half = p.Substring(0, p.Length / 2);
                    if(a > b) break;
                }

                p = half + half;
                a = long.Parse(p);

                if(a <= b && a >= startA) 
                {
                    res += a;
                }

                var x = long.Parse(half) + 1;
                half = x.ToString();
            }
        }
        
        Console.WriteLine("Task 1: " + res);
    }

    public static void Task2()
    {
        var content = File.ReadAllText("in.txt");
        content = content.Replace("\n", "");
        var tab = content.Split(",");
        long res = 0;

        foreach(var elem in tab)
        {
            
            var match = Regex.Match(elem, "([0-9]+)-([0-9]+)");
            var a = long.Parse(match.Groups[1].Value);
            var b = long.Parse(match.Groups[2].Value);

            while(a <= b)
            {
                var p = a.ToString();
                match = Regex.Match(p, "^([0-9]+)\\1+$");

                if(match.Groups[1].Value != "")
                {
                    res += a;
                }

                a++;
            }

        }

        Console.WriteLine("Task 2: " + res);
    }

    public static void Main(string[] args)
    {
        Task1();
        Task2();
    }
}