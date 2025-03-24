using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    //time complexity of dictionary is O(1)
    public static Dictionary<int, string> MyDictionary = new Dictionary<int, string>
    {
        { 1, "Reda" },
        { 5, "Ahmed" },
        { 433, "Khalid" },
        { 11, "Salim" },
        { 543, "Yasir" },
        { 4, "Ali" },
        { 32, "Ibrahim" },
        { -5, "Saif" }
    };

    public static Dictionary<string, string> FruitsCategory = new Dictionary<string, string>
    {
        {"Apple", "Tree" },
        {"Banana", "Herb" },
        {"Cherry", "Tree" },
        {"Strawberry", "Bush" },
        {"Raspberry", "Bush" },
        {"Orange", "Tree" }
    };

    public static void PrintDictionaryContent<Tkey, Tvalue>(Dictionary<Tkey, Tvalue> dictionary)
    {
        Console.WriteLine($"\n\nNumber of Dictionary Elements: {dictionary.Count}.");

        foreach (KeyValuePair<Tkey, Tvalue> pair in dictionary)
        {
            Console.WriteLine($"Key = {pair.Key}, Value = {pair.Value}");
        }
    }

    public static void TryGetValue_Example()
    {
        //use .TryGetValue() to handle error if the key wasn't found
        bool IsFound = MyDictionary.TryGetValue(666, out string value);
        Console.WriteLine("\n\n.TryGetValue() result: " + IsFound + (IsFound ? ", Value: " + value : string.Empty));

    }

    public static void LINQ_Example1()
    {

        //Using LINQ to transform items
        var TransformedDic = MyDictionary.Select(n => new { n.Key, n.Value });
        //after transform we can apply LINQ operations, like:
        TransformedDic.OrderBy(n => n.Key);


        //or
        Dictionary<int, string> FilteredDic = MyDictionary.Where(n => n.Key >= 0 && n.Key <= 11).OrderBy(n => n.Key).ToDictionary(n => n.Key, n => n.Value);
        PrintDictionaryContent(FilteredDic);


        int sum = MyDictionary.Sum(n => n.Key);
        Console.WriteLine("\nAggregate Function Exampele: SUM of dictionary keys = " + sum);
        

    }

    public static void LINQ_Example2()
    {
        Console.WriteLine("\n\n\n");

        //grouping by fruits category
        var groupedFruits = FruitsCategory.GroupBy(n => n.Value);

        foreach (var group in groupedFruits)
        {
            Console.WriteLine($"Category: [{group.Key}]");
            foreach(var item in group)
            {
                Console.WriteLine("  - " + item.Key);
            }

        }

    }

    static void Main(string[] args)
    {

        //accessing/modifing dictionary
        MyDictionary[11] = "Omar"; 
        
        
        //printing a dictionary content by iterating
        PrintDictionaryContent<int, string>(MyDictionary);
        PrintDictionaryContent<string, string>(FruitsCategory);

        //TryGetValue_Example();

        //LINQ_Example1();

        LINQ_Example2();


    }

}

/* Dictionary in C#
    Dictionary is a collection of key-value pairs that provides fast retrieval based on the key. It is part of the System.Collections.Generic namespace and is widely used in situations where quick lookups are necessary.


    Introduction to Dictionary
    Key-Value Pairs: Stores data as pairs of keys and values. Each key must be unique.
    Fast Lookups: Provides very efficient retrieval of values based on keys.
    Generic Collection: Allows specifying types for both keys and values.
    Dictionary is like MAP in C++.
    Conclusion
    The Dictionary<TKey, TValue> in C# is a powerful and efficient collection for storing and retrieving data based on keys. It is essential in scenarios where quick data access and retrieval are critical.
 */

/*Dictionary vs HashTable

In C#, both Dictionary and Hashtable are collection types used to store key-value pairs. However, they are designed to cater to different needs and scenarios based on their features and implementations. Understanding the differences between Dictionary and Hashtable is crucial for choosing the appropriate collection type for a given situation.

Dictionary
Dictionary<TKey, TValue> is a generic collection introduced in .NET 2.0. It resides in the System.Collections.Generic namespace and provides fast lookups to manage collections of keys and values. The key features of Dictionary include:

Generic: Allows for type-safe data storage, ensuring that both keys and values are of a specified type, which helps to prevent runtime errors and eliminates the need for casting when retrieving values.
Performance: Offers fast access to elements based on keys. The performance of searching for a key is close to O(1), making it highly efficient for lookups.
Order: Does not guarantee the order of elements. The order in which elements are returned during enumeration may not match the order in which they were inserted.
Thread Safety: Not inherently thread-safe. If multiple threads access it concurrently, you must implement your own synchronization mechanism.
Hashtable
Hashtable, part of the System.Collections namespace, is a non-generic collection available since .NET 1.0. It can store keys and values of any types because it works with the object type. Key characteristics of Hashtable include:

Non-Generic: Keys and values are of type object, which means they can store any data type. This flexibility comes at the cost of type safety, as it requires casting when retrieving values and increases the chance of runtime errors.
Performance: Like Dictionary, Hashtable also provides fast access to elements. However, the need for boxing and unboxing when working with value types can affect performance.
Order: Does not maintain the order of stored elements, similar to Dictionary.
Thread Safety: Provides some thread safety features, such as synchronized (thread-safe) wrappers obtained through the Hashtable.Synchronized method. However, for full thread safety with multiple writers, external synchronization is recommended.
Comparison Summary
Type Safety: Dictionary is strongly typed, whereas Hashtable requires casting for non-object types.
Performance: Both provide fast lookups, but Dictionary can be more performant due to type safety and the lack of boxing/unboxing for value types.
Version Compatibility: Hashtable is available from the first version of .NET, making it suitable for legacy applications. Dictionary was introduced later and is preferred for new development due to its generic nature.
Thread Safety: Hashtable offers basic thread safety features, but neither collection is fully thread-safe for concurrent modifications without external synchronization.
Choosing Between Dictionary and Hashtable
Use Dictionary when you need strong type safety, better performance with value types, and are working with .NET 2.0 or later.
Consider Hashtable if you are maintaining legacy code or need a collection that accepts keys and values of any type without specifying their data types upfront.
In modern .NET applications, Dictionary is generally preferred due to its type safety and performance advantages. However, understanding Hashtable is still valuable for working with existing codebases that use it.
 */