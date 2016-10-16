using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    static void Main(string[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        Console.ReadLine();
        var X = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

        Console.WriteLine(StandardDeviation(X));
    }
    public static string StandardDeviation(int[] values)
    {
        var mean = Mean(values);
        var valueMeanSquared = 0m;
        foreach (var value in values)
        {
            var valueMean = value - mean;
            valueMeanSquared += (valueMean * valueMean);
        }
        var variance = valueMeanSquared / values.Length;
        return string.Format("{0:0.0}", Math.Sqrt((double)variance));
    }

    public static decimal Mean(int[] values)
    {
        var mean = 0m;
        foreach (var element in values) mean += element;
        return mean / values.Length;
    }
}

