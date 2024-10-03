namespace InheritanceDemo;

class Program
{
    static void Main(string[] args)
    {
        Pet myDog = new Pet("Dog", "Fido", "Tim", 7.5, 5);
        Pet myCat = new Pet("Dat", "Mary", "Ruth", 4.7, 9);

        myDog.PrintPetInfo();
        myCat.PrintPetInfo();

        Console.WriteLine("\n------Fido had a birthday------");
        myDog.HasBirthday();
        myDog.PrintPetInfo();

        Console.WriteLine("\n------Create a Dog using the Dog Class");
        Dog lucky = new Dog("Lucky", "Ricky", 32.1, 7, "Doberman");
        lucky.PrintPetInfo();
        Console.WriteLine(lucky.ToString());

    }
}
