MyCustomCollection

Generic Array-Based Collection in C#

Features

Add / Remove Elements

Add Unique Elements (AddUnique)

Clear Elements Safely

Sort Ascending / Descending

Shuffle Elements

Enumerable with foreach

Usage Example
var names = new MyCustomCollection<string>();
names.Add("Mohhamed");
names.Add("Dina");
names.Add("John");

names.SortDescending(); // Sort descending
names.Shuffle();        // Shuffle elements

foreach(var n in names)
    Console.WriteLine(n);

names.Remove("John");   // Remove an element
names.Clear();          // Clear all elements

Notes

Only valid elements (0.._Count-1) are used in operations

Default values after _Count do not affect enumeration or sorting

Can be extended with additional utility methods like FindAll, InsertAt, etc
