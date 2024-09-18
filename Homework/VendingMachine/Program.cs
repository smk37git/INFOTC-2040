using System.Runtime.ConstrainedExecution;

namespace VendingMachine;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main -- Total time spent 4 1/2 hours :(
        // I tried my best to organize it into functions but couldn't figure it out.

        // Starting Variables
        int price = 50; int coins = 0;

        // Starting lines:
        Console.WriteLine("\nVending Machine \n---------------");
        Console.WriteLine("Amount Due: 50");

        // While Loop --> Will be broken when 50 = 0
        while(price > 0){

            // Ask for the input
            Console.WriteLine("Insert Coin:");
            string UserInput = Console.ReadLine()!;


            // Check for positive, integer numbers
            try{
                coins = int.Parse(UserInput);
                if (coins < 0){
                    Console.WriteLine("ERROR: Coin must be positive");
                }
            }catch(Exception){
                Console.WriteLine("ERROR: Only whole numerical coins allowed.");
                continue;
            }


            // Now that the input is positiveand an integer,
            // Switch case to assign it to (1, 5, 10, 25)
            // Calculate equation

            switch (coins){
                case 1:
                    price = price - 1;
                    if(price > 0){
                        Console.WriteLine($"\nAmount Due: {price}");
                    }
                    break;
                case 5:
                    price = price - 5;
                    if(price > 0){
                        Console.WriteLine($"\nAmount Due: {price}");
                    }
                    break;
                case 10:
                    price = price - 10;
                    if(price > 0){
                        Console.WriteLine($"\nAmount Due: {price}");
                    }
                    break;
                case 25:
                    price = price - 25;
                    if(price > 0){
                        Console.WriteLine($"\nAmount Due: {price}");
                    }
                    break;
                default:
                    if(coins != 1 && coins != 5 && coins != 10 && coins != 25){
                        Console.WriteLine("ERROR: Please select a valid coin [1, 5, 10, 25]");
                    }
                    break;
            }
        }

        // Calculate Change owed
        Console.WriteLine($"Change Owed: {price * -1}");

    }
}
