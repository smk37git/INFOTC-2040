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

        // Polymorphism demo
        List<Dog> dogList = new List<Dog>();

        Dog myDog = new Dog("Test Dog", "Truman", 9.9, 8);
        Cat myCat = new Cat("Test Cat", "Fiona", 4.5, 3);

        // Add dog and cat to dog list
        dogList.Add(myDog);
        
        // This results in an error because a cat is not a dog, even though both are pets
        // dogList.Add(myCat);

        Console.WriteLine("\n----------Searching List Example----------");
        // Find the pet who is 5 years old
        int targetAge = 5;
        bool foundPet = false;
        Pet currentPet = null;

        // Search through the list of pets using a for loop
        // If we find the pet, assign the pet to a Pet object for further processing
        foreach(Pet pet in petList){

            // At each step, compare the pet's age with 5, if pet age == target age, we found our pet
            if(pet.GetAge() == targetAge){

                // Assign for further processing
                currentPet = pet;
                foundPet = true;
                break;
            }
        }

        // We are done searching the list and pet not found.
        if(foundPet == false){
            Console.WriteLine($"Sorry: we don't have any {targetAge} year old pets.");
        }else{
            currentPet.PrintPetInfo();
            currentPet.MakeSound(targetAge);
        }

    }
}
