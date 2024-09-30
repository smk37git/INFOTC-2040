using System.Diagnostics.Metrics;

namespace MathGame;

class Program
{
    static void Main(string[] args)
    {
        /*
        Sebastian Main -- Math Game Program
        Needs atleast 4 Functions

        1. Welcome and Name:
        Prompt the user and ask them to enter their name.
        If the user doesn't enter a name, ask them to try again.

        2. Choose Your Challenge:
        Ask the user to select their desired difficulty level (1, 2, or 3).
        If the user enters an invalid option, output an error message showing the valid options and ask them to try again.

        3. Set the Question Limit:
        Ask the user how many math problems they want to answer. Valid options (3 - 10).
        If the user enters an invalid number, output an error message showing the valid range and ask them to try again.

        4. Ask the Questions:
        Present each problem to the user in the format X + Y =  .
        Generate the specified number of math problems based on the chosen question limit. The numbers in the problem (X  and Y ) should have the chosen difficulty number of digits:
        Level 1: Single-digit numbers (1-9)
        Level 2: Double-digit numbers (10-99)
        Level 3: Triple-digit numbers (100-999)
        Get the user's answer.

        5. Evaluate the Answer:
        If the answer is correct:
        Output: YaY! You Got It Right!!!
        Move on to the next problem.
        If the answer is incorrect (or not even a number):
        Output: OOPS! You Got it WRONG!!!
        The user is allowed a maximum of three (3) attempts per question to give a correct answer.
        If the user does not give the correct answer after three tries, output the correct answer.
        Move on to the next problem.

        6. Final Score:
        Once all problems are answered, congratulate the user on their effort.
        Calculate and display their percentage of correct answers with two decimal places.

        7.  End the program
        */

        // Clear Console
        Console.Clear();

        // Welcome Name Function
        // Input: User Input
        // Output: UserName
        string UserName = GetUserInput();

        // Choose Difficulty Function
        // Input: User Input
        // Output: Difficulty
        int Difficulty = GetDifficulty();

        // Choose the Question Limit Function
        // Input: User Input
        // Output: # of questions
        int QuestionLimit = GetLimit();
        

        // Ask Problem Function
        // Input: Difficulty, Limit
        // Output: Questions
        string AskProblem = AskQuestions(Difficulty, QuestionLimit);

    }

    static string GetUserInput(){
        // While Loop to get input
        while (true){

            Console.WriteLine("Enter Your Name: ");
            string UserInput = Console.ReadLine()!;

            // Check to see if username is not empty, If it is then reprompt.
            if(UserInput == ""){
                Console.WriteLine("ERROR: Please enter a name!");
                continue;
            }
        return UserInput;
        }
    }

    static int GetDifficulty(){
        // While Loop to get difficulty
        while (true){
        
            // Prompt Difficulty
            Console.WriteLine("\nPlease select a difficulty:\n1\n2\n3");
            int UserDifficulty = int.Parse(Console.ReadLine()!);

            // Check to see if UserDifficulty selected difficulty
            if(UserDifficulty < 1 || UserDifficulty > 3){
                Console.WriteLine("ERROR: Please enter a difficulty between [1-3].");
                continue;
            }
        return UserDifficulty;
        }
    }

    static int GetLimit(){
        // While Loop to get limit
        while (true){
            
            // Prompt Limit
            Console.WriteLine("\nPlease select how many questions you want [3-10]");
            int UserLimit = int.Parse(Console.ReadLine()!);

            // Check to see if UserLimit is in bounds
            if(UserLimit < 3 || UserLimit > 10){
                Console.WriteLine("ERROR: Please enter a limit between [3-10]");
                continue;
            }
        return UserLimit;
        }
    }

    static string AskQuestions(int Difficulty, int QuestionLimit){
        // Initalize Random
        Random random = new Random();

        // Seperate by Difficulty
        switch (Difficulty){
            case 1: // EASY
                Console.WriteLine("ONE SELECTED");

                // Randomize X and Y
                int oneX = random.Next(1, 10);
                int oneY = random.Next(1,10);

                // Write Question
                Console.WriteLine($"{oneX} + {oneY} = ");
                break;

            case 2: // MEDIUM
                Console.WriteLine("TWO SELECTED");

                // Randomize X and Y
                int twoX = random.Next(10, 101);
                int twoY = random.Next(10, 101);

                // Write Question
                Console.WriteLine($"{twoX} + {twoY} = ");
                break;

            case 3: // HARD
                Console.WriteLine("THREE SELECTED");

                // Randomize X and Y
                int threeX = random.Next(100,1000);
                int threeY = random.Next(100, 1000);

                // Write Question
                Console.WriteLine($"{threeX} + {threeY} = ");
                break;

            default:
                Console.WriteLine("Difficulty out of range.");
                return AskQuestions(Difficulty, QuestionLimit);
        }
        string Question = "TEST";
        return Question;
    }

}
