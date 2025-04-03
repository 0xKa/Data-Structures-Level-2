using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Implementing a Priority Queue Using Min-Heap /// 
///
public class PriorityQueueNode<T>
{
    public T Value { get; set; }

    public int Priority { get; set; }

    public PriorityQueueNode(T value, int priority)
    {
        this.Value = value;
        this.Priority = priority;
    }

}

public class PriorityQueue<T>
{
    private List<PriorityQueueNode<T>> heap = new List<PriorityQueueNode<T>>();

    public void Insert(PriorityQueueNode<T> value)
    {
        heap.Add(value);

        this.HeapifyUp(heap.Count - 1);
    }

    //Helper method to maintain the heap property after insertions.
    private void HeapifyUp(int indexOfLastItem)
    {
        while (indexOfLastItem > 0)
        {
            int parentIndex = (indexOfLastItem - 1) / 2;

            if (heap[parentIndex].Priority <= heap[indexOfLastItem].Priority) break;

            //shorthand way to swap using tuple instead of using temp variable
            (heap[indexOfLastItem], heap[parentIndex]) = (heap[parentIndex], heap[indexOfLastItem]);

            indexOfLastItem = parentIndex; //update the index to continue cheacking the tree until the index is 0
        }

    }


    public T ExtractMinValue()
    {
        T minValue = PeekValue();

        //move last element to root
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);

        HeapifyDown(0);

        return minValue;
    }

    public PriorityQueueNode<T> ExtractMin()
    {
        PriorityQueueNode<T> minValue = Peek();

        //move last element to root
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);

        HeapifyDown(0);

        return minValue;
    }

    //Helper method to maintain the heap property after deletions
    private void HeapifyDown(int indexOfRoot = 0)
    {
        while (indexOfRoot < heap.Count)
        {
            int leftChildIndex = 2 * indexOfRoot + 1;
            int rightChildIndex = 2 * indexOfRoot + 2;

            int smallestIndex = indexOfRoot;

            //check the childs if they are smaller than root then swap, loop util the root beacome the smallest

            if (leftChildIndex < heap.Count && heap[leftChildIndex].Priority < heap[smallestIndex].Priority)
                smallestIndex = leftChildIndex;

            if (rightChildIndex < heap.Count && heap[rightChildIndex].Priority < heap[smallestIndex].Priority)
                smallestIndex = rightChildIndex;

            if (smallestIndex == indexOfRoot) break;

            (heap[indexOfRoot], heap[smallestIndex]) = (heap[smallestIndex], heap[indexOfRoot]);

            indexOfRoot = smallestIndex;

        }
    }

    public void Print()
    {
        if (heap.Count == 0)
        {
            Console.WriteLine("Heap is Empty."); return;
            //throw new InvalidOperationException("Heap is empty.");
        }

        Console.WriteLine("\nPriority Queue Elements:");
        foreach (PriorityQueueNode<T> item in heap)
            Console.Write($"Value: {item.Value}, Priority: {item.Priority}\n");
        Console.WriteLine();
    }

    // Peek the minimum element without removing it
    public T PeekValue()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("Heap is empty.");

        return heap[0].Value; // The smallest element is at the root
    }
    public PriorityQueueNode<T> Peek()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("Heap is empty.");

        return heap[0]; // The smallest element is at the root
    }


}

internal class Program
{
    static void Main(string[] args)
    {
        PriorityQueue<string> priorityQueue = new PriorityQueue<string>();

        //number is the most priority, beccaue I used Min Heap 
        priorityQueue.Insert(new PriorityQueueNode<string>("Task1", 5));
        priorityQueue.Insert(new PriorityQueueNode<string>("Task1", 3));
        priorityQueue.Insert(new PriorityQueueNode<string>("Task1", 4));
        priorityQueue.Insert(new PriorityQueueNode<string>("Task1", 1));
        priorityQueue.Insert(new PriorityQueueNode<string>("Task1", 2));

        priorityQueue.Print();

        PriorityQueueNode<string> extractedNode = priorityQueue.ExtractMin();
        Console.WriteLine("Extracted Node Value    : " + extractedNode.Value);
        Console.WriteLine("Extracted Node Priority : " + extractedNode.Priority);

        priorityQueue.Print();
        
        PriorityQueueNode<string> extractedNode2 = priorityQueue.ExtractMin();
        Console.WriteLine("Extracted Node Value    : " + extractedNode2.Value);
        Console.WriteLine("Extracted Node Priority : " + extractedNode2.Priority);

        priorityQueue.Print();




    }
}

/* What is a Priority Queue? 
    
A Priority Queue is a type of data structure where each element is associated with a "priority" level. Elements are processed based on their priority, not just their order of insertion. In a Min-Heap-based Priority Queue, the element with the lowest priority value is served first.

Key Properties:
    Min-Priority Queue: The element with the lowest priority is served first.
    Max-Priority Queue: The element with the highest priority is served first.
    Why Use a Min-Heap for a Priority Queue?
    A Min-Heap is well-suited for a priority queue because:

Efficient Access: The smallest element (root) can be accessed in constant time.
    Efficient Insert and Remove: Insertions and deletions take O(log n) time, making it efficient for dynamic datasets.
 */
