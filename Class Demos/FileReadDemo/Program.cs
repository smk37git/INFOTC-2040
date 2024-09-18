using Microsoft.VisualBasic;

namespace FileReadDemo;

class Program
{
    static void Main(string[] args)
    {
        // Load the data from file.csv into a list
        List<string> listOfNames = loadDataFromFile();

        // Print names to the console.
        printNames(listOfNames);

        // Write the names to an output.txt file in reverse order
        WriteListToFile(listOfNames);
    }

    // Function to write names to a file from a list
    // Input: a list of names
    // Output: None
    static void WriteListToFile(List<string> listOfNames){

        // Create a file handler to write the names to a file
        using(StreamWriter fileWriter = new StreamWriter("output.txt")){
            // Write the names to the file as [firstname], [lastname]
            foreach(string name in listOfNames){
                string[] nameParts = name.Split(" ");
                string firstName = nameParts[0];
                string lastName = nameParts[1];

                // Write name to file
                fileWriter.WriteLine($"{firstName}, {lastName}");

            }
        }
        return;

    }

    // Function to print names from a list
    // Input: List<string>
    // Output: none
    static void printNames(List<string> nameList){
        // Print all names
        foreach(string name in nameList){
            Console.WriteLine(name);
        }
        return;
    }

    // Function to read data from a csv file and load into a list of strings
    // Input: none
    // Output: List<string> of names
    // Static [return type] [function name] [function parameters]
    static List<string> loadDataFromFile(){
        // create an empty list to stre the names in
        List<string> nameList = new List<string>();

        string fullPath = Path.Join(".", "data", "file.csv");
        // Open the file
        using(StreamReader fileReader = new StreamReader(fullPath)){
            // Skip the first line which is the header row
            string headerData = fileReader.ReadLine()!;

            // Read names from the file line by line
            while(!fileReader.EndOfStream){
                string lineofData = fileReader.ReadLine()!;

                // Split each line at the ", "
                string[] nameData = lineofData.Split(", ");

                // Get first and last name
                string firstName = nameData[1];
                string lastName = nameData[0];

                // Store name in list: [firstname] [lastname]
                nameList.Add($"{firstName} {lastName}");
            } 
        }
        return nameList;
    }
}
