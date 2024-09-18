namespace StringDemo;

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

        

    }
}
