namespace InheritanceDemo;

class Program
{
    static void Main(string[] args)
    {
       // Create a list of pets
       List<Pet> petList = PetDataLoader.LoadPets("data.csv");

       // Print pet info for each pet
       foreach(Pet pet in petList){
        pet.PrintPetInfo();
       }
    }
}
