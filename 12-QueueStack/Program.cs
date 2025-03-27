using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    public static void Queue_Example()
    {
        Queue<string> queue = new Queue<string>();

        // Enqueue items into the queue
        queue.Enqueue("C#");
        queue.Enqueue("Java");
        queue.Enqueue("Python");
        Console.WriteLine("Items in Queue: " + string.Join(", ", queue));

        // Peek the front item
        Console.WriteLine("Front Item: " + queue.Peek());

        // Dequeue items from the queue
        Console.WriteLine("Dequeued Item: " + queue.Dequeue());
        Console.WriteLine("Queue After Dequeue: " + string.Join(", ", queue));

        // Check if the queue contains an item
        Console.WriteLine("Contains 'Python': " + queue.Contains("Python"));

        // Get count of items
        Console.WriteLine("Number of Items: " + queue.Count);

        // Clear the queue
        queue.Clear();
        Console.WriteLine("Queue Cleared. Count: " + queue.Count);
    }
    public static void Stack_Example()
    {
        Stack<string> stack = new Stack<string>();

        // Push items onto the stack
        stack.Push("C#");
        stack.Push("Java");
        stack.Push("Python");
        Console.WriteLine("Items in Stack: " + string.Join(", ", stack));

        // Peek the top item
        Console.WriteLine("Top Item: " + stack.Peek());

        // Pop items from the stack
        Console.WriteLine("Popped Item: " + stack.Pop());
        Console.WriteLine("Stack After Pop: " + string.Join(", ", stack));

        // Check if the stack contains an item
        Console.WriteLine("Contains 'C#': " + stack.Contains("C#"));

        // Get count of items
        Console.WriteLine("Number of Items: " + stack.Count);

        // Clear the stack
        stack.Clear();
        Console.WriteLine("Stack Cleared. Count: " + stack.Count);
    }
    

    static void Main(string[] args)
    {
        Queue_Example();

        Console.WriteLine("\n\n\n");
        
        Stack_Example();

        Console.WriteLine("\n\n\n");
    }

}