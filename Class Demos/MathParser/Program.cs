using System.IO.Compression;

namespace MathParser;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter a math equation in the form "A operator B".
        // Operator can be [+, -, *, /].
        // Example:
        // Valid: 4 + 3, Invalid: 4+3, Invalid: 4+ 3, Invalid 4 + 3 + 2.
        // Answer: 7

        // Declare variables
        int number1 = 0, number2 = 0;
        string mathOperator = "";

        // Prompt the user to enter the equation.
        Console.WriteLine("Enter equation:");

        // Get user input and assign to a variable.
        string equation = Console.ReadLine()!;

        // Parse the equation to get the numbers and operator. Use the .Split() method
        // 2 + 3: [2, +, 3]
        string[] equationParts = equation.Split(" ");

        // Make sure equation is in the correct format and equationParts has 3 items.
        if(equationParts.Length != 3){
            Console.WriteLine("ERROR: Incorrect format.\nExiting Program...");
            Environment.Exit(0);
        }

        // Validate input: make sure A and B are numbers, make sure the operator is [+, -, *, /].
        try{
            number1 = int.Parse(equationParts[0]);
            number2 = int.Parse(equationParts[2]);
        }catch(Exception){
            Console.WriteLine("ERROR: Must enter numbers in the equation.\nExiting program...");
            Environment.Exit(0);
        }

        // End the program if user input is invalid.
        // Make sure the operator is [+, -, *, /].
        // Determine which calculation to carry out. Carry out the calculation. Output the answer.
        mathOperator = equationParts[1];
        switch(mathOperator){
            case "+":
                Console.WriteLine($"Answer: {number1 + number2}");
                break;
            case "-":
                Console.WriteLine($"Answer: {number1 - number2}");
                break;
            case "*":
                Console.WriteLine($"Answer {number1 * number2}");
                break;
            case "/":
            // Handle divide by 0 error checking
                if(number2 == 0){
                    Console.WriteLine("ERROR: Cannot divide by 0.\nExiting program...");
                    Environment.Exit(0);
                }
                Console.WriteLine($"Answer: {(float)number1 / (float)number2}");
                break;
            default:
                Console.WriteLine($"ERROR: {mathOperator} is not a valid operator.\nExiting program...");
                Environment.Exit(0);
                break;
        }
    }
}
