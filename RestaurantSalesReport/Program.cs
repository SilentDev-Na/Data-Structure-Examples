using System;
using System.Collections.Generic;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {

        string[] restaurantNames = { "Dominos Pizza", "KFC", "Al-Baik", "Al-Basheer" };

        decimal[][] restaurantSales = new decimal[4][];

        restaurantSales[0] = new decimal[6] { 100.33M, 150.50M, 120.75M, 130.00M, 99.90M, 110.10M };
        restaurantSales[1] = new decimal[5] { 200.00M, 220.50M, 180.25M, 195.00M, 210.10M };
        restaurantSales[2] = new decimal[4] { 300.00M, 250.50M, 275.75M, 290.00M };
        restaurantSales[3] = new decimal[6] { 120.00M, 130.50M, 140.25M, 150.00M, 160.75M, 170.00M };


        DisplayRestaurantSales(restaurantNames, restaurantSales);



        ReadKey();
    }

    static void PrintSalesSummary(decimal totalSales, decimal maxSale, ref decimal minSale)
    {
        SetSeperator('=', 55);
        WriteLine($"{"Total Sales:",-15:C} {"Minimum Sale:",17:C} {"Maximum Sale:",17:C}");

        SetSeperator('=', 55);

        WriteLine($"\n{totalSales,-15:C} {minSale,11:C} {maxSale,17:C}");
        WriteLine();
    }

    static void DisplayRestaurantSales(string[] restaurantNames, decimal[][] restaurantSales)
    {
        for (int i = 0; i < restaurantSales.Length; i++)
        {
            WriteLine($"\n{"Restaurant",-15} {"Sales:",15}");
            SetSeperator('-', 55);

            if (restaurantSales[i]?.Length > 0)
            {
                decimal total = 0;
                decimal minSale = restaurantSales[i][0];
                decimal maxSale = restaurantSales[i][0];

                WriteLine($"{restaurantNames[i],-15}");
                foreach (var sale in restaurantSales[i])
                {
                    WriteLine($"{sale,31:C}");
                    total += sale;

                    if (sale < minSale)
                        minSale = sale;

                    if (sale > maxSale)
                        maxSale = sale;
                }

                PrintSalesSummary(total, maxSale, ref minSale);
            }
            else
            {
                WriteLine($"{restaurantNames[i],-15} {"No Sales Today",15}");
            }

            SetSeperator('-', 55);
            WriteLine();
        }
    }

    static void SetSeperator(char sep, int Length)
    {
        WriteLine(new string(sep, Length));
    }

}
