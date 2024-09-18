using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MenuOrder;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main -- Total time: 1hr
        // This program is a ordering system. Input order, calculate total, print total
        Console.Clear();

        // Create the menu dictionary
        Dictionary<string, float> itemPrices = new Dictionary<string, float>(){
            {"Baja Taco", 4.00f},
            {"Burrito", 7.50f},
            {"Bowl", 8.50f},
            {"Nachos", 11.00f},
            {"Quesadilla", 8.50f},
            {"Super Burrito", 8.50f},
            {"Super Quesadilla", 9.50f},
            {"Taco", 3.00f},
            {"Tortilla Salad", 8.00f}
        };

        // List menu
        Console.WriteLine("Our menu choices are:\n---------------------\nBaja Taco [$4.00]\nBurrito [$7.50]\nBowl [$8.50]\nNachos [$11.00]\nQuesadilla [$8.50]\nSuper Burrito [$8.50]\nSuper Quesadilla [$9.50]\nTaco [$3.00]\nTortilla Salad [$8.00]");

        // Initialize total
        float total = 0.00f;

        // Input in while loop
        // Input: Item
        // Output: total
        while(true){

            // Ask for input
            Console.WriteLine("\nWhat would you like to order: ");
            string item = Console.ReadLine()!;

            // End command
            string end = "END";

            // Check for end command, convert input to UPPERCASE and see if it matches keyword.
            if(item.ToUpper() == end){
                Console.WriteLine($"\nThanks for ordering!\nYour total is {total.ToString("F2")}");
                Environment.Exit(0);
            }

            // Check if item exists in the dictionary
            if(itemPrices.ContainsKey(item)){

                // Add itemPrice to total
                total += (itemPrices[item]);
                Console.WriteLine($"Total: ${total.ToString("F2")}");

              
            }else{
                Console.WriteLine($"{item} was not on the menu! Please enter an item on the menu.");
            }   
        }
    }
}
