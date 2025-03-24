using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Hashtable
 * A hash table is a data structure that you can use to store data in key-value format with direct access to its items in constant time.
 
        Hash tables are said to be associative, which means that for each key, data occurs at most once. Hash tables let us implement things like phone books or dictionaries; in them, we store the association between a value (like a dictionary definition of the word "chair") and its key (the word "chair" itself).

        We can use hash tables to store, retrieve, and delete data uniquely based on their unique key.

        A hashtable, also known as a hash map, is a data structure that implements an associative array abstract data type, a structure that can map keys to values. It uses a hash function to compute an index into an array of buckets or slots, from which the desired value can be found. Ideally, the hash function will assign each key to a unique bucket, but most hash table designs assume that hash collisions (two keys that are different but have the same hash value) are inevitable and must be accommodated in some way.

        Here are the key features of hashtables:

        Efficient Access: Hashtables provide very efficient average time complexity for insert, delete, and search operations, ideally in O(1) time, which means the time to perform these operations is constant and does not grow with the size of the data.
        Dynamic Resizing: To maintain efficient operations and a good load factor (the ratio of the number of entries to the number of buckets), hashtables may dynamically resize. This involves creating a larger array and rehashing all existing entries into the new array.
        Use Cases: Hashtables are widely used in many computer science applications, including database indexing, caching, symbol tables in compilers, and implementing associative arrays in programming languages.
        In summary, hashtables are powerful data structures for efficiently managing key-value pairs, allowing for quick data retrieval, addition, and removal.
 */

/* Hashtable in C#
    A Hashtable in C# is a collection that stores key-value pairs, organized based on the hash code of the key. It resides in the System.Collections namespace and is designed for scenarios where quick searches, additions, and deletions are crucial. Unlike generic collections, Hashtable allows for keys and values of any type, adding versatility but requiring careful handling of data types.

    Key Features
    Non-Generic: Operates on objects of any type, requiring casting when retrieving elements.
    Efficient Lookups: Utilizes hash codes for keys, optimizing search operations.
    Uniqueness: Keys must be unique, though values may repeat.
    Order: Does not maintain a predictable order of stored elements.
    Conclusion
    Hashtable is a powerful, if somewhat dated, collection type in C# that excels in scenarios requiring quick access to elements by key. While newer, generic collections like Dictionary<TKey, TValue> offer type safety and potentially better performance, understanding how to use Hashtable is still valuable, especially for working with legacy code or APIs that require it. This lesson has equipped you with the knowledge to utilize Hashtable effectively in your C# applications.
 */

internal class Program
{
    static void Main(string[] args)
    {
        Hashtable hs = new Hashtable
        {
            { "key1", "reda" },
            { 3, "bassam" },
            { 0, "........" },
            { "key10", 420},
            { 66, "hilal" },
            { 41, "bader" }
        };

        //accessing elements
        Console.WriteLine(hs["key1"]);


        //modifing elemnent
        hs[0] = "dsa";

        //removing elements
        hs.Remove(0);

        //iterating 
        foreach (DictionaryEntry entry in hs)
        {
            Console.WriteLine(entry.Key + ", " + entry.Value);
        }

        Console.ReadKey();
    }
}