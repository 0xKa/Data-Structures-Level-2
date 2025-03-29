using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/* When to Use Arrays Over Other Collections? 
 * 
      - Performance-critical scenarios where you know the size of the collection in advance.

      - When you want fixed-size collections.

      - When you need low memory overhead (compared to List<T> or LinkedList<T>).

      - For multidimensional data (e.g., matrices).
 */

internal class Program
{
    public static void ArrayOpeartions()
    {
        int[] numbers = new int[5];  // Array with default values 
        int[] predefined = { 1, 2, 3, 4, 5 };  // Predefined array

        string[] languages = new string[] { "C#", "Java", "Python" };  // Explicit initialization


        Console.WriteLine(predefined[0]); // Outputs: 1
        predefined[1] = 10;              // Modifies the second element
        Console.WriteLine(predefined[1]); // Outputs: 10


        /// Traversing an Array using for loop ///
        for (int i = 0; i < predefined.Length; i++)
        {
            Console.Write(predefined[i] + " ");
        }
        /// Traversing an Array using foreach loop ///
        foreach (int number in predefined)
        {
            Console.WriteLine(number + " ");
        }

        /// Sorting Array ///
        int[] unsorted = { 3, 1, 4, 1, 5, 9 };
        Array.Sort(unsorted); // Sorts in ascending order
        Console.WriteLine("Sorted: " + string.Join(", ", unsorted)); // Outputs: 1, 1, 3, 4, 5, 9

        Array.Reverse(unsorted); // Reverses the order (descending)
        Console.WriteLine("Descending: " + string.Join(", ", unsorted)); // Outputs: 9, 5, 4, 3, 1, 1


        /// Searching in Array ///
        int[] mynumbers = { 1, 2, 3, 4, 5 };

        int index = Array.IndexOf(mynumbers, 3); // Finds index of 3
        Console.WriteLine(index); // Outputs: 2

        int firstEven = Array.Find(mynumbers, n => n % 2 == 0); // Finds the first even number
        Console.WriteLine(firstEven); // Outputs: 2

        /// Copying Arrays ///
        // Array.Copy(): A method to copy elements from one array to another.
        // Shallow Copy: Only references are copied if the array contains objects, to do it you can use = operator.

        int[] source = { 1, 2, 3 };
        int[] destination = new int[source.Length];

        Array.Copy(source, destination, source.Length);
        Console.WriteLine("Copied: " + string.Join(", ", destination)); // Outputs: 1, 2, 3

        int[] cloned = (int[])source.Clone();
        Console.WriteLine("Cloned: " + string.Join(", ", cloned)); // Outputs: 1, 2, 3


        /// Resizing an Array ///
        int[] nums = { 1, 2, 3 };
        Array.Resize(ref nums, 5); // Resizes to a length of 5 // Note: that arrays have a fixed size, so resizing creates a new array behind the scenes.
        Console.WriteLine("Resized: " + string.Join(", ", nums)); // Outputs: 1, 2, 3, 0, 0

        /// Clearing an Array ///
        Array.Clear(nums, 0, nums.Length);
        Console.WriteLine("Cleared: " + string.Join(", ", nums)); // Outputs: 0, 0, 0, 0, 0


        /// Multidimensional Array /// 
        int[,] matrix = new int[2, 3]; // 2x3 matrix
        int[,] PredefinedMatrix = { { 1, 2, 3 }, { 4, 5, 6 } }; // Predefined 2x3 matrix

        Console.WriteLine("Printing Matrix:");
        for (int i = 0; i < PredefinedMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < PredefinedMatrix.GetLength(1); j++)
            {
                Console.Write(PredefinedMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }

    }

    public static void LINQ_Example1()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        IEnumerable<int> query = numbers.Where(n => n % 2 == 0); // Returns even numbers
        foreach (int number in query)
        {
            Console.Write(number + " "); // Outputs: 2 4
        }
        Console.WriteLine();

        IEnumerable<int> query2 = numbers.Select(n => n * 10); // Multiplies each number by 10
        foreach (int number in query2)
        {
            Console.Write(number + " "); // Outputs: 10 20 30 40 50
        }
        Console.WriteLine();

        IEnumerable<int> query3 = numbers.OrderBy(n => n); // Sorts in ascending order
        foreach (int number in query3)
        {
            Console.Write(number + " "); // Outputs: 1 2 3 4 5
        }
        Console.WriteLine();

        IEnumerable<int> query4 = numbers.OrderByDescending(n => n); // Sorts in descending order
        foreach (int number in query4)
        {
            Console.Write(number + " "); // Outputs: 5 4 3 2 1
        }
        Console.WriteLine();

        IEnumerable<int> query5 = numbers.Take(3); // Takes the first 3 elements
        foreach (int number in query5)
        {
            Console.Write(number + " "); // Outputs: 1 2 3
        }
        Console.WriteLine();

        IEnumerable<int> query6 = numbers.Skip(2); // Skips the first 2 elements
        foreach (int number in query6)
        {
            Console.Write(number + " "); // Outputs: 3 4 5
        }
        Console.WriteLine();

        IEnumerable<int> query7 = numbers.Where(n => n % 2 == 0).OrderBy(n => n).Select(n => n * 10);
        foreach (int number in query7)
        {
            Console.Write(number + " "); // Outputs: 20 40
        }
        Console.WriteLine();

        // Query Syntax
        IEnumerable<int> query8 = from n in numbers
                                  where n % 2 == 0
                                  orderby n
                                  select n * 10;
        foreach (int number in query8)
        {
            Console.Write(number + " "); // Outputs: 20 40
        }
        Console.WriteLine();

        // Query Syntax with Multiple Data Sources
        int[] numbers1 = { 1, 2, 3 };
        int[] numbers2 = { 3, 4, 5 };
        IEnumerable<int> query9 = from n1 in numbers1
                                  from n2 in numbers2
                                  select n1 * n2;
        foreach (int number in query9)
        {
            Console.Write(number + " "); // Outputs: 3 4 5 6 8 10 9 12 15
        }
        Console.WriteLine();



    }

    public static void LINQ_Example2()
    {
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        //calculates the square of even numbers
        var query = from n in arr
                    where n % 2 == 0
                    select n * n;

        foreach (var item in query)
        {
            Console.WriteLine(item);
        }
    }

    public static void LINQ_Example3()
    {
        // array of anonymous objects
        var people = new[]
        {
            new { Name = "Reda", Age = 30 },
            new { Name = "Omar", Age = 25 },
            new { Name = "Marwan", Age = 35 },
            new { Name = "Salim", Age = 25 },
            new { Name = "Ibrahim", Age = 35 },
            new { Name = "Omarn", Age = 25 },
            new { Name = "Khalid", Age = 30 },
            new { Name = "Ahmed", Age = 30 },
            new { Name = "Ali", Age = 35 },
            new { Name = "Mustafa", Age = 25 }
        };

        //group people by age then oreder them by name
        var groupedByAgeQuery = from n in people
                                group n by n.Age into AgeGrouped
                                orderby AgeGrouped.Key ascending // Order groups by age (ascending)
                                select new 
                                {
                                    //specifing each group
                                    Age = AgeGrouped.Key,
                                    People = AgeGrouped.OrderBy(p => p.Name) // Order people by name within each group

                                };

        foreach (var group in groupedByAgeQuery)
        {
            Console.WriteLine("Age Group: " + group.Age);
            foreach (var item in group.People)
            {
                Console.WriteLine($"   - Name: {item.Name}, {item.Age}");
            }
        }

    }

    public static void LINQ_Example4()
    {
        /// Joining and Projection ///

        // Array of employees
        var employees = new[]
        {
            new { Id = 1, Name = "Alice", DepartmentId = 2 },
            new { Id = 2, Name = "Bob", DepartmentId = 1 }
        };


        // Array of departments
        var departments = new[]
        {
            new { Id = 1, Name = "Human Resources" },
            new { Id = 2, Name = "Development" }
        };

        var JoinQuery = employees.Join(
            departments,
            e => e.DepartmentId, 
            d => d.Id, 
            (e, d) => new { e.Name, Department = d.Name });

        foreach (var detail in JoinQuery)
        {
            Console.WriteLine($"Employee: {detail.Name}, Department: {detail.Department}");
        }

    }

    static void Main(string[] args)
    {
        //ArrayOpeartions();
        //LINQ_Example1();
        //LINQ_Example2();
        //LINQ_Example3();
        LINQ_Example4();

    }
}