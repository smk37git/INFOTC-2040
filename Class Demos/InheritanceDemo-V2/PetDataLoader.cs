namespace InheritanceDemo;

// Create a class to read data from a file and return a list of objects
public class PetDataLoader{
    
    // Create a method to read data from a file and return a list of pets
    public static List<Pet> LoadPets(string filePath){
        // Create an empty list to store pet objects
        List<Pet> petList = new List<Pet>();

        // Open the data.csv file with a streamreader object
        using(StreamReader fileReader = new StreamReader(filePath)){

            // Create a counter to keep track of the line in the file we are reading from
            int lineNumber = 0;
            int piecesOfData = 5;

            // Read the file line by line
            while(!fileReader.EndOfStream){
                // Increment line number
                lineNumber++;

                // Split the line at the comma
                string lineOfData = fileReader.ReadLine()!;

                string[] petData = lineOfData.Split(",");

                // Ensure each line has 5 pieces of data
                if(petData.Length != piecesOfData){
                    string errorMessage = $"Line {lineNumber} in your data file contains {petData.Length} pieces of data. It should contain {piecesOfData} pieces of data.";
                }

                // Get each value from the resulting array and assign to a variable, convert data type as necessary
                try{
                    string petName = petData[0];
                    string owner = petData[1];
                    int petAge = int.Parse(petData[2]);
                    double petWegiht = double.Parse(petData[3]);
                    string petType = petData[4];
                     // Create the appropiate object with the values
                    if(petType == "dog"){
                        petList.Add(new Dog(petName, owner, petWegiht, petAge));
                    }else{
                        petList.Add(new Cat(petName, owner, petWegiht, petAge));
                    }
                }catch(Exception error){
                    string message = $"There was an error reading line {lineNumber}: {error.Message}";
                    Console.WriteLine(message);
                    LogError(message);
                    continue;
                }
            }
            return petList;
        }
    }

    // Method to log errors
    // Input: string error message
    // Output: None
    public static void LogError(string errorMessage){
        // Log the error to a file called log.txt
        // Get the current data and time
        DateTime logDate = DateTime.Now;

        using(StreamWriter logger = File.AppendText("log.txt")){
            logger.WriteLine(logDate + ": " + errorMessage);
        }
    }

}