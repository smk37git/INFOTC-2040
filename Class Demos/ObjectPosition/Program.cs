namespace ObjectPosition;

class Program
{
    static void Main(string[] args)
    {
        // Declare variables
        float initialPosition, initialVelocity, acceleration, elapsedTime;
        double finalPosition = 0;
        bool doCalculation = true;

        Console.WriteLine("This program calculates an object's final position.");

        while (doCalculation){
            // Prompt the user to enter initial position
            initialPosition = GetFloatInput("Enter the object's initial position: ", false);
            
            // Prompt the user to enter initial velocity
            // Get the initial velocity the user entered
            initialVelocity = GetFloatInput("Enter the object's inital velocity: ", false);

            // Prompt the user to enter initial acceleration
            // Get the acceleration the user entered
            acceleration = GetFloatInput("Enter the object's acceleration: ", false);

            // Prompt the user to enter elapsed time
            // Get the elapsed time the user entered
            // Time MUST be positive.
            elapsedTime = GetFloatInput("Enter the elapsed time: ", true);

            // Calculate the final position using the user input values
            // ip (inital positon) + iv (initial velocity) * et (elapsed time) + 1/2at^2 (acceleration * time)
            finalPosition = initialPosition + initialVelocity * elapsedTime + 0.5 * acceleration * Math.Pow(elapsedTime, 2);

            // Print the result to the console
            Console.WriteLine($"Final Position: {finalPosition:N2}");

            // Ask the user if they want to run the program again
            Console.WriteLine("Do you want the program to run again? (y/n)");
            string anotherCalculation = Console.ReadLine()!;

            // if yes run the program again, if no terminate program.
            if(anotherCalculation != "y"){
                doCalculation = false;
            }
        }
    }  

    /*
    Function to get float input from user
    Input: prompt
    Output: number (float)
    */
    static float GetFloatInput(string prompt, bool mustBePositive){
        float userInput = 0;
        
        while(true){
            Console.WriteLine("\n" + prompt);
            // Get the prompt the user entered
            try{
                userInput = float.Parse(Console.ReadLine()!);
                if(userInput < 0 && mustBePositive){
                    Console.WriteLine("Error: input must be greater than 0.");
                    continue;
                }
                break;
            // Validate the input. Reprompt the user if input is invalid
            }catch(Exception error){
                Console.WriteLine("The value you entered is invalid. Only numerical values allowed");
                Console.WriteLine($"Error: {error.GetType().Name}");
            }    
        }

        return userInput;

    }
}
