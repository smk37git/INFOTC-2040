namespace StringDemo;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // clear console
        Console.Clear();

        string mascot = "Truman Tiger";
        // Strings are arrays of characters
        // Loop through the characters in mascot
        Console.WriteLine("\nLoop through String");
        foreach(char letter in mascot){
            Console.WriteLine(letter);
        }

        Console.WriteLine("\nGet length of a String");
        // Get length of a string
        int numberOfCharacters = mascot.Length;
        Console.WriteLine($"There are {numberOfCharacters} in {mascot}.");

        Console.WriteLine("\nConvert a string to upper case and lower case\n------------------");
        Console.WriteLine(mascot.ToLower());
        Console.WriteLine(mascot.ToUpper());
        
        Console.WriteLine("\nLoop Through a string usisng indexes\n------------------");
        // index 0: T, index 1: R
        for(int index = 0; index < mascot.Length; index++){
            Console.WriteLine($"index {index}: {mascot[index]}");
        }

        // Concatenate strings
        Console.WriteLine("\nString Concatenation\n------------------");
        string firstName = "Taylor"; 
        string lastName = "Swift";

        // Create a fullName variable as ["firstName"] ["lastName"]
        string fullName = String.Concat(firstName, " ", lastName);
        Console.WriteLine($"Full name: {fullName}");

        string fullName2 = firstName + " " + lastName;
        Console.WriteLine($"Full name: {fullName2}");

        string number1 = "5", number2 = "4";
        string sum = number1 + number2;
        Console.WriteLine($"Sum of {number1} + {number2} = {sum}");

        //Endswith
        Console.WriteLine("\nEndsWith Method\n--------------");
        string email = "taylor.swift@example.com";
        bool endsInDotCom = email.EndsWith(".com");

        Console.WriteLine($"{email} ends in .com {endsInDotCom}");

        // Contains Method
        Console.WriteLine("\nContains Method\n--------------");
        bool hasAtSymbol = email.Contains("@");
        Console.WriteLine($"{email} contains @: {hasAtSymbol}");

        //Substrings
        Console.WriteLine("\nSubstrings\n--------------");
        string emailLastName = email.Substring(7, 5);
        Console.WriteLine(emailLastName);

        // Replace
        Console.WriteLine("\nReplace Method\n--------------");
        string text = "I love C# programming";
        string replacedString = text.Replace("C#", "Python");
        Console.WriteLine(replacedString);

        // Regular Expression -- to be made


    }
}
