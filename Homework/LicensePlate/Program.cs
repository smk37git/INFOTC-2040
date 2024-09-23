using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace LicensePlate;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main
        // License Plate Challenge
        // This program will prompt  the user for a vanity plate, and output valid if it meets the requirements
        // If it is invalid it did not meet the requirements.
        // Assume that any input letters will be in uppercase.

        // Requirements:
        // Start with 2 letters
        // Maximum of 6 characters (letters or numbers) and a minimum of 2 characters
        // Numbers cannot be used in the middle of a plate; they must come at the end. (AAA222)
        // First number cannot be a 0
        // No periods, spaces, or other marks allowed. Only letters and numbers

        // 3 Functions
        // 1 -- Get User Input
        // 2 -- Determine if its Valid
        // 3 -- Display the result

        // Clear Consle
        Console.Clear();


        // UserInput Function
        // Input: User
        // Output: License Plate
        string LicensePlate = GetUserInput()!;

        // Validation Function
        // Input: License Plate
        // Output: Bool (True/False)
        bool Validation = ValidateLicense(LicensePlate)!;

    }

    static string GetUserInput(){

        // While Loop to get input
        while (true){

            Console.WriteLine("Enter License Plate: ");
            string UserInput = Console.ReadLine()!;

            // Check to see if License Plate is 2-6 characters, If not then reprompt.
            if(UserInput.Length < 2 || UserInput.Length > 6){
                Console.WriteLine("ERROR: Please enter a Valid License Plate (2-6 Characters)");
                continue;
            }

        return UserInput;
        }

    }

    static bool ValidateLicense(string LicensePlate){

        // Check for requirements
        // Check if [0-1] are letters
        if(char.IsLetter(LicensePlate[0]) || char.IsLetter(LicensePlate[1])){
            Console.WriteLine("YES");
            return true;
        }else{
            Console.WriteLine("NO");
            return false;
        }

        // Check if [2-5] have no numbers in middle. (AAA222 [TRUE] / AA2AAA [FALSE])


    }
}
