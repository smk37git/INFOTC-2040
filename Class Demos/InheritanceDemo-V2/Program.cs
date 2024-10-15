namespace InheritanceDemo;

class Program
{
    static void Main(string[] args)
    {
        // Get the file name from the command line arguements
        // Check if the argument is present
        // If not, print an error message
        if(args.Length != 1){
            Console.WriteLine("ERROR: Incorrect format to start the program.");
            Console.WriteLine("Correct Format: dotnet run <filename>");
            Environment.Exit(0);
        }

        Console.WriteLine($"Number of Args: {args.Length}");
        string fileName = args[0];
        Console.WriteLine(fileName);

        // Create a list of pets
        List<Pet> petList = PetDataLoader.LoadPets(fileName);

        // Print pet info for each pet
        foreach(Pet pet in petList){
            pet.PrintPetInfo();
        }
    }
}
