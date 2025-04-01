using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// IEnumerable: items iteration ///
public class CustomCollection1<T> : IEnumerable<T>
{
    private List<T> _list = new List<T>();

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _list.Count; i++)
        {
            yield return _list[i]; /* How yield return Works
                1- It pauses execution of the method and returns a value.

                2- The next time the method is called (like in a foreach loop), execution resumes from where it left off.

                3- This avoids creating and storing the entire collection in memory at once, improving performance.
             */
        }
    }

    IEnumerator IEnumerable.GetEnumerator() 
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        _list.Add(item);
    }

}

/// ICollection: basic operations add, remove, etc...  /// extends IEnumerable
public class CustomCollection2<T> : ICollection<T>
{
    private List<T> _list = new List<T>();


    public int Count => _list.Count;

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        _list.Add(item);
    }

    public void Clear()
    {
        _list.Clear();
    }

    public bool Contains(T item)
    {
        return _list.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }


    public bool Remove(T item)
    {
        return _list.Remove(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

/// IList: access elements using index /// extends ICollection
public class CustomCollection3<T> :IList<T>
{
    private List<T> _list = new List<T>();

    public T this[int index] { get => _list[index]; set => _list[index] = value; }

    public int Count => _list.Count;

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        _list.Add(item);
    }

    public void Clear()
    {
        _list.Clear();
    }

    public bool Contains(T item)
    {
        return _list.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    public int IndexOf(T item)
    {
        return _list.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        _list.Insert(index, item);
    }

    public bool Remove(T item)
    {
        return _list.Remove(item);
    }

    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

/// IDictionary: key-value pairs /// extends ICollection
public class CustomCollection4<TKey, TValue> : IDictionary<TKey, TValue>
{
    private List<KeyValuePair<TKey, TValue>> _list = new List<KeyValuePair<TKey, TValue>>();

    public TValue this[TKey key]
    {
        get
        {
            foreach (var pair in _list)
            {
                if (pair.Key.Equals(key))
                    return pair.Value;
            }

            throw new KeyNotFoundException($"The given key '{key}' was not present in the dictionary.");
        }
        set
        {
            bool IsFound = false;
            
            // modify the element if exists
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].Key.Equals(key))
                {
                    _list[i] = new KeyValuePair<TKey, TValue>(key, value);
                    IsFound = true;
                    break;
                }
            }

            // if not exists, then we add it
            if (!IsFound)
                _list.Add(new KeyValuePair<TKey, TValue>(key,value));

        }


    }

    public ICollection<TKey> Keys => _list.ConvertAll(kvp => kvp.Key);

    public ICollection<TValue> Values => _list.ConvertAll(kvp => kvp.Value);

    public int Count => _list.Count;

    public bool IsReadOnly => false;

    public void Add(TKey key, TValue value)
    {
        foreach (var pair in _list)
            if (pair.Key.Equals(key))
                throw new ArgumentException("An element with the same key already exists.");
        _list.Add(new KeyValuePair<TKey, TValue>(key, value));   
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        Add(item.Key, item.Value);
    }

    public void Clear() => _list.Clear();

    public bool Contains(KeyValuePair<TKey, TValue> item) => _list.Contains(item);

    public bool ContainsKey(TKey key)
    {
        foreach (var pair in _list)
            if (pair.Key.Equals(key))
                return true;
              
        return false;
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() =>  _list.GetEnumerator();

    public bool Remove(TKey key)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            if (Equals(_list[i].Key, key))
            {
                _list.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public bool Remove(KeyValuePair<TKey, TValue> item) => _list.Remove(item);

    public bool TryGetValue(TKey key, out TValue value)
    {
        foreach (var kvp in _list)
        {
            if (Equals(kvp.Key, key))
            {
                value = kvp.Value;
                return true;
            }
        }
        value = default;
        return false;
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Person : IComparable<Person>
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(int iD, string name, int age)
    {
        ID = iD;
        Name = name;
        Age = age;
    }

    public int CompareTo(Person other)
    {
        if (other == null) return 1;

        
        return this.Age.CompareTo(other.Age); // this will set the default comparer to Age
        //this means when comparing Person objects it will compare thier ages
    }
}

internal class Program
{
    public static void IEnumerable_Example()
    {
        CustomCollection1<int> numbers = new CustomCollection1<int>();

        numbers.Add(200);
        numbers.Add(100);
        numbers.Add(500);


        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nAverage: " + numbers.Average());

        var query = numbers.Select(x => x * x);
        Console.WriteLine("\nNumbers Squared:");
        foreach (var item in query)
        {
            Console.WriteLine(item);
        }

    }
    
    public static void ICollection_Example()
    {
        CustomCollection2<string> names = new CustomCollection2<string>();

        names.Add("Ahmed");
        names.Add("Victor");
        names.Add("Reda");

        foreach (var item in names)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nContains 'Ahmed'?: " + names.Contains("Ahmed"));
        Console.WriteLine("\nRemove 'Ahmed'?: " + names.Remove("Ahmed"));
        foreach (var item in names)
        {
            Console.WriteLine(item);
        }
    }
    
    public static void IList_Example()
    {
        CustomCollection3<int> nums = new CustomCollection3<int>()
        {
            0,0,0
        };



        nums[0] = 1;
        nums[1] = -1;
        nums[2] = 10;


        foreach (var item in nums)
        {
            Console.Write(nums.IndexOf(item) + ": " + item);
            Console.WriteLine();
        }

    }

    public static void IDictionary_Example()
    {
        var myDictionary = new CustomCollection4<int, string>();


        // Adding elements to the dictionary
        myDictionary.Add(1, "One");
        myDictionary.Add(2, "Two");
        myDictionary.Add(3, "Three");


        // Accessing an element by key
        Console.WriteLine($"Element with key 2: {myDictionary[2]}");


        // Updating an element by key
        myDictionary[2] = "Two Updated";
        Console.WriteLine($"Updated element with key 2: {myDictionary[2]}");


        // Iterating over the dictionary
        Console.WriteLine("\nIterating over the dictionary:");
        foreach (var kvp in myDictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }


        // Demonstrate the ContainsKey and Remove functionality
        if (myDictionary.ContainsKey(3))
        {
            Console.WriteLine("\nContains key 3, removing...");
            myDictionary.Remove(3);
        }

        // Display the dictionary after removal
        Console.WriteLine("\nDictionary after removing key 3:");
        foreach (var kvp in myDictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
        Console.ReadKey();
    }

    public static void IComparable_Example()
    {
        List<Person> people = new List<Person>()
        {
            new Person(1, "Reda", 20),
            new Person(2, "Ahmed", 19),
            new Person(3, "Khalid", 24),
            new Person(4, "Mustafa", 22),
        };

        Console.WriteLine("People List:");
        foreach (var person in people)
        {
            Console.WriteLine($"{person.ID}: {person.Name}, {person.Age}");
        }
        

        Console.WriteLine("\n\nPeople List Sorted by the Default Comparer:");
        people.Sort();
        foreach (var person in people)
        {
            Console.WriteLine($"{person.ID}: {person.Name}, {person.Age}");
        }


    }

    static void Main(string[] args)
    {
        //IEnumerable_Example();
        //ICollection_Example();
        //IList_Example();
        //IDictionary_Example();
        IComparable_Example();
    }
}


/* IEnumerable Interface 

What is IEnumerable?
Definition
    IEnumerable is an interface located in the System.Collections namespace. It serves as the backbone for iterating over collections, including arrays, lists, and other enumerable data structures.

Purpose
    IEnumerable & IEnumerable<T>: The base interface for all collections, providing support for simple iteration over a collection, This interface allows a collection to be iterated over using the foreach loop in C#.

    IEnumerable is also crucial for LINQ, allowing for powerful data queries on collections.

How IEnumerable Works
    Basic Mechanics
        The IEnumerable interface defines a single method, GetEnumerator, which returns an IEnumerator object. This IEnumerator allows for moving through a collection, accessing elements without modifying the underlying data structure.

IEnumerator Interface
    IEnumerator provides the mechanism for iteration with three key components:

        MoveNext(): Advances the enumerator to the next element in the collection.
        Current: Returns the current element in the collection.
        Reset(): Sets the enumerator to its initial position, before the first element in the collection.
    Best Practices
        Use IEnumerable<T> when you need to read a collection of items and you don’t need to modify the collection.
        Prefer IEnumerable<T> over IEnumerable for type safety and better performance.
        When implementing IEnumerable<T>, use the yield return statement for a simpler implementation of the enumerator pattern.

Conclusion
    The IEnumerable interface is a cornerstone of collection manipulation and querying in C#. By understanding and implementing IEnumerable, you enhance your ability to work efficiently with data in .NET environments.

    Understanding and implementing IEnumerable and IEnumerable<T> is fundamental for working with collections in C#. It provides a standard way to iterate over collections, enhances code readability, and ensures type safety with IEnumerable<T>. By incorporating these interfaces into your custom collections, you can leverage the power of foreach loops and LINQ queries, making your C# applications more efficient and maintainable.
 */

/* ICollection Interface 
 
What is ICollection?
Definition
    ICollection is an interface in the System.Collections namespace that extends IEnumerable.

    It provides a general-purpose way to manage collections, adding functionalities such as counting, adding, and removing elements.

Purpose
    While IEnumerable allows for simple iteration over a collection, ICollection takes it a step further by offering additional capabilities that are essential for managing dynamic collections.

Key Features of ICollection
    ICollection includes properties and methods that enable more comprehensive management of collections. Key features include:

        Count: Gets the number of elements contained in the collection.
        IsReadOnly: Gets a value indicating whether the collection is read-only.
        Add, Remove, Clear: Methods to modify the collection.
        Contains Method: Checks if the collection contains a specific item.
Best Practices
    Use ICollection<T> when you need a modifiable collection with basic operations such as add, remove, and contains.
    ICollection<T> is more specialized than IEnumerable<T> but less so than IList<T> or IDictionary<TKey, TValue>. Choose the interface that best fits your needs based on the operations you require.
    Implementing ICollection<T> in custom collections makes them more versatile and compatible with .NET's collection manipulation and LINQ queries.

Conclusion
    The ICollection interface is a powerful tool for managing collections in C#. By offering a standardized way to manipulate collections beyond simple iteration, it enables developers to handle dynamic data sets efficiently.

Understanding and implementing ICollection and ICollection<T> is crucial for creating and manipulating collections in C#. These interfaces provide a standardized way to manage collections with operations like add, remove, and check for items, enhancing the functionality and flexibility of your C# applications. Through practical implementations and adherence to best practices, developers can effectively utilize these interfaces to manage collections in a type-safe and efficient manner.
 */

/* IList Interface

What is IList?
Definition
    List is an interface that resides in the System.Collections namespace and extends ICollection. It represents a collection of objects that can be individually accessed by index, offering a more flexible way to interact with collections.

Purpose
    The primary advantage of IList is its support for indexed access, which allows for the retrieval, update, or removal of elements at specific positions within the collection. This feature is crucial for many data manipulation scenarios where order and position matter.

Key Features of IList
    IList includes all the functionalities of IEnumerable and ICollection, with additional features tailored towards indexed access:

        Index-based access: IList provides the ability to access, modify, or remove items based on their index in the collection.
        Insert and RemoveAt: Add or remove elements at a specified index, adjusting the collection accordingly.
        IndexOf: Find the index of a specific element in the collection.
        Count and IsReadOnly properties: Similar to ICollection, these properties provide information about the size of the collection and whether it is read-only.
        Add, Insert, Remove, and RemoveAt methods: Beyond the capabilities inherited from ICollection, IList allows for inserting and removing items at specified indices.
Best Practices
    Choosing between IList and other collection interfaces: Use IList when you need both sequential access and the ability to manipulate the collection by index. If you only need sequential access without modifications, IEnumerable might be sufficient. For collections that require key-value pair management, consider IDictionary.
    Performance considerations: Operations that involve indexing, like inserting or removing at a specific index, can have different performance characteristics depending on the underlying collection type (e.g., List<T> vs. LinkedList<T>). Choose the appropriate concrete collection type based on your performance requirements.

Conclusion
    The IList interface is a versatile tool in the .NET collection framework, offering a blend of enumeration, collection manipulation, and indexed access. Its ability to provide direct access to elements by index makes it indispensable for many programming scenarios in C#.

    IList plays a crucial role in the .NET collection hierarchy by providing a versatile interface for collections that can be accessed and manipulated by index. Through implementing IList<T>, developers can create custom collections that offer detailed control over their elements, making it easier to manage collections in a variety of application scenarios. Understanding how to use and implement IList alongside other collection interfaces like IEnumerable and ICollection enables developers to leverage the full power of the .NET Framework's collection management capabilities.
 */

/* IDictionary Interface
What is IDictionary?
Definition
    IDictionary is an interface located in the System.Collections namespace that represents a collection of key-value pairs. It extends ICollection, facilitating not just the enumeration but also the sophisticated manipulation of data based on keys.

    The IDictionary interface is implemented by many classes, including Dictionary<TKey,TValue>, SortedDictionary<TKey,TValue>, and ConcurrentDictionary<TKey,TValue>, each offering different features and performance benefits.

Purpose
    The main purpose of IDictionary is to provide a mechanism for accessing items quickly using keys, ensuring efficient data retrieval and storage. It is particularly useful in scenarios where items need to be located and manipulated based on unique identifiers.

    IDictionary stands out from other collection interfaces by focusing on key-value pair management. Unlike IEnumerable, ICollection, and IList, which facilitate enumeration and indexed access, IDictionary provides optimized data access through keys, making it ideal for lookup scenarios.

Key Features of IDictionary
    IDictionary enhances data manipulation capabilities by introducing features centered around key-value pair management:

        Keys and Values Properties: Access collections of keys and values separately.
        Item Property: Get or set the value associated with a specific key.
        Add, Remove, ContainsKey: Methods to add new key-value pairs, remove pairs, and check if a key exists in the collection.

Conclusion
    The IDictionary interface is an essential component of the .NET collection framework, offering a structured approach to managing key-value pairs. Its ability to facilitate quick data access and manipulation based on keys makes it a valuable tool for developers.
 */

/* ISet Interface 
 What is ISet?
Definition
    ISet is an interface located in the System.Collections.Generic namespace, designed to represent a collection of unique elements, ensuring no duplicates are stored.

Purpose
    The primary aim of ISet is to facilitate the management of collections where the uniqueness of each element is paramount, providing efficient methods for set operations like union, intersection, and difference.

    ISet differentiates itself from other collection interfaces like IEnumerable, ICollection, and IList by focusing on the uniqueness of elements and providing set operations. These capabilities make ISet ideal for scenarios requiring distinct elements with efficient mathematical set processing.

Key Features of ISet
    ISet brings forth a set of functionalities tailored for handling unique collections:
        Uniqueness: Automatically ensures all elements in the collection are unique.
        Set Operations: Supports mathematical set operations, including UnionWith, IntersectWith, ExceptWith, and SymmetricExceptWith, allowing for the combination, comparison, and manipulation of sets.
        Add, Remove, Contains: Methods to add new elements (if not already present), remove elements, and check for the existence of elements.

Conclusion
    The ISet interface offers a powerful framework for managing collections that require each element to be unique. By providing efficient operations for manipulating sets, ISet enables developers to handle distinct collections effectively in C#.
 */

/* IComparable Interface

What is IComparable?
Definition
    mparable is an interface defined in the System namespace that provides a method for comparing an instance of a class to another instance of the same class.

Purpose
    rimary purpose of IComparable is to provide a standard way to compare objects, allowing them to be ordered or sorted based on a specific field or property. This is especially useful when working with collections that need to be sorted or when determining the position of an object relative to others in a list.

Conclusion
     IComparable interface is essential for defining how objects are compared and sorted within collections in C#. By implementing IComparable, developers gain fine-grained control over the order of their custom objects, facilitating efficient sorting and ordering operations based on custom criteria.
 */
