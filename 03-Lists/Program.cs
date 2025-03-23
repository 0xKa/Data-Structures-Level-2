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
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(int ID, string name, int age)
        {
            this.ID = ID;
            this.Name = name;
            this.Age = age;
        }
    }

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
        666, 21 ,34 ,325, 5132, 63, 91, -8, 329, -940, 1221, 312, 832, -54, 2, 16, 37, -8, 720, -100
    };

    public static List<Person> PeopleList = new List<Person>
    {
        new Person(1, "Mohammed", 20),
        new Person(2, "Ahmed", 23),
        new Person(3, "Reda", 20),
        new Person(4, "Salim", 18),
        new Person(5, "Ali", 26),
        new Person(6, "Omar", 25),
        new Person(7, "Saif", 29)
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
    public static void CheckingList()
    {
        Console.WriteLine("List Contains [12]? : " + numbersList.Contains(12));

        Console.WriteLine("\nCondition Exists [n > 20]? :" + numbersList.Exists(n => n > 20)); 
        Console.WriteLine("Condition Exists (using .Any())[n > 20]? :" + numbersList.Any(n => n > 20)); //same as Exists, but for more collections

        Console.WriteLine("\nFind First Element that [n >= 20]: " + numbersList.Find(n => n >= 20)); 
        Console.WriteLine("Find Last Element that [n >= 20]: " + numbersList.FindLast(n => n >= 20)); 
        Console.WriteLine("Find First Index of Element that [n >= 20]:" + numbersList.FindIndex(n => n >= 20));
        Console.WriteLine("Find Last Index of Element that [n >= 20]:" + numbersList.FindLastIndex(n => n >= 20));
        


        Console.WriteLine("\nFind All Elements that [n >= 500]:");
        PrintList(numbersList.FindAll(n => n >= 500));

        /* .Exists() vs .Any()
                -Exists is specific to List<T> and is available directly on instances of List<T>.
                -Any is a LINQ extension method available for any collection implementing IEnumerable<T>.
                -Both methods serve similar purposes, but Exists is more specialized for lists, while Any is more versatile and can be used with any enumerable collection.
                -Exists is more efficient than Any for lists because it directly operates on the list without the overhead of LINQ. However, for collections other than lists, Any is often the only option.
         */

    }
    public static void ListWithCustomObject()
    {
        Console.WriteLine("People List:");
        foreach (Person person in PeopleList)
        {
            Console.WriteLine(person.ID + ", " + person.Name + ", " + person.Age);
        }

        Console.WriteLine("\nFinding Person Name [Ali]: " + PeopleList.Exists(p => p.Name == "Ali"));

        Console.WriteLine("\nFinding all people that [Age >= 25]: ");
        List<Person> peopleOver25 = PeopleList.FindAll(p => p.Age >= 25);
        foreach (Person person in peopleOver25)
        {
            Console.WriteLine(person.ID + ", " + person.Name + ", " + person.Age);
        }

        Console.WriteLine("\nRemoving all people that [Age >= 25]: ");
        Console.WriteLine(PeopleList.RemoveAll(p => p.Age >= 25) + " People Removed.");
        foreach (Person person in PeopleList)
        {
            Console.WriteLine(person.ID + ", " + person.Name + ", " + person.Age);
        }


    }
    public static void ConvertListToArray()
    {
        //convert list to array
        int[] arr = numbersList.ToArray();

        Console.WriteLine(string.Join(", ", arr));

        //convert array to list
        List<int> NumbersList = new List<int>(arr);
        PrintList(NumbersList);

        //another way
        NumbersList = arr.ToList();
        PrintList(NumbersList);

    }

    static void Main(string[] args)
    {
        
        AddItems();
        //RemoveItems();

        //LoopThroughList();

        //AggregatingDataUsingLINQ();

        //FilteringDatawithLINQ();

        //SortingAList();

        //CheckingList();

        //ListWithCustomObject();

        //ConvertListToArray();


        //PrintList<string>(stringList);
        //PrintList<int>(numbersList);

        Console.ReadLine();

    }
}