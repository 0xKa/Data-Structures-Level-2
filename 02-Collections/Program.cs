﻿using System;
using System.Collections;
using System.Collections.Generic;

/* What are Collections?
        • Collections are data structures used to store and organize groups of related objects in memory.
        • Collections are sophisticated/modern ways to store and manage data in C#.
        • They offer more flexibility and functionality compared to basic array types.
        • They allow for dynamic memory allocation, meaning the size of the collection can grow or shrink as needed.
 
    Common Operations in Collections:
    Adding, removing, modifying, sorting, searching, and accessing elements
 */

/* Common Collection Types in C#
    • List
    • SortedList
    • Dictionary
    • Hashtable
    • ArrayList
    • HashSet
    • Stack
    • Queue
    • LinkedList
    • ObservableCollection
    • ConcurrentDictionary
    • BitArray
 */


/* What are Generic Collections?
    Generic collections are part of the System.Collections.Generic namespace.
    Generics allow us to create reusable code that can work with different types.
    Generics introduce the concept of type parameters to collections, making them more flexible and type-safe.
    They allow collections to store any data type and prevent runtime type errors.
    They allow you to specify the type of objects they store example: List<int> .
    They offer type safety, better performance, and reduced need for boxing/unboxing.
    Advantages of Generic Collections
    Type Safety: They store elements of a specified type, reducing runtime errors.
    Performance: No need for boxing/unboxing of value types, which improves performance.
    Reduced Memory Overhead: They directly store elements without converting them to object type.
    Code reusability: Avoids code duplication by creating generic algorithms and data structures.


Key Generic Collections
    List<T>: A list of elements, dynamically resizable.
    Dictionary<TKey, TValue>: A collection of key-value pairs.
    Queue<T>: A first-in, first-out collection.
    Stack<T>: A last-in, first-out collection.
    HashSet<T>: A set of unique elements.
 */

/* What are Non-Generic Collections?
    Non-generic collections are part of the System.Collections namespace.
    They store elements as object types, allowing them to hold any data type.
    They require boxing/unboxing for value types.
    Disadvantages Compared to Generic Collections
    Type Unsafe: Can store any type of object, leading to runtime errors.
    Performance Overhead: Boxing/unboxing of value types impacts performance.
    Memory Overhead: Storing value types as objects consumes more memory.

Key Non-Generic Collections
    ArrayList: Similar to List<T>, but can contain elements of any type.
    Hashtable: Similar to Dictionary<TKey, TValue>, but uses object types for keys and values.
    Queue: A first-in, first-out collection.
    Stack: A last-in, first-out collection.
 */


/* Generic Collections (System.Collections.Generic)
    List<T>: A list of elements that can be accessed by index.
    Dictionary<TKey, TValue>: A collection of key-value pairs.
    Queue<T>: A first-in, first-out (FIFO) collection of objects.
    Stack<T>: A last-in, first-out (LIFO) collection of objects.
    HashSet<T>: A collection of unique and unordered elements.
    LinkedList<T>: A doubly-linked list.
    SortedSet<T>: A collection of objects that maintains order.
    SortedDictionary<TKey, TValue>: A dictionary with sorted keys.
    SortedList<TKey, TValue>: Similar to SortedDictionary but with different performance characteristics.
    ConcurrentDictionary<TKey, TValue>: A thread-safe dictionary used in concurrent scenarios.
    BlockingCollection<T>: Provides blocking and bounding capabilities for thread-safe collections.
    ConcurrentBag<T>: An unordered collection of objects suitable for concurrent scenarios.
    ConcurrentQueue<T>: A thread-safe FIFO collection.
    ConcurrentStack<T>: A thread-safe LIFO collection.
 */

/* Non-Generic Collections (System.Collections)
    ArrayList: A dynamically resizable array.
    Hashtable: A collection of key-value pairs organized based on the hash code of the key.
    Queue: A first-in, first-out (FIFO) collection.
    Stack: A last-in, first-out (LIFO) collection.
    SortedList: A collection of key-value pairs that are sorted by the keys and are accessible by key and by index.
    BitArray: Manages a compact array of bit values, which are represented as Booleans.
    HybridDictionary: Implements IDictionary using a ListDictionary while the collection is small, and then switching to a Hashtable as the collection grows.
    ListDictionary: A simple, small dictionary implemented as a singly linked list.
    NameValueCollection: Represents a collection of associated String keys and String values that can be accessed either with the key or with the index.
    OrderedDictionary: A collection of key-value pairs that are accessible by the key or index.
    StringCollection: A collection of strings.
    StringDictionary: A collection of associated String keys and String values with a hash table implementation.
 */

internal class Program
{
    static void Main(string[] args)
    {
        
        

        Console.ReadKey();
    }
}
