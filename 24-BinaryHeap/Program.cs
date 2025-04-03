using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

public class MinHeap
{
    private List<int> heap = new List<int>();

    public void Insert(int value)
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

            if (heap[parentIndex] <= heap[indexOfLastItem]) break;

            //shorthand way to swap using tuple instead of using temp variable
            (heap[indexOfLastItem], heap[parentIndex]) = (heap[parentIndex], heap[indexOfLastItem]);

            indexOfLastItem = parentIndex; //update the index to continue cheacking the tree until the index is 0
        }

    }


    public int ExtractMin()
    {
        int minValue = Peek();

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

            if (leftChildIndex < heap.Count && heap[leftChildIndex] < heap[smallestIndex])
                smallestIndex = leftChildIndex;

            if (rightChildIndex < heap.Count && heap[rightChildIndex] < heap[smallestIndex])
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

        Console.WriteLine("\nMinHeap Elements:");
        foreach (int item in heap) 
            Console.Write(item + " ");
        Console.WriteLine();
    }

    // Peek the minimum element without removing it
    public int Peek()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("Heap is empty.");

        return heap[0]; // The smallest element is at the root
    }


}

public class MaxHeap
{
    private List<int> heap = new List<int>();

    public void Insert(int value)
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

            if (heap[parentIndex] >= heap[indexOfLastItem]) break;

            (heap[indexOfLastItem], heap[parentIndex]) = (heap[parentIndex], heap[indexOfLastItem]);

            indexOfLastItem = parentIndex; //update the index to continue cheacking the tree until the index is 0
        }

    }


    public int ExtractMax()
    {
        int maxValue = Peek();

        //move last element to root
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);

        HeapifyDown(0);

        return maxValue;
    }

    //Helper method to maintain the heap property after deletions
    private void HeapifyDown(int indexOfRoot = 0)
    {
        while (indexOfRoot < heap.Count)
        {
            int leftChildIndex = 2 * indexOfRoot + 1;
            int rightChildIndex = 2 * indexOfRoot + 2;

            int largestIndex = indexOfRoot;

            //check the childs if they are greater than root then swap, loop util the root beacome the largest

            if (leftChildIndex < heap.Count && heap[leftChildIndex] > heap[largestIndex])
                largestIndex = leftChildIndex;

            if (rightChildIndex < heap.Count && heap[rightChildIndex] > heap[largestIndex])
                largestIndex = rightChildIndex;

            if (largestIndex == indexOfRoot) break;

            (heap[indexOfRoot], heap[largestIndex]) = (heap[largestIndex], heap[indexOfRoot]);

            indexOfRoot = largestIndex;

        }
    }


    public void Print()
    {
        if (heap.Count == 0)
        {
            Console.WriteLine("Heap is Empty."); return;
            //throw new InvalidOperationException("Heap is empty.");
        }

        Console.WriteLine("\nMaxHeap Elements:");
        foreach (int item in heap)
            Console.Write(item + " ");
        Console.WriteLine();
    }

    // Peek the maximum element without removing it
    public int Peek()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("Heap is empty.");

        return heap[0]; // The largest element is at the root
    }

}

internal class Program
{
    public static void MinHeap_Example()
    {
        MinHeap minHeap = new MinHeap();

        minHeap.Insert(10);
        minHeap.Insert(0);
        minHeap.Insert(50);
        minHeap.Insert(30);
        minHeap.Insert(22);
        minHeap.Insert(5);
        minHeap.Insert(6);
        minHeap.Insert(25);

        minHeap.Print();

        Console.WriteLine("Minimum Element: " + minHeap.Peek());

        Console.WriteLine("\nExtracting the Minimum Element: " + minHeap.ExtractMin());
        minHeap.Print();

        Console.WriteLine("\nExtracting the Minimum Element: " + minHeap.ExtractMin());
        minHeap.Print();

        Console.WriteLine("\nExtracting the Minimum Element: " + minHeap.ExtractMin());
        minHeap.Print();
    }
    
    public static void MaxHeap_Example()
    {
        MaxHeap maxHeap = new MaxHeap();

        maxHeap.Insert(10);
        maxHeap.Insert(0);
        maxHeap.Insert(50);
        maxHeap.Insert(30);
        maxHeap.Insert(22);
        maxHeap.Insert(5);
        maxHeap.Insert(6);
        maxHeap.Insert(25);

        maxHeap.Print();

        Console.WriteLine("Maximum Element: " + maxHeap.Peek());

        Console.WriteLine("\nExtracting the Maximum Element: " + maxHeap.ExtractMax());
        maxHeap.Print();

        Console.WriteLine("\nExtracting the Maximum Element: " + maxHeap.ExtractMax());
        maxHeap.Print();

        Console.WriteLine("\nExtracting the Maximum Element: " + maxHeap.ExtractMax());
        maxHeap.Print();
    }

    static void Main(string[] args)
    {
        MinHeap_Example();
        MaxHeap_Example();

    }
}

/* Heap/Binary Heap Data Structure 
1. What is a Heap?
    A Heap is a special tree-based data structure that satisfies the heap property:

    For a Max-Heap: The value of each node is greater than or equal to the values of its children.
    For a Min-Heap: The value of each node is less than or equal to the values of its children.
    In both types of heaps, the root node represents the maximum (in Max-Heap) or minimum (in Min-Heap) value in the tree.

2. Types of Heaps
    Max-Heap: The root node contains the largest element, and every parent node is greater than or equal to its children.
    Min-Heap: The root node contains the smallest element, and every parent node is less than or equal to its children.


    We call it a heap data structure because it is built with a specific organizational property (the heap property) that makes it efficient for tasks that need quick access to the minimum or maximum element. The term "heap" refers to the fact that elements are stored in a way that resembles a loosely ordered "pile" or "heap" where only the top element (the smallest or largest, depending on the type of heap) is directly accessible.



    Heap Data Structure Applications
    Heap is used while implementing a priority queue.
    Heap Sort.
    Other algorithms.


Here are key reasons why it's named a heap:

    1. Heap Property
    In a Min-Heap, every parent node is less than or equal to its children, ensuring the smallest element is at the root.
    In a Max-Heap, every parent node is greater than or equal to its children, so the largest element is at the root.
    This ordering property makes heaps ideal for efficient insertion, deletion, and retrieval of the minimum or maximum element.
    2. Efficiency of Access and Organization
    Heaps allow for constant-time access to the smallest or largest element (O(1)), which is crucial for priority-based tasks.
    Insertions and deletions in heaps take O(log n) time due to the tree structure, where elements are only rearranged as needed to maintain the heap property.
    3. Binary Tree Structure
    A heap is typically implemented as a binary tree where each level of the tree is filled before moving to the next. This gives it a balanced structure, with operations like insertion and deletion having predictable time complexities.
    The binary tree structure is particularly suitable for array-based implementations, allowing for a compact representation in memory.
    4. Naming Origin
    The term "heap" was originally used to describe any unstructured collection of elements. Over time, it came to refer to this structured binary tree due to its specialized ordering property and application in priority tasks.
    In summary, the name "heap" comes from both its physical structure (resembling a loosely ordered pile) and its function in data handling (providing efficient access to the smallest or largest elements). The structure's properties and applications make it one of the most efficient and widely used data structures for tasks requiring prioritized access.
 */

/* Overview of Heap Operations 
The main operations in a Min-Heap are:

    Insert: Add a new element while maintaining the heap property.
    HeapifyUp: Helper method to maintain the heap property after insertions.
    Peek: Get the smallest element without removing it.
    ExtractMin: Remove and return the smallest element (root) while preserving the heap structure.
    HeapifyDown: Helper method to maintain the heap property after deletions
 */
