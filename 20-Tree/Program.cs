using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TreeNode<T>
{
    public T Value { get; set; }
    public List<TreeNode<T>> Children { get; set; }

    public TreeNode(T value)
    {
        this.Value = value;
        Children = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> node)
    {
        Children.Add(node);
    }

    public TreeNode<T> Find(T value)
    {
        if (EqualityComparer<T>.Default.Equals(value, Value))
            return this;

        foreach (TreeNode<T> child in this.Children)
        {
            TreeNode<T> found = child.Find(value);

            if (found != null) 
                return found;
        }

        return null;
    }

}

public class Tree<T>
{
    public TreeNode<T> Root { get; private set; }

    public Tree(T rootValue)
    {
        Root = new TreeNode<T>(rootValue);
    }

    public Tree(TreeNode<T> rootNode)
    {
        Root = rootNode;
    }

    public static void PrintTree(TreeNode<T> node, string indent = "", bool isLast = true)
    {
        if (node == null) return;

        Console.Write(indent);
        Console.Write(isLast ? "└── " : "├── ");
        Console.WriteLine(node.Value);

        for (int i = 0; i < node.Children.Count; i++)
        {
            PrintTree(node.Children[i], indent + (isLast ? "    " : "│   "), i == node.Children.Count - 1);
        }
    }

    public void PrintTree()
    {
        PrintTree(this.Root);
    }

    public TreeNode<T> Find(T value)
    {
        return Root?.Find(value);
    }

}

internal class Program
{


    public class Examples
    { 
        public static void CompanyTree()
        {
            TreeNode<string> node1 = new TreeNode<string>("CEO");
            TreeNode<string> node2 = new TreeNode<string>("CFP");
            TreeNode<string> node3 = new TreeNode<string>("CTO");
            TreeNode<string> node4 = new TreeNode<string>("CMO");


            Tree<string> CompanyTree = new Tree<string>(node1);
            CompanyTree.Root.AddChild(node2);
            CompanyTree.Root.AddChild(node3);
            CompanyTree.Root.AddChild(node4);

            TreeNode<string> node5 = new TreeNode<string>("Accountant");
            TreeNode<string> node6 = new TreeNode<string>("Developer");
            TreeNode<string> node7 = new TreeNode<string>("UX Designer");
            TreeNode<string> node8 = new TreeNode<string>("Social Media Manager");

            node2.AddChild(node5);
            node3.AddChild(node6);
            node3.AddChild(node7);
            node4.AddChild(node8);

            Tree<string>.PrintTree(node1); //start from node1
            Console.WriteLine();

            Tree<string>.PrintTree(node3); //start from node2
            Console.WriteLine();

            Tree<string>.PrintTree(node8); //start from node3
            Console.WriteLine();

            string Title = "Database Adminstartor";
            Console.WriteLine($"\nSearching for {Title} Node...");
            if (CompanyTree.Find(Title) != null)
                Console.WriteLine($"  - {Title} Found");
            else
                Console.WriteLine($"  - {Title} Not Found");

            Title = "Developer";
            Console.WriteLine($"\nSearching for {Title} Node...");
            if (CompanyTree.Find(Title) != null)
                Console.WriteLine($"  - {Title} Found");
            else
                Console.WriteLine($"  - {Title} Not Found");


        }

        public static void FamilyTree1()
        {
            TreeNode<string> grandParent1 = new TreeNode<string>("George I");

            TreeNode<string> parent1 = new TreeNode<string>("Jonathan");

            TreeNode<string> child1 = new TreeNode<string>("George II");

            TreeNode<string> grandChild1 = new TreeNode<string>("Joseph");

            TreeNode<string> grandGrandChild1 = new TreeNode<string>("Josuke");
            TreeNode<string> grandGrandChild2 = new TreeNode<string>("Holy");

            TreeNode<string> grandgrandGrandChild1 = new TreeNode<string>("Jotaro");

            TreeNode<string> grandgrandgrandGrandChild1 = new TreeNode<string>("Jolyne");


            Tree<string> JoestarFamilyTree = new Tree<string>("Joestar");
        
            JoestarFamilyTree.Root.AddChild(grandParent1);
            grandParent1.AddChild(parent1);
            parent1.AddChild(child1);
            child1.AddChild(grandChild1);
            grandChild1.AddChild(grandGrandChild1);
            grandChild1.AddChild(grandGrandChild2);
            grandGrandChild2.AddChild(grandgrandGrandChild1);
            grandgrandGrandChild1.AddChild(grandgrandgrandGrandChild1);

            JoestarFamilyTree.PrintTree();
        
        }

        public static void FamilyTree2()
        {
            // Generation 1 (Root Ancestor)
            TreeNode<string> rootAncestor = new TreeNode<string>("Sheikh Abdulrahman");

            // Generation 2
            TreeNode<string> gen2_child1 = new TreeNode<string>("Omar");
            TreeNode<string> gen2_child2 = new TreeNode<string>("Khalid");

            rootAncestor.AddChild(gen2_child1);
            rootAncestor.AddChild(gen2_child2);

            // Generation 3
            TreeNode<string> gen3_child1 = new TreeNode<string>("Fahd");
            TreeNode<string> gen3_child2 = new TreeNode<string>("Aisha");
            gen2_child1.AddChild(gen3_child1);
            gen2_child1.AddChild(gen3_child2);

            TreeNode<string> gen3_child3 = new TreeNode<string>("Hassan");
            gen2_child2.AddChild(gen3_child3);

            // Generation 4
            TreeNode<string> gen4_child1 = new TreeNode<string>("Saud");
            TreeNode<string> gen4_child2 = new TreeNode<string>("Fatima");
            gen3_child1.AddChild(gen4_child1);
            gen3_child2.AddChild(gen4_child2);

            TreeNode<string> gen4_child3 = new TreeNode<string>("Abdullah");
            gen3_child3.AddChild(gen4_child3);

            // Generation 5
            TreeNode<string> gen5_child1 = new TreeNode<string>("Nasser");
            gen4_child1.AddChild(gen5_child1);

            TreeNode<string> gen5_child2 = new TreeNode<string>("Maryam");
            TreeNode<string> gen5_child3 = new TreeNode<string>("Zayed");
            gen4_child2.AddChild(gen5_child2);
            gen4_child2.AddChild(gen5_child3);

            TreeNode<string> gen5_child4 = new TreeNode<string>("Yousef");
            gen4_child3.AddChild(gen5_child4);

            // Generation 6
            TreeNode<string> gen6_child1 = new TreeNode<string>("Ibrahim");
            gen5_child1.AddChild(gen6_child1);

            TreeNode<string> gen6_child2 = new TreeNode<string>("Layla");
            gen5_child2.AddChild(gen6_child2);

            TreeNode<string> gen6_child3 = new TreeNode<string>("Mohammed");
            gen5_child3.AddChild(gen6_child3);

            TreeNode<string> gen6_child4 = new TreeNode<string>("Rashid");
            gen5_child4.AddChild(gen6_child4);

            // Generation 7
            TreeNode<string> gen7_child1 = new TreeNode<string>("Sami");
            gen6_child1.AddChild(gen7_child1);

            TreeNode<string> gen7_child2 = new TreeNode<string>("Amal");
            gen6_child2.AddChild(gen7_child2);

            TreeNode<string> gen7_child3 = new TreeNode<string>("Ali");
            gen6_child3.AddChild(gen7_child3);

            TreeNode<string> gen7_child4 = new TreeNode<string>("Tariq");
            gen6_child4.AddChild(gen7_child4);

            // Generation 8
            TreeNode<string> gen8_child1 = new TreeNode<string>("Hussein");
            gen7_child1.AddChild(gen8_child1);

            TreeNode<string> gen8_child2 = new TreeNode<string>("Nadia");
            gen7_child2.AddChild(gen8_child2);

            TreeNode<string> gen8_child3 = new TreeNode<string>("Bilal");
            gen7_child3.AddChild(gen8_child3);

            TreeNode<string> gen8_child4 = new TreeNode<string>("Karim");
            gen7_child4.AddChild(gen8_child4);

            // Generation 9
            TreeNode<string> gen9_child1 = new TreeNode<string>("Ahmed");
            gen8_child1.AddChild(gen9_child1);

            TreeNode<string> gen9_child2 = new TreeNode<string>("Sara");
            gen8_child2.AddChild(gen9_child2);

            TreeNode<string> gen9_child3 = new TreeNode<string>("Othman");
            gen8_child3.AddChild(gen9_child3);

            TreeNode<string> gen9_child4 = new TreeNode<string>("Faisal");
            gen8_child4.AddChild(gen9_child4);

            // Generation 10
            TreeNode<string> gen10_child1 = new TreeNode<string>("Salim");
            gen9_child1.AddChild(gen10_child1);

            TreeNode<string> gen10_child2 = new TreeNode<string>("Hana");
            gen9_child2.AddChild(gen10_child2);

            TreeNode<string> gen10_child3 = new TreeNode<string>("Mustafa");
            gen9_child3.AddChild(gen10_child3);

            TreeNode<string> gen10_child4 = new TreeNode<string>("Zain");
            gen9_child4.AddChild(gen10_child4);

            // Create the tree and print it
            Tree<string> arabFamilyTree = new Tree<string>(rootAncestor);
            Tree<string>.PrintTree(arabFamilyTree.Root);
        }


    }



    static void Main(string[] args)
    {
        Examples.CompanyTree();

        //Examples.FamilyTree1();
        //Examples.FamilyTree2();

    }
}