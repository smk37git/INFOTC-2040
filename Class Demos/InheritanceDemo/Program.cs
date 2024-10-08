﻿namespace InheritanceDemo;

class Program
{
    static void Main(string[] args)
    {
        Pet myDog = new Pet(PetType.Dog, "Fido", "Tim", 7.5, 5);
        Pet myCat = new Pet(PetType.Cat, "Mary", "Ruth", 4.7, 9);

        myDog.PrintPetInfo();
        myCat.PrintPetInfo();

        Console.WriteLine("\n------Fido had a birthday------");
        myDog.HasBirthday();
        myDog.PrintPetInfo();

        Console.WriteLine("\n------Create a Dog using the Dog Class------");
        Dog lucky = new Dog("Lucky", "Ricky", 32.1, 7, "Doberman");
        lucky.PrintPetInfo();
        Console.WriteLine(lucky.ToString());

        Console.WriteLine("\n------------Make the Dog Bark------------");
        lucky.MakeSound(3);

        Console.WriteLine("\n-------------Create a blank Pet--------------");
        Pet blankPet = new Pet();
        blankPet.PrintPetInfo();

        Console.WriteLine("\n------------Create a Cat from the Cat class------------");
        Cat baxter = new Cat("Baxter", "Tina", 11.2, 6);
        baxter.PrintPetInfo();
        baxter.MakeSound(5);


    }
}
