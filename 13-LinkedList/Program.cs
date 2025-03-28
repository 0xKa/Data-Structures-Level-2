using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    static void Main(string[] args)
    {
        // Create a LinkedList of strings
        LinkedList<string> programmingLanguages = new LinkedList<string>();

        // Add elements to the linked list
        programmingLanguages.AddLast("C#");
        programmingLanguages.AddLast("Java");
        programmingLanguages.AddLast("Python");
        programmingLanguages.AddFirst("C++");

        Console.WriteLine("LinkedList Elements: ");
        foreach (var lang in programmingLanguages)
        {
            Console.WriteLine("- " + lang);
        }

        // Add an element after "Java"
        LinkedListNode<string> javaNode = programmingLanguages.Find("Java");
        programmingLanguages.AddAfter(javaNode, "JavaScript");

        // Add an element before "Python"
        LinkedListNode<string> pythonNode = programmingLanguages.Find("Python");
        programmingLanguages.AddBefore(pythonNode, "Go");

        Console.WriteLine("\nLinkedList After Additions: ");
        foreach (var lang in programmingLanguages)
        {
            Console.WriteLine("- " + lang);
        }

        // Remove elements
        programmingLanguages.Remove("C#");         // Remove specific element
        programmingLanguages.RemoveFirst();       // Remove first element
        programmingLanguages.RemoveLast();        // Remove last element

        Console.WriteLine("\nLinkedList After Removals: ");
        foreach (var lang in programmingLanguages)
        {
            Console.WriteLine("- " + lang);
        }

        // Check count
        Console.WriteLine("\nNumber of Elements: " + programmingLanguages.Count);

        // Clear the linked list
        programmingLanguages.Clear();
        Console.WriteLine("\nLinkedList Cleared. Count: " + programmingLanguages.Count);


    }
}