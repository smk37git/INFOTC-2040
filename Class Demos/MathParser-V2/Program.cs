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

        // end the program if user input is invalid
        if(!IsValidEquation(equation)){
            Console.WriteLine("Exiting the program...");
            Environment.Exit(0);
        }

        // Get the number1, number2, and math operator.
        string[] equationParts = equation.Split(" ");
        mathOperator = equationParts[1];
        number1 = int.Parse(equationParts[0]);
        number2 = int.Parse(equationParts[2]);


        // Calculate equation
        CalculateEquation(number1, number2, mathOperator);

    }

    // Validating Function -- validate equation format and number values
    // Input: equation
    // Output: 
    static bool IsValidEquation(string equation){

        int number1, number2;
        // Parse the equation to get the numbers and operator. Use the .Split() method
        // 2 + 3: [2, +, 3]
        string[] equationParts = equation.Split(" ");

        // Make sure equation is in the correct format and equationParts has 3 items.
        if(equationParts.Length != 3){
            Console.WriteLine("ERROR: Incorrect format.");
            return false;
        }

        // Validate input: make sure A and B are numbers, make sure the operator is [+, -, *, /].
        try{
            number1 = int.Parse(equationParts[0]);
            number2 = int.Parse(equationParts[2]);
        }catch(Exception){
            Console.WriteLine("ERROR: Must enter numbers in the equation.");
            return false;
        }

        return true;
    }

    // Calculating Function -- carry outh math operation
    // Input: number1, number2, math operator
    // Output: none

    static void CalculateEquation(int numberA, int numberB, string mathOperator){

        // End the program if user input is invalid.
        // Make sure the operator is [+, -, *, /].
        // Determine which calculation to carry out. Carry out the calculation. Output the answer.

        switch(mathOperator){
            case "+":
                Console.WriteLine($"Answer: {numberA + numberB}");
                break;
            case "-":
                Console.WriteLine($"Answer: {numberA - numberB}");
                break;
            case "*":
                Console.WriteLine($"Answer {numberA * numberB}");
                break;
            case "/":
            // Handle divide by 0 error checking
                if(numberB == 0){
                    Console.WriteLine("ERROR: Cannot divide by 0.\nExiting program...");
                    Environment.Exit(0);
                }
                Console.WriteLine($"Answer: {(float)numberA / (float)numberB}");
                break;
            default:
                Console.WriteLine($"ERROR: {mathOperator} is not a valid operator.\nExiting program...");
                Environment.Exit(0);
                break;
        }
    }
}