using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    public static (int Min, int Max, int Sum, int Count) GetMinMaxSumCount(int[] Numbers) => (Numbers.Min(), Numbers.Max(), Numbers.Sum(), Numbers.Count());

    static void Main(string[] args)
    {
        var UnnamedTuple = ("Reda", 20 , 120000.0);
        
        var MyTuple = (Name: "Reda", Age: 20, Salary: 120000.0);
        Console.WriteLine(MyTuple.Name);
        Console.WriteLine(MyTuple.Age);
        Console.WriteLine(MyTuple.Salary);

        int[] numbers = { 10, 32, 0, 392, 1, 169, -13, 32, -9 };
        var result = GetMinMaxSumCount(numbers);
        Console.WriteLine($"Min = {result.Min}");
        Console.WriteLine($"Max = {result.Max}");
        Console.WriteLine($"Sum = {result.Sum}");
        Console.WriteLine($"Count = {result.Count}");

        Console.WriteLine();
        /// LINQ ///
        Console.WriteLine("LINQ:");
        var query = numbers.Where(x => x < 0);

        foreach (var number in query)
        {
            Console.WriteLine(number);
        }


    }
}

/* Key Features of Tuples

    Lightweight and Simple: Tuples allow you to quickly group a set of values without defining a separate type (e.g., a class).

    Type Safety: Each element in the tuple has a specific type, and C# enforces type safety.

    Immutable: Tuples are immutable, meaning their values cannot be changed after initialization.

    Supports Named Elements: Modern tuples (introduced in C# 7.0) support named elements for better readability.
 */