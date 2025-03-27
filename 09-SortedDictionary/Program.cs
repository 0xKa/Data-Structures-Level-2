using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_SortedDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a SortedDictionary
            SortedDictionary<int, string> students = new SortedDictionary<int, string>();

            // Add elements
            students.Add(300, "Mustafa");
            students.Add(200, "Ahmed");
            students.Add(400, "Omar");
            students.Add(100, "Reda");

            // Display all elements
            Console.WriteLine("Sorted Dictionary Elements:");
            foreach (var kvp in students)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            Console.WriteLine("\nAdding a new student:");
            // Add a new student
            students[500] = "Ali"; // Using indexer to add
            foreach (var kvp in students)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            Console.WriteLine("\nUpdating a student's name:");
            // Update an existing value
            students[300] = "Mustafa Updated"; // Update the value for key 300
            Console.WriteLine($"Key: 300, Value: {students[300]}");

            Console.WriteLine("\nChecking if a key exists:");
            // Check if a key exists
            int keyToFind = 300;
            if (students.ContainsKey(keyToFind))
            {
                Console.WriteLine($"Key {keyToFind} exists with value: {students[keyToFind]}");
            }

            Console.WriteLine("\nChecking if a value exists:");
            // Check if a value exists
            string valueToFind = "Reda";
            if (students.ContainsValue(valueToFind))
            {
                Console.WriteLine($"Value '{valueToFind}' exists in the dictionary.");
            }

            Console.WriteLine("\nRemoving an element:");
            // Remove an element by key
            students.Remove(400); // Remove the student with key 400
            foreach (var kvp in students)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            Console.WriteLine("\nCount of elements:");
            // Get the count of elements
            Console.WriteLine($"Total students: {students.Count}");

            Console.WriteLine("\nIterating over keys:");
            // Iterate over just the keys
            foreach (var key in students.Keys)
            {
                Console.WriteLine($"Key: {key}");
            }

            Console.WriteLine("\nIterating over values:");
            // Iterate over just the values
            foreach (var value in students.Values)
            {
                Console.WriteLine($"Value: {value}");
            }

        }
    }
}

/* SortedDictionary vs. SortedList in C#


    In C#, SortedDictionary and SortedList are two commonly used data structures for maintaining a collection of key-value pairs sorted by keys. While they serve similar purposes, they have distinct characteristics that make them suitable for different scenarios. 

SortedDictionary:
    SortedDictionary<TKey, TValue> is a generic collection class in C# that represents a collection of key-value pairs sorted by keys.
    It is implemented as a binary search tree, which ensures that the keys are always sorted in ascending order.
    SortedDictionary offers efficient key-based operations like adding, removing, and searching for elements.
    It provides O(log n) complexity for most operations, making it suitable for scenarios where efficient searching and insertion are required.
    SortedList:

    SortedList<TKey, TValue> is another generic collection class in C# that represents a collection of key-value pairs sorted by keys.
    It is implemented as an array of key-value pairs, sorted by keys using an internal binary search algorithm.
    SortedList offers efficient indexed access to elements, similar to arrays, with O(log n) complexity for searching and insertion operations.
    However, it may incur overhead when elements are inserted or removed, as it may require shifting elements to maintain the sorted order.

Differences between SortedDictionary and SortedList:

    Implementation:
        SortedDictionary: Implemented as a binary search tree.
        SortedList: Implemented as an array of key-value pairs.
        
    Performance Characteristics:
        SortedDictionary offers efficient key-based operations with O(log n) complexity.
        SortedList provides efficient indexed access with O(log n) complexity for searching and insertion but may incur overhead during insertion/removal.
    
    Memory Usage:
        SortedDictionary typically consumes more memory due to its tree structure.
        SortedList may have better memory efficiency, especially for large collections.


In terms of raw performance, the efficiency of SortedDictionary and SortedList can depend on the specific operations you perform and the size of the collection. Here's a breakdown:
    Insertion and Removal:
        SortedList: Insertions and removals may require shifting elements in the underlying array to maintain the sorted order. This operation has a time complexity of O(n) in the worst-case scenario because it may involve copying elements.
        SortedDictionary: Insertions and removals have a time complexity of O(log n) due to the underlying binary search tree structure. This makes SortedDictionary more efficient for these operations, especially for larger collections.
    Search:
        Both data structures offer efficient search operations. SortedList uses binary search (O(log n)) for indexed access, while SortedDictionary also has O(log n) complexity for searching by key.
    Memory Usage:
        SortedList: Typically consumes less memory compared to SortedDictionary because it uses an array structure to store elements.
        SortedDictionary: May consume more memory due to the overhead of maintaining a binary search tree.
    Index-Based Access:
        SortedList: Provides efficient indexed access similar to arrays with O(log n) complexity.
        SortedDictionary: Does not support index-based access directly; you must access elements by their keys, which may involve searching.
    
Considering these factors, if your application involves frequent insertions and removals with a relatively small collection size or if memory efficiency is a concern, SortedList might be a better choice. On the other hand, if you require efficient search operations, especially with larger collections, or if memory usage is not a primary concern, SortedDictionary could be more suitable.

Ultimately, the choice between SortedDictionary and SortedList should be based on your specific use case, considering factors like the size of the collection, the frequency of different operations, and memory constraints.
 */

