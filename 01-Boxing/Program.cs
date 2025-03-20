using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Boxing is the process of converting Value Type to Reference Type (pointer),
// this will result the value to be stored in the Heap instead of the Stack
// Example: int --> object
// boxing was imporent back in the day, now now can use Generics
internal class Program
{
    static void Main(string[] args)
    {

        int num = 420;
        object obj = num; //Boxing
        int num2 = (int)obj; //Unboxing

        Console.WriteLine(num);
        Console.WriteLine(obj);
        Console.WriteLine(num2);


        Console.ReadLine();
    }
}
