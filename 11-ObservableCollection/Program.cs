using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

internal class Program
{
    public static ObservableCollection<string> programmingLanguages = new ObservableCollection<string>()
    {
        "C", "Java", "Python", "C++", "JavaScript", "PHP", "Swift", "Ruby", "Kotlin",
        //"Go", "Rust", "TypeScript", "Dart", "Perl", "Scala", "Matlab", "Objective-C",
        //"Shell", "Groovy", "Visual Basic", "F#", "Haskell", "Erlang", "Delphi", "Ada",
        //"Julia", "Prolog",
    };
 
    public static void PrintObservableCollection<T>(ObservableCollection<T> collection)
    {
        Console.WriteLine("\n   - Items Count:" + collection.Count);
        Console.WriteLine("   - [" + string.Join(", ", collection) + "]\n");
    }

    static void Main(string[] args)
    {

        programmingLanguages.CollectionChanged += ProgrammingLanguages_CollectionChanged;

        PrintObservableCollection(programmingLanguages);

        //adding item
        programmingLanguages.Add("Pascal");
        programmingLanguages.Add ("R");
        programmingLanguages.Add("C#");

        //removing item
        programmingLanguages.Remove("C#");
        programmingLanguages.Remove("R");

        //changing item
        programmingLanguages[3] = "C#";

        //moving item
        programmingLanguages.Move(0, 7);
        programmingLanguages.Move(9, 5);

        //clearing item
        programmingLanguages.Clear();


    }

    private static void ProgrammingLanguages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                Console.WriteLine("New Programming Language Added: " + e.NewItems[0]);
                break;

            case NotifyCollectionChangedAction.Remove:
                Console.WriteLine("Programming Language [" + e.OldItems[0] + "] Removed.");
                break;

            case NotifyCollectionChangedAction.Replace:
                Console.WriteLine("Programming Language [" + e.OldItems[0] + "] Replaced with [" + e.NewItems[0] + "].");
                break;

            case NotifyCollectionChangedAction.Move:
                Console.WriteLine("Programming Language [" + e.OldItems[0] + "] Moved From Index[" + e.OldStartingIndex + "] to Index[" + e.NewStartingIndex + "].");
                break;

            case NotifyCollectionChangedAction.Reset:
                Console.WriteLine("Programming Languages Collection Was Cleared.");
                break;

            default:
                Console.WriteLine("Programming Languages Collection Was Modified.");
                break;
        }

        //print to view changes
        PrintObservableCollection(programmingLanguages);


    }
}

/* Introduction to ObservableCollection<T> in C# 

Introduction
    ObservableCollection<T>: A dynamic collection in the System.Collections.ObjectModel namespace.
    Key Feature: Automatically notifies about any changes made to the collection, like additions, deletions, or refreshes.
    Common Use: Widely used in data-binding scenarios, particularly in UI programming with frameworks like WPF (Windows Presentation Foundation).

Key Concepts
    ObservableCollection<T> is a generic collection, meaning it can hold any type (denoted by <T>).
    It implements INotifyCollectionChanged and INotifyPropertyChanged interfaces, making it ideal for data binding as it provides change notifications to bound UI elements.

Conclusion
     ObservableCollection<T> is crucial for developers working in environments where data changes need to be reflected in real-time in the UI, such as desktop applications with dynamic data displays.
 */

/* Important
    ObservableCollection<T> internally uses a List<T> as its underlying data structure to store its elements. This means that most of the operations, such as adding, removing, and accessing items, are implemented using the features of the generic List<T>.

    However, ObservableCollection<T> adds additional functionality to the List<T> by providing change notifications through events like CollectionChanged. This makes it suitable for scenarios where you need to monitor changes to the collection, such as updating a UI dynamically.
 */