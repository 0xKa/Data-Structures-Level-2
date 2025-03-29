using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    public static void PrintJaggedArray<T>(T[][] jaggedArr)
    {
        for (int i = 0; i < jaggedArr.Length; i++)
        {
            for (int j = 0; j < jaggedArr[i].Length; j++)
            {
                Console.Write(jaggedArr[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
    static void Main(string[] args)
    {
        //jagged array is a an array that stores arrays as elements
        int[][] JaggedArray = new int[3][]; //3 elements and each elements contains an array

        JaggedArray[0] = new int[] { 32, 231, 32 };
        JaggedArray[1] = new int[] { 123, 231, 32, 0, 12, 3 };
        JaggedArray[2] = new int[] { 1, 0 };

        PrintJaggedArray(JaggedArray);

        /// LINQ ///

        // all elements sum
        int totalSum = JaggedArray.SelectMany(subarray => subarray).Sum();
        Console.WriteLine("Totak Sum: " + totalSum);

        //find array that has more than 3 elements and select the first elemnet
        var query = JaggedArray.Where(subArr => subArr.Length >= 3).Select(subArr => subArr.First());

        Console.Write("First Elements of Long Rows: ");
        foreach (var item in query)
        {
            Console.Write(item + " ");
        }


    }
}

/* What is Jagged Array?
    • Jagged arrays are a special type of array in C# that store arrays as their elements.
    • Unlike multidimensional arrays, each row in a jagged array can have a different length, providing more flexibility.
    • Jagged arrays are useful when working with a non-rectangular data structure. They provide more control over the array size of each row, allowing for more efficient memory usage in some scenarios.
 */

/* Advanced Concepts in Jagged Arrays
1. Initializing with Different Sizes
    Jagged arrays can have each row with a different size, which is particularly useful for efficiently managing data that doesn't fit neatly into a rectangular grid.

2. Dynamic Row Initialization
    You can initialize each row of a jagged array dynamically, even after the array has been declared. This allows for flexibility in handling data whose size isn't known at compile time.

3. Looping Through Jagged Arrays
    Iterating over jagged arrays requires nested loops - an outer loop for the rows and an inner loop for the columns within each row.

4. Real-World Use-Cases
    Jagged arrays are useful in scenarios where you're dealing with data that naturally forms a hierarchy or tree-like structure. For example, representing a network of roads, where each road (first dimension) has a varying number of intersections (second dimension).
 */

/* Tips for Working with Jagged Arrays
    Memory Efficiency: Jagged arrays can be more memory-efficient than multidimensional arrays when dealing with non-uniform data.
    Initialization Care: Always initialize each row of a jagged array to avoid NullReferenceException.
    Use Cases: Consider using jagged arrays when dealing with complex data structures like graphs, trees, or matrices with rows of varying lengths.
 */
