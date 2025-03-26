using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    public static SortedList<int, string> MySortedList = new SortedList<int, string>()
    {
        {2, "MP5" },
        {1, "AK-47" },
        {4, "M4A1" },
        {8, "SPAS-12" },
        {6, "D-Eagle" },
        {13, "Kar98k" },
        {5, "ACR" },
        {14, "MAC-10" },
        {11, "FAMAS" },
        {3, "M16" },
        {7, "RPD" },
        {9, "SCAR-H" },
        {12, "AUG" },
        {10, "P90" }

    };

    public static void PrintSortedList<TKey, TValue>(SortedList<TKey, TValue> SortedList)
    {
        Console.WriteLine("\n\nSorted List Count: " + SortedList.Count);
        //use foreach or string.Join()
        Console.WriteLine(string.Join(",\n", SortedList));
    }

    public static void LINQ_Example1()
    {

        var query = from listItem in MySortedList
                    where listItem.Value.Any(char.IsDigit) //check if any item value contains a Number
                    select listItem;

        foreach (var item in query) Console.WriteLine(item.Key + ", " + item.Value);

    }
    
    public static void LINQ_Example2()
    {

        var query = from listItem in MySortedList
                    group listItem by listItem.Value.Length; //group by string length

        foreach (var group in query)
        {
            Console.WriteLine("String Length: " + group.Key);

            Console.WriteLine(string.Join(", ", group.Select(g => g.Value)) + "\n");

            //foreach (var item in group)
            //    Console.Write(item.Value + " ");
            //Console.WriteLine("\n");
        }

    }

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }


        public Employee(string name, string department, decimal salary)
        {
            Name = name;
            Department = department;
            Salary = salary;
        }
    }
    public static SortedList<int, Employee> employees = new SortedList<int, Employee>()
    {
        { 4, new Employee("Mustafa", "IT", 80000) },
        { 8, new Employee("Salim", "Sales", 52000) },
        { 5, new Employee("Mubark", "Marketing", 45000) },
        { 3, new Employee("Khalid", "HR", 80000) },
        { 6, new Employee("Malek", "IT", 44000) },
        { 7, new Employee("Reda", "Sales", 56000) },
        { 12, new Employee("Abdullah", "HR", 72000) },
        { 9, new Employee("Marwan", "Sales", 34250) },
        { 10, new Employee("Omran", "Marketing", 52000) },
        { 1, new Employee("Ahmed", "HR", 50000) },
        { 11, new Employee("Yousif", "IT", 77700) },
        { 2, new Employee("Mohammed", "IT", 70000) }
    };
    public static void LINQ_Example3()
    {

        var query = from employee in employees
                    group employee by employee.Value.Department; //group by department name

        foreach ( var group in query)
        {
            Console.WriteLine("Department: " + group.Key);
            Console.WriteLine(string.Join(", ", from emp in @group select emp.Value.Name));
            //Console.WriteLine(string.Join(", ", group.Select(emp => emp.Value.Name))); //alternative
        }

    }
    public static void LINQ_Example4()
    {

        var query = from employee in employees
                    where employee.Value.Salary <= 50000 && employee.Value.Department != "Sales"
                    orderby employee.Value.Salary descending
                    select employee;

        Console.WriteLine("Employees Where Salary <= 50000 & NOT from Sales Department : ");
        
        foreach (var emp in query)
            Console.WriteLine(emp.Key + ", " + emp.Value.Name + ", " + emp.Value.Department + ", " + emp.Value.Salary);

    }

    static void Main(string[] args)
    {
        //PrintSortedList<int, string>(MySortedList);

        //LINQ_Example1();
        //LINQ_Example2();
        //LINQ_Example3();
        //LINQ_Example4();

        Console.WriteLine("\n\n\n");
    }
}
/* SortedList in C#

    The SortedList is a collection that stores key-value pairs, sorted by the key. It is part of the System.Collections (non-generic) and System.Collections.Generic namespaces in C#.

    Understanding how to use SortedList is important for scenarios where you need a dictionary-like collection with sorting by default.

Characteristics of SortedList
    Automatically Sorted: The elements in a SortedList are sorted by the key as soon as they are added.
    Key-Value Pairs: Similar to a dictionary, it stores elements as key-value pairs.
    Unique Keys: Keys must be unique, and an exception is thrown if a duplicate key is added.
    Slower for addition and Faster for Search because it uses binary search algorithm.
    
Conclusion
    SortedList in C# is a useful collection for scenarios where automatic sorting of elements is required. Understanding when to use SortedList over other collections like Dictionary or List is crucial for efficient data management in your applications.
 */

/* SortedList vs List
In C#, SortedList and List are two different types of collections that serve different purposes and have different characteristics. Here's a comparison to help you understand the differences between them:

- List<T>
    Type: A generic collection that stores elements in a linear fashion.
    Ordering: The elements in a List<T> are ordered based on how they are added or inserted. You can manually sort the list using the Sort() method.
    Performance: Adding elements to a List<T> is fast, especially at the end. However, inserting or removing elements in the middle or beginning of the list can be slower because it may require shifting elements.
    Use Case: Use List<T> when you need a simple, flexible collection to add, remove, and access elements in no particular order, or when you control the order of elements manually.

- SortedList<TKey, TValue>
    Type: A generic collection that stores key-value pairs sorted by keys. It is a combination of an array and a hashtable.
    Ordering: The elements in a SortedList<TKey, TValue> are automatically sorted by the key. You cannot insert elements at a specific position as their position is determined by the key.
    Performance: Adding, removing, and accessing elements can be fast if the collection is not large, as it uses binary search to find keys. However, the performance can degrade as the collection grows due to the cost of maintaining order.
    Use Case: Use SortedList<TKey, TValue> when you need a collection of key-value pairs that must be sorted by key and you frequently need to search elements by key.

-Summary
    Purpose: List<T> is used for a simple list of items, whereas SortedList<TKey, TValue> is used for sorted key-value pairs.
    Ordering: List<T> maintains the order of elements as they are added, while SortedList<TKey, TValue> sorts elements by key.
    Performance: List<T> is generally faster for adding/removing at the end; SortedList<TKey, TValue> maintains sorted order, which can affect performance during additions/removals.
    Use Case: Choose List<T> for simplicity and when order is controlled manually or not important. Choose SortedList<TKey, TValue> when you need automatic sorting by keys and efficient key-based lookups.
    
Each collection type in C# is designed for specific scenarios, so the choice between List<T> and SortedList<TKey, TValue> depends on your specific requirements regarding ordering, performance, and the nature of operations you'll be performing on the collection.
 */
