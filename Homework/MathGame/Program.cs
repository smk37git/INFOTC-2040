using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Formats.Asn1;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

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
        string Score = AskQuestions(Difficulty, QuestionLimit);

        // Calculate Score Function
        // Input: Score
        // Output: Score in decimal (.00)
        string FinalScore = CalculateScore(Score, QuestionLimit, UserName);


    }

    static string GetUserInput(){
        // While Loop to get input
        while (true){

            Console.Write("Enter Your Name: ");
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
        // Initalize UserDifficulty
        int UserDifficulty;
        
        // While Loop to get difficulty
        while (true){
        
            // Prompt Difficulty
            Console.Write("\nPlease select a difficulty:\n---------------------------\n1\n2\n3\n \nDifficulty: ");

            // Check to see if UserDifficulty selected difficulty
            try{
                
                UserDifficulty = int.Parse(Console.ReadLine()!);

                if (UserDifficulty < 1 || UserDifficulty > 3){
                    Console.WriteLine("ERROR: Please enter a difficulty between [1-3].");
                    continue;
                }
            }catch(Exception){
                Console.WriteLine("ERROR: Only numbers allowed.");
                continue;
            }

        return UserDifficulty;
        }
    }

    static int GetLimit(){
        // Initalize UserLimit
        int UserLimit;
        
        // While Loop to get limit
        while (true){
            
            // Prompt Limit
            Console.Write("\nPlease select how many questions you want [3-10]:\n-------------------------------------------------\n \nQuestions: ");

            // Check to see if UserLimit is in bounds
            try{

                UserLimit = int.Parse(Console.ReadLine()!);

                if (UserLimit < 3 || UserLimit > 10){
                    Console.WriteLine("ERROR: Please enter a limit between [3-10]");
                    continue;
                }
            }catch(Exception){
                Console.WriteLine("ERROR: Only numbers allowed.");
                continue;
            }

        return UserLimit;
        }
    }

    static string AskQuestions(int Difficulty, int QuestionLimit){
        // Initalize Random and X / Y and Score and Answer
        Random random = new Random();
        int X, Y;
        int Score = 0;
        int Answer;


        // Seperate by Difficulty
        switch (Difficulty){
            case 1: // EASY

                // Write Opening Line
                Console.WriteLine("\nMATH GAME: DIFFICULTY 1\n-----------------------");

                // For loop for each question
                for(int question = 0; question < QuestionLimit; question++){

                    // Initalize Attempts
                    int Attempts = 0;

                    // Randomize X and Y
                    X = random.Next(1, 10);
                    Y = random.Next(1, 10);

                    // Write Question Loop
                    while(Attempts < 3){
                        Console.Write($"{X} + {Y} = ");

                        // Check to see if Answer is numbers
                        try{
                            Answer = int.Parse(Console.ReadLine()!);

                            // Validating Function
                            // Input: Answer, X / Y
                            // Output: Bool (Correct == True, Incorrect == False)
                            bool Validation = ValidateAnswer(Answer, X, Y);

                            if(Validation == true){
                                Score ++;
                                break;
                            }else if(Validation == false){
                                Attempts ++;
                            }
                            
                            break;
                        }catch(Exception){
                            Console.WriteLine("ERROR: Only numbers allowed.");
                            continue;
                        }
                    }
                }    
                
                break;

            case 2: // MEDIUM

                // Write Opening Line
                Console.WriteLine("\nMATH GAME: DIFFICULTY 2\n-----------------------");

                // For loop for each question
                for(int question = 0; question < QuestionLimit; question++){

                    // Initalize Attempts
                    int Attempts = 0;

                    // Randomize X and Y
                    X = random.Next(10, 101);
                    Y = random.Next(10, 101);

                    // Write Question Loop
                    while(Attempts < 3){
                        Console.Write($"{X} + {Y} = ");
                        Answer = int.Parse(Console.ReadLine()!);

                        // Validating Function
                        // Input: Answer, X / Y
                        // Output: Bool (Correct == True, Incorrect == False)
                        bool Validation = ValidateAnswer(Answer, X, Y);

                        if(Validation == true){
                            Score ++;
                            break;
                        }else if(Validation == false){
                            Attempts ++;
                        }
                    }
                }
                break;

            case 3: // HARD
                // Write Opening Line
                Console.WriteLine("\nMATH GAME: DIFFICULTY 3\n-----------------------");

                // For loop for each question
                for(int question = 0; question < QuestionLimit; question++){

                    // Initalize Attempts
                    int Attempts = 0;

                    // Randomize X and Y
                    X = random.Next(100, 1000);
                    Y = random.Next(100, 1000);

                    // Write Question Loop
                    while(Attempts < 3){
                        Console.Write($"{X} + {Y} = ");
                        Answer = int.Parse(Console.ReadLine()!);

                        // Validating Function
                        // Input: Answer, X / Y
                        // Output: Bool (Correct == True, Incorrect == False)
                        bool Validation = ValidateAnswer(Answer, X, Y);

                        if(Validation == true){
                            Score ++;
                            break;
                        }else if(Validation == false){
                            Attempts ++;
                        }
                    }
                }
                break;

            default:
                Console.WriteLine("Difficulty out of range.");
                return AskQuestions(Difficulty, QuestionLimit);
        }
        
        return Score.ToString();
    }

    static bool ValidateAnswer(int Answer, int X, int Y){
        if(Answer == X + Y){
            Console.WriteLine("YaY! You Got It Right!!!\n");
            return true;
        }else{
            Console.WriteLine("OOPS! You Got it WRONG!!!\n");
            return false;
        }

    }

    static string CalculateScore(string Score, int QuestionLimit, string UserName){

        // Congratulate User
        Console.WriteLine($"Congratulations {UserName}!\nThank you for playing!");

        // Calculate and output Score
        float CalcScore = (float.Parse(Score) / QuestionLimit) * 100f;
        Console.WriteLine($"Final Score: {CalcScore:F2}%");

        // Return Score
        return CalcScore.ToString();



    }

}
