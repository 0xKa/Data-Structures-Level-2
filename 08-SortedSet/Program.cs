using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_SortedSet
{
    internal class Program
    {
        public static SortedSet<string> programmingLanguages = new SortedSet<string>()
        {
            "C", "Java", "Python", "C++", "C#", "JavaScript", "PHP", "Swift", "Ruby", "Kotlin",
            "Go", "Rust", "TypeScript", "Dart", "Perl", "Scala", "R", "Matlab", "Objective-C",
            "Shell", "Lua", "Groovy", "Visual Basic", "F#", "Haskell", "Erlang", "Delphi", "Ada", 
            "Julia", "Prolog", "JavaScript", "Pascal"
        };

        public static void PrintSortedList<T>(SortedSet<T> sortedList)
        {
            Console.WriteLine("Number of Elements: " + sortedList.Count);
            Console.WriteLine("[" + string.Join(", ", sortedList) + "]");
        }

        public static void LINQ_Example()
        {
            var query = from plGroup in programmingLanguages
                        group plGroup by plGroup.Length into Grouped
                        orderby Grouped.Key descending
                        select Grouped;


            foreach (var plGroup in query)
            {
                Console.WriteLine("Length of string: " + plGroup.Key);
                foreach (var pl in plGroup)
                {
                    Console.WriteLine("  - " + pl + " ");
                }
                Console.WriteLine("\n");
            }

        }

        static void Main(string[] args)
        {
            //PrintSortedList<string>(programmingLanguages);

            LINQ_Example();

            /// same as hashset we can apply:
            /// Union, Intersection, Difference, Equality, Subset, and Superset operations
        }
    }
}
/* SortedSet in C#
    SortedSet is a collection class in C# that represents a sorted set of elements. It stores unique elements in sorted order, allowing for efficient search, insertion, and removal operations.
    SortedSet is part of the System.Collections.Generic namespace in .NET.

Characteristics of SortedSet:
    Stores unique elements in sorted order.
    Provides fast search, insertion, and removal operations.
    Automatically maintains sorted order as elements are added or removed.
    Does not allow duplicate elements.
    
Advantages of Using SortedSet:
    Ensures elements are always stored in sorted order, facilitating efficient traversal and manipulation.
    Provides fast lookup, insertion, and removal operations compared to other collection types.
    Suitable for scenarios where maintaining sorted order and uniqueness of elements are essential.
    Simplicity: The API of SortedSet is simpler compared to SortedList, as it deals with single elements rather than key/value pairs.

Conclusion:
    SortedSet is a useful collection class in C# for storing unique elements in sorted order. It provides efficient search, insertion, and removal operations, making it suitable for a wide range of scenarios where maintaining sorted order is essential. By understanding the characteristics and advantages of SortedSet, developers can leverage it effectively in their C# programs.
 */
