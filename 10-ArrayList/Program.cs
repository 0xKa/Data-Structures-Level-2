using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int ID, string Name) { 
        Id = ID;
        this.Name = Name;
        }
    }
    static void Main(string[] args)
    {
        // Create an ArrayList
        ArrayList items = new ArrayList();

        // Add elements to the ArrayList
        items.Add("Reda");
        items.Add("Hilal");
        items.Add(42); // Adding an integer
        items.Add(3.14); // Adding a double
        items.Add("Salim");
        items.Add(true); // Adding a boolean
        items.Add(new Person(1, "Mustafa")); // Adding a custom object

        Console.WriteLine("ArrayList after adding elements:");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nInserting an element at a specific index:");
        // Insert an element at index 2
        items.Insert(2, "Tariq");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nRemoving an element:");
        // Remove an element (by value)
        items.Remove("Hilal");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nRemoving an element by index:");
        // Remove an element by index
        items.RemoveAt(3);
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nChecking if the ArrayList contains an element:");
        // Check if an element exists
        bool containsReda = items.Contains("Reda");
        Console.WriteLine($"Contains 'Reda': {containsReda}");

        Console.WriteLine("\nSorting the ArrayList:");
        try
        {
            items.Sort(); // Sort the ArrayList
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Cannot sort: ArrayList contains mixed types.");
        }

        Console.WriteLine("\nAccessing an element by index:");
        // Access an element by index
        Console.WriteLine($"Element at index 1: {items[1]}");

        Console.WriteLine("\nClearing the ArrayList:");
        // Clear the ArrayList
        items.Clear();
        Console.WriteLine($"Number of elements after clearing: {items.Count}");


        /// to use LINQ operatins we can cast the ArrayList first
    }
}

/* Introduction to ArrayList

Overview:
    ArrayList is a dynamic array that can hold elements of any data type.
    It's part of the System.Collections namespace.
    Unlike arrays, ArrayList can grow dynamically as elements are added, but it does not automatically decrease its capacity when elements are removed.

Key Points:
    Dynamic Sizing: Unlike arrays, ArrayList automatically increases its size as elements are added. However, it does not automatically decrease its capacity when elements are removed.
    Heterogeneous Collection: ArrayList can hold elements of different data types. This flexibility allows for the storage of different types of objects within the same collection.
    Methods and Properties: ArrayList provides various methods and properties to manipulate and access elements, such as Add(), Remove(), Insert(), Count, and Capacity.
    Memory Management: Although ArrayList does not automatically decrease its capacity when elements are removed, you can use the TrimToSize() method to reduce the capacity to match the number of elements stored in the list.
 */


