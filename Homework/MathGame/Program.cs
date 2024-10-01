namespace MathGame;

class Program
{
    static void Main(string[] args)
    {

        // Sebastian Main -- Math Game Program
        // Made with 6 functions

        // This program will provide a game for the user. The user can select the difficulty [1-3] and the
        // number of questions [3-10]. It will then prompt the user with the questions, they have three
        // attempts to get it right, if they don't it moves on the the next question. After completing
        // the questions it will then calculate the score based on 0%-100%. Then the program ends.

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

        // Program ends


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

                        // Output Equation
                        Console.Write($"{X} + {Y} = ");

                        // Check to see if Answer is numbers
                        try{
                            Answer = int.Parse(Console.ReadLine()!);
                        }catch(Exception){
                            Console.WriteLine("ERROR: Only numbers allowed.\n ");
                            Attempts ++;
                            continue;
                        }

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

                        // Output Equation
                        Console.Write($"{X} + {Y} = ");

                        // Check to see if Answer is numbers
                        try{
                            Answer = int.Parse(Console.ReadLine()!);
                        }catch(Exception){
                            Console.WriteLine("ERROR: Only numbers allowed.");
                            Attempts ++;
                            continue;
                        }

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

                        // Output Equation
                        Console.Write($"{X} + {Y} = ");

                        // Check to see if Answer is numbers
                        try{
                            Answer = int.Parse(Console.ReadLine()!);
                        }catch(Exception){
                            Console.WriteLine("ERROR: Only numbers allowed.");
                            Attempts ++;
                            continue;
                        }

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

        // Is Answer correct or incorrect?
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
        Console.WriteLine($"Congratulations {UserName}! Thank you for playing!\n-------------------------------------------");

        // Calculate and output Score
        float CalcScore = (float.Parse(Score) / QuestionLimit) * 100f;
        Console.WriteLine($"You got {Score} out of {QuestionLimit} questions right.");
        Console.WriteLine($"Final Score: {CalcScore:F2}%\n ");

        // Return Score
        return CalcScore.ToString();

    }
}