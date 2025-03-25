using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    public static HashSet<int> MyHashset = new HashSet<int>()
    {
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
    };

    public static void PrintHashset<T>(HashSet<T> hashset)
    {
        Console.WriteLine("\n\nNumber of Elements: " + hashset.Count());
        Console.Write("[" + string.Join(", ", hashset) + "]\n\n");
    }

    public static void UsingHashsetToRemoveDuplicates()
    {
        int[] arr = new int[] { 0, 100, 100, 200, 300, 100, 300, 300, 0, 100, 300 };

        HashSet<int> hsValues = new HashSet<int>(arr); //hashset will automatically remove Duplicates

        PrintHashset(hsValues);
    }

    public static void LINQ_Example1()
    {
        var EvenNumbers_Query = MyHashset.Where(n => n % 2 == 0).OrderByDescending(n => n);

        foreach (var item in EvenNumbers_Query)
        {
            Console.Write(item + " ");
        }
    }

    public static HashSet<int> hashset1 = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public static HashSet<int> hashset2 = new HashSet<int>() { 7, 8, 9, 0, 33, 2004, 8, 6, 88888 };
    public static void UnionOperationWithHashSet()
    {
        hashset1.UnionWith(hashset2); //combine hashset2 elemnets with hashsets1

        PrintHashset(hashset1);
    }
    public static void IntersectionOperationWithHashSet()
    {
        hashset1.IntersectWith(hashset2); //gets the intersection elements of hashset1 and hashsets2

        PrintHashset(hashset1);
    }
    public static void DifferenceOperationWithHashSet()
    {
        hashset1.ExceptWith(hashset2); //gets the elements of hashset1 Excepts hashsets2 elements

        PrintHashset(hashset1);
    }
    public static void SymmetricDifferenceOperationWithHashSet()
    {
        hashset1.SymmetricExceptWith(hashset2); //SymmetricDifference = Remove Differences + Union

        PrintHashset(hashset1);
    }

    public static void ComparingHashSets()
    {
        //check if a hashset equals a given collection
        bool result1 = hashset1.SetEquals(hashset2);
        bool result2 = hashset1.SetEquals(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

        //check if a hashset is a subset of a given collection
        bool result3 = hashset1.IsSubsetOf(MyHashset);
        bool result4 = hashset1.IsSubsetOf(new int[] { 1, 2, 3 });
        
        //check if a hashset is a superset of a given collection
        bool result5 = hashset1.IsSupersetOf(MyHashset);
        bool result6 = hashset1.IsSupersetOf(new int[] { 1, 2, 3 });

        bool result7 = hashset1.Overlaps(hashset2);

        Console.WriteLine(result1);
        Console.WriteLine(result2);
        Console.WriteLine(result3);
        Console.WriteLine(result4);
        Console.WriteLine(result5);
        Console.WriteLine(result6);
        Console.WriteLine(result7);

    }

    static void Main(string[] args)
    {

        //MyHashset.Add(1); //retruns false if the element exists

        //PrintHashset(MyHashset);

        ////remove elements based on condition
        //MyHashset.RemoveWhere(n => n >= 5);
        //PrintHashset(MyHashset);


        //UsingHashsetToRemoveDuplicates();


        //LINQ_Example1();


        //UnionOperationWithHashSet();
        //IntersectionOperationWithHashSet();
        //DifferenceOperationWithHashSet();
        //SymmetricDifferenceOperationWithHashSet();


        //ComparingHashSets();

        Console.WriteLine("\n\n\n");
    }
}

/* Hashset
Introduction 
    Definition: HashSet<T> is a collection class in the System.Collections.Generic namespace designed to store unique elements.
    Uniqueness: The primary feature of HashSet<T> is that it automatically ensures all elements are unique.
    No Indexing: Unlike lists, HashSet<T> does not maintain the order of its elements and does not support indexing.
    Generic: HashSet<T> is a generic collection, meaning it can store any type of object.

Conclusion
    HashSet<T> in C# is a powerful collection for storing unique elements. It is particularly useful when you need to ensure no duplicates, perform MyHashset operations, and when the order of elements is not a concern.

    Remember, HashSet<T> does not support indexing, so if you need to access elements by index, consider using other collections like List<T>.
 */