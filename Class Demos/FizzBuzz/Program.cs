namespace FizzBuzz;

class Program
{
    static void Main(string[] args)
    {
        // Fizz Buzz from 0 - 100
        // If number is divisible by 3: output Fizz
        // If number is divisible by 5: output Buzz
        // If number is divisible by both 3 and 5: output FizzBuzz

        // Ask a user for the stop value
        int stopValue = getStopValue();

        // Write a for loop to loop from 0 to 100
        for(int number = 0; number <= stopValue; number++){
            // Logical Error fix for "0"
            if (number == 0){
                Console.WriteLine(number);
            }else if((number % 3 == 0) && (number % 5 == 0)){
                Console.WriteLine("FizzBuzz");
            }else if (number % 3 ==0){
                Console.WriteLine("Fizz");
            }else if(number % 5 ==0){
                Console.WriteLine("Buzz");
            }else{
                Console.WriteLine(number);
            }
        }
    }

    // Function to get and return the stop value
    // Input: none
    // Output: an integer number
    static int getStopValue(){
        // Prompt the user to enter a value
        Console.WriteLine("Enter the stop value:");
        // Get the number the user entered
        string stringNumber = Console.ReadLine()!;
        // Convert the number to an integer
        int number = int.Parse(stringNumber);
        // return the number
        return number;

    }
}
