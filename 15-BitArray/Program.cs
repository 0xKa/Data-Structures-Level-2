using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{

    public static string BitArrayToString(BitArray bitArray)
    {
        char[] charBits = new char[bitArray.Length];

        for (int i = 0; i < bitArray.Length; i++)
        {
            charBits[i] = bitArray[i] ? '1' : '0';

        }

        return new string(charBits);
    }
    public static void PrintBitArray(BitArray bitArray) => Console.WriteLine("Bit Array: " + BitArrayToString(bitArray));
    public static void PrintArrayWithIndex(BitArray bitArray)
    {
        //Printing values values by index
        for (int i = 0; i < bitArray.Length; i++)
        {
            Console.WriteLine($"Bit at Index[{i}] = " + bitArray[i]);
        }
        Console.WriteLine();

    }
    
    public static void BitwiseOperations()
    {
        Console.WriteLine("----------------- Bitwise Operations -----------------");
        BitArray bits1 = new BitArray(new bool[] { true, false, true, false, true, true, false, false });
        BitArray bits2 = new BitArray(new bool[] { false, false, false, false, true, true, false, true });
        BitArray NOT_result = new BitArray(bits1);
        BitArray AND_result = new BitArray(bits1);
        BitArray OR_result = new BitArray(bits1);
        BitArray XOR_result = new BitArray(bits1);

        Console.WriteLine("\n\nBitwise [NOT] result:");
        PrintBitArray(bits1);
        Console.WriteLine("-----------------");
        NOT_result.Not();
        PrintBitArray(NOT_result);

        Console.WriteLine("\n\nBitwise [AND] result:");
        PrintBitArray(bits1);
        PrintBitArray(bits2);
        Console.WriteLine("-----------------");
        AND_result.And(bits2);
        PrintBitArray(AND_result);

        Console.WriteLine("\n\nBitwise [OR] result:");
        PrintBitArray(bits1);
        PrintBitArray(bits2);
        Console.WriteLine("-----------------");
        OR_result.Or(bits2);
        PrintBitArray(OR_result);

        Console.WriteLine("\n\nBitwise [XOR] result:");
        PrintBitArray(bits1);
        PrintBitArray(bits2);
        Console.WriteLine("-----------------");
        XOR_result.Xor(bits2);
        PrintBitArray(XOR_result);
    }

    static void Main(string[] args)
    {
        BitArray bitArray1 = new BitArray(8);

        PrintBitArray(bitArray1);
        PrintArrayWithIndex(bitArray1);
        
        //Creaing a BitArray from bool[]
        bool[] booleans = new bool[6] { true, false, true, false, true, true };
        BitArray bitArray2 = new BitArray(booleans);
        PrintBitArray(bitArray2);
        PrintArrayWithIndex(bitArray2);

        //Creaing a BitArray from byte[]
        byte[] bytes = { 32, 0xEF, 0x3C, 255};
        BitArray bitArray3 = new BitArray(bytes);
        PrintBitArray(bitArray3);
        PrintArrayWithIndex(bitArray3);


        //basic operations
        BitArray bitArray4 = new BitArray(16); //0000000000000000
        
        bitArray4.SetAll(true); //set all bits to true
        bitArray4.SetAll(false); //set all bits to false

        bitArray4.Set(2, true);
        bitArray4.Set(5, true);
        bitArray4.Set(12, true);
        bitArray4[13] = true;
        bitArray4[0] = true;
        PrintBitArray(bitArray4);
        PrintArrayWithIndex(bitArray4);


        BitwiseOperations();
    }
}

/* Introduction to BitArray in C#


Key Concepts:

    BitArray: A class in the System.Collections namespace that represents a collection of bits.
    Efficient Storage: BitArray allows for efficient storage and manipulation of binary data, offering a compact representation of boolean values.


Benefits:

    Compact Representation: BitArray provides a compact representation of boolean values, consuming less memory compared to traditional boolean arrays.
    Efficient Operations: It offers methods for efficient manipulation of individual bits and bitwise operations, making it suitable for various binary-related tasks.


Use Cases:

    Binary Data Manipulation: Working with binary data such as encoding, decoding, or bitwise operations.
    Memory Optimization: Storing a large number of boolean flags or states in memory efficiently.
    Algorithm Optimization: Improving performance in algorithms that require bit-level manipulation.


Summary:
    Understanding the basics of BitArray in C# is crucial for efficiently handling binary data and optimizing memory usage. In the following lesson, we will delve into working with BitArray, exploring its methods and practical examples.
 */

/* BitArray vs Bool[]:
    
   - A bool[] stores each bool value as at least 1 byte (8 bits) due to the way memory alignment works in .NET.
   - A BitArray stores multiple boolean values in a compact bit-packed format, using only 1 bit per value
 */