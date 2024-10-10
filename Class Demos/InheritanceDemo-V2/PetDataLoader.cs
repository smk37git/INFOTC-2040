namespace InheritanceDemo;

// Create a class to read data from a file and return a list of objects
public class PetDataLoader{
    
    // Create a method to read data from a file and return a list of pets
    public static List<Pet> LoadPets(string filePath){
        // Create an empty list to store pet objects
        List<Pet> petList = new List<Pet>();

        // Open the data.csv file with a streamreader object
        using(StreamReader fileReader = new StreamReader(filePath)){

            // Read the file line by line
            while(!fileReader.EndOfStream){

                // Split the line at the comma
                string lineOfData = fileReader.ReadLine()!;

                string[] petData = lineOfData.Split(",");

                // Get each value from the resulting array and assign to a variable, convert data type as necessary
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
            }
            return petList;
        }
    }
}