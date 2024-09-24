namespace CharDemo;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string className = "IT*2040";
        char character = 't';

        // Is the second character in the class name a letter
        char secondLetter = className[1];
        bool isLetter = Char.IsLetter(secondLetter);
        Console.WriteLine($"It is {isLetter} that {secondLetter} is a letter.");

        // Is the third character in the class name a letter
        char thirdLetter = className[2];
        bool isLetter3 = Char.IsLetter(thirdLetter);
        Console.WriteLine($"It is {isLetter3} that {thirdLetter} is a letter.");

        // Is the third character in the class name a letter
        bool isDigit = Char.IsDigit(thirdLetter);
        Console.WriteLine($"It is {isDigit} that {thirdLetter} is a digit.");

        // Is the third character in the class name a letter or a digit
        bool IsLetterOrDigit = Char.IsLetterOrDigit(thirdLetter);
        Console.WriteLine($"It is {isDigit} that {thirdLetter} is a letter or a digit.");

        // Use our function to determine if non alphanumeric characters are in the classname
        bool isValid = IsValidName(className);

        if(isValid){
            Console.WriteLine("Class name only contains alphanumeric characters");
        }else{
            Console.WriteLine("Class name contains non-alphanumeric characters");
        }

    }
    

    // Function to determine valid characters
    // Input: (string) className
    // Output: bool: True if all characters alhpanumeric. False if not
    static bool IsValidName(string cName){

        // Determine if all characters are alphanumeric
        foreach(char letter in cName){
            if(!Char.IsLetterOrDigit(letter)){
                return false;
            }
        }

        return true;

    }



}
