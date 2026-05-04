using System;
using System.Linq;

class Program
{
    static void Main()
    {
        double[] data = {
            115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83,
            21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109,
            105, 183, 110
        };

        Array.Sort(data);
        int n = data.Length;

        double mean = data.Average();

        double median = (n % 2 == 0) ?
            (data[n / 2] + data[n / 2 - 1]) / 2 :
            data[n / 2];

        var mode = data.GroupBy(x => x)
                       .OrderByDescending(g => g.Count())
                       .First().Key;

        double variance = data.Sum(x => Math.Pow(x - mean, 2)) / n;

        double stdDev = Math.Sqrt(variance);

        double range = data.Max() - data.Min();

        double Q1 = data[n / 4];
        double Q2 = median;
        double Q3 = data[(3 * n) / 4];

        double IQR = Q3 - Q1;

        double P20 = data[(int)(0.2 * n)];
        double P50 = median;

        Console.WriteLine("Mean = " + mean);
        Console.WriteLine("Median = " + median);
        Console.WriteLine("Mode = " + mode);
        Console.WriteLine("Variance = " + variance);
        Console.WriteLine("Standard Deviation = " + stdDev);
        Console.WriteLine("Range = " + range);
        Console.WriteLine("Q1 = " + Q1);
        Console.WriteLine("Q2 = " + Q2);
        Console.WriteLine("Q3 = " + Q3);
        Console.WriteLine("IQR = " + IQR);
        Console.WriteLine("P20 = " + P20);
        Console.WriteLine("P50 = " + P50);

        double lower = Q1 - 1.5 * IQR;
        double upper = Q3 + 1.5 * IQR;

        Console.WriteLine("\nOutliers:");
        foreach (var x in data)
        {
            if (x < lower || x > upper)
                Console.WriteLine(x);
        }
    }
}

// Mean = 161.28
// Median = 172
// Mode = 21
// Variance = 41525.2416
// Standard Deviation = 203.7774315276351
// Range = 1094
// Q1 = 62
// Q2 = 172
// Q3 = 188
// IQR = 126
// P20 = 31
// P50 = 172

// Outliers:
// 1099