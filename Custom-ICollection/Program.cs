using Custom_ICollection.Array_Based_Collection;
using System;
using System.Collections.Generic;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        MyCustomCollection<string> names = new MyCustomCollection<string>();

        //Adding
        names.Add("Mohhamed");
        names.Add("Dina");
        names.Add("John");
        names.Add("Daved");
        names.Add("Ahmed");


        //________________________________
        names.SortDescending();

        WriteLine("Sorted Names:");
        foreach (var name in names) 
            WriteLine(name);



        //_______________________________

        names.Shuffle();
        WriteLine("\nAfter Shuffle:");
        foreach (var name in names)
            WriteLine(name);


        //___________________________________

        string target = "Daved";
        WriteLine("\nRemoving '{0}'", target);

        if (names.Contains(target))
        {
            names.Remove(target);
            WriteLine($"'{target}' Deleted");
        }
        else
            WriteLine("'" + target + "' NOT found it the list");


        //____________________________________

        WriteLine("\nClear");
        names.Clear();

        WriteLine("\nDone Clear!");


            ReadKey();
    }
}
