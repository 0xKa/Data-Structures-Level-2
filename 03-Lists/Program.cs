using System;
using System.Collections.Generic;
using System.Linq;

/* Key Concepts of List<T>
    1. Generic Collection
        - T in List<T> is a type parameter, meaning that you can create a list of any type (e.g., List<int>, List<string>, or List<YourCustomType>).
    2. Dynamic Sizing
        - Automatically resizes itself, offering more flexibility than traditional arrays.
    3. Zero-Based Index
        - Like arrays, lists use zero-based indexing.
    4. Strongly Typed
        - Ensures type safety. You cannot add an int to a List<string>, for example.
 */

internal class Program
{

    public static List<string> stringList = new List<string>
    {
        "Reda",
        "Ahmed",
        "Mohammed",
        "Khalid",
        "Tariq"

    };

    public static List<int> numbersList = new List<int>
    {
        666, 21 ,34 ,325, 5132, 63, 91, -8, 329, -940, 1221, 312, 832, -54, 2, 16, 37, -8, -100, 20
    };


    public static void PrintList<T>(List<T> list, string title = null)
    {
        if (title == null)
            Console.WriteLine($"Number of items in the List: {list.Count}");
        else
            Console.WriteLine(title);

        Console.WriteLine("List: [" + string.Join(", ", list) + "]\n");
    }
    public static void AddItems()
    {
        //alternative way is to use .Add()
        stringList.Add("Omar");

        //Inserting value at specific position
        stringList.Insert(4, "Ali");

        //Inserting list at specific position
        stringList.InsertRange(4, new List<string>() { "Salim", "Abdullah" });


    }
    public static void RemoveItems()
    {
        //Remove elements 
        stringList.Remove("Ahmed"); //remove by item
        stringList.RemoveAt(6); //remove by index
        stringList.RemoveRange(0, 4); //remove 4 items
        stringList.RemoveAll(s => s.StartsWith("O")); //remove elements that starts with "O"
        stringList.Clear(); // remove all items

    }
    public static void LoopThroughList()
    {
        //we can use normal for, foreach statements or this method:
        stringList.ForEach(s => Console.WriteLine(s)); //apply an action for each elemnt 
    }
    public static void AggregatingDataUsingLINQ()
    {
        

        Console.WriteLine("Count : " + numbersList.Count());
        Console.WriteLine("Sum   : " + numbersList.Sum());
        Console.WriteLine("Avg   : " + numbersList.Average());
        Console.WriteLine("Max   : " + numbersList.Max());
        Console.WriteLine("Min   : " + numbersList.Min());
    }
    public static void FilteringDatawithLINQ()
    {
        PrintList(numbersList);
        Console.WriteLine("Even Numbers             : [" + string.Join(", ", numbersList.Where(n => n % 2 == 0)) + "]");
        Console.WriteLine("Numbers Greater than 500 : [" + string.Join(", ", numbersList.Where(n => n > 500)) + "]");
        Console.WriteLine("Every Second Number      : [" + string.Join(", ", numbersList.Where((n, index) => index % 2 == 1)) + "]");
        Console.WriteLine("Between -100 and 50      : [" + string.Join(", ", numbersList.Where(n => n >= -100 && n <= 50)) + "]");

    }
    public static void SortingAList()
    {
        numbersList.Sort();
        stringList.Sort();

        PrintList(numbersList, "Numbers List Order Ascending:");
        PrintList(stringList, "String List Order Ascending:");
        
        numbersList.Reverse();
        stringList.Reverse();
        PrintList(numbersList, "Numbers List Order Descending:");
        PrintList(stringList, "String List Order Descending:");

        //using LINQ
        Console.WriteLine("Order Ascending: [" + string.Join(", ", numbersList.OrderBy(n => n)) + "]");
        Console.WriteLine("Order Descending: [" + string.Join(", ", numbersList.OrderByDescending(n => n)) + "]");


    }

    static void Main(string[] args)
    {
        
        AddItems();
        //RemoveItems();

        //LoopThroughList();

        //AggregatingDataUsingLINQ();

        //FilteringDatawithLINQ();

        SortingAList();

        //PrintList<string>(stringList);
        //PrintList<int>(numbersList);

        Console.ReadLine();

    }
}